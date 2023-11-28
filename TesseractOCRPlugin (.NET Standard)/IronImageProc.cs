using IronSoftware.Drawing;
using SixLabors.ImageSharp.Processing;
using System;
using System.Diagnostics;

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

        private static AnyBitmap Deskewimage(AnyBitmap image)
        {
            Deskew SkewDetect = new Deskew();
            SkewDetect.DeskewImage(image);

            return image;
        }

        public static SixLabors.ImageSharp.Image ImageProcessing(SixLabors.ImageSharp.Image SourceImage, int Zoomlevel)
        {
            SourceImage = Grayscaleimage(SourceImage);

            if (Zoomlevel != 1)
            {
                SourceImage = Resizeimage(SourceImage, SourceImage.Width * Zoomlevel, SourceImage.Height * Zoomlevel);
            }
            SourceImage = Deskewimage(SourceImage);

            return SourceImage;
        }
    }
}