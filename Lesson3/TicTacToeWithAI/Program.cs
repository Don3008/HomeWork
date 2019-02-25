using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeWithAI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool turnOfAI = false;
            char[,] field = new char[3, 3];
            int rows = field.GetUpperBound(0) + 1;
            int columns = field.Length / rows;
            field = CreateField();
            ShowField(field, rows, columns);
            bool marker = WhoseTurn(turnOfAI);
            bool win = false;
            int count = 0;
            while (win == false)
            {
                ShowField(field, rows, columns);
                int turnLine = TurnLine(turnOfAI);
                int turnColumn = TurnColumn(turnOfAI);
                if (field[turnLine, turnColumn] != '.')
                {
                    Console.WriteLine("Сюда уже ходить нельзя!");
                    count--;
                }
                else if (count == 8)
                {
                    Console.WriteLine("Ничья!");
                    break;
                }
                else
                {
                    turnOfAI = TurnOfAI();
                    field = InputTurn(marker, field, turnLine, turnColumn);
                    field = TurnOfAI(turnOfAI, marker, field);
                    turnOfAI = TurnOFAIFalse();
                }
                win = CheckRows(field, rows, columns, marker, win);
                win = CheckColumns(field, rows, columns, marker, win);
                win = CheckDiagonal(field, rows, columns, marker, win);
                count++;
            }
        }
        static bool CheckRows(char[,] field, int rows, int columns, bool marker, bool win)
        {
            for (int i = 0; i < rows; i++)
            {
                string check = "";
                for (int j = 0; j < columns; j++)
                {
                    check += field[i, j];
                }
                if (check == "xxx")
                {
                    Console.WriteLine("Победа крестиков!");
                    ShowField(field, rows, columns);
                    win = true;
                    break;
                }
                else if (check == "ooo")
                {
                    Console.WriteLine("Победа ноликов!");
                    ShowField(field, rows, columns);
                    win = true;
                    break;
                }
            }
            return win;
        }
        static bool CheckColumns(char[,] field, int rows, int columns, bool marker, bool win)
        {
            for (int j = 0; j < columns; j++)
            {
                string check = "";
                for (int i = 0; i < rows; i++)
                {
                    check += field[i, j];
                }
                if (check == "xxx")
                {
                    Console.WriteLine("Победа крестиков!");
                    ShowField(field, rows, columns);
                    win = true;
                    break;
                }
                else if (check == "ooo")
                {
                    Console.WriteLine("Победа ноликов!");
                    ShowField(field, rows, columns);
                    win = true;
                    break;
                }
            }
            return win;
        }
        static bool CheckDiagonal(char[,] field, int rows, int columns, bool marker, bool win)
        {
            if (((field[0, 0] & field[1, 1] & field[2, 2]) == 'x') ||
                ((field[0, 2] & field[1, 1] & field[2, 0]) == 'x'))
            {
                Console.WriteLine("Победа крестиков!");
                ShowField(field, rows, columns);
                win = true;
            }
            else if (((field[0, 0] & field[1, 1] & field[2, 2]) == 'o') ||
                    ((field[0, 2] & field[1, 1] & field[2, 0]) == 'o'))
            {
                Console.WriteLine("Победа ноликов!");
                ShowField(field, rows, columns);
                win = true;
            }
            return win;
        }
        static char[,] CreateField()
        {
            char[,] field = new char[,] { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };
            return field;
        }
        static void ShowField(char[,] field, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{field[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
        static bool WhoseTurn(bool turnOfAI)
        {

            bool marker = true;
            while (turnOfAI == false)
            {

                Console.WriteLine("Выберете, кто ходит первый. \n Если крестики - нажмите \"x\" \n Если нолики - нажмите \"o\"");
                char choise = char.Parse(Console.ReadLine());
                if (choise == 'x')
                {
                    turnOfAI = TurnOfAI();
                    marker = true;
                }
                else
                {
                    turnOfAI = TurnOfAI();
                    marker = false;
                }
            }
            return marker;
        }
        static int TurnLine(bool turnOfAI)
        {
            int turnLine = 0;
            while (turnOfAI == false)
            {
                Console.Write("Введите номер строки в которой хотите сделать ход: ");
                turnLine = int.Parse(Console.ReadLine());
                turnLine -= 1;
                turnOfAI = true;
            }
            return turnLine;
        }
        static int TurnColumn(bool turnOfAI)
        {
            int turnColumn = 0;
            while (turnOfAI == false)
            {
                Console.Write("Введите номер столбца в которой хотите сделать ход: ");
                turnColumn = int.Parse(Console.ReadLine());
                turnColumn -= 1;
                turnOfAI = true;
            }
            return turnColumn;
        }
        static bool TurnOfAI()
        {
            bool turnOfAI = true;
            return turnOfAI;
        }
        static char[,] TurnOfAI(bool turnOfAI, bool marker, char[,] field)
        {
            while (turnOfAI == true)
            {
                bool turnDone = false;
                int turnLine, turnColumn;
                Random random = new Random();
                if (marker == false)
                    marker = true;
                else
                    marker = false;

                while (turnDone == false)
                {
                    turnLine = random.Next(0, 3);
                    turnColumn = random.Next(0, 3);
                    if (marker == true && field[turnLine, turnColumn] == '.')
                    {
                        field[turnLine, turnColumn] = 'x';
                        turnDone = true;
                    }
                    else if (marker == false && field[turnLine, turnColumn] == '.')
                    {
                        field[turnLine, turnColumn] = 'o';
                        turnDone = true;
                    }
                }
                turnOfAI = TurnOFAIFalse();
            }
            return field;
        }
        static bool TurnOFAIFalse()
        {
            bool turnOfAI = false;
            return turnOfAI;
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
    }
}
