namespace No8.Solution.Concrete
{
    // not well, need to exclude hard link to concrete printer
    public class EpsonPrinter: Printer
    {
        private const string NAME = "Epson";
        private const string MODEL = "231";

        protected EpsonPrinter() : base(NAME, MODEL)
        {
        }
    }
}
