using System;
using System.Collections.Generic;
using System.Drawing;
using Tesseract;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;


namespace TesseractOCRPlugin
{   


    public class TesseractOCR
    {
        /// <summary>
        /// The main Tesseract Object use this to play with variables etc.
        /// </summary>
        public  TesseractEngine TesseractOCRCore;
        private Bitmap ImageToOCR;




        public enum Quality
        {
            Low,
            Medium,
            High,
        };





        string  Tessdatapath = "";
        string  x86path = "";
        string  x64path = "";


        public TesseractOCR(string LanguageCode,Quality Qualitylevel)
        {

            //Build ocr object upfront this minimises time to load for muliple OCR jobs
            Tessdatapath = (Path.GetDirectoryName(Assembly.GetAssembly(GetType()).CodeBase) + @"\Tessdata").Replace("file:\\", "");
            x86path = (Path.GetDirectoryName(Assembly.GetAssembly(GetType()).CodeBase) + @"\x86").Replace("file:\\", "");
            x64path = (Path.GetDirectoryName(Assembly.GetAssembly(GetType()).CodeBase) + @"\x64").Replace("file:\\", "");




            string FileCheckerResult =TesseractFileChecker();
            if (FileCheckerResult == "True")
            {
                switch (Qualitylevel)
                {
                    case Quality.High:
                        TesseractOCRCore = new TesseractEngine(Path.GetDirectoryName(Tessdatapath), LanguageCode, EngineMode.TesseractAndCube);
                        break;
                    case Quality.Medium:
                        TesseractOCRCore = new TesseractEngine(Path.GetDirectoryName(Tessdatapath), LanguageCode, EngineMode.TesseractOnly);
                        break;
                    case Quality.Low:
                        TesseractOCRCore = new TesseractEngine(Path.GetDirectoryName(Tessdatapath), LanguageCode, EngineMode.CubeOnly);
                        break;
                }
               
                
            }

            
        }


        private string TesseractFileChecker()
        {
            /*
            This function is setup to check that the tesseract folder are in the correct location
            because to be honest tesseract reports 99% of error as "Key not found in Dictionary"
            So I thought in would be best to check the x86, x64 and Tessdata files are where they should 
            be
            */








            if (Directory.Exists(Tessdatapath) == false)
            { 
                throw new TesseractFileNotFoundException("TessData folder missing from: " + Tessdatapath);
            }
            if (Directory.Exists(x86path) == false)
            {

                throw new TesseractFileNotFoundException("x86 folder missing from: " + x86path);
            }
            if (Directory.Exists(x64path) == false)
            {

                throw new TesseractFileNotFoundException("x64 folder missing from: " + x64path);
            }

            return "True";


        }

        #region Load image overloads

        private void  LoadImage (string imagePath)
        {
            //Welcome to the bizarre world of GDI+ in C# with new Bitmap everywhere 

            #region The best answer I have
            /*
               The most merciful thing in the world, I think, is the inability
               of the human mind to correlate all its contents. We
               live on a placid island of ignorance in the midst of black seas
               of infinity, and it was not meant that we should voyage far. 
             */
            #endregion

            Bitmap BitmapToOCR = new Bitmap(new Bitmap (imagePath));
            BitmapToOCR = BitmapToOCR.Clone(new Rectangle(0, 0, BitmapToOCR.Width, BitmapToOCR.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //Format32bppArgb
            ImageToOCR = new Bitmap (BitmapToOCR);
            BitmapToOCR.Dispose();
        }
        private void  LoadImage (Image ImageToUse)
        {
            //Welcome to the bizarre world of GDI+ in C# with new Bitmap everywhere 

            #region The best answer I have
            /*
               The most merciful thing in the world, I think, is the inability
               of the human mind to correlate all its contents. We
               live on a placid island of ignorance in the midst of black seas
               of infinity, and it was not meant that we should voyage far. 
             */
            #endregion

            Bitmap BitmapToOCR = new Bitmap(new Bitmap(ImageToUse));
            BitmapToOCR = BitmapToOCR.Clone(new Rectangle(0, 0, BitmapToOCR.Width, BitmapToOCR.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //Format32bppArgb
            ImageToOCR = new Bitmap(BitmapToOCR);
            BitmapToOCR.Dispose();
        }
        #endregion
        //OCR function and their overloads

        #region OCRImage Overloads
        public string OCRimage(string imagelocation)
        {
            //load in image
            LoadImage(imagelocation);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR);
            //Random rnd = new Random();
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();
            img.Dispose();
            page.Dispose();
            return text;
            //return "";
        }
        public string OCRimage(Image ImageToUse)
        {
            //load in image
            LoadImage(ImageToUse);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();
            img.Dispose();
            page.Dispose();
            return text;
            //return "";
        }


        public string OCRimage(string imagelocation, int Zoomlevel)
        {
            //load in image
            LoadImage(imagelocation);
            //post process the image
            ImageToOCR =  AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR, Zoomlevel);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();
            img.Dispose();
            page.Dispose();
            return text;
            //return "";
        }
        public string OCRimage(Image ImageToUse, int Zoomlevel)
        {
            //load in image
            LoadImage(ImageToUse);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR, Zoomlevel);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();
            img.Dispose();
            page.Dispose();
            return text;
            //return "";
        }


        public string OCRimage(string imagelocation, out float Confidence)
        {
            //load in image
            LoadImage(imagelocation);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();
            //Get confidence
            Confidence = page.GetMeanConfidence();
            return text;
            //return "";
        }
        public string OCRimage(Image ImageToUse, out float Confidence)
        {
            //load in image
            LoadImage(ImageToUse);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();
            //Get confidence
            Confidence = page.GetMeanConfidence();
            return text;
            //return "";
        }
        public string OCRimage(string imagelocation, int Zoomlevel, out float Confidence)
        {
            //load in image
            LoadImage(imagelocation);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR, Zoomlevel);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();
            //Get confidence
            Confidence = page.GetMeanConfidence();
            return text;
            //return "";
        }
        public string OCRimage(Image ImageToUse, int Zoomlevel, out float Confidence)
        {
            //load in image
            LoadImage(ImageToUse);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR, Zoomlevel);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();
            //Get confidence
            Confidence = page.GetMeanConfidence();
            return text;
            //return "";
        }

        public string OCRimage(string imagelocation, out double TimeTaken)
        {
            DateTime Starttime = DateTime.Now;
            
            //load in image
            LoadImage(imagelocation);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();
            //Get Time
            DateTime EndTime = DateTime.Now;
            TimeTaken = (EndTime - Starttime).TotalSeconds;
            return text;
            //return "";
        }
        public string OCRimage(Image ImageToUse, out double TimeTaken)
        {
            DateTime Starttime = DateTime.Now;

            //load in image
            LoadImage(ImageToUse);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();
            //Get Time
            DateTime EndTime = DateTime.Now;
            TimeTaken = (EndTime - Starttime).TotalSeconds;
            return text;
            //return "";
        }
        public string OCRimage(string imagelocation, int Zoomlevel, out double TimeTaken)
        {
            DateTime Starttime = DateTime.Now;

            //load in image
            LoadImage(imagelocation);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR, Zoomlevel);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();
            //Get Time
            DateTime EndTime = DateTime.Now;
            TimeTaken = (EndTime - Starttime).TotalSeconds;
            return text;
            //return "";
        }
        public string OCRimage(Image ImageToUse, int Zoomlevel, out double TimeTaken)
        {
            DateTime Starttime = DateTime.Now;

            //load in image
            LoadImage(ImageToUse);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR, Zoomlevel);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();
            //Get Time
            DateTime EndTime = DateTime.Now;
            TimeTaken = (EndTime - Starttime).TotalSeconds;
            return text;
            //return "";
        }



        public string OCRimage(string imagelocation, out double TimeTaken, out float Confidence)
        {
            DateTime Starttime = DateTime.Now;

            //load in image
            LoadImage(imagelocation);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();

            //Get confidence
            Confidence = page.GetMeanConfidence();
            //Get Time
            DateTime EndTime = DateTime.Now;
            TimeTaken = (EndTime - Starttime).TotalSeconds;
            return text;
            //return "";
        }
        public string OCRimage(Image ImageToUse, out double TimeTaken, out float Confidence)
        {
            DateTime Starttime = DateTime.Now;

            //load in image
            LoadImage(ImageToUse);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();

            //Get confidence
            Confidence = page.GetMeanConfidence();
            //Get Time
            DateTime EndTime = DateTime.Now;
            TimeTaken = (EndTime - Starttime).TotalSeconds;
            return text;
            //return "";
        }
        public string OCRimage(string imagelocation, int Zoomlevel, out double TimeTaken, out float Confidence)
        {
            DateTime Starttime = DateTime.Now;

            //load in image
            LoadImage(imagelocation);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR, Zoomlevel);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();

            //Get confidence
            Confidence = page.GetMeanConfidence();
            //Get Time
            DateTime EndTime = DateTime.Now;
            TimeTaken = (EndTime - Starttime).TotalSeconds;
            return text;
            //return "";
        }
        public string OCRimage(Image ImageToUse, int Zoomlevel, out double TimeTaken, out float Confidence)
        {
            DateTime Starttime = DateTime.Now;

            //load in image
            LoadImage(ImageToUse);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR, Zoomlevel);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            var page = TesseractOCRCore.Process(img);
            //get test
            var text = page.GetText();

            //Get confidence
            Confidence = page.GetMeanConfidence();
            //Get Time
            DateTime EndTime = DateTime.Now;
            TimeTaken = (EndTime - Starttime).TotalSeconds;
            return text;
            //return "";
        }

        #endregion

        #region Parallel OCR work
        //Let's get fancy

        //multi-threading ocr across multiple files
       

        public List<string> BulkOCRParallel(List<string> imagelocations)
        {

            List<string> Templist = new List<string>();
            Parallel.ForEach(imagelocations, (currentimage) =>
                {
                    //build up the results file via a templist
                    Templist.Add(OCRimage(currentimage));
                });
            return Templist;

        }

        public List<string> BulkOCRParallel(List<Image> ImagestoUse)
        {

            List<string> Templist = new List<string>();
            Parallel.ForEach(ImagestoUse, (currentimage) =>
            {
                //build up the results file via a templist
                Templist.Add(OCRimage(currentimage));
            });
            return Templist;

        }

        #endregion

        #region HOCR
        //Get word location
        public string OCRimagewithLocation(Image ImageToUse, int Zoomlevel)
        {
            //load in image
            LoadImage(ImageToUse);
            //post process the image
            ImageToOCR = AccordImageProcessing.AccordImageProc.ImageProcessing(ImageToOCR, Zoomlevel);
            //Convert to Tesseract format
            var img = PixConverter.ToPix(ImageToOCR);
            // OCR it
            Tesseract.Page  page = TesseractOCRCore.Process(img);
            //get test

         

            var text = page.GetHOCRText(1);
            img.Dispose();
            page.Dispose();
            return text;
            //return "";
        }
        #endregion






        //Destructor
        ~TesseractOCR ()
        {
            if (TesseractOCRCore != null)
            {
                TesseractOCRCore.Dispose();
            }
        }
    }






}