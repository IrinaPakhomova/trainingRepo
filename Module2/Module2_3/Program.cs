using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            String num1, num2, temp;
            double number;
            bool isParse;

            Char separator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

            do
            {
                Console.Write("Enter number 1:");
                num1 = Console.ReadLine();
                isParse = double.TryParse(num1.Replace(',', separator).Replace('.', separator), out number);
                if (!isParse)
                {
                    Console.WriteLine($"{num1} isn't a number! Try again!");
                }

            } while (!isParse);


            do
            {
                Console.Write("Enter number 2:");
                num2 = Console.ReadLine();
                isParse = double.TryParse(num2.Replace(',', separator).Replace('.', separator), out number);
                if (!isParse)
                {
                    Console.WriteLine($"{num2} isn't a number! Try again!");
                }

            } while (!isParse);

            Console.WriteLine($"Befor change: n1={num1}   n2={num2}");
            temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine($"After change: n1={num1}   n2={num2}");
            Console.ReadKey();
        }
    }
}