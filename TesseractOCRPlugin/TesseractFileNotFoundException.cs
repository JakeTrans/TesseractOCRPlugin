using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesseractOCRPlugin
{
    class TesseractFileNotFoundException : Exception 
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
