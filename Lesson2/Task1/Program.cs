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
            while (naturalNumber != 0)
            {
                int rem;
                naturalNumber = Math.DivRem(naturalNumber, 10, out rem);
                if (rem % 2 == 0)
                sum += rem;
            }
            Console.WriteLine(sum);
        }
    }
}
