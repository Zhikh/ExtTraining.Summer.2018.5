using System;
using NUnit.Framework;
using No8.Solution.Interfaces;
using No8.Solution.Concrete;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class PrinterServiceTests
    {
        private IPrinterService printerService;

        [SetUp]
        public void Init()
        {
            printerService = PrinterService.Instance;
        }

        #region Exceptions
        [Test]
        public void Add_NullPrinter_ArgumentNullException() => 
            Assert.Catch<ArgumentNullException>(() => printerService.Add(null));

        [Test]
        public void Remove_NullPrinter_ArgumentNullException() =>
            Assert.Catch<ArgumentNullException>(() => printerService.Remove(null));
        #endregion

        #region Add printer
        [TestCase("name1", "model1", "model2", "model3")]
        public void Add_UniquePrinters_CorrectResult(string name, params string[] models)
        {
            foreach (var model in models)
            {
                printerService.Add(new Printer(name, model));
            }

            var printers = printerService.GetAll();
            int i = 0;
            foreach(var printer in printers)
            {
                Assert.AreEqual(name, printer.Name);
                Assert.AreEqual(models[i++], printer.Model);
            }
        }

        [TestCase(1, "name1", "model1", "model1")]
        public void Add_SamePrinters_CorrectResult(int dublicate, string name, params string[] models)
        {
            foreach (var model in models)
            {
                printerService.Add(new Printer(name, model));
            }

            printerService.Add(new Printer(name, models[dublicate]));

            var printers = printerService.GetAll();
            int i = 0;
            foreach (var printer in printers)
            {
                Assert.AreEqual(name, printer.Name);
                Assert.AreEqual(models[i++], printer.Model);
            }
        }
        #endregion

        #region Remove printer

        #endregion

        #region Events

        #endregion
    }
}
