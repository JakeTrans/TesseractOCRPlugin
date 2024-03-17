using IronSoftware.Drawing;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using System.IO;
using TesseractOCRPlugin__.Net_Standard_.Deskew;

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

        public static SixLabors.ImageSharp.Image ImageProcessing(SixLabors.ImageSharp.Image SourceImage, int Zoomlevel)
        {
            Deskew cVDeskew = new Deskew();

            if (Zoomlevel != 1)
            {
                SourceImage = Resizeimage(SourceImage, SourceImage.Width * Zoomlevel, SourceImage.Height * Zoomlevel);
            }
            MemoryStream memoryStream = new MemoryStream();
            IImageEncoder IID = new PngEncoder();
            SourceImage.Save(memoryStream, IID);

            SourceImage = cVDeskew.DeskewImage(SourceImage);
            SourceImage.Save(memoryStream, IID);
            return SourceImage;
        }
    }
}