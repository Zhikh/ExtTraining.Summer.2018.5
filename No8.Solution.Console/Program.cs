using No8.Solution.Concrete;
using No8.Solution.Interfaces;
using System;
using System.Collections.Generic;

namespace No8.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PrinterService printerService = PrinterService.Instance;
            
            while (true)
            {
                System.Console.WriteLine("Select:");
                System.Console.WriteLine("0: Add new printer");

                IEnumerable<IPrinter> printers = printerService.GetAll();

                int i = 1;
                foreach (var printer in printers)
                {
                    System.Console.WriteLine($"{i}: Print on {printer.Name} ({printer.Model})");
                }

                var key = System.Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    System.Console.Clear();

                    System.Console.WriteLine("Название:");
                    var name = System.Console.ReadLine();

                    System.Console.WriteLine("Модель:");
                    var model = System.Console.ReadLine();

                    printerService.Add(new Printer(name, model));

                    i++;
                }
                else
                {
                    foreach(var printer in printers)
                    {

                    }
                }
            }
        }
    }
}
