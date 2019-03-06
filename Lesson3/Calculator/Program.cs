using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

    enum ChoiseAct
    {
        ContinueCalculation = 1,
        NewCalculation,
        OutputValue,
        Exit
    }

    class Program
    {
        static double result;
        static void Main(string[] args)
        {
            string path = @"result.txt";
            DisplayMenu();
            Operation operation = ChoiceFunction();
            double firstValue = InputValue("Введите первое значение: ");
            double secondValue = InputValue("Введите второе значение: ");
            double result = Calculation(firstValue, secondValue, operation);
            ChoiseAct choiseAct = new ChoiseAct();
            NextAct(result, path, choiseAct);
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Выберете действие, которое хотите совершить над числами.");
            Console.WriteLine($" {(int)Operation.Add} - Сложение \n {(int)Operation.Substruct} - Вычитание \n " +
                $"{(int)Operation.Multiply} - Умножение \n {(int)Operation.Divide} - Деление \n {(int)Operation.Exponentiation} - " + $"Возведение в степень \n {(int)Operation.Root} - Извлечение корня");
        }

        static Operation ChoiceFunction()
        {
            Operation operation;
            int input = int.Parse(Console.ReadLine());
            while (input > Enum.GetNames(typeof(Operation)).Length + 1)
            {
                Console.WriteLine("Выбрана несуществующая функция!");
                input = int.Parse(Console.ReadLine());
            }
            operation = (Operation)input;
            return operation;
        }

        static double InputValue(string message)
        {
            Console.Write(message);
            double value = double.Parse(Console.ReadLine());
            return value;
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
                    }
                    else
                    {
                        result = firstValue / secondValue;
                    }
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

        static void Write(string path, double newValue)
        {
            File.Create(path);
            using (StreamWriter writer = new StreamWriter(path, true, Encoding.Default))
            {
                writer.WriteLine(newValue);
            }
        }

        static void Read(string path, int position)
        {
            using (StreamReader reader = new StreamReader(path, Encoding.Default))
            {
                string line;
                for (int i = 1; i < position; i++)
                {
                    reader.ReadLine();
                }
                line = reader.ReadLine();
                Console.WriteLine("Переменная: " + line);
            }
        }
       
        static void NextAct(double result, string path, ChoiseAct choiseAct)
        {
            bool isExit = true;
            while (isExit)
            {
                Console.WriteLine($"Выберете дальнейшее действие: \n {(int)ChoiseAct.ContinueCalculation}. Выполнить действие с предыдущим результатом. \n" +
                    $" {(int)ChoiseAct.NewCalculation}. Начать новый расчет. \n {(int)ChoiseAct.OutputValue}. Введите номер промежуточной переменной, которую хотите вывести на экран. \n {(int)ChoiseAct.Exit}. Выход.");
                int input = int.Parse(Console.ReadLine());
                choiseAct = (ChoiseAct)input;
                switch (choiseAct)
                {
                    case ChoiseAct.ContinueCalculation:
                        Console.Clear();
                        DisplayMenu();
                        Console.WriteLine($"Предыдущий результат: {result}");
                        Operation func = ChoiceFunction();
                        double newValue = InputValue("Введите значение: ");
                        Write(path, newValue);

                        result = Calculation(result, newValue, func);
                        break;
                    case ChoiseAct.NewCalculation:
                        Delete(path);
                        Console.Clear();
                        DisplayMenu();
                        Operation operation = ChoiceFunction();
                        double firstValue = InputValue("Введите первое значение: ");
                        double secondValue = InputValue("Введите второе значение: ");
                        Calculation(firstValue, secondValue, operation);
                        break;
                    case ChoiseAct.OutputValue:
                        Console.Write("Введите номер позиции переменной, которую хотите вывести: ");
                        int position = int.Parse(Console.ReadLine());
                        Read(path, position);
                        break;
                    case ChoiseAct.Exit:
                        isExit = false;
                        Delete(path);
                        break;
                    default:
                        Console.WriteLine("Неверный ввод!");
                        break;
                }
            }
        }

        static void Delete(string path)
        {
            File.Delete(path);
        }
    }
}
