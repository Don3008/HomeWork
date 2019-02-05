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
            string stringNumber;
            Console.Write("Введите число: ");
            stringNumber = (Console.ReadLine());
            foreach (char stringNumeral in stringNumber)
            {
                int numeral = (int)Char.GetNumericValue(stringNumeral);
                Console.Write("{0},  ", numeral);
            }
            Console.WriteLine();
        }
    }
}
