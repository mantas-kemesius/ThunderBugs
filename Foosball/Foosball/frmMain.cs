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
        Value scoR = delegate (int val)
        {
            scoreR = val;
        };
        Value scoB = val => scoreB = val;

        private void frmMain_Load(object sender, EventArgs e)
        {
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

        public static readonly HttpClient client = new HttpClient();
        public static string url = "http://localhost:5000/api/scores/";
        bool zero = false;

        async void processFrameAndUpdateGUI(object sender, EventArgs arg)
        {
            Lazy < Player > player1 = new Lazy<Player>();
            Lazy < Player > player2 = new Lazy<Player>();

<<<<<<< HEAD
            Console.WriteLine("Setting up listener");
            listener.Prefixes.Add("http://localhost:50438/api/foosballs/");
            listener.Start();
            if (listener.IsListening)
            {
                Console.WriteLine("HTTP listener set up");
            }
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
=======
            HttpPut put = new HttpPut();
>>>>>>> 573a5970db4edb18b4a3558d3960aafe436cd9b5

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

            player2.Value.name = "Petras";
            player2.Value.lastname = "Petraitis";

            if (zero == false)
            {
                put.Put(player1.Value.name, scoreR, player2.Value.name, scoreB);
                zero = true;
            }

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
                    if (scoreR < redTeam.getGoalCount())
                    {
                        scoreR = redTeam.getGoalCount();
                        put.Put(player1.Value.name, scoreR, player2.Value.name, scoreB);
                    }
                    blueTeam.count(Coords.X, Coords.Y);
                    if (scoreB < blueTeam.getGoalCount())
                    {
                        scoreB = blueTeam.getGoalCount();
                        put.Put(player1.Value.name, scoreR, player2.Value.name, scoreB);
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
            string msg = "wins";
            string bl = "Blue Team";
            string re = "Red Team";
            EventClass eClass1 = new EventClass();
            eClass1.MyEvent += new EventClass.MyDelegate(eClass1_MyEvent);

            if (red > blue)
            {
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


