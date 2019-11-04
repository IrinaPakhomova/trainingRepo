using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            uint number;
            Console.Write("Enter a natural number:");
            while (!uint.TryParse(Console.ReadLine(), out number) || (number == 0))
            {
                Console.Write("The number should be natural! Try again! \nEnter a natural number:");
            }
           
            Console.WriteLine("The first {0} natural even numbers:", number);
            for (int i = 1; i <= number; i++)
            {
                Console.Write(i * 2 + " ");
            }
            Console.WriteLine("\n\nPress any key...");
            Console.ReadKey();
        }
    }    
}