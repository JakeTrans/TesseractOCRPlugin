using System;

namespace TesseractOCRPlugin
{
    internal class TesseractFileNotFoundException : Exception
    {
        public TesseractFileNotFoundException()
           : base("Files Not Found")
        {
        }

        public TesseractFileNotFoundException(string message)
            : base(message)
        {
        }

        public TesseractFileNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}