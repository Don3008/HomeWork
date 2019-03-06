using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*3.       Сделать записную книжку, которая будет сохранять данные в файл.
3* Каждая запись храниться в отдельном файле и при запуске программы, программа проверяет не пустая ли папка, и если нет то выводит список доступных записей которые можно выбрать.
3** Все данные хранятся в одном файле разбитые между собой и при запуске программы, программа считыает файл и выводит список доступных записей.
*/
namespace Notebook
{
    public class Notes
    {
        public static int Variant(HowWrite howWrite, int count)
        {
            switch (howWrite)
            {
                case HowWrite.ManyFiles:
                    count = DifferentFiles(count);
                    break;
                case HowWrite.OneFile:
                    WriteInOneFile();
                    break;
                default:
                    Console.WriteLine("Выбран несуществующий вариант!");
                    break;
            }
            return count;
        }

        static int DifferentFiles(int count)
        {
            string path = @"C:\Users\don30\source\repos\HomeWork\Lesson4\Notebook\Notes\";
            string file = count.ToString();
            string subPath = path;
            path = path + file + ".txt";
            FileInfo files = new FileInfo(path);
            while (files.Exists)
            {
                count++;
                file = count.ToString();
                path = subPath + file + ".txt";
                files = new FileInfo(path);
            }
            string text = InputText();
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.Default))
            {
                writer.WriteLine(text);
            }
            count++;
            return count;
        }

        public static void ReadFromDifferentFiles()
        {
            string path = @"C:\Users\don30\source\repos\HomeWork\Lesson4\Notebook\Notes\";
            int count = 0;
            string file;
            string subPath = path;
            path = path + "0.txt";
            FileInfo files = new FileInfo(path);
            do
            {
                FileInfo fileInfo = new FileInfo(path);
                
                if (fileInfo.Exists)
                {
                    Console.WriteLine("Название файла {0}: ", fileInfo.Name);
                    Console.WriteLine("Время создания {0}: ", fileInfo.CreationTime);
                }
                FileStream fileStream = File.OpenRead(path);
                byte[] arr = new byte[fileStream.Length];
                fileStream.Read(arr, 0, arr.Length);
                string textFromFile = Encoding.Default.GetString(arr);
                fileStream.Close();
                Console.WriteLine(textFromFile);
                ++count;
                file = count.ToString();
                path = subPath + file + ".txt";
            }
            while (files.Exists);
        }

        static string InputText()
        {
            Console.WriteLine("Введите информацию, которую хотите сохранить:");
            string text = Console.ReadLine();
            return text;
        }

        static void WriteInOneFile()
        {
            string text = InputText();
            string path = @"C:\Users\don30\source\repos\HomeWork\Lesson4\Notebook\Notes\oneFile.txt";
            DateTime ThToday = DateTime.Now;
            string ThData = ThToday.ToString();
            using (StreamWriter streamWriter = new StreamWriter(path, true, Encoding.Default))
            {
                streamWriter.WriteLine(ThData);
                streamWriter.WriteLine(text);
            }
        }

        public static void ReadFromOneFile()
        {
            string path = @"C:\Users\don30\source\repos\HomeWork\Lesson4\Notebook\Notes\oneFile.txt";
            using (StreamReader streamReader = new StreamReader(path, Encoding.Default))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }

        public static bool NewNote(bool isExit)
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            bool rightInput = false;
            while (rightInput == false)
            {
                Console.WriteLine("Записать еще информацию? \n Введите Y - если да, N - если нет");
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    rightInput = true;
                    return isExit;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    isExit = true;
                    rightInput = true;
                    return isExit;
                }
                else
                {
                    Console.WriteLine("Введено неверное значение!");
                    rightInput = false;
                }
            }
            return isExit;
        }
    }
}
