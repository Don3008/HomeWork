using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1 //Сумма четных цифр в натуральном числе
{
    class Program
    {
        static void Main(string[] args)
        {
            string naturalNumber;
            Console.Write("Введите натуральное число: ");
            naturalNumber = (Console.ReadLine());
            int sumOfNumeral = 0;
            foreach (char numeral in naturalNumber)
            {
                int numeralToInt = (int)Char.GetNumericValue(numeral);
                if (numeralToInt % 2 == 0)
                    sumOfNumeral += numeralToInt;
            }
            Console.WriteLine($"Сумма четных цифр в натуральном числе равна {sumOfNumeral}");
        }
    }
}
