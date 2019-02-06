using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2 //Умножение чисел через сумму
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первый множитель: ");
            int firstMultiplier = int.Parse(Console.ReadLine());
            Console.Write("Введите второй множитель: ");
            int secondMultiplier = int.Parse(Console.ReadLine());
            int absFirstMultiplier = Math.Abs(firstMultiplier);
            int i = 1;
            int composition = absFirstMultiplier;
            if (firstMultiplier != 0 && secondMultiplier != 0)
            {
                while (i < Math.Abs(secondMultiplier))
                {
                    composition += absFirstMultiplier;
                    i++;
                }
                if (firstMultiplier < 0 & secondMultiplier > 0 || firstMultiplier > 0 & secondMultiplier < 0)
                    composition = -composition;
                    Console.WriteLine($"Произведение чисел {firstMultiplier} и {secondMultiplier} равно {composition}");
            }
            else
                Console.WriteLine("Произведение равно 0");
        }
    }
}
