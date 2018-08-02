using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            Console.WriteLine("2:Print on Canon"); // захардкожено имя
            Console.WriteLine("3:Print on Epson"); // принтеров может быть много и нет печати для добавленного принтера

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                CreatePrinter();
            }

            if (key.Key == ConsoleKey.D2)
            {
                Print(new CanonPrinter());
            }

            if (key.Key == ConsoleKey.D3)
            {
                Print(new EpsonPrinter());
            }

            while (true)
            {
                // waiting
            }
        }

        #region привязка под конкретный принтер, возможно не имеет смысла выделять отдельным методом
        // TODO: return to view on containing
        private static void Print(EpsonPrinter epsonPrinter)
        {
            PrinterManager.Print(epsonPrinter);
            PrinterManager.Log("Printed on Epson");
        }

        private static void Print(CanonPrinter canonPrinter)
        {
            PrinterManager.Print(canonPrinter);
            PrinterManager.Log("Printed on Canon");
        }
        #endregion

        private static void CreatePrinter()
        {
            PrinterManager.Add(new Printer());
        }
    }
}
