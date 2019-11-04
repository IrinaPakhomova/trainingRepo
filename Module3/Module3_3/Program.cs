using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            uint number;
            Console.Write("Enter a natural number:");
            while (!uint.TryParse(Console.ReadLine(), out number) && (number == 0))
            {
                Console.Write("The number should be natural! Try again! \nEnter a natural number:");
            }

            ulong firstElem = 0, nextElem = 1;
            ulong lastElem;
            int i = 0;

            Console.Write($"The first {number} Fibonacci numbers: ");
            while (i++ < number)
            {
                Console.Write(firstElem + " ");
                lastElem = firstElem + nextElem;
                firstElem = nextElem;
                nextElem = lastElem;
            }
            Console.WriteLine("\n\nPress any key...");
            Console.ReadKey();
        }
    }
}
