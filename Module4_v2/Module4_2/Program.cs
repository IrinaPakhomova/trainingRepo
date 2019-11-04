using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Module4_2
{
    class Program
    {

        static void Main(string[] args)
        {
            /*sum integer numbers*/
            int a = 10;
            int b = 4;
            int c = 7;
            Console.WriteLine($" Addition({a},{b}) = {Addition(a, b)}\n");
            Console.WriteLine($" Addition({a},{b},{c}) = {Addition(a, b, c)}\n");

            /*sum real numbers*/
            double d = 2.3;
            double f = 8.3;
            double e = -2.5;
            Console.WriteLine($" Addition({d},{f},{e}) = {Addition(d, f, e)}\n");

            /*concatenation strings*/
            string str1 = "Hello ";
            string str2 = "world!";
            Console.WriteLine($" Addition({str1},{str2}) = {Addition(str1, str2)}\n");

            /*sum elements of arrays*/
            int[] mas1, mas2, mas3;
            uint num1, num2;

            Console.Write("Enter the length the first array:");
            while (!uint.TryParse(Console.ReadLine(), out num1) || num1 == 0)
            {
                Console.Write("Enter the length first array:");
            }
            mas1 = new int[num1];
            InitMas(ref mas1);

            Console.Write("Enter the length the second array:");
            while (!uint.TryParse(Console.ReadLine(), out num2) || num2 == 0)
            {
                Console.Write("Enter the length first array:");
            }
            mas2 = new int[num2];
            InitMas(ref mas2);
            OutMas(mas1);
            Console.WriteLine("");
            OutMas(mas2);
            Console.WriteLine("");
            Console.WriteLine("Addition(mas1, mas2) will be:");
            mas3 = Addition(mas1, mas2);
            OutMas(mas3);
            Console.WriteLine("\n\nPress any key...");
            Console.ReadLine();
        }

        static int Addition(int a, int b)
        {
            return a + b;
        }

        static int Addition(int a, int b, int c)
        {
            return a + b + c;
        }

        static double Addition(double a, double b, double c)
        {
            return a + b + c;
        }

        static string Addition(string a, string b)
        {
            return a + b;
        }
        static int[] Addition(int[] mas1, int[] mas2)
        {
            /*sum of two arrays*/
            int[] mas3;
            if (mas1.Length > mas2.Length)
            {
                mas3 = mas1;
                for (int i = 0; i < mas2.Length; i++)
                {
                    mas3[i] = mas1[i] + mas2[i];
                }
            }
            else
            {
                mas3 = mas2;
                for (int i = 0; i < mas1.Length; i++)
                {
                    mas3[i] = mas1[i] + mas2[i];
                }
            }
            return mas3;
        }

        static void InitMas(ref int[] mas)
        {
            Random rdn = new Random();
            /*fill elements array random values*/
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rdn.Next(-5, 10);
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
