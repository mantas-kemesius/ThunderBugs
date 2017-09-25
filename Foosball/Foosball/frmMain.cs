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
    public partial class frmMain : Form
    {
        public int redTeam = 0;
        public int blueTeam = 0;

        // member variables ///////////////////////////////////////////////////////////////////////
        VideoCapture capWebcam;
        bool blnCapturingInProcess = false;

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
                // C:/Users/Mantas/Desktop/Git/ThunderBugs/foosball.mp4
                // C:/Users/Mantas/Desktop/Git/ThunderBugs/video.mov
                capWebcam = new VideoCapture("C:/Users/Mantas/Desktop/Git/ThunderBugs/foosball.mp4");
            }
            catch (Exception ex)
            {
                MessageBox.Show("unable to read from webcam, error: " + Environment.NewLine + Environment.NewLine +
                                ex.Message + Environment.NewLine + Environment.NewLine +
                                "exiting program");
                Environment.Exit(0);
                return;
            }
            Application.Idle += processFrameAndUpdateGUI;       // add process image function to the application's list of tasks
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

            var csv = new StringBuilder();

            int[] Array;
            Array = new int[5000];


            foreach (CircleF circle in circles)
            {
                // ifs who check or it's not a player
                
                if ((int)circle.Center.X != 95 )
                {
                    if ((int)circle.Center.X != 23)
                    {
                        if ((int)circle.Center.X != 387)
                        {
                            if ((int)circle.Center.X != 385)
                            {
                                if ((int)circle.Center.X != 239)
                                {
                                    if ((int)circle.Center.X != 267)
                                    {
                                        if ((int)circle.Center.X != 93)
                                        {
                                            if ((int)circle.Center.X != 503)
                                            {
                                                if ((int)circle.Center.X != 97)
                                                {
                                                    if ((int)circle.Center.X != 273)
                                                    {
                                                        if ((int)circle.Center.X != 237)
                                                        {
                                                            if ((int)circle.Center.X != 25)
                                                            {
                                                                if ((int)circle.Center.X != 21)
                                                                {
                                                                    if ((int)circle.Center.X >= 413)
                                                                        if((int)circle.Center.X <= 420)
                                                                            if((int)circle.Center.Y >= 85)
                                                                                if ((int)circle.Center.Y <= 135)
                                                                                        redTeam++;
                                                                    goalRed(redTeam);
                                                                    if (txtXYRadius.Text != "")
                                                                    {                         // if we are not on the first line in the text box
                                                                        txtXYRadius.AppendText(Environment.NewLine);         // then insert a new line char
                                                                    }


                                                                    txtXYRadius.AppendText("ball position x = " + circle.Center.X.ToString().PadLeft(4) + ", y = " + circle.Center.Y.ToString().PadLeft(4) + ", radius = " + circle.Radius.ToString("###.000").PadLeft(7));
                                                                    txtXYRadius.ScrollToCaret();             // scroll down in text box so most recent line added (at the bottom) will be shown

                                                                    CvInvoke.Circle(imgOriginal, new Point((int)circle.Center.X, (int)circle.Center.Y), (int)circle.Radius, new MCvScalar(255, 0, 0), 2, LineType.AntiAlias);
                                                                    CvInvoke.Circle(imgOriginal, new Point((int)circle.Center.X, (int)circle.Center.Y), 3, new MCvScalar(0, 255, 0), -1);

                                                                    //CSV
                                                                    var first = circle.Center.X.ToString().PadLeft(4);
                                                                    var second = circle.Center.Y.ToString().PadLeft(4);
                                                                    //Suggestion made by KyleMit
                                                                    var newLine = string.Format("{0},{1}", first, second);
                                                                    csv.AppendLine(newLine);

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

            File.AppendAllText("C:/Users/Mantas/Desktop/Git/ThunderBugs/test.csv", csv.ToString());



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
            label3.Text = blue.ToString();
        }
    }
}
