using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TesseractOCRPlugin;

namespace TesseractOCRPluginUnitTests
{
    [TestClass]
    public class TesseractTest
    {
        [TestMethod]
        public void InitTest()
        {
            TesseractOCR TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High);
        }
    }
}