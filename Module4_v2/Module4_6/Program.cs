using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas1;

            InitMas(out mas1);
            Console.WriteLine("Generated next array:");
            OutMas(mas1);

            Console.WriteLine("\n\nAfter adding the number 5 to the elements of the array, array is:");
            AddNumberToElemntsMas(ref mas1, 5);
            OutMas(mas1);

            Console.WriteLine("\n\nPress any key...");
            Console.ReadKey();
        }
        static void InitMas(out int[] mas)
        {
            /*generate a filled array*/
            Random rdn = new Random();
            int len = rdn.Next(5, 10);
            mas = new int[len];
            for (int i = 0; i < len; i++)
            {
                mas[i] = rdn.Next(-5, 15);
            }
        }
        static void OutMas(int[] mas)
        {
            /*output the array on display*/
            foreach (int elem in mas)
            {
                Console.Write($"{elem} ");
            }
        }
        static void AddNumberToElemntsMas(ref int[] mas, int num)
        {
            /*add the number num to array elements*/
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] += num;
            }
        }
    }
}
