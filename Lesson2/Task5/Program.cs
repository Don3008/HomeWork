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
            int num;
            Console.Write("Введите число: ");
             num = int.Parse(Console.ReadLine());
            Console.Write(num % 10);
            while ((num /= 10) != 0)
                Console.Write(num % 10);
            Console.WriteLine();
        }
    }
}
