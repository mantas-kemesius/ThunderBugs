using System;
using System.Drawing;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;


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
        private int checking = 0;
        private Timer sw = new Timer();
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

            var redCounter = new RedScoreCounter();
            var blueCounter = new BlueScoreCounter();
            
            var redTeam = new ScoreSaver(redCounter);
            var blueTeam = new ScoreSaver(blueCounter);
            var Coords = new Coordinates(0, 0, 0);
            bool isNew;

            Mat imgOriginal;
            imgOriginal = capWebcam.QueryFrame();

            if (imgOriginal == null)
            {
                MessageBox.Show("End of video capture reached, exiting program.");
                Environment.Exit(0);
            }

            Mat imgThresh = await Task.Run(() => Recognition.FindingBall(imgOriginal));

            CircleF[] circles = CvInvoke.HoughCircles(imgThresh, HoughType.Gradient, 2.0, imgThresh.Rows / 4, 60, 30, 5, 10);

            player1.Value.Name = "Jonas";
            player1.Value.Lastname = "Jonaitis";

            player2.Value.Name = "Petras";
            player2.Value.Lastname = "Petraitis";

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

                if (checking == Coords.X)
                {
                    isNew = true;
                }
                else isNew = false;

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

                    BallFinder ballFinder = new BallFinder();
                    BallLocationChanges Ball = new BallLocationChanges();

                    txtXYRadius.AppendText("(" + Coords.X.ToString().PadLeft(4) + " ; " + Coords.Y.ToString().PadLeft(4) +
                        "), radius = " + Coords.R.ToString("###.000").PadLeft(7) +
                        Ball.WhichSide(Coords.X, isNew).PadLeft(75) + Ball.LocationCommentator(ballFinder.commentArea(Coords.X), isNew).PadLeft(75) + Ball.TimeCommentator(isNew).PadLeft(25));
                    txtXYRadius.ScrollToCaret();

                    CvInvoke.Circle(imgOriginal, new Point(Coords.X, Coords.Y), (int)circle.Radius,
                        new MCvScalar((double)BGRcolours.B5, (double)BGRcolours.G5, (double)BGRcolours.R5), 2, LineType.AntiAlias);
                    CvInvoke.Circle(imgOriginal, new Point(Coords.X, Coords.Y), 3,
                        new MCvScalar((double)BGRcolours.B6, (double)BGRcolours.G6, (double)BGRcolours.R6), -1);
                }
            }
            checking = Coords.X;
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

            EventClass eClass1 = new EventClass();
            eClass1.MyEvent += new EventClass.MyDelegate(eClass1_MyEvent);

            if (red > blue)
            {
                msg = "Red";
                eClass1.RaiseEvent(msg);
                label2.Text = HardcodedConstants.bl;
            }
            else if (blue > red)
            {
                msg = "Blue";
                eClass1.RaiseEvent(msg);
                label1.Text = HardcodedConstants.re;
            }
            else
            {
                label1.Text = HardcodedConstants.re;
                label2.Text = HardcodedConstants.bl;
            }
        }

        public void eClass1_MyEvent(string message)
        {
            if (message == "Red")
            {
                label1.Text = message + HardcodedConstants.msg;
            }
            else { label2.Text = message + HardcodedConstants.msg; }
        }
    }
}


