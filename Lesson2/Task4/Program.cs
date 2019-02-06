using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4 //Из каких цифр состоит число
{
    class Program
    {
        static void Main(string[] args)
        {
            string number;
            Console.Write("Введите число: ");
            number = Console.ReadLine();
            foreach (char numeral in number)
            {
                int num = (int)Char.GetNumericValue(numeral);
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
        }
    }
}
