using Accord.Imaging;
using Accord.Imaging.Filters;
using System.Drawing;
using IronSoftware.Drawing;
using SixLabors.ImageSharp.Processing;

namespace AccordImageProcessing
{
    internal static class AccordImageProc
    {
        private static SixLabors.ImageSharp.Image Grayscaleimage(SixLabors.ImageSharp.Image image)
        {
            image.Mutate(x => x.Grayscale());

            return image;
        }

        private static SixLabors.ImageSharp.Image Resizeimage(SixLabors.ImageSharp.Image image, int NewWidth, int NewHeight)
        {
            image.Mutate(x => x.Resize(NewWidth, NewHeight));

            return image;
        }

        //private static AnyBitmap Deskewimage(AnyBitmap image)
        //{
        //    // create instance of skew checker
        //    DocumentSkewChecker skewChecker = new DocumentSkewChecker();
        //    // get documents skew angle

        //    double angle = skewChecker.GetSkewAngle(image);
        //    // create rotation filter
        //    RotateBilinear rotationFilter = new RotateBilinear(-angle)
        //    {
        //        FillColor = IronSoftware.Drawing.Color.White
        //    };
        //    // rotate image applying the filter
        //    return rotationFilter.Apply(image);
        //}

        public static SixLabors.ImageSharp.Image ImageProcessing(SixLabors.ImageSharp.Image SourceImage, int Zoomlevel)
        {
            SourceImage = Grayscaleimage(SourceImage);

            if (Zoomlevel != 1)
            {
                SourceImage = Resizeimage(SourceImage, SourceImage.Width * Zoomlevel, SourceImage.Height * Zoomlevel);
            }
            // SourceImage = Deskewimage(SourceImage);
            //SourceImage = Denoiseimage(SourceImage);
            return SourceImage;
        }
    }
}