using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 15;
            int b = -30;
            int c = 28;

            Console.WriteLine("Before execution of the method:");
            Console.WriteLine($"a = {a}; b = {b}; c = {c}");
            AddTen(ref a, ref b, ref c);
            Console.WriteLine("After execution of the method(add 10 to each element):");
            Console.WriteLine($"a = {a}; b = {b}; c = {c}");

            double radius, len, area;
            Console.Write("\nEnter radius of circle:");
            while (!double.TryParse(Console.ReadLine(), out radius) || radius < 0)
            {
                Console.Write("Try again! Enter radius of circle:");
            }
            CircleLengthAndSquare(radius, out len, out area);
            Console.WriteLine($"Circumference = {len}; Circle area = {area}");

            int[] mas1;
            int minElem, maxElem, sumOfElements;
            InitMas(out mas1);
            Console.WriteLine("\nGenerated next array:");
            OutMas(mas1);
            Console.WriteLine("\n\nFor this array found:");
            MinMaxSumInMassive(ref mas1, out minElem, out maxElem, out sumOfElements);
            Console.WriteLine($"minElement = {minElem}; maxElement = {maxElem}; sumOfElements = {sumOfElements}");
            Console.WriteLine("\n\nPress any key...");
            Console.ReadLine();
        }

        static void AddTen(ref int a, ref int b, ref int c)
        {
            a += 10;
            b += 10;
            c += 10;
        }

        static void CircleLengthAndSquare(double radius, out double s, out double p)
        {
            s = Math.PI * radius * radius;
            p = 2 * Math.PI * radius;
        }

        static void MinMaxSumInMassive(ref int[] mas, out int min, out int max, out int sum)
        {
            /*finding the maximum element, minimum element and the sum of all elements of the array*/
            min = mas[0];
            max = mas[0];
            sum = 0;
            foreach (int elem in mas)
            {
                min = min > elem ? min = elem : min;
                max = max < elem ? max = elem : max;
                sum += elem;
            }
        }

        static void InitMas(out int[] mas)
        {
            /*generate a filled array*/
            Random rdn = new Random();
            int len = rdn.Next(5, 10);
            mas = new int[len];
            for (int i = 0; i < len; i++)
            {
                mas[i] = rdn.Next(-5, 15);
            }
        }

        static void OutMas(int[] mas)
        {
            /*output the array on display*/
            foreach (int elem in mas)
            {
                Console.Write($"{elem} ");
            }
        }
    }
}
