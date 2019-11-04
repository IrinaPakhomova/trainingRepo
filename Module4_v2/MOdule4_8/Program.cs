using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_8
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = -10;
            double b = 10;
            double eps = 0.001;

            Console.WriteLine($"Solution of the equation x * 5 - 16 = 0 by the dichotomy method \non the segment [{a};{b}] with precision {eps}");
            Console.WriteLine($"\nx = {Dihotomia(a, b, eps)}");
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
        static double Func(double x)
        {
            return x * 5 - 16;
        }

        static double Dihotomia(double a, double b, double eps)
        {
            double c = (a + b) / 2;
            if (Math.Abs(Func(a) - Func(b)) <= eps)
            {
                return (a + b) / 2;
            }
            if (Func(a) * Func(c) < 0)
            {
                return Dihotomia(a, c, eps);
            }
            else
            {
                return Dihotomia(b, c, eps);
            }
        }
    }
}
