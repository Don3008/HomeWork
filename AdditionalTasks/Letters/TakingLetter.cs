using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letters
{
    class TakingLetter
    {
        public static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            while (true)
            {
                Letter[] letters = new Letter[20];
                Console.WriteLine("Выберете имя:");
                int i = 1;
                foreach (var adr in Enum.GetValues(typeof(Addresses)))
                {
                    Console.WriteLine(i + " - " + adr);
                    i++;
                }
                string name = "";
                name = ChooseName();
                Person person = new Person(name);
                for (int j = 0; j < letters.Length; j++)
                {
                    letters[j] = new Letter();
                    Console.WriteLine("Письмо №" + (j + 1));
                    bool done;
                    done = person.TakeLetter(letters[j]);
                    if (done)
                    {
                        done = person.OpenLetter();
                        if (done)
                        {
                            person.ReadLetter();
                        }
                        else
                        {
                            Console.WriteLine("Откладываем в сторону...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Следующее письмо...");
                    }
                }
                Console.WriteLine("Начать заново? Y - Да, Любая клавиша - нет");
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    continue;
                }
                else
                {
                    break;
                }
            } 
        }

        static string ChooseName()
        {
            string name = string.Empty;
            Addresses adr;
            int input = int.Parse(Console.ReadLine());
            adr = (Addresses)input;
            switch (adr)
            {
                case Addresses.Igor:
                    name = Addresses.Igor.ToString();
                    break;
                case Addresses.Ivan:
                    name = Addresses.Ivan.ToString();
                    break;
                case Addresses.Michael:
                    name = Addresses.Michael.ToString();
                    break;
                case Addresses.Dmitriy:
                    name = Addresses.Dmitriy.ToString();
                    break;
                case Addresses.Pavel:
                    name = Addresses.Pavel.ToString();
                    break;
                case Addresses.Alex:
                    name = Addresses.Alex.ToString();
                    break;
                default:
                    Console.WriteLine("Несуществующее имя!");
                    break;
            }
            return name;
        }
    }
}
