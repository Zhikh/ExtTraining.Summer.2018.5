using System;

namespace No8.Solution.Interfaces
{
    public class PrintArgs : EventArgs
    {
        public PrintArgs(string name, string model)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public string Name { get; set; }

        public string Model { get; set; }
    }
}