using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letters
{
    class Person
    {
        private bool isConfirmed = false;

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
                ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
                bool isExit = false;
                Console.WriteLine("Взять письмо? Нажмите: Y - Да или N - нет");
                while (!isExit)
                {
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Y)
                    {
                        this.letter = letter;
                        isExit = true;
                        isConfirmed = true;
                    }
                    else if (keyInfo.Key == ConsoleKey.N)
                    {
                        Console.WriteLine("...");
                        isExit = true;
                        isConfirmed = false;
                    }
                    else
                    {
                        isExit = false;
                    }
                }
                return isConfirmed;
            }
            else
            {
                Console.WriteLine("Не тот адресат");
                return isConfirmed = false;
            }
        }

        public bool OpenLetter()
        {
            if (!CheckExistsLetter())
            {
                return isConfirmed;
            }
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            bool isExit = false;
            Console.WriteLine("Открыть письмо? Нажмите: Y - Да или N - нет");
            while (!isExit)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    letter.Open();
                    isExit = true;
                    isConfirmed = true;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("...");
                    isExit = true;
                    isConfirmed = false;
                }
                else
                {
                    isExit = false;
                }
            }
            return isConfirmed;
        }

        public void ReadLetter()
        {
            if (!CheckExistsLetter())
            {
                return;
            }
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            bool isExit = false;
            Console.WriteLine("Прочитать письмо? Нажмите: Y - Да или N - нет");
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
