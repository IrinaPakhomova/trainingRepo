using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            uint number;
            byte digit;

            Console.Write("Enter a natural number:");
            while (!uint.TryParse(Console.ReadLine(), out number) || number == 0)
            {
                Console.Write("The number should be natural! Try again! \nEnter a natural number:");
            }

            Console.Write("\nEnter a digit which you want delete from number:");
            while (!byte.TryParse(Console.ReadLine(), out digit) || (digit > 9))
            {
                Console.Write("The digit should be from 0 to 9! Try again! \nEnter a digit which you want delete from number:");
            }

            uint poz = 1;
            uint newNumber = 0;
            uint tempNumber = number;
            while (tempNumber > 0)
            {
                if (tempNumber % 10 != digit)
                {
                    newNumber += poz * (tempNumber % 10);
                    poz *= 10;
                }
                tempNumber /= 10;
            }
            Console.WriteLine($"\nAfter deleting all the digits {digit} from {number} we got a new number: {newNumber}");
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}
