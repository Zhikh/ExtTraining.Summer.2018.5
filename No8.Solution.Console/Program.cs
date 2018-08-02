using No8.Solution.Concrete;
using No8.Solution.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace No8.Solution.Console
{
    class Program
    {
        private enum Action { Add, Remove };

        static void Main(string[] args)
        {
            PrinterService printerService = PrinterService.Instance;
            
            while (true)
            {
                IEnumerable<IPrinter> printers = printerService.GetAll();

                PrintMenu(printers);
                ExucuteAction(printerService, printers);
            }
        }

        private static void ExucuteAction(PrinterService printerService, IEnumerable<IPrinter> printers)
        {
            string value = System.Console.ReadLine();

            if (int.TryParse(value, out int key))
            {
                System.Console.Clear();

                string name, model;

                switch (key)
                {
                    case (int)Action.Add:
                        GetPrinterInfo(out name, out model);

                        printerService.Add(new Printer(name, model));
                        break;
                    case (int)Action.Remove:
                        GetPrinterInfo(out name, out model);

                        printerService.Remove(new Printer(name, model));
                        break;
                    default:
                        int i = 1;

                        if (printers.Count() != 0)
                        {
                            i++;
                        }

                        foreach (var printer in printers)
                        {
                            if (key == i)
                            {
                                System.Console.WriteLine(printer.Print<string, string>("From"));
                            }
                        }
                        break;
                }
            }
        }

        private static void GetPrinterInfo(out string name, out string model)
        {
            System.Console.WriteLine("Название:");
            name = System.Console.ReadLine();
            System.Console.WriteLine("Модель:");
            model = System.Console.ReadLine();
        }

        private static int PrintMenu(IEnumerable<IPrinter> printers)
        {
            int i = 0;
            System.Console.WriteLine("Select:");
            System.Console.WriteLine($"{i++}: Add new printer");

            if (printers.Count() != 0)
            {
                System.Console.WriteLine($"{i++}: Remove printer");
            }

            foreach (var printer in printers)
            {
                System.Console.WriteLine($"{i++}: Print on {printer.Name} ({printer.Model})");
            }

            return i;
        }
    }
}
