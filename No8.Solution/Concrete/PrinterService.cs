using No8.Solution.Interfaces;
using System;
using System.Collections.Generic;

namespace No8.Solution.Concrete
{
    /*
     * если я правильно поняла постановку задачи из текстового файла: есть сущность, которая знает о всех принтерах в системе,
     * получает данные об их активности и логирует их,
     * ничего не сказанно, что она ещё и управлением печати занимается
     */
    public  class PrinterService : IPrinterService
    {
        private readonly PrintersCollection _printers;
        private readonly IFileLogger _logger = new FileLogger();    // не есть хорошо
        
        public static PrinterService Instance
        {
            get { return Nested._instance; }
        }

        private static class Nested
        {
            public static readonly PrinterService _instance =
                new PrinterService();
        }

        private PrinterService()
        {
            _printers = new PrintersCollection();
        }

        public void Add(IPrinter printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            try
            {
                _printers.Add(printer);
                _logger.LogInfo($"{printer.Name} ({printer.Model}) was added!");

                printer.StartPrintChange += StartPrintChanged;
                printer.EndPrintChange += EndPrintChanged;
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"On Add: {ex.Message}!", ex);
            }
        }

        public void Remove(IPrinter printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            try
            {
                _printers.Remove(printer);
                _logger.LogInfo($"{printer.Name} ({printer.Model}) was removed!");

                printer.StartPrintChange -= StartPrintChanged;
                printer.EndPrintChange -= EndPrintChanged;
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"On Remove: {ex.Message}!", ex);
            }
        }

        public IEnumerable<IPrinter> GetAll()
        {
            return _printers;
        }

        private void StartPrintChanged(object sender, PrintArgs e)
        {
            _logger.LogInfo($"{e.Name} ({e.Model}) start printing!");
        }

        private void EndPrintChanged(object sender, PrintArgs e)
        {
            _logger.LogInfo($"{e.Name} ({e.Model}) end printing!");
        }
    }
}
