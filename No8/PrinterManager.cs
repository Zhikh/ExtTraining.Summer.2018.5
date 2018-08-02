using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace No8
{
    public delegate void PrinterDelegate(string arg);

    internal static class PrinterManager
    {
        static PrinterManager()
        {
            Printers = new List<object>();
        }

        public static List<object> Printers { get; set; }

        // IPrinter + не его обязанность заниматься коллекцией принтеров напрямую(?)
        public static void Add(Printer p1)
        {
            // логика ui + бизнесс логика
            Console.WriteLine("Enter printer name");
            p1.Name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            p1.Model = Console.ReadLine();

            if (!Printers.Contains(p1))
            {
                Printers.Add(p1);
                Console.WriteLine("Printer added");
            }
        }

        // привязываемся к конкретной реализации
        public static void Print(EpsonPrinter p1)
        {
            Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            p1.Print(f);
            Log("Print finished");
        }

        // привязываемся к конкретной реализации
        public static void Print(CanonPrinter p1)
        {
            Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            p1.Print(f);
            Log("Print finished");
        }

        // часть обязанностей логгера
        public static void Log(string s)
        {
            File.AppendText("log.txt").Write(s);
        }

        // использование кастомного делегата: возможно не его обязанность
        public static event PrinterDelegate OnPrinted;
    }
}