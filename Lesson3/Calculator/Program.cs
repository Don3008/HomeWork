using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    enum Operation
    {
        Add = 1,
        Substruct,
        Multiply,
        Divide,
        Exponentiation,
        Root,
    }
    class Program
    {
        static double result;
        static void Main(string[] args)
        {
            DisplayMenu(new Operation());
            Operation operation = ChoiceFunction();
            double firstValue = InputFirstValue();
            double secondValue = InputSecondValue();
            double result = Calculation(firstValue, secondValue, operation);
            NextAct(result);
        }
        static void DisplayMenu(Operation operation)
        {
            Console.WriteLine("Выберете действие, которое хотите совершить над числами.");
            Console.WriteLine($" 1.{Operation.Add} - Сложение \n 2.{Operation.Substruct} - Вычитание \n " +
                $"3.{Operation.Multiply} - Умножение \n 4.{Operation.Divide} - Деление \n 5.{Operation.Exponentiation} - " +
                $"Возведение в степень \n 6.{Operation.Root} - Извлечение корня");
        }
        static Operation ChoiceFunction()
        {
            Operation operation;
            int input = int.Parse(Console.ReadLine());
            while (input > 6)
            {
                Console.WriteLine("Выбрана несуществующая функция!");
                input = int.Parse(Console.ReadLine());
            }
            operation = (Operation)input;
            return operation;
        }
        static double InputFirstValue()
        {
            Console.Write("Введите первое значение: ");
            double firstValue = double.Parse(Console.ReadLine());
            return firstValue;
        }
        static double InputSecondValue()
        {
            Console.Write("Введите второе значение: ");
            double secondValue = double.Parse(Console.ReadLine());
            return secondValue;
        }
        static double Calculation(double firstValue, double secondValue, Operation operation)
        {
            switch (operation)
            {
                case Operation.Add:
                    result = firstValue + secondValue;
                    break;
                case Operation.Substruct:
                    result = firstValue - secondValue;
                    break;
                case Operation.Multiply:
                    result = firstValue * secondValue;
                    break;
                case Operation.Divide:
                    if (secondValue == 0)
                    {
                        Console.WriteLine("На ноль делить нельзя!");
                        break;
                    }
                    result = firstValue / secondValue;
                    break;
                case Operation.Exponentiation:
                    result = Math.Pow(firstValue, secondValue);
                    break;
                case Operation.Root:
                    if (secondValue == 0)
                        Console.WriteLine("Степень корня не может равняться нулю!");
                    result = Math.Pow(firstValue, 1 / secondValue);
                    break;
            }
            Console.WriteLine($"Результат: {result}");
            return result;
        }
        static void NextAct(double result)
        {
            bool isExit = true;
            while (isExit)
            {
                Console.WriteLine("Выберете дальнейшее действие: \n 1. Выполнить действие с предыдущим результатом. \n" +
                    "2. Начать новый расчет. \n 3. Выход.");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        DisplayMenu(new Operation());
                        Console.WriteLine($"Предыдущий результат: {result}");
                        Operation func = ChoiceFunction();
                        Console.Write("Введите значение: ");
                        double newValue = double.Parse(Console.ReadLine());
                        result = Calculation(result, newValue, func);
                        break;
                    case 2:
                        Console.Clear();
                        DisplayMenu(new Operation());
                        Operation operation = ChoiceFunction();
                        double firstValue = InputFirstValue();
                        double secondValue = InputSecondValue();
                        Calculation(firstValue, secondValue, operation);
                        break;
                    case 3:
                        isExit = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод!");
                        break;
                }
            }
        }
    }
}
