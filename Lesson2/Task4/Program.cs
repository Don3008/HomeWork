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
            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            int result = number;
            int i = 0;
            int j = 1;
            int firstDigit = number;
            int otherDigits = number;
            int k = 2;
            while (result > 0)
            {
                result /= 10;
                i++;
            }
            firstDigit = (int)(firstDigit / (Math.Pow(10, (i - 1))));
            Console.Write(firstDigit);
            while (j != i && k <= i)
            {
                otherDigits = number;
                otherDigits = (int)(number % (Math.Pow(10, (i - j))) / (Math.Pow(10, (i - k))));
                j++;
                k++;
                Console.Write("\t" + otherDigits);
            }
            Console.WriteLine();
        }
    }
}
