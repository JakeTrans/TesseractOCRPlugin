using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using IronSoftware.Drawing;
using System;
using System.Diagnostics;

namespace TesseractOCRPlugin__.Net_Standard_.Deskew
{
    public class Deskew
    {
        public AnyBitmap DeskewImageP(AnyBitmap image)
        {
            double cannyThreshold = 180.0;
            double cannyThresholdLinking = 120.0;
            // Load the image

            Mat src = AnyBitmapExenstion.GetMatFromAnyBitmap(image);
            // Convert to grayscale
            Mat gray = new Mat();
            Mat Bilateral = new Mat();
            CvInvoke.CvtColor(src, gray, ColorConversion.Bgr2Gray);

            CvInvoke.BilateralFilter(gray, Bilateral, 15, 10, 10);

            Mat cannyEdges = new Mat();
            CvInvoke.Canny(Bilateral, cannyEdges, cannyThreshold, cannyThresholdLinking);

            LineSegment2D[] lines = CvInvoke.HoughLinesP(
                image: cannyEdges,
                rho: 1, //Distance resolution in pixel-related units
                theta: Math.PI / 360, //Angle resolution measured in radians.
                80, //threshold
                30, //min Line width
                10); //gap between lines

            //LineSegment2D[] lines = CvInvoke.HoughLinesP(
            //    image: cannyEdges,
            //    rho: 1, //Distance resolution in pixel-related units
            //    theta: Math.PI / 360, //Angle resolution measured in radians.
            //    10, //threshold
            //    10, //min Line width
            //    10); //gap between lines

            double angle = 0.0;

            foreach (LineSegment2D line in lines)
            {
                angle += Math.Atan2(line.P2.Y - line.P1.Y, line.P2.X - line.P1.X);
            }

            // Get the average angle in degrees
            angle = angle / lines.Length * 180.0 / Math.PI;

            Mat rotated = Bilateral;

            Image<Bgr, byte> orignalimage = rotated.ToImage<Bgr, byte>(); ;
            Debug.Print("angle detected was: " + angle);
            //Image<Bgr, byte> rotatedImage = orignalimage.Rotate(angle, new Bgr(255, 255, 255));
            Image<Bgr, byte> rotatedImage = orignalimage.Rotate(-angle, new Bgr(255, 255, 255));

            return rotatedImage.ToBitmap<Bgr, byte>();
        }
    }
}