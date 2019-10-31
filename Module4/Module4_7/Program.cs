using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_7
{
    enum MySort
    {
        Asc = 1,
        Desc
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas1, mas2;
            InitMas(out mas1);
            Console.WriteLine("Generated next array:");
            OutMas(mas1);
            Console.WriteLine("\n\nSort array elements in ascending order:");
            Sort(ref mas1, MySort.Asc);
            OutMas(mas1);

            InitMas(out mas2);
            Console.WriteLine("\n\nGenerated next array:");
            OutMas(mas2);
            Console.WriteLine("\n\nSort array elements in descending order:");
            Sort(ref mas2, MySort.Desc);
            OutMas(mas2);
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
                mas[i] = rdn.Next(-15, 15);
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
        static void Sort(ref int[] mas, MySort sort_order)
        {
            /*sort array in descending and ascending order*/
            int temp;
            for (int k = 0; k < mas.Length; k++)
            {
                for (int i = 0; i < mas.Length - 1; i++)
                {
                    if (sort_order == MySort.Asc)
                    {
                        if (mas[i] > mas[i + 1])
                        {
                            temp = mas[i];
                            mas[i] = mas[i + 1];
                            mas[i + 1] = temp;
                        }
                    }
                    else
                    {
                        if (mas[i] < mas[i + 1])
                        {
                            temp = mas[i];
                            mas[i] = mas[i + 1];
                            mas[i + 1] = temp;
                        }

                    }
                }
            }

        }
    }
}
