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
            
            if (GetValue(printer) != null)
            {
                throw new ArgumentException($"The printer: {printer.Name} ({printer.Model}) - aleady exists!");
            }

            _printers.Add(printer);
        }

        public void Remove (IPrinter printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            var value = GetValue(printer);

            if (value == null)
            {
                throw new ArgumentException($"The printer: {printer.Name} ({printer.Model}) - doesn't exist!");
            }

            _printers.Remove(value);
        }

        public IPrinter Find(Func<IPrinter,bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return _printers.FirstOrDefault(predicate);
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

        private IPrinter GetValue(IPrinter printer)
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
                    return element;
                }
            }

            return null;
        }

    }
}
