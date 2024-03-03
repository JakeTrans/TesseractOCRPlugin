using IronSoftware.Drawing;

using SixLabors.ImageSharp.Processing;
using System.IO;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats;
using TesseractOCRPlugin__.Net_Standard_.Deskew;
using SixLabors.ImageSharp;

namespace IronImageProcessing
{
    internal static class IronImageProc
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

        private static AnyBitmap Deskewimage(SixLabors.ImageSharp.Image image)
        {
            Deskew cVDeskew = new Deskew();
            //double Angle = cVDeskew.GetDeskewAngle(image);
            //image.SaveAsBmp(new FileStream(@"D:\OCR\TestInput.bmp", FileMode.Create, FileAccess.Write, FileShare.ReadWrite));
            //Angle = Angle * -1;
            //image.Mutate(x => x.Rotate((float)Angle));
            image = cVDeskew.DeskewImage(image);
            //image.SaveAsBmp(new FileStream(@"D:\OCR\Testoutput.bmp", FileMode.Create, FileAccess.Write, FileShare.ReadWrite));
            return image;
        }

        public static SixLabors.ImageSharp.Image ImageProcessing(SixLabors.ImageSharp.Image SourceImage, int Zoomlevel)
        {
            // SourceImage = Grayscaleimage(SourceImage);

            if (Zoomlevel != 1)
            {
                SourceImage = Resizeimage(SourceImage, SourceImage.Width * Zoomlevel, SourceImage.Height * Zoomlevel);
            }
            MemoryStream memoryStream = new MemoryStream();
            IImageEncoder IID = new PngEncoder();
            SourceImage.Save(memoryStream, IID);

            //Mat mat = Mat.FromArray(memoryStream.ToArray());

            SourceImage = Deskewimage(SourceImage);

            return SourceImage;
        }
    }
}