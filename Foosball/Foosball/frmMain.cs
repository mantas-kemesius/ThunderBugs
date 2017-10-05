using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;                  //
using Emgu.CV.CvEnum;           // usual Emgu CV imports
using Emgu.CV.Structure;        //
using Emgu.CV.UI;               //
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
        private OpenFileDialog ofd = null;

        public frmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
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

            CvInvoke.InRange(imgHSV, new ScalarArray(new MCvScalar(0, 155, 155)), new ScalarArray(new MCvScalar(18, 255, 255)), imgThreshLow);
            CvInvoke.InRange(imgHSV, new ScalarArray(new MCvScalar(165, 155, 155)), new ScalarArray(new MCvScalar(179, 255, 255)), imgThreshHigh);

            CvInvoke.Add(imgThreshLow, imgThreshHigh, imgThresh);

            CvInvoke.GaussianBlur(imgThresh, imgThresh, new Size(3, 3), 500);

            Mat structuringElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));

            CvInvoke.Dilate(imgThresh, imgThresh, structuringElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0, 0, 0));
            CvInvoke.Erode(imgThresh, imgThresh, structuringElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0, 0, 0));

            CircleF[] circles = CvInvoke.HoughCircles(imgThresh, HoughType.Gradient, 2.0, imgThresh.Rows / 4, 60, 30, 5, 10);
            // 4, 100, 50, 10, 400

            var redTeam = new Score();
            var blueTeam = new Score();
            var Coords = new Coordinates(0,0,0);

            foreach (CircleF circle in circles)
            {
                // ifs who check or it's not a player
                Coords.X = (int)circle.Center.X;
                Coords.Y = (int)circle.Center.Y;
                Coords.R = (float)circle.Radius;

                if (Coords.X != 95 )
                {
                    if (Coords.X != 23)
                    {
                        if (Coords.X != 387)
                        {
                            if (Coords.X != 385)
                            {
                                if (Coords.X != 239)
                                {
                                    if (Coords.X != 267)
                                    {
                                        if (Coords.X != 93)
                                        {
                                            if (Coords.X != 503)
                                            {
                                                if (Coords.X != 97)
                                                {
                                                    if (Coords.X != 273)
                                                    {
                                                        if (Coords.X != 237)
                                                        {
                                                            if (Coords.X != 25)
                                                            {
                                                                if (Coords.X != 21)
                                                                {

                                                                    redTeam.redGoal(Coords.X, Coords.Y);
                                                                    blueTeam.blueGoal(Coords.X, Coords.Y);

                                                                    goalRed(redTeam.getGoalCount());
                                                                    goalBlue(blueTeam.getGoalCount());

                                                                    if (txtXYRadius.Text != "")
                                                                    {                         // if we are not on the first line in the text box
                                                                        txtXYRadius.AppendText(Environment.NewLine);         // then insert a new line char
                                                                    }
                                                                 

                                                                    txtXYRadius.AppendText("(" + Coords.X.ToString().PadLeft(4) + " ; " + Coords.Y.ToString().PadLeft(4) + "), radius = " + Coords.R.ToString("###.000").PadLeft(7));
                                                                    txtXYRadius.ScrollToCaret(); 

                                                                    CvInvoke.Circle(imgOriginal, new Point(Coords.X, Coords.Y), (int)circle.Radius, new MCvScalar(255, 0, 0), 2, LineType.AntiAlias);
                                                                    CvInvoke.Circle(imgOriginal, new Point(Coords.X, Coords.Y), 3, new MCvScalar(0, 255, 0), -1);

                                                                    var file = new DataAnalysis();

                                                                    if (ofd == null)
                                                                    {
                                                                        ofd = new OpenFileDialog();
                                                                        ofd.Filter = "CSV file |*.csv";
                                                                        ofd.ShowDialog();

                                                                    }

                                                                    file.Ofd = ofd.FileName;
                                                                    file.writeToCsv(Coords.X.ToString().PadLeft(4), Coords.X.ToString().PadLeft(4));

                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }


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
