using No8.Solution.Interfaces;
using System;
using System.IO;

namespace No8.Solution.Concrete
{
    public class TextDataProvider : ITextDataProvider
    {
        private readonly FileInfo _file;

        public TextDataProvider(FileInfo file)
        {
            _file = file ?? throw new ArgumentNullException(nameof(file));

            if (!file.Exists)
            {
                throw new FileNotFoundException(nameof(file));
            }
        }

        public string Load()
        {
            string result = "";

            using (StreamReader reader = new StreamReader(_file.FullName))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    result += line;
                }
            }

            return result;
        }
    }
}
