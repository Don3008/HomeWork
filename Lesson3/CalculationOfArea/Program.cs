using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationOfArea
{
    enum Figure
    {
        Circle = 1,
        Triangle,
        Rectangle,
        Polygon,
        Trapezium,
        Exit
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = true;
            while (isExit)
            {
                Figure figure = ChoiceOfFigure();
                Calculation(figure);
                isExit = Exit();
            }
        }
        static Figure ChoiceOfFigure()
        {
            Figure figure;
            Console.WriteLine("Расчет площади различных фигур.");
            Console.WriteLine($"Выберете фигуру: \n 1.{Figure.Circle} - круг \n 2.{Figure.Triangle} - треугольник" +
                $"\n 3.{Figure.Rectangle} - прямоугольник \n 4.{Figure.Polygon} - многоугольник \n 5.{Figure.Trapezium} - трапеция");
            int input = int.Parse(Console.ReadLine());
            figure = (Figure)input;
            return figure;
        }
        static void Calculation(Figure figure)
        {
            switch (figure)
            {
                case Figure.Circle:
                    Console.Write("Введите радиус: ");
                    double radius = double.Parse(Console.ReadLine());
                    double squareCircle = Math.PI * radius * radius;
                    Console.WriteLine($"Площадь круга равна {squareCircle}");
                    break;
                case Figure.Triangle:
                    Console.WriteLine("Если известно три стороны треугольника - нажмите \"1\" \n" +
                        "Если известна высота треугольника и основание - нажмите \"2\" \n" +
                        "Если треугольник прямоугольный и известны его катеты - нажмите 3");
                    int whichIsTriangle = int.Parse(Console.ReadLine());
                    switch (whichIsTriangle)
                    {
                        case 1:
                            Console.Write("Введите сторону a: ");
                            double aSide = double.Parse(Console.ReadLine());
                            Console.Write("Введите сторону b: ");
                            double bSide = double.Parse(Console.ReadLine());
                            Console.Write("Введите сторону c: ");
                            double cSide = double.Parse(Console.ReadLine());
                            double p = (aSide + bSide + cSide) / 2;
                            if ((p * (p - aSide) * (p - bSide) * (p - cSide)) == 0)
                            {
                                Console.WriteLine("Стороны треугольника введены неверно!");

                            }
                            else
                            {
                                double squareTriangle1 = Math.Pow((p * (p - aSide) * (p - bSide) * (p - cSide)), (0.5));
                                Console.WriteLine($"Площадь треугольника равна {squareTriangle1}");
                            }
                            break;
                        case 2:
                            Console.Write("Введите основание треугольника: ");
                            double baseTriangle = double.Parse(Console.ReadLine());
                            Console.Write("Введите высоту треугольника: ");
                            double heightTriangle = double.Parse(Console.ReadLine());
                            double squareTriangle2 = baseTriangle * heightTriangle / 2;
                            Console.WriteLine($"Площадь треугольника равна {squareTriangle2}");
                            break;
                        case 3:
                            Console.Write("Введите катет a: ");
                            double aLeg = double.Parse(Console.ReadLine());
                            Console.Write("Введите катет b: ");
                            double bLeg = double.Parse(Console.ReadLine());
                            double squareTriangle3 = aLeg * bLeg / 2;
                            Console.WriteLine($"Площадь треугольника равна {squareTriangle3}");
                            break;

                        default:
                            Console.WriteLine("Неверное значение!");
                            break;
                    }
                    break;
                case Figure.Rectangle:
                    Console.Write("Введите сторону a: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("Введите сторону b: ");
                    double b = double.Parse(Console.ReadLine());
                    double squareRectangle = a * b;
                    Console.WriteLine($"Площадь прямоугольника равна {squareRectangle}");
                    break;
                case Figure.Polygon:
                    Console.Write("Введите апофему: ");
                    double apothem = double.Parse(Console.ReadLine());
                    Console.Write("Введите количество сторон: ");
                    double numberOfSides = double.Parse(Console.ReadLine());
                    Console.Write("Введите длину стороны: ");
                    double lengthOfSide = double.Parse(Console.ReadLine());
                    double squarePolygon = numberOfSides * lengthOfSide * apothem / 2;
                    Console.WriteLine($"Площадь многоугольника равна {squarePolygon}");
                    break;
                case Figure.Trapezium:
                    Console.Write("Введите высоту: ");
                    double height = double.Parse(Console.ReadLine());
                    Console.Write("Введите основание a: ");
                    double firstBase = double.Parse(Console.ReadLine());
                    Console.Write("Введите основание b: ");
                    double secondBase = double.Parse(Console.ReadLine());
                    double squareTrapezium = (firstBase + secondBase) * height / 2;
                    Console.WriteLine($"Площадь трапеции равна {squareTrapezium}");
                    break;
            }
        }
        static bool Exit()
        {
            Console.WriteLine("Если хотите выйти - нажмите 0, если начать новый расчет - любую цифру");
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
            {
                bool isExit = false;
                return isExit;
            }
            else
            {
                Console.Clear();
                bool isExit = true;
                return isExit;
            }
        }
    }
}
