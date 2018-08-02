using System;
using No8.Solution.Interfaces;

namespace No8.Solution.Concrete
{
    public abstract class BasePrinter : IPrinter
    {
        protected BasePrinter(string name, string model)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public string Name { get; }

        public string Model { get; }

        public event EventHandler<PrintArgs> StartPrintChange = delegate { };
        public event EventHandler<PrintArgs> EndPrintChange = delegate { };

        public TResult Print<TResult>(IProvider<TResult> resource)
        {
            OnStartPrintChange(this, new PrintArgs(Name, Model));

            var data = PrintData(resource);

            OnEndPrintChange(this, new PrintArgs(Name, Model));

            return data;
        }

        internal abstract TResult PrintData<TResult>(IProvider<TResult> resource);

        private void OnEndPrintChange(object sender, PrintArgs eventArgs)
        {
            EndPrintChange?.Invoke(this, eventArgs);
        }

        private void OnStartPrintChange(object sender, PrintArgs eventArgs)
        {
            StartPrintChange?.Invoke(this, eventArgs);
        }
    }

}