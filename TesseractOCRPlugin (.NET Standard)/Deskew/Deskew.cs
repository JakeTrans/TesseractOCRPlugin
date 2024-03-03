using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using IronSoftware.Drawing;

namespace TesseractOCRPlugin__.Net_Standard_.Deskew
{
    public class Deskew
    {
        public double GetDeskewAngle(AnyBitmap image)
        {
            // Load the image

            Mat src = AnyBitmapExenstion.GetMatFromAnyBitmap(image);
            // Convert to grayscale
            Mat gray = new Mat();
            CvInvoke.CvtColor(src, gray, ColorConversion.Bgr2Gray);

            // Use Hough transform to detect the skewed line
            LineSegment2D[] lines = CvInvoke.HoughLinesP(
               gray,
               1, //Distance resolution in pixel-related units
               Math.PI / 360, //Angle resolution measured in radians.
               20, //threshold
               3, //min Line width
               10); //gap between lines

            double angle = 0.0;

            foreach (LineSegment2D line in lines)
            {
                angle += Math.Atan2(line.P2.Y - line.P1.Y, line.P2.X - line.P1.X);
            }

            // Get the average angle in degrees
            angle = angle / lines.Length * 180.0 / Math.PI;

            return angle;
        }

        public AnyBitmap DeskewImage(AnyBitmap image)
        {
            // Load the image

            Mat src = AnyBitmapExenstion.GetMatFromAnyBitmap(image);
            // Convert to grayscale
            Mat gray = new Mat();
            CvInvoke.CvtColor(src, gray, ColorConversion.Bgr2Gray);

            // Use Hough transform to detect the skewed line
            LineSegment2D[] lines = CvInvoke.HoughLinesP(
               gray,
               1, //Distance resolution in pixel-related units
               Math.PI / 360, //Angle resolution measured in radians.
               20, //threshold
               3, //min Line width
               10); //gap between lines

            double angle = 0.0;

            foreach (LineSegment2D line in lines)
            {
                angle += Math.Atan2(line.P2.Y - line.P1.Y, line.P2.X - line.P1.X);
            }

            // Get the average angle in degrees
            angle = angle / lines.Length * 180.0 / Math.PI;

            Mat rotated = gray;

            Image<Bgr, byte> orignalimage = rotated.ToImage<Bgr, byte>(); ;
            Debug.Print("angle detected was: " + angle);
            //Image<Bgr, byte> rotatedImage = orignalimage.Rotate(angle, new Bgr(255, 255, 255));
            Image<Bgr, byte> rotatedImage = orignalimage.Rotate(angle, new Bgr(255, 255, 255));
            return rotatedImage.ToBitmap<Bgr, byte>();
        }
    }
}