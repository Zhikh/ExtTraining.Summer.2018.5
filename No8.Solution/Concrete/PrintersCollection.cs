using No8.Solution.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace No8.Solution
{
    public class PrintersCollection : IEnumerable<IPrinter>
    {
        private List<IPrinter> _printers = new List<IPrinter>();

        public void Add (IPrinter printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            // TODO: save to logger
            if (this.IsContain(printer))
            {
                throw new ArgumentException($"The printer: {printer.Name} {printer.Model} - exists!");
            }

            _printers.Add(printer);
        }

        public void Remove (IPrinter printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            // TODO: save to logger
            if (!this.IsContain(printer))
            {
                throw new ArgumentException($"The printer: {printer.Name} {printer.Model} - doesn't exist!");
            }

            _printers.Add(printer);
        }

        public bool IsContain(IPrinter printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            foreach (var element in _printers)
            {
                if (element.Name == printer.Name && 
                    element.Model == printer.Model)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<IPrinter> GetEnumerator()
        {
            foreach (var printer in _printers)
            {
                yield return printer;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
