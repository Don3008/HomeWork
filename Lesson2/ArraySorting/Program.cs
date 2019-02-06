using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива: ");
            int len = int.Parse(Console.ReadLine());
            int[] arr = new int[len];
            int sym;
            Console.WriteLine("Введити целочисленные элементы массива.");
            for (int i = 0; i < len; i++)
            {
                Console.Write($"Введите {i + 1}-ый элемент массива: ");
                sym = int.Parse(Console.ReadLine());
                arr[i] = sym;
            }
            int k;

            for (int j = 0; j < arr.Length; j++)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        k = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = k;
                    }
                }
            }
            foreach (int elem in arr)
            {
                Console.Write("{0} ", elem);
            }
            Console.WriteLine();

        }
    }
}
