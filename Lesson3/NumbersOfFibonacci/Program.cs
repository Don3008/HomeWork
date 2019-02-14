using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersOfFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите номер порядкового элемента Чисел Фибоначчи, который необходимо отобразить: ");
            uint numberFib = uint.Parse(Console.ReadLine());
            if (numberFib == 0 || numberFib == 1)

            {
                Console.WriteLine($"{numberFib}-й элемент Чисел Фибоначчи равен {numberFib}");
            }
            else
            {
                numberFib -= 1;
                FibonacciNumber(numberFib);
                uint result = FibonacciNumber(numberFib);
                Console.WriteLine($"{numberFib + 1}-й элемент Чисел Фибоначчи равен {result}");
            }
        }
        static uint FibonacciNumber(uint num)
        { 
            if (num == 0)
            {
                return 0;
            }
            else if (num == 1)
            {
                return 1;
            }
            else
            {
                return  FibonacciNumber(num - 1) + FibonacciNumber(num - 2);
            }
        }
        
    }
}
