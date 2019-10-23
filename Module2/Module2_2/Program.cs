using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            bool check;
            /*initialization block*/
            Console.Write("Enter number n:");
            do
            {
                check = int.TryParse(Console.ReadLine(), out num);

                if (!check)
                {
                    Console.Write("Number should be integer! Try again! \nEnter number n:");
                }
                else if (num < 0)
                {
                    Console.Write("Age must be positive number! You can try again! \nEnter number n:");
                }

            } while (!check || num < 0);


            if (num % 2 == 0 && num > 18)
            {
                if (num > 100)
                {
                    Console.WriteLine("You were 18 years old many years ago! You are probably Duncan MacLeod");
                }
                else
                {
                    Console.WriteLine("Congratulations! You have 18 years!");
                }

            }
            else if (num % 2 == 1 && num < 18 && num > 13)
            {
                Console.WriteLine("Congratulations! You are in the secondary school!");
            }
            else
            {
                Console.WriteLine("Sorry! Actions aren't defined for your n.");
            }

            Console.ReadKey();
        }
    }
}