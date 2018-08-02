using System;
using No8.Solution.Concrete;
using NUnit.Framework;
using System.IO;
using System.Diagnostics;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class PrinterTests
    {
        #region Exception
        [Test]
        public void Print_NullName_ArgumentNullException()
           => Assert.Catch<ArgumentNullException>(() =>
           {
               var printer = new Printer(null, "model");
           });

        [Test]
        public void Print_NullModel_ArgumentNullException()
           => Assert.Catch<ArgumentNullException>(() =>
           {
               var printer = new Printer("name", null);
           });

        [Test]
        public void Print_EmptyName_ArgumentException()
          => Assert.Catch<ArgumentException>(() =>
          {
              var printer = new Printer("", "model");
          });

        [Test]
        public void Print_EmptyModel_ArgumentException()
          => Assert.Catch<ArgumentException>(() =>
          {
              var printer = new Printer("name", "");
          });
        #endregion

        [TestCase("name", "model")]
        public void Printer_CorrectData_SavingInProperties(string name, string model)
        {
            var printer = new Printer(name, model);

            Assert.AreEqual(name, printer.Name);
            Assert.AreEqual(model, printer.Model);
        }

        [TestCase("test data")]
        public void Print_FakeData_SameValue(string fakeData)
        {
            var printer = new Printer("test", "test");

            var printData = printer.Print<string, string>(fakeData);

            Assert.AreEqual(fakeData, printData);
        }

        [TestCase(@"C:\Users\Zhikh Anastasya\Documents\ExtTraining.Summer.2018.5\No8.Solution.Tests\bin\Debug\Test.txt")]
        public void Print_DataFromFile_SameValue(string path)
        {
            string expected = FileDataProvider.Load(new FileInfo(path));
            Debug.Write(expected);

            var printer = new Printer("test", "test");
            var actual = printer.Print<string, string>(expected);

            Assert.AreEqual(expected, actual);
        }
    }
}
