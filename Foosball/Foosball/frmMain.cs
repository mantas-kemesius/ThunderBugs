using System;
using System.Drawing;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Media;

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
        public delegate void Value(int value);
        static int scoreR = 0;
        static int scoreB = 0;
        private int checking = 0;
        private string sides;
        private Timer sw = new Timer();
        frmNames names = new frmNames();
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
            if (names.ShowDialog() == DialogResult.OK)
            {
                label1.Text = names.Team1;
                label2.Text = names.Team2;
            }

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

            BallLocationChanges Ball = new BallLocationChanges();
            BallFinder ballFinder = new BallFinder();
            PlayByPlay playByPlay = new PlayByPlay();

            HttpPut put = new HttpPut();

            var redCounter = new RedScoreCounter();
            var blueCounter = new BlueScoreCounter();
            
            var redTeam = new ScoreSaver(redCounter);
            var blueTeam = new ScoreSaver(blueCounter);
            var Coords = new Coordinates(0, 0, 0);
            bool isNew;
            bool diffSide = true;

            Mat imgOriginal;
            imgOriginal = capWebcam.QueryFrame();

            if (imgOriginal == null)
            {
                MessageBox.Show("End of video capture reached, exiting program.");
                Environment.Exit(0);
            }

            Mat imgThresh = await Task.Run(() => Recognition.FindingBall(imgOriginal));

            CircleF[] circles = CvInvoke.HoughCircles(imgThresh, HoughType.Gradient, 2.0, imgThresh.Rows / 4, 60, 30, 5, 10);

            player1.Value.Name = label1.Text;
            player2.Value.Name = label2.Text;

            if (zero == false)
            {
                put.Put(player1.Value.Name, scoreR, player2.Value.Name, scoreB);
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

                if (sides == Ball.WhichSide(Coords.X, diffSide))
                {
                    diffSide = false;
                }
                else diffSide = true;

                Regex regex = new Regex("95|23|387|385|239|267|93|503|97|273|237|25|21");
                Match match = regex.Match(Coords.X.ToString());

                if (!match.Success)
                {
                    redTeam.count(Coords.X, Coords.Y);
                    if (scoreR < redTeam.getGoalCount())
                    {
                        PlayGoalSound();
                        scoreR = redTeam.getGoalCount();
                        Console.WriteLine("Goal was scored by "+ playByPlay.WhichRod(Coords.X, names.Team1, names.Team2));
                        put.Put(player1.Value.Name, scoreR, player2.Value.Name, scoreB);
                    }
                    blueTeam.count(Coords.X, Coords.Y);
                    if (scoreB < blueTeam.getGoalCount())
                    {
                        PlayGoalSound();
                        scoreB = blueTeam.getGoalCount();
                        Console.WriteLine("Goal was scored by " + playByPlay.WhichRod(Coords.X, names.Team1, names.Team2));
                        put.Put(player1.Value.Name, scoreR, player2.Value.Name, scoreB);
                    }

                    setGoalRed(scoreR);
                    setGoalBlue(scoreB);

                    if (txtXYRadius.Text != "")
                    {
                        txtXYRadius.AppendText(Environment.NewLine);
                    }

                    txtXYRadius.AppendText("(" + Coords.X.ToString().PadLeft(4) + " ; " + Coords.Y.ToString().PadLeft(4) +
                        "), radius = " + Coords.R.ToString("###.000").PadLeft(7) +
                        Ball.WhichSide(Coords.X, diffSide).PadLeft(75) + Ball.LocationCommentator(ballFinder.commentArea(Coords.X), isNew).PadLeft(75) + Ball.TimeCommentator(isNew).PadLeft(25));
                    txtXYRadius.ScrollToCaret();

                    CvInvoke.Circle(imgOriginal, new Point(Coords.X, Coords.Y), (int)circle.Radius,
                        new MCvScalar((double)BGRcolours.B5, (double)BGRcolours.G5, (double)BGRcolours.R5), 2, LineType.AntiAlias);
                    CvInvoke.Circle(imgOriginal, new Point(Coords.X, Coords.Y), 3,
                        new MCvScalar((double)BGRcolours.B6, (double)BGRcolours.G6, (double)BGRcolours.R6), -1);
                }
            }
            
            sides = Ball.WhichSide(Coords.X, diffSide);
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

        public void PlayGoalSound()
        {
            string goalsound_filename = "GoalSoundFile.wav";
            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var file = Path.Combine(projectFolder, goalsound_filename);
            using (var soundPlayer = new SoundPlayer(file))
            {
                soundPlayer.Play();
            }
        }
    }
}


