using Emgu.CV.Structure;
using Emgu.CV;
using IronSoftware.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;

namespace TesseractOCRPlugin__.Net_Standard_.Deskew
{
    public static class AnyBitmapExenstion
    {
        public static Mat GetMatFromAnyBitmap(AnyBitmap anyBitmap)
        {
            Bitmap bmp = anyBitmap;
            int stride = bmp.Width * (bmp.PixelFormat == PixelFormat.Format32bppArgb ? 4 : 3);
            Image<Bgra, byte> cvImage = new Image<Bgra, byte>(bmp.Width, bmp.Height, stride, (IntPtr)bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat).Scan0);
            //bmp.UnlockBits(bmpData);
            return cvImage.Mat;
        }
    }
}