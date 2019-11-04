using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            int sign = 1;
            int product = 0;

            Console.Write("Enter first multiplier:");
            while (!int.TryParse(Console.ReadLine(), out num1))
            {
                Console.Write("Number should be integer! Try again! \nEnter first multiplier:");
            }

            Console.Write("Enter second multiplier:");
            while (!int.TryParse(Console.ReadLine(), out num2))
            {
                Console.Write("Number should be integer! Try again! \nEnter second multiplier:");
            }

            if ((num1 < 0) && (num2 > 0) || (num1 > 0) && (num2 < 0))
            {
                sign = -1;
            }

            int factor1 = Math.Abs(num1);
            int factor2 = Math.Abs(num2);

            if (factor1 > factor2)
            {
                for (int i = 1; i <= factor2; i++)
                {
                    product += factor1;
                }
            }
            else
            {
                for (int i = 1; i <= factor1; i++)
                {
                    product += factor2;
                }
            }
            product *= sign;
            if (num2 < 0)
            {
                Console.WriteLine($"{num1} * ({num2}) = {product}");
            }
            else
            {
                Console.WriteLine($"{num1} * {num2} = {product}");
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}

