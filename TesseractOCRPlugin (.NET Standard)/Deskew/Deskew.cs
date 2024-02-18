using System;
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
               Math.PI / 45.0, //Angle resolution measured in radians.
               20, //threshold
               30, //min Line width
               10); //gap between lines

            double angle = 0.0;

            foreach (LineSegment2D line in lines)
            {
                angle += Math.Atan2(line.P2.Y - line.P1.Y, line.P2.X - line.P1.X);
            }

            // Get the average angle in degrees
            angle = angle / lines.Length * 180.0 / Math.PI;

            //// Create a rotation matrix
            //Mat rotMat = new Mat();
            //CvInvoke.GetRotationMatrix2D(new CenterSpace(), angle, 1.0, rotMat);

            //// Rotate the image
            //Mat dst = new Mat();
            //CvInvoke.WarpAffine(src, dst, rotMat, src.Size);

            //// Save the deskewed image
            //CvInvoke.Imwrite("path_to_output_image", dst);

            return angle;
        }
    }
}