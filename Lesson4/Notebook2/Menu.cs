using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook2
{
    class Menu
    {
        public bool Repeat { get; private set; }

        public static void Main(string[] args)
        {
            string path = @"C:\Users\don30\source\repos\HomeWork\Notebook2\Notes\";
            bool isExit = false;
            int count = 0;
            while (!isExit)
            {
                
                Notes note = new Notes(path);
                
                string text = InputText();
                isExit = NewNote(text, path, isExit, note, count);
                
            }
            
        }



        public static bool NewNote(string text, string path, bool isExit, Notes note, int count)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            Console.WriteLine("Хотите создать еще одну заметку? \n Нажмите Y, если да, N - если нет");
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Y)
            {
                count = Counter(count);
                note.Write(text);
            }
            else if (key.Key == ConsoleKey.N)
            {
                isExit = true;
            }
            else
            {
                Console.WriteLine("Неверный ввод!");
            }
            return isExit;
        }

        static int Counter(int count)
        {
            count++;
            return count;
        }

        public static string InputText()
        {
            Console.WriteLine("Введите информацию, которую хотите сохранить.");
            string text = Console.ReadLine();
            return text;
        }
    }

}

