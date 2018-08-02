using System;
using System.IO;

namespace No8
{
    // модификатор доступа
    internal class CanonPrinter
    {
        public CanonPrinter()
        {
            // константы
            Name = "Canon";
            Model = "123x";
        }

        // смешана бизнесс логика и логика ui
        // Stream
        public void Print(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }

        // состояния конкретного принтера не должно меняться => Name {get;}
        public string Name { get; set; }

        // аналогично
        public string Model { get; set; }
    }
}