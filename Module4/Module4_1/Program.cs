using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myMas;
            uint num;

            Console.Write("Enter the number of elements:");
            while (!uint.TryParse(Console.ReadLine(), out num) || num == 0)
            {
                Console.Write("Enter the number of elements:");
            }

            myMas = new int[num];
            InitMas(ref myMas);

            Console.WriteLine("\nThe following array was automatically generated:");
            OutMas(myMas);

            Console.WriteLine($"\n\nThe maximum element in the array: {MaxElementInArray(myMas)}");
            Console.WriteLine($"\nThe minimum element in the array: {MinElementInArray(myMas)}");
            Console.WriteLine($"\nDifference between the maximum and the minimum elements in the array: {DiffBitweenMaxAndMin(myMas)}");


            Console.WriteLine($"\nSum of array elements: {SumAllElementsInArray(myMas)}");
            Console.WriteLine("\nDo operations with array elements");
            Console.WriteLine("(add the maximum element to the even ones, subtract the minimum element from the odd ones):\n");
            Operation(ref myMas);
            OutMas(myMas);

            Console.WriteLine("\n\nPress any key...");
            Console.ReadKey();
        }

        static void InitMas(ref int[] mas)
        {
            /*fill  elements array random values*/
            Random rdn = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rdn.Next(-10, 10);
            }
        }

        static void OutMas(int[] mas)
        {
            /*output on display*/
            foreach (int elem in mas)
            {
                Console.Write($"{elem} ");
            }
        }

        static int MaxElementInArray(int[] mas)
        {
            /*finding the maximum element*/
            int max = mas[0];
            foreach (int x in mas)
            {
                if (max < x)
                {
                    max = x;
                }
            }
            return max;
        }

        static int MinElementInArray(int[] mas)
        {
            /* finding the minimum element*/
            int min = mas[0];
            foreach (int x in mas)
            {
                if (min > x)
                {
                    min = x;
                }
            }
            return min;
        }

        static int SumAllElementsInArray(int[] mas)
        {
            /*the sum of all elements of the array*/
            int sum = 0;
            foreach (int x in mas)
            {
                sum += x;
            }
            return sum;
        }

        static int DiffBitweenMaxAndMin(int[] mas)
        {
            /*Difference between the maximum and the minimum elements in the array*/
            return MaxElementInArray(mas) - MinElementInArray(mas);
        }

        static void Operation(ref int[] mas)
        {
            int max = MaxElementInArray(mas);
            int min = MinElementInArray(mas);
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] % 2 == 0)
                {
                    mas[i] += max;
                }
                else
                {
                    mas[i] -= min;
                }
            }
        }
    }
}