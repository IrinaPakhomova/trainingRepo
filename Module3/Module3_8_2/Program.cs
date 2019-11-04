using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*part 2 task 8 module3*/
            int sizeOfMatrix;
           
            Console.Write("Enter size of Square matrix n:");
            while (!int.TryParse(Console.ReadLine(), out sizeOfMatrix) || sizeOfMatrix <= 0)
            {
                Console.Write("The size of array should be natural! Try again! \nEnter size of array:");
            }
            Console.WriteLine();
            int[,] array = new int[sizeOfMatrix, sizeOfMatrix];

            int stage = sizeOfMatrix / 2;

            int value = 1;

            for (int i, j, k = 1; k <= stage; k++)
            {
                /*filling horizontally to the right*/
                for (i = k - 1; i <= sizeOfMatrix - k; i++)
                {
                    array[k - 1, i] = value;
                    value++;
                }

                /*filling vertically down*/
                for (j = k; j <= sizeOfMatrix - k; j++)
                {
                    array[j, sizeOfMatrix - k] = value;
                    value++;
                }
                
                /*filling horizontally to the left*/
                for (i = sizeOfMatrix - k - 1; i >= k - 1; i--)
                {
                    array[sizeOfMatrix - k, i] = value;
                    value++;
                }
                
                /*filling vertically up*/
                for (j = sizeOfMatrix - k - 1; j >= k; j--)
                {
                    array[j, k - 1] = value;
                    value++;
                }
            }

            /*filling the last element if the number of elements is odd*/
            if (sizeOfMatrix * sizeOfMatrix % 2 == 1)
            {
                array[sizeOfMatrix / 2, sizeOfMatrix / 2] = value;
            }
           
            for (int i = 0; i < sizeOfMatrix; i++)
            {
                for (int j = 0; j < sizeOfMatrix; j++)
                {
                    Console.Write($"{array[i, j]}  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}
