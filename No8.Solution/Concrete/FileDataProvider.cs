using System;
using System.IO;

namespace No8.Solution.Concrete
{
    // должен быть на стороне клиента
    public static class FileDataProvider
    {
        private const string EXTENSION = ".txt";

        public static string Load(FileInfo file)
        {
            Validate(file);

            string result = "";

            using (StreamReader reader = new StreamReader(file.FullName))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    result += line;
                }
            }

            return result;
        }

        private static void Validate(FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (!file.Exists)
            {
                throw new FileNotFoundException(nameof(file));
            }

            if (file.Extension != EXTENSION)
            {
                throw new FileLoadException(nameof(file));
            }
        }
    }
}
