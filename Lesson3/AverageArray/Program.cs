using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[10, 10];
            int rows = array.GetUpperBound(0) + 1;
            int columns = array.Length / rows;
            array = AddArray(rows, columns, array);
            SumInRows(array, rows, columns);
            Console.WriteLine("_____________________________________________");
            SumInColumns(array, rows, columns);
        }
        static int[,] AddArray(int rows, int columns, int[,] array)
        {
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = random.Next(0, 10);
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            return array;
        }
        static void SumInRows(int[,] array, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < columns; j++)
                {
                    sum += array[i, j];
                }
                Console.WriteLine($"Сумма {i + 1} строки равна: {sum}");
            }
        }
        static void SumInColumns(int[,] array, int rows, int columns)
        {
            for (int j = 0; j < columns; j++)
            {
                int sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    sum += array[i, j];
                }
                Console.WriteLine($"Сумма {j + 1} столбца равна: {sum}");
            }
        }
    }
}
