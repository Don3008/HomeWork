using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Notebook
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("Выберете, как сохранять данные: \n 1.В отдельных файлах. \n 2.В одном файле");
                int variant = int.Parse(Console.ReadLine());
                count = Variant(variant, count);
                isExit = NewRecord(isExit);
            }

        }
        static int Variant(int variant, int count)
        {
            switch (variant)
            {
                case 1:
                    count = DifferentFiles(count);
                    return count;
                    break;
                case 2:
                    OneFile();
                    return count;
                    break;
                default:
                    Console.WriteLine("Выбран несуществующий вариант!");
                    return count;
                    break;
            }
        }
        static int DifferentFiles(int count)
        {

            int countDir = 0;
            string path = @"C:\Users\don30\source\repos\HomeWork\Lesson4\Notebook\";
            //bool isCreate = false;

            //while (isCreate == false)
            //{
            bool isEmpty = false;
            string subPath = path + $@"{countDir}\";
            while (!isEmpty)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(subPath);
                directoryInfo.Create();
                if (directoryInfo.GetFiles().GetLength(1) == 0)
                {
                    countDir++;
                    subPath = path + $@"{countDir}\";
                    
                    
                    //isCreate = true;
                }
                else
                {
                    //directoryInfo = new DirectoryInfo(subPath);
                    
                    isEmpty = true;
                }
                
            }


            string file = count.ToString();
            path = subPath + file + ".txt";
            Console.WriteLine("Введите информацию, которую хотите сохранить:");
            string text = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(path, true, Encoding.Default))
            {
                writer.WriteLine(text);
            }
            count++;
            return count;
            //}
            //return count;
        }
        static void OneFile()
        {
            Console.WriteLine("Ща все будет!");
        }
        static bool NewRecord(bool isExit)
        {
            bool rightInput = false;
            while (rightInput == false)
            {
                Console.WriteLine("Записать еще информацию? \n Введите Y - если да, N - если нет");
                char key = char.Parse(Console.ReadLine());
                if (key == 'Y')
                {
                    rightInput = true;
                    return isExit;
                }
                else if (key == 'N')
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
