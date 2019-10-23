using System;

namespace Module1_1
{
    class Program
    {
        /*
            program is swapped the value of two variables
         */

        static void Main(string[] args)
        {
            var a = 1;
            var b = 2;
            Console.Write("(a = {0}, b = {1} -> ", a, b);
            var с = a;
            a = b;
            b = с;
            Console.Write("a = {0}, b = {1})", a, b);
            Console.ReadKey();
        }
    }
}
