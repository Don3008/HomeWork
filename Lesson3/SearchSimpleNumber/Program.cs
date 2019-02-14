using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSimpleNumber
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            uint num = InputNumber();
            int amount = CountOfSimpleNumber(num);
            if (num == 0 || num == 1)
                amount = 0;
            Console.WriteLine($"Количество простых чисел составляет {amount}");
        }
        static uint InputNumber()
        {
            Console.Write("Введите натуральное число: ");
            uint num = uint.Parse(Console.ReadLine());
            return num;
        }
        static int CountOfSimpleNumber(uint num)
        {
            int count;
            int amountOfPrimeNumbers = 0;
            for (int i = 2; i <= num; i++)
            {
                count = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        count++;
                    }
                }
                if (count == 2)
                {
                    amountOfPrimeNumbers++;
                }
            }
            return amountOfPrimeNumbers;
        }
    }
}
