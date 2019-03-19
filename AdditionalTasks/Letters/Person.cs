using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letters
{
    class Person
    {
        private bool done = false;

        public string Name { get; private set; }
        public Letter letter { get; private set; }

        public Person(string name)
        {
            Name = name;
        }

        public bool TakeLetter(Letter letter)
        {
            if (Name.Equals(letter.AddressedTo))
            {
                this.letter = letter;
                ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
                bool isExit = false;
                Console.WriteLine("Вы хотите взять письмо? Нажмите: Y - Да или N - нет");
                while (!isExit)
                {
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Y)
                    {
                        isExit = true;
                        done = true;
                    }
                    else if (keyInfo.Key == ConsoleKey.N)
                    {
                        Console.WriteLine("...");
                        isExit = true;
                        done = false;
                    }
                    else
                    {
                        isExit = false;
                    }
                }
                return done;
            }
            else
            {
                Console.WriteLine("Не тот адресат");
                return done = false;
            }
        }

        public bool OpenLetter()
        {
            if (!CheckExistsLetter())
            {
                return done;
            }
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            bool isExit = false;
            Console.WriteLine("Вы хотите открыть письмо? Нажмите: Y - Да или N - нет");
            while (!isExit)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    letter.Open();
                    isExit = true;
                    done = true;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("...");
                    isExit = true;
                    done = false;
                }
                else
                {
                    isExit = false;
                }
            }
            return done;
        }

        public void ReadLetter()
        {
            if (!CheckExistsLetter())
            {
                return;
            }
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            bool isExit = false;
            Console.WriteLine("Вы хотите прочитать письмо? Нажмите: Y - Да или N - нет");
            while (!isExit)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    letter.Read();
                    isExit = true;
                    Console.WriteLine("Текст письма: \n " + letter.Read());
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("...");
                    Console.WriteLine("Откладываем в сторону...");
                    isExit = true;
                }
                else
                {
                    isExit = false;
                }
            }
        }

        private bool CheckExistsLetter()
        {
            if (letter == null)
            {
                Console.WriteLine("У меня нет письма");
                return false;
            }
            return true;
        }
    }
}
