using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5 //Перевернуть число
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            string stringNumber = Console.ReadLine();
            int lengthOfNumber = 0;
            foreach (char numeral in stringNumber)
            {
                lengthOfNumber++;
            }
            char[] arrayOfNumber = new char[lengthOfNumber];
            int i = 0;
            foreach (char numeral in stringNumber)
            {
                arrayOfNumber[i] = numeral;
                i++;
            }
            for (i = lengthOfNumber - 1; i >= 0; i--)
                Console.Write(arrayOfNumber[i]);
            Console.WriteLine();
        }
    }
}
