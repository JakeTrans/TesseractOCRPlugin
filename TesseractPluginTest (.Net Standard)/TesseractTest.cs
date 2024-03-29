using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using TesseractOCRPlugin;

namespace TesseractPluginTest
{
    [TestClass]
    public class TesseractTest
    {
        private readonly string startupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(@"file:\", string.Empty);

        [TestMethod]
        public void InitTest()
        {
            TesseractOCR TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High);
        }

        [TestMethod]
        public void ScanTest()
        {
            string expectedtext = "This is a lot of 12 point text to test the\n" +
                                    "ocr code and see if it works on all types\n" +
                                    "of file format." + "\n\n" +
                                    "The quick brown dog jumped over the" + "\n" +
                                    "lazy fox. The quick brown dog jumped" + "\n" +
                                    "over the lazy fox. The quick brown dog" + "\n" +
                                    "jumped over the lazy fox. The quick" + "\n" +
                                    "brown dog jumped over the lazy fox." + "\n";

            TesseractOCR TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High);

            string text = TessOCR.OCRimage(startupPath + @"\Images\testocr.png");
            Trace.WriteLine("Output of OCR was:");
            Trace.WriteLine(text);

            Assert.AreEqual(expectedtext, text, "OCR doesn't match");
        }

        [TestMethod]
        public void SkewTest10DegreeAntiClockwise()
        {
            string expectedtext = "This is a lot of 12 point text to test the\n" +
                        "ocr code and see if it works on  alltypes\n" +
                        "of file format." + "\n\n" +
                        "The quick brown dog jumped over the" + "\n" +
                        "lazy fox. The quick brown dog jumped" + "\n" +
                        "over the lazy fox. The quick brown dog" + "\n" +
                        "jumped over the lazy fox. The quick" + "\n" +
                        "brown dog jumped over the lazy fox" + "\n";

            TesseractOCR TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High);

            string text = TessOCR.OCRimage(startupPath + @"\Images\text10anticlockwise.jpg");
            Trace.WriteLine("Output of OCR was:");
            Trace.WriteLine(text);

            Assert.AreEqual(expectedtext, text, "OCR doesn't match");
        }

        [TestMethod]
        public void SkewTest10Degreelockwise()
        {
            string expectedtext = "This is a lot of 12 point text to test the\n" +
                        "ocr code and see if it works on all types\n" +
                        "of file format." + "\n\n" +
                        "The quick brown dog jumped over the" + "\n" +
                        "lazy fox. The quick brown dog jumped" + "\n" +
                        "over the lazy fox. The quick brown dog" + "\n" +
                        "jumped over the lazy fox. The quick" + "\n" +
                        "brown dog jumped over the lazy fox." + "\n";

            TesseractOCR TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High);

            string text = TessOCR.OCRimage(startupPath + @"\Images\text10clockwise.jpg", 2);
            Trace.WriteLine("Output of OCR was:");
            Trace.WriteLine(text);

            Assert.AreEqual(expectedtext, text, "OCR doesn't match");
        }
    }
}