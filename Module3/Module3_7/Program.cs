using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_7
{
    class Program
    {
        static void Main(string[] args)
        {
            uint sizeOfArray;

            Console.Write("Enter size of array:");
            while (!uint.TryParse(Console.ReadLine(), out sizeOfArray) || sizeOfArray == 0)
            {
                Console.Write("The size of array should be natural! Try again! \nEnter size of array:");
            }

            /*initialization the elements of array*/
            int[] mas = new int[sizeOfArray];
            Console.WriteLine("Enter the elements of array:");
            for (int i = 0; i < sizeOfArray; i++)
            {
                Console.Write($"a[{(i + 1)}] = ");
                while (!int.TryParse(Console.ReadLine(), out mas[i]))
                {
                    Console.WriteLine("The element should be integer! Try again! \n");
                    Console.Write($"a[{(i + 1)}] = ");
                }
            }

            Console.Write("Your array:");
            foreach (int i in mas)
            {
                Console.Write($"{i} ");
            }

            Console.Write("\n\nElements of array whose previous is less than the current:");
            for (int i = 1; i < sizeOfArray; i++)
            {
                if (mas[i - 1] < mas[i])
                {
                    Console.Write($"{mas[i]} ");
                }
            }
            Console.WriteLine("\n\nPress any key...");
            Console.ReadKey();
        }
    }
}