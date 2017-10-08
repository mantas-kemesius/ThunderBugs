using System;
using System.Drawing;
using System.Windows.Forms;

using Emgu.CV;                  //
using Emgu.CV.CvEnum;           // usual Emgu CV imports
using Emgu.CV.Structure;        //
using System.Text.RegularExpressions;

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
    enum BGRcolours
    {
        B1 = 0, B2 = 18, B3 = 165, B4 = 179, B5 = 255, B6 = 0,
        G1 = 155, G2 = 255, G3 = 155, G4 = 255, G5 = 0, G6 = 255,
        R1 = 155, R2 = 255, R3 = 155, R4 = 255, R5 = 0, R6 = 0

    }
    public partial class frmMain : Form
    {

        VideoCapture capWebcam;
        bool blnCapturingInProcess = false;
        private OpenFileDialog _ofd = null;
        static int scoreR = 0;
        static int scoreB = 0;

        public frmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("unable to read from webcam, error: " + Environment.NewLine + Environment.NewLine +
                                ex.Message + Environment.NewLine + Environment.NewLine +
                                "exiting program");
                Environment.Exit(0);
                return;
            }
            Application.Idle += processFrameAndUpdateGUI;
            blnCapturingInProcess = true;
        }

        void processFrameAndUpdateGUI(object sender, EventArgs arg)
        {
            var redTeam = new Score();
            var blueTeam = new Score();
            Mat imgOriginal;

            imgOriginal = capWebcam.QueryFrame();

            if (imgOriginal == null)
            {
                MessageBox.Show("unable to read from webcam" + Environment.NewLine + Environment.NewLine +
                                "exiting program");
                Environment.Exit(0);
                return;
            }

            Mat imgHSV = new Mat(imgOriginal.Size, DepthType.Cv8U, 3);

            Mat imgThreshLow = new Mat(imgOriginal.Size, DepthType.Cv8U, 1);
            Mat imgThreshHigh = new Mat(imgOriginal.Size, DepthType.Cv8U, 1);

            Mat imgThresh = new Mat(imgOriginal.Size, DepthType.Cv8U, 1);

            CvInvoke.CvtColor(imgOriginal, imgHSV, ColorConversion.Bgr2Hsv);

            CvInvoke.InRange(imgHSV, new ScalarArray(new MCvScalar((double)BGRcolours.B1, (double)BGRcolours.G1, (double)BGRcolours.R1)), new ScalarArray(new MCvScalar((double)BGRcolours.B2, (double)BGRcolours.G2, (double)BGRcolours.R2)), imgThreshLow);
            CvInvoke.InRange(imgHSV, new ScalarArray(new MCvScalar((double)BGRcolours.B3, (double)BGRcolours.G3, (double)BGRcolours.R3)), new ScalarArray(new MCvScalar((double)BGRcolours.B4, (double)BGRcolours.G4, (double)BGRcolours.R4)), imgThreshHigh);

            CvInvoke.Add(imgThreshLow, imgThreshHigh, imgThresh);

            CvInvoke.GaussianBlur(imgThresh, imgThresh, new Size(3, 3), 500);

            Mat structuringElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));

            CvInvoke.Dilate(imgThresh, imgThresh, structuringElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0, 0, 0));
            CvInvoke.Erode(imgThresh, imgThresh, structuringElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0, 0, 0));

            CircleF[] circles = CvInvoke.HoughCircles(imgThresh, HoughType.Gradient, 2.0, imgThresh.Rows / 4, 60, 30, 5, 10);
            // 4, 100, 50, 10, 400

            var Coords = new Coordinates(0, 0, 0);
            var file = new DataAnalysis();

            foreach (CircleF circle in circles)
            {
                // ifs who check or it's not a player
                Coords.X = (int)circle.Center.X;
                Coords.Y = (int)circle.Center.Y;
                Coords.R = (float)circle.Radius;

                Regex regex = new Regex("95|23|387|385|239|267|93|503|97|273|237|25|21");
                Match match = regex.Match(Coords.X.ToString());

                if (!match.Success)
                {
                    redTeam.redGoal(Coords.X, Coords.Y);

                    if (scoreR <= redTeam.getGoalCount())
                    {
                        scoreR = redTeam.getGoalCount();
                    }
                    blueTeam.blueGoal(Coords.X, Coords.Y);

                    if (scoreB <= blueTeam.getGoalCount())
                    {
                        scoreB = blueTeam.getGoalCount();
                    }

                    goalRed(scoreR);
                    goalBlue(scoreB);

                    if (txtXYRadius.Text != "")
                    {                         // if we are not on the first line in the text box
                        txtXYRadius.AppendText(Environment.NewLine);         // then insert a new line char
                    }

                    SidesCommentator commSides = new SidesCommentator();

                    txtXYRadius.AppendText("(" + Coords.X.ToString().PadLeft(4) + " ; " + Coords.Y.ToString().PadLeft(4) + 
                        "), radius = " + Coords.R.ToString("###.000").PadLeft(7) +
                        commSides.commentsSide(Coords.X).PadLeft(100) + commSides.commentArea(Coords.X).PadLeft(75));
                    txtXYRadius.ScrollToCaret();

                    CvInvoke.Circle(imgOriginal, new Point(Coords.X, Coords.Y), (int)circle.Radius, 
                        new MCvScalar((double)BGRcolours.B5, (double)BGRcolours.G5, (double)BGRcolours.R5), 2, LineType.AntiAlias);
                    CvInvoke.Circle(imgOriginal, new Point(Coords.X, Coords.Y), 3,
                        new MCvScalar((double)BGRcolours.B6, (double)BGRcolours.G6, (double)BGRcolours.R6), -1);

                    if (_ofd == null)
                    {
                        _ofd = new OpenFileDialog();
                        _ofd.Filter = "CSV file |*.csv";
                        _ofd.ShowDialog();

                    }

                    file.Ofd = _ofd.FileName;
                    file.writeToCsv(Coords.X.ToString().PadLeft(4), Coords.Y.ToString().PadLeft(4));

                }

            }

            /*Jei norim panaudot kur nors Commentator klasę, reikėtų kur nors šitą kodo gabalą įkišt.
             * Šiaip, pačioj klasėj įgyvendinti reikalavimai keli, tai geriau būtų jos netrint, bet
             * realiai, ar ją būtina naudot, tai nežinau.
             * 
             * Commentator c = new Commentator();
            var player = new Player<string>();
            player[0] = "Red team";
            player[1] = "Blue team";

            txtXYRadius.AppendText(c.introduction(player));*/


            ibOriginal.Image = imgOriginal;
            ibThresh.Image = imgThresh;

        }

        private void btnPauseOrResume_Click(object sender, EventArgs e)
        {
            if (blnCapturingInProcess == true)
            {                    // if we are currently processing an image, user just choose pause, so . . .
                Application.Idle -= processFrameAndUpdateGUI;       // remove the process image function from the application's list of tasks
                blnCapturingInProcess = false;                      // update flag variable
                btnPauseOrResume.Text = " Resume ";                 // update button text
            }
            else
            {                                                // else if we are not currently processing an image, user just choose resume, so . . .
                Application.Idle += processFrameAndUpdateGUI;       // add the process image function to the application's list of tasks
                blnCapturingInProcess = true;                       // update flag variable
                btnPauseOrResume.Text = " Pause ";                  // new button will offer pause option
            }
        }

        private void tlbInner_Paint(object sender, PaintEventArgs e)
        {

        }

        private void goalRed(int red)
        {
            label3.Text = red.ToString();
        }

        private void goalBlue(int blue)
        {
            label4.Text = blue.ToString();
        }
    }
}