using Accord.Imaging;
using Accord.Imaging.Filters;
using System.Drawing;

namespace AccordImageProcessing
{
    internal static class AccordImageProc
    {
        private static Bitmap Grayscaleimage(Bitmap image)
        {
            //set up filter
            Grayscale Grayscalefilter = new Grayscale(0.2125, 0.7154, 0.0721);
            //apply filter
            image = Grayscalefilter.Apply(image);
            return image;
        }

        private static Bitmap Resizeimage(Bitmap image, int NewWidth, int NewHeight)
        {
            //set up filter
            ResizeBicubic ResizeFilter = new ResizeBicubic(NewWidth, NewHeight);
            //apply filter
            image = ResizeFilter.Apply(image);
            return image;
        }

        private static Bitmap Deskewimage(Bitmap image)
        {
            // create instance of skew checker
            DocumentSkewChecker skewChecker = new DocumentSkewChecker();
            // get documents skew angle
            double angle = skewChecker.GetSkewAngle(image);
            // create rotation filter
            RotateBilinear rotationFilter = new RotateBilinear(-angle)
            {
                FillColor = Color.White
            };
            // rotate image applying the filter
            return rotationFilter.Apply(image);
        }

        private static Bitmap Denoiseimage(Bitmap image)
        {
            // create filter
            ConservativeSmoothing filter = new ConservativeSmoothing();
            // apply the filter
            filter.ApplyInPlace(image);
            return image;
        }

        public static Bitmap ImageProcessing(Bitmap SourceImage, int Zoomlevel)
        {
            SourceImage = Grayscaleimage(SourceImage);

            if (Zoomlevel != 1)
            {
                SourceImage = Resizeimage(SourceImage, SourceImage.Width * Zoomlevel, SourceImage.Height * Zoomlevel);
            }
            SourceImage = Deskewimage(SourceImage);
            SourceImage = Denoiseimage(SourceImage);
            return SourceImage;
        }

        public static Bitmap ImageProcessing(Bitmap SourceImage)
        {
            SourceImage = Grayscaleimage(SourceImage);
            SourceImage = Deskewimage(SourceImage);
            SourceImage = Denoiseimage(SourceImage);
            return SourceImage;
        }

        public static Bitmap GrayScaleOnly(Bitmap SourceImage)
        {
            SourceImage = Grayscaleimage(SourceImage);
            return SourceImage;
        }
    }
}