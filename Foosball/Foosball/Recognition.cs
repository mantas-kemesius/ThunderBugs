using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

namespace Foosball
{
    enum BGRcolours
    {
        B1 = 0, B2 = 18, B3 = 165, B4 = 179, B5 = 255, B6 = 0,
        G1 = 155, G2 = 255, G3 = 155, G4 = 255, G5 = 0, G6 = 255,
        R1 = 155, R2 = 255, R3 = 155, R4 = 255, R5 = 0, R6 = 0
    }
    public static class Recognition
    {
        public static Mat FindingBall(Mat imgOriginal)
        {
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

            return imgThresh;
        }
    }
}
