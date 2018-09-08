using System.Collections.Generic;

namespace No8.Solution.Interfaces
{
    public interface IPrinterService
    {
        void Add(IPrinter resource);
        void Remove(IPrinter resource);
        string Print(string name, string model, string data);

        IEnumerable<IPrinter> GetAll();
    }
}
