using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*first part task 8 module3*/
            double exp = 0.0001;
            double temp;

            double a = -1000;
            double b = 1000;

            Console.WriteLine("Solve the equation by dichotomy: 5*x-10 = 0\n");

            if (a > b)
            {
                temp = b;
                b = a;
                a = temp;
            }

            if (func(a) * func(b) < 0)
            {
                do
                {
                    temp = a + (b - a) / 2;
                    if (func(a) * func(temp) < 0)
                    {
                        b = temp;

                    }
                    else if (func(b) * func(temp) < 0)
                    {
                        a = temp;
                    }
                    else
                    {
                        Console.WriteLine("x = " + temp);
                        break;
                    }

                } while ((b - a) > exp);

                Console.WriteLine($" x = {(a + b) / 2}");

            }
            else if (func(a) * func(b) > 0)
            {
                Console.WriteLine("no roots in this range");
            }
            else
            {
                if (func(a) == 0)
                {
                    Console.WriteLine($" x = {a}");
                }
                else
                {
                    Console.WriteLine($" x = {b}");
                }
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        static double func(double x)
        {
            return 5 * x - 10;
        }
    }
}
