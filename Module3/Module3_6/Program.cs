using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_6
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
            Console.WriteLine("\nThe values of the elements of the array will generate randomly.");
            Console.WriteLine("\nArray before changing:");
            int[] mas = new int[sizeOfArray];
            Random rnd = new Random();
            for (int i = 0; i < sizeOfArray; i++)
            {
                mas[i] = rnd.Next(-100, 100);
                Console.Write(mas[i] + " ");
            }

            Console.WriteLine("\n\nArray after changing the sign of the elements:");
            for (int i = 0; i < sizeOfArray; i++)
            {
                mas[i] *= -1;
                Console.Write(mas[i] + " ");
            }

            Console.WriteLine("\n\nPress any key...");
            Console.ReadKey();
        }
    }
}
