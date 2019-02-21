using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] field = new char[3, 3];
            field = CreateField();
            ShowField(field);
            bool marker = WhoseTurn();
            bool win = false;
            int count = 0;
            while (win == false)
            {
                ShowField(field);
                int turnLine = TurnLine();
                int turnColumn = TurnColumn();
                if (field[turnLine, turnColumn] != '.')
                {
                    Console.WriteLine("Сюда уже ходить нельзя!");
                    marker = PlayerChange(marker);
                    count--;
                }
                else if (count >= 9)
                {
                    Console.WriteLine("Ничья!");
                    break;
                }
                else
                {
                    field = InputTurn(marker, field, turnLine, turnColumn);
                }
                if (((field[0, 0] & field[0, 1] & field[0, 2]) == 'x') ||
                    ((field[0, 0] & field[0, 1] & field[0, 2]) == 'o') ||
                    ((field[1, 0] & field[1, 1] & field[1, 2]) == 'x') ||
                    ((field[1, 0] & field[1, 1] & field[1, 2]) == 'o') ||
                    ((field[2, 0] & field[2, 1] & field[2, 2]) == 'x') ||
                    ((field[2, 0] & field[2, 1] & field[2, 2]) == 'o') ||
                    ((field[0, 0] & field[1, 1] & field[2, 2]) == 'x') ||
                    ((field[0, 0] & field[1, 1] & field[2, 2]) == 'o') ||
                    ((field[0, 2] & field[1, 1] & field[2, 0]) == 'x') ||
                    ((field[0, 2] & field[1, 1] & field[2, 0]) == 'o'))
                {
                    Console.WriteLine(marker ? "Победа крестиков!" : "Победа ноликов!");
                    ShowField(field);
                    win = true;
                    break;
                }
                count++;
                marker = PlayerChange(marker);
            }
        }
        static char[,] CreateField()
        {
            char[,] field = new char[,] { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };
            return field;
        }
        static void ShowField(char[,] field)
        {
            int rows = field.GetUpperBound(0) + 1;
            int columns = field.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{field[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
        static bool WhoseTurn()
        {
            bool marker;
            Console.WriteLine("Выберете, кто ходит первый. \n Если крестики - нажмите \"x\" \n Если нолики - нажмите \"o\"");
            char choise = char.Parse(Console.ReadLine());
            if (choise == 'x')
                return marker = true;
            else
                return marker = false;
        }
        static int TurnLine()
        {
            Console.Write("Введите номер строки в которой хотите сделать ход: ");
            int turnLine = int.Parse(Console.ReadLine());
            turnLine -= 1;
            return turnLine;
        }
        static int TurnColumn()
        {
            Console.Write("Введите номер столбца в которой хотите сделать ход: ");
            int turnColumn = int.Parse(Console.ReadLine());
            turnColumn -= 1;
            return turnColumn;
        }
        static char[,] InputTurn(bool marker, char[,] field, int turnLine, int turnColumn)
        {
            if (marker == true)
            {
                field[turnLine, turnColumn] = 'x';
            }
            else
            {
                field[turnLine, turnColumn] = 'o';
            }
            return field;
        }
        static bool PlayerChange(bool marker)
        {
            if (marker == true)
                marker = false;
            else
                marker = true;
            return marker;
        }
    }
}
