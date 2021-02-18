using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesseractOCRPlugin
{
    public class TesseractOCRResult
    {
        public TesseractOCRResult(string oCRResult, double timeTaken, float confidence)
        {
            OCRResult = oCRResult;
            TimeTaken = timeTaken;
            Confidence = confidence;
        }

        public string OCRResult { get; set; }
        public double TimeTaken { get; set; }
        public float Confidence { get; set; }
    }
}