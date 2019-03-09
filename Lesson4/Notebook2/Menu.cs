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
            string path = @"C:\Users\don30\source\repos\HomeWork\Notebook2\";
            bool isExit = false;
            //int count = 0;
            while (!isExit)
            {
                
                Note note = new Note(path);
                
                string text = InputText();
                isExit = NewNote(text, path, isExit, note);
                
            }
            
        }



        public static bool NewNote(string text, string path, bool isExit, Note note)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            Console.WriteLine("Хотите создать еще одну заметку? \n Нажмите Y, если да, N - если нет");
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Y)
            {
                
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

        public static string InputText()
        {
            Console.WriteLine("Введите информацию, которую хотите сохранить.");
            string text = Console.ReadLine();
            return text;
        }
    }

}

