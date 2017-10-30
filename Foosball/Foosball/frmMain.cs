using System;
using System.Drawing;
using System.Windows.Forms;

using Emgu.CV;                  
using Emgu.CV.CvEnum;           
using Emgu.CV.Structure;        
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
            var redTeam = new Score();  //del sitos vietos kaskart nusinulina, ji reiktu iskelt kazkur globaliau
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
            //metodas kitas nuo cia
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
            //iki cia
            var Coords = new Coordinates(0, 0, 0);
            var file = new DataAnalysis();

            foreach (CircleF circle in circles)
            {
                Coords.X = (int)circle.Center.X;
                Coords.Y = (int)circle.Center.Y;
                Coords.R = (float)circle.Radius;

                Regex regex = new Regex("95|23|387|385|239|267|93|503|97|273|237|25|21");
                Match match = regex.Match(Coords.X.ToString());

                if (!match.Success)
                {
                    redTeam.redGoal(Coords.X, Coords.Y);
                    //du kartus ta pati metoda kviecia, geriau butu tiesiog kazkam prisiskirt
                    if (scoreR <= redTeam.getGoalCount())
                    {
                        scoreR = redTeam.getGoalCount();
                    }
                    blueTeam.blueGoal(Coords.X, Coords.Y);

                    if (scoreB <= blueTeam.getGoalCount())
                    {
                        scoreB = blueTeam.getGoalCount();
                    }

                    setGoalRed(scoreR);
                    setGoalBlue(scoreB);

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

                    if (_ofd == null)
                    {
                        _ofd = new OpenFileDialog();
                        _ofd.Filter = "CSV file |*.csv";
                        _ofd.ShowDialog();

                    }

                    file.Ofd = _ofd.FileName;
                    file.WriteToCsv(Coords.X.ToString().PadLeft(4), Coords.Y.ToString().PadLeft(4));

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
    }
}