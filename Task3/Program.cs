using System;
using System.Drawing;

namespace Task3
{
    class Program
    {
        public static DateTime dateTime;
        public const int timeToDelete = 0;
        public static string generalPath;
        public static long size;

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
            Console.WriteLine($"Исходный размер папки: {size} байт");
            long lastSize = size;
            deleteDirsAndFiles(generalPath);
            sizeOfDirectory(generalPath);
            Console.WriteLine($"Освобождено: {lastSize - size} байт");
            Console.WriteLine($"Текущий размер папки: {size} байт");
        }

        public static void sizeOfDirectory(in string path)
        {
            size = 0;
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

        public static void deleteDirsAndFiles(in string path)
        {
            try
            {
                var directories = Directory.GetDirectories(path);
                foreach (string directory in directories)
                {
                    deleteDirsAndFiles(directory);
                }

                var files = Directory.GetFiles(path);
                foreach (string file in files) 
                {
                        File.Delete(file);
                }

                if (Directory.GetFiles(path).Length == 0 && Directory.GetDirectories(path).Length == 0 && path != generalPath)
                {
                    Directory.Delete(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}