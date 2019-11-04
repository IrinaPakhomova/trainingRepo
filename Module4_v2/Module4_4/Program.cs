using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            (int a, int b, int c) tuple = (a: 15, b: -30, c: 28);
            Console.WriteLine("Before execution of the method:");
            Console.WriteLine($"a = {tuple.a}; b = {tuple.b}; c = {tuple.c}");
            AddNumber(ref tuple, 10);
            Console.WriteLine("After execution of the method(add 10 to each element):");
            Console.WriteLine($"a = {tuple.a}; b = {tuple.b}; c = {tuple.c}");

            double radius;
            Console.Write("\nEnter radius of circle:");
            while (!double.TryParse(Console.ReadLine(), out radius) || radius < 0)
            {
                Console.Write("Try again! Enter radius of circle:");
            }
            var tupleCircle = CircleLengthAndSquare(radius);
            Console.WriteLine($"Circumference = {tupleCircle.lenght}; Circle area = {tupleCircle.area}");

            int[] mas1;
            InitMas(out mas1);
            Console.WriteLine("\nGenerated next array:");
            OutMas(mas1);
            Console.WriteLine("\n\nFor this array found:");
            var tupleMas = MinMaxSumInMassive(mas1);
            Console.WriteLine($"maxElement = {tupleMas.max};  minElement = {tupleMas.min}; sumOfElements = {tupleMas.sum}");
            Console.WriteLine("\n\nPress any key...");
            Console.ReadLine();
        }

        static void AddNumber(ref (int a, int b, int c) tuple, int number)
        {
            tuple.a += number;
            tuple.b += number;
            tuple.c += number;
        }

        static (double lenght, double area) CircleLengthAndSquare(double radius)
        {
            (double lenght, double area) result;
            result.lenght = Math.PI * radius * radius;
            result.area = 2 * Math.PI * radius;
            return result;
        }

        static (int max, int min, int sum) MinMaxSumInMassive(int[] mas)
        {
            /*finding the maximum element, minimum element and the sum of all elements of the array*/
            (int max, int min, int sum) tuple;
            tuple.min = mas[0];
            tuple.max = mas[0];
            tuple.sum = 0;
            foreach (int elem in mas)
            {
                tuple.min = tuple.min > elem ? tuple.min = elem : tuple.min;
                tuple.max = tuple.max < elem ? tuple.max = elem : tuple.max;
                tuple.sum += elem;
            }
            return tuple;
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
