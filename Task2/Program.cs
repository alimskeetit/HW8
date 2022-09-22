using System;

namespace Task2
{
    class Program
    {
        public static string generalPath;
        public static long size = 0;
        public static void Main()
        {
            Console.WriteLine("Введите имя папки: ");
            generalPath = Console.ReadLine();
            if (!Directory.Exists(generalPath))
            {
                Console.WriteLine("Данной папки не существует");
                return;
            }
            sizeOfDirectory(generalPath);
            Console.WriteLine(size);

        }

        public static void sizeOfDirectory(in string path)
        {
            try
            {
                var directories = Directory.GetDirectories(path);
                foreach (string directory in directories)
                {
                    sizeOfDirectory(directory);
                }

                var files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    size += new FileInfo(file).Length;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}