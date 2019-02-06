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
            int naturalNumber;
            Console.Write("Введите натуральное число: ");
            naturalNumber = int.Parse(Console.ReadLine());
            int sum = 0;
            while (naturalNumber > 0)
            {
                if (naturalNumber % 10 % 2 == 0)
                    sum += naturalNumber % 10;
                naturalNumber /= 10;
            }
            Console.WriteLine($"Сумма четных цифр равна {sum}");
        }
    }
}
