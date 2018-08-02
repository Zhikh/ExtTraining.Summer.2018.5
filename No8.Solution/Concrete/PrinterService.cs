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

        public void Add(IPrinter resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            try
            {
                _printers.Add(resource);

                resource.StartPrintChange += StartPrintChanged;
                resource.EndPrintChange += EndPrintChanged;
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("On add", ex);
            }
        }

        public void Remove(IPrinter resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            try
            {
                _printers.Remove(resource);

                resource.StartPrintChange -= StartPrintChanged;
                resource.EndPrintChange -= EndPrintChanged;
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("On Remove", ex);
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
