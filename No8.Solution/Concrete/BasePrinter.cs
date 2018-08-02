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

            if (name  == string.Empty)
            {
                throw new ArgumentException(nameof(name));
            }

            if (model == string.Empty)
            {
                throw new ArgumentException(nameof(model));
            }
        }

        public string Name { get; }

        public string Model { get; }

        public event EventHandler<PrintArgs> StartPrintChange = delegate { };
        public event EventHandler<PrintArgs> EndPrintChange = delegate { };
        
        public TResult Print<TSource, TResult>(TSource data)
        {
            OnStartPrintChange(this, new PrintArgs(Name, Model));

            TResult result = (dynamic)PrintData(data);

            OnEndPrintChange(this, new PrintArgs(Name, Model));

            return result;
        }

        internal abstract object PrintData<T>(T data);

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