using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using TesseractOCRPlugin;

namespace TesseractPluginTest__.Net_Standard_
{
    [TestClass]
    public class TesseractTest
    {
        private string startupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(@"file:\", string.Empty);

        [TestMethod]
        public void InitTest()
        {
            TesseractOCR TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High);
        }

        [TestMethod]
        public void ScanTest()
        {
            string expectedtext = @"This is a lot of 12 point text to test the ocr code and see if it works on all types
    of file format.

    The quick brown dog jumped over the
    lazy fox. The quick brown dog jumped
    over the lazy fox. The quick brown dog
    jumped over the lazy fox. The quick
    brown dog jumped over the lazy fox.";

            TesseractOCR TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High);

            string text = TessOCR.OCRimage(startupPath + @"\Images\testocr.png");
            Trace.WriteLine("Output of OCR was:");
            Trace.WriteLine(text);

            Assert.AreEqual(expectedtext.Replace(" ", "").Replace(Environment.NewLine, ""), text.Replace(" ", "").Replace("\n", ""), "OCR doesn't match");
        }
    }
}