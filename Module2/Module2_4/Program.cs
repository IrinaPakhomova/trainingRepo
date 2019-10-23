using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int typeOfShape = 0;
            string figureAction;
            double radius;
            double rectWidht, rectHight;
            double triangSide1, triangSide2, triangSide3;
            double S, P;

            Console.Write("Choose for which shape you want to calculate the area or perimeter. \nPlease enter the number of shape (triangle - 1, rectangle - 2, circle - 3):");
            if (!int.TryParse(Console.ReadLine(), out typeOfShape))
            {
                Exit();
                return;
            }

            Console.Write("What would you like calculation: Square(S) or Perimere(P).  \nPlease enter symbol S or P:");
            figureAction = Console.ReadLine();

            if (string.Compare(figureAction, "S") != 0 && string.Compare(figureAction, "P") != 0)
            {
                Console.WriteLine("Invalid action!");
                Console.ReadKey();
                return;
            }

            switch (typeOfShape)
            {
                case 1: //triangle

                    Console.Write("Enter the value of the first side of the Triangle:");
                    if (!double.TryParse(Console.ReadLine(), out triangSide1))
                    {
                        Exit();
                        return;
                    }

                    if (triangSide1 < 0)
                    {
                        InvalidValue();
                        return;
                    }

                    Console.Write("Enter the value of the second side of the Triangle:");
                    if (!double.TryParse(Console.ReadLine(), out triangSide2))
                    {
                        Exit();
                        return;
                    }

                    if (triangSide2 < 0)
                    {
                        InvalidValue();
                        return;
                    }

                    Console.Write("Enter the value of the third side of the Triangle:");
                    if (!double.TryParse(Console.ReadLine(), out triangSide3))
                    {
                        Exit();
                        return;
                    }

                    if (triangSide3 < 0)
                    {
                        InvalidValue();
                        return;
                    }

                    P = triangSide1 + triangSide2 + triangSide3;

                    if (string.Compare(figureAction, "S") == 0)
                    {
                        double p = P / 2;
                        S = Math.Sqrt(p * (p - triangSide1) * (p - triangSide2) * (p - triangSide3));
                        Console.WriteLine($"S = {S}");
                        Console.WriteLine($"Such an area for a Square with a side: {SideOfFoursquare(0, S)}");
                        Console.WriteLine($"Such an area for a Circle with a radius: {RadiusOfCircle(0, S)}");
                    }
                    else
                    {
                        Console.WriteLine($"P = {P}");
                        Console.WriteLine($"Such a perimeter for a Square with a side: {SideOfFoursquare(P, 0)}");
                        Console.WriteLine($"Such a perimeter for a Circle with a radius: {RadiusOfCircle(P, 0)}");
                    }
                    break;

                case 2: //Rectangle

                    Console.Write("Enter the value of the Widht of the Rectangle:");
                    if (!double.TryParse(Console.ReadLine(), out rectWidht))
                    {
                        Exit();
                        return;
                    }

                    if (rectWidht < 0)
                    {
                        InvalidValue();
                        return;
                    }

                    Console.Write("Enter the value of the Hight of the Rectangle:");
                    if (!double.TryParse(Console.ReadLine(), out rectHight))
                    {
                        Exit();
                        return;
                    }

                    if (rectHight < 0)
                    {
                        InvalidValue();
                        return;
                    }

                    if (string.Compare(figureAction, "S") == 0)
                    {
                        S = rectWidht * rectHight;
                        Console.WriteLine($"S = {S}");
                        Console.WriteLine($"Such an area for a Equilateral Triangle with a side: {SideOfEquilateralTriangle(0, S)}");
                        Console.WriteLine($"Such an area for a Circle with a radius: {RadiusOfCircle(0, S)}");
                    }
                    else
                    {
                        P = 2 * (rectWidht + rectHight);
                        Console.WriteLine($"P = {P}");
                        Console.WriteLine($"Such a perimeter for a Equilateral Triangle with a side: {SideOfEquilateralTriangle(P, 0)}");
                        Console.WriteLine($"Such a perimeter for a Circle with a radius: {RadiusOfCircle(P, 0)}");
                    }
                    break;

                case 3: //circle 

                    Console.Write("Enter the value of the Radius of the Circle:");
                    if (!double.TryParse(Console.ReadLine(), out radius))
                    {
                        Exit();
                        return;
                    }

                    if (radius < 0)
                    {
                        InvalidValue();
                        return;
                    }

                    if (string.Compare(figureAction, "S") == 0)
                    {
                        S = Math.PI * radius * radius;
                        Console.WriteLine($"S = {S}");
                        Console.WriteLine($"Such an area for a Square with a side: {SideOfFoursquare(0, S)}");
                        Console.WriteLine($"Such an area for a Equilateral Triangle with a side: {SideOfEquilateralTriangle(0, S)}");
                    }
                    else
                    {
                        P = 2 * Math.PI * radius;
                        Console.WriteLine($"L = {P}");
                        Console.WriteLine($"Such a perimeter for a Square with a side: {SideOfFoursquare(P, 0)}");
                        Console.WriteLine($"Such a perimeter for a Equilateral Triangle with a side: {SideOfEquilateralTriangle(P, 0)}");
                    }
                    break;

                default:
                    Console.WriteLine("Your area don't exist!");
                    break;
            }

            Console.ReadKey();
        }

        static double SideOfFoursquare(double perimetr, double square)
        {
            if (perimetr != 0)
            {
                return perimetr / 4;
            }
            else
            {
                return Math.Sqrt(square);
            }
        }

        static double SideOfEquilateralTriangle(double perimetr, double square)
        {
            if (perimetr != 0)
            {
                return perimetr / 3;
            }
            else
            {
                return Math.Sqrt(4 * square / Math.Sqrt(3));
            }
        }

        static double RadiusOfCircle(double perimetr, double square)
        {
            if (perimetr != 0)
            {
                return perimetr / (2 * Math.PI);
            }
            else
            {
                return Math.Sqrt(square / Math.PI);
            }
        }

        static void Exit()
        {
            Console.WriteLine("Value is not correct! Program terminated abnormally");
            Console.ReadKey();
        }
        static void InvalidValue()
        {
            Console.WriteLine("Value must  be  positive number!");
            Console.ReadKey();
        }
    }
}