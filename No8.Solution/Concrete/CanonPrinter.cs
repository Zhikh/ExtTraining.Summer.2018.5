using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Concrete
{
    public class CanonPrinter : Printer
    {
        private const string NAME = "Canon";
        private const string MODEL = "123x";

        protected CanonPrinter() : base(NAME, MODEL)
        {
        }
    }
}
