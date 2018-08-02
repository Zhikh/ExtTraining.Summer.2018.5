using System.Collections.Generic;

namespace No8.Solution.Interfaces
{
    public interface IPrinterService
    {
        void Add(IPrinter resource);
        void Remove(IPrinter resource);

        IEnumerable<IPrinter> GetAll();
    }
}
