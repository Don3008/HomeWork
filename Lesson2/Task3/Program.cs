﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3 //Угадай число
{
    class Program
    {
        static void Main(string[] args)
        {
            int from = 0;
            int to = 5;
            Random random = new Random();
            int randomNumber = random.Next(from, to);
            bool rightEnter = false;
            int inputNumber;
            string userInput;
            while (true)
            {
                Console.Write("Введите число от \"0\" до \"5\": ");
                userInput = Console.ReadLine();
                rightEnter = int.TryParse(userInput, out inputNumber);
                if (userInput == "Выход" || userInput == "выход")
                    break;
                if (rightEnter == false)
                    Console.WriteLine("Неверный ввод!");
                else
                {
                    if (inputNumber < 0 || inputNumber > 5)
                        Console.WriteLine("Введите число в указанном промежутке!");
                    else if (inputNumber == randomNumber)
                    {
                        Console.WriteLine("Вы угадали число!");
                        break;
                    }
                    else
                        Console.WriteLine("Вы не угадали число.");
                }
            }

        }
    }
}
