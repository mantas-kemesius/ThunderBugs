using System;
using System.Drawing;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;

using System.Net;
using System.IO;

namespace Foosball
{
    public struct Coordinates
    {
        public int X, Y;
        public float R;

        public Coordinates(int X, int Y, int R)
        {
            this.X = X;
            this.Y = Y;
            this.R = R;
        }
    }
    public partial class frmMain : Form
    {
        VideoCapture capWebcam;
        bool blnCapturingInProcess = false;
        private OpenFileDialog _ofd = null;
        public delegate void Value(int value);
        static int scoreR=0;
        static int scoreB=0;
        public frmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        // TODO kimutis : why do we need a delegate for this?
        Value scoR = delegate (int val)
        {
            scoreR = val;
        };

        // TODO kimutis : and a second one here?
        Value scoB = val => scoreB = val;
        private void frmMain_Load(object sender, EventArgs e)
        {
            // TODO kimutis : why do we need to set it to zero, if its already done when defining scores?
            scoR(0);
            scoB(0);

            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Video Files |*.mp4";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    capWebcam = new VideoCapture(ofd.FileName);
                }
                else
                {
                    throw new System.Exception();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("unable to read from webcam" + Environment.NewLine + 
                                ex.Message + Environment.NewLine +
                                "exiting program");
                Environment.Exit(0);
                return;
            }
            Application.Idle += processFrameAndUpdateGUI;
            blnCapturingInProcess = true;
        }

        // TODO kimutis : all fields and properties should be defined in one place
        public static readonly HttpClient client = new HttpClient();
        public static string url = "http://localhost:50438/api/foosballs/";

        // TODO kimutis : redundant namespace should be removed
        public static System.Net.HttpListener listener = new System.Net.HttpListener();

        async void processFrameAndUpdateGUI(object sender, EventArgs arg)
        {
            Lazy < Player > player1 = new Lazy<Player>();
            Lazy < Player > player2 = new Lazy<Player>();


            // TODO kimutis : what is this? for things like that in c# we can use #region
            //*******************************************************************************************************

            Console.WriteLine("Setting up listener");
            listener.Prefixes.Add("http://localhost:50438/api/foosballs/");
            listener.Start();
            if (listener.IsListening)
            {
                Console.WriteLine("HTTP listener set up");
            }
            // TODO kimutis : two things. 1. curly brackets 2.this kind of failure should have a retry strategy
            else Console.WriteLine("Failed to set up HTTP listener");

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(frmMain.url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                Foosball output = new Foosball(1,2);
                string jsonOut = JsonConvert.SerializeObject(output);
                httpWebRequest.ContentLength = jsonOut.Length;
                using (var writer = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    writer.Write(jsonOut);
                }
                var response = httpWebRequest.GetResponse() as HttpWebResponse;

            //******************************************************************************************************

            // TODO kimutis : redCounter,redTeam, player1, scoreR... maybe we could have a single game model?
            var redCounter = new redScoreCounter();
            var blueCounter = new blueScoreCounter();
            
            var redTeam = new scoreSaver(redCounter);
            var blueTeam = new scoreSaver(blueCounter);
            var Coords = new Coordinates(0, 0, 0);

            Mat imgOriginal;
            imgOriginal = capWebcam.QueryFrame();

            if (imgOriginal == null)
            {
                MessageBox.Show("End of video capture reached, exiting program.");
                Environment.Exit(0);
            }

            Mat imgThresh = await Task.Run(() => Recognition.FindingBall(imgOriginal));

            CircleF[] circles = CvInvoke.HoughCircles(imgThresh, HoughType.Gradient, 2.0, imgThresh.Rows / 4, 60, 30, 5, 10);

            player1.Value.name = "Jonas";
            player1.Value.lastname = "Jonaitis";

            player1.Value.name = "Petras";
            player1.Value.lastname = "Petraitis";

            foreach (CircleF circle in circles)
            {
                Coords.X = (int)circle.Center.X;
                Coords.Y = (int)circle.Center.Y;
                Coords.R = (float)circle.Radius;

                Regex regex = new Regex("95|23|387|385|239|267|93|503|97|273|237|25|21");
                Match match = regex.Match(Coords.X.ToString());

                if (!match.Success)
                {
                    redTeam.count(Coords.X, Coords.Y);
                    if (scoreR <= redTeam.getGoalCount())
                    {
                        scoreR = redTeam.getGoalCount();
                    }
                    blueTeam.count(Coords.X, Coords.Y);
                    if (scoreB <= blueTeam.getGoalCount())
                    {
                        scoreB = blueTeam.getGoalCount();
                    }

                    setGoalRed(scoreR);
                    setGoalBlue(scoreB);
                    setWin(scoreR, scoreB);

                    if (txtXYRadius.Text != "")
                    {
                        txtXYRadius.AppendText(Environment.NewLine);
                    }

                    SidesCommentator commSides = new SidesCommentator();

                    txtXYRadius.AppendText("(" + Coords.X.ToString().PadLeft(4) + " ; " + Coords.Y.ToString().PadLeft(4) +
                        "), radius = " + Coords.R.ToString("###.000").PadLeft(7) +
                        commSides.WhichSide(Coords.X).PadLeft(100) + commSides.commentArea(Coords.X).PadLeft(75));
                    txtXYRadius.ScrollToCaret();

                    CvInvoke.Circle(imgOriginal, new Point(Coords.X, Coords.Y), (int)circle.Radius,
                        new MCvScalar((double)BGRcolours.B5, (double)BGRcolours.G5, (double)BGRcolours.R5), 2, LineType.AntiAlias);
                    CvInvoke.Circle(imgOriginal, new Point(Coords.X, Coords.Y), 3,
                        new MCvScalar((double)BGRcolours.B6, (double)BGRcolours.G6, (double)BGRcolours.R6), -1);
                }
            }

            ibOriginal.Image = imgOriginal;
            ibThresh.Image = imgThresh;

        }

        private void btnPauseOrResume_Click(object sender, EventArgs e)
        {
            if (blnCapturingInProcess == true)
            {
                Application.Idle -= processFrameAndUpdateGUI;
                blnCapturingInProcess = false;
                btnPauseOrResume.Text = " Resume ";
            }
            else
            {
                Application.Idle += processFrameAndUpdateGUI;
                blnCapturingInProcess = true;
                btnPauseOrResume.Text = " Pause ";
            }
        }

        private void tlbInner_Paint(object sender, PaintEventArgs e)
        {

        }

        private void setGoalRed(int red)
        {
            label3.Text = red.ToString();
        }

        private void setGoalBlue(int blue)
        {
            label4.Text = blue.ToString();
        }
        private void setWin(int red, int blue)
        {
            // TODO kimutis : there are many hardcoded values used - please move it to separate class (Constants)
            string msg = "wins";
            string bl = "Blue Team";
            string re = "Red Team";
            EventClass eClass1 = new EventClass();
            eClass1.MyEvent += new EventClass.MyDelegate(eClass1_MyEvent);

            if (red > blue)
            {
                // TODO kimutis : msg becomes from wins to Red?
                // TODO kimutis : msg should be an enum
                msg = "Red";
                eClass1.RaiseEvent(msg);
                label2.Text = bl;
            }
            else if (blue > red)
            {
                msg = "Blue";
                eClass1.RaiseEvent(msg);
                label1.Text = re;
            }
            else
            {
                label1.Text = re;
                label2.Text = bl;
            }
        }

        public void eClass1_MyEvent(string message)
        {
            string msg = " Team Wins";
            if (message == "Red")
            {
                label1.Text = message + msg;
            }
            else { label2.Text = message + msg; }
        }
    }
}


