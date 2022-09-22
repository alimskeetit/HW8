using System;

namespace Task1
{
    class Program
    {
        public static DateTime dateTime;
        public const int timeToDelete = 1;
        public static string generalPath;
        public static void Main()
        {
            Console.WriteLine("Введите имя папки: ");
            generalPath = Console.ReadLine();
            if (!Directory.Exists(generalPath))
            {
                Console.WriteLine("Данной папки не существует");
                return;
            }

            dateTime = DateTime.Now.AddMinutes(timeToDelete);
            deleteDirsAndFiles(generalPath);
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
                    var a = DateTime.Now;
                    var b = File.GetLastWriteTime(file);
                    var c = TimeSpan.FromMinutes(timeToDelete);
                    if (a.Subtract(b) > c)
                    {
                        File.Delete(file);
                    }
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