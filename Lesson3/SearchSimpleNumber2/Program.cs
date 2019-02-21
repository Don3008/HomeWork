using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSimpleNumber2
{
    class Program
    {
        static void Main(string[] args)
        {
            uint num = InputNumber();
            int result = CountOfNumber(num);
            Console.WriteLine($"Простое число под номером {num} является: {result}");
        }
        static uint InputNumber()
        {
            Console.Write("Введите число: ");
            uint num = uint.Parse(Console.ReadLine());
            return num;
        }
        static int CountOfNumber(uint num)
        {
            int number = 1;
            int count = 0;
            
            while (count != num)
            {
                int amountOfPrimeNumbers = 0;
                for (int i = 1; i <= number; i++)
                {
                    if (number % i == 0)
                        amountOfPrimeNumbers++;
                }
                if (amountOfPrimeNumbers == 2)
                {
                    count++;
                }
                if (count == num)
                    break;
                number++;
            }
            return number;
        }
    }
}
