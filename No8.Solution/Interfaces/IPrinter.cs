using System;

namespace No8.Solution.Interfaces
{
    public interface IPrinter
    {
        event EventHandler<PrintArgs> StartPrintChange;

        event EventHandler<PrintArgs> EndPrintChange;
        
        string Name { get; }
        
        string Model { get; }

        TResult Print<TResult>(IProvider<TResult> resource);
    }
}
