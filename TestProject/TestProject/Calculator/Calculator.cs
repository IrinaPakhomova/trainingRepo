using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Calculator
{
    class Calculator<T>: ICalculator<T> //where T:struct

    {
        public void Addition(T value1, T value2)
        {
            Object tempValue1 = value1;
            Object tempValue2 = value2;
            Console.Write($"{tempValue1.ToString()} + {tempValue2.ToString()} = ");

            if (value1.GetType() == typeof(int) && value2.GetType() == typeof(int))
            {
                Console.WriteLine((int)tempValue1 + (int)tempValue2);
                return;
            }
            if (value1.GetType() == typeof(double) && value2.GetType() == typeof(double))
            {
                Console.WriteLine((double)tempValue1 + (double)tempValue2);
                return;
            }
            if (value1.GetType() == typeof(char) && value2.GetType() == typeof(char))
            {
                Console.WriteLine((char)((char)tempValue1 + (char)tempValue2));
                return;
            }
            if (value1.GetType() == typeof(string) && value2.GetType() == typeof(string))
            {
                Console.WriteLine(((string)tempValue1) + (string)tempValue2);
                return;
            }
            Console.WriteLine("Для этого типа нет реализации"); 

        }
        public void Subtraction(T value1, T value2)
        {
            Object tempValue1 = value1;
            Object tempValue2 = value2;
            Console.Write($"{tempValue1.ToString()} - {tempValue2.ToString()} = ");

            if (value1.GetType() == typeof(int) && value2.GetType() == typeof(int))
            {
                Console.WriteLine((int)tempValue1 - (int)tempValue2);
                return;
            }
            if (value1.GetType() == typeof(double) && value2.GetType() == typeof(double))
            {
                Console.WriteLine((double)tempValue1 - (double)tempValue2);
                return;
            }
            if (value1.GetType() == typeof(char) && value2.GetType() == typeof(char))
            {
                Console.WriteLine((char)(Math.Abs((char)tempValue1 - (char)tempValue2)));
                return;
            }
            if (value1.GetType() == typeof(string) && value2.GetType() == typeof(string))
            {
                string str1 = (string)tempValue1;
                string str2 = (string)tempValue2;
                for (int i = 0; i< str2.Length; i++)
                {
                    str1 = str1.Replace(str2[i].ToString(), "");
                }
                Console.WriteLine(str1);
                return;
            }
            Console.WriteLine("Для этого типа нет реализации");
        }
        public void Multiplication(T value1, T value2)
        {
            Object tempValue1 = value1;
            Object tempValue2 = value2;
            Console.Write($"{tempValue1.ToString()} * {tempValue2.ToString()} = ");

            if (value1.GetType() == typeof(int) && value2.GetType() == typeof(int))
            {
                Console.WriteLine((int)tempValue1 * (int)tempValue2);
                return;
            }
            if (value1.GetType() == typeof(double) && value2.GetType() == typeof(double))
            {
                Console.WriteLine((double)tempValue1 * (double)tempValue2);
                return;
            }
            if (value1.GetType() == typeof(char) && value2.GetType() == typeof(char))
            {
                Console.WriteLine((char)((char)tempValue1 * (char)tempValue2));
                return;
            }
            if (value1.GetType() == typeof(string) && value2.GetType() == typeof(string))
            {
                string str1 = (string)tempValue1;
                string str2 = (string)tempValue2;
                string result = "";
                int minLength = (str1.Length <= str2.Length? str1.Length : str2.Length);
                for (int i = 0; i < minLength; i++)
                {
                    result += str1[i].ToString() + str2[i].ToString();
                }
                if (str1.Length > minLength)
                {
                    result += str1.Substring(minLength);
                }
                if (str2.Length > minLength)
                {
                    result += str2.Substring(minLength);
                }
                Console.WriteLine(result);
                return;
            }
            Console.WriteLine("Для этого типа нет реализации");
        }

        public void Division(T value1, T value2)
        {
            Object tempValue1 = value1;
            Object tempValue2 = value2;

            Console.Write($"{tempValue1.ToString()} / {tempValue2.ToString()} = ");
            if (value1.GetType() == typeof(int) && value2.GetType() == typeof(int))
            {
                if ((int)tempValue2 != 0)
                {
                    Console.WriteLine((int)tempValue1 / (int)tempValue2);
                }
                else
                {
                    Console.WriteLine("На ноль делить нельзя!");
                }
                return;
            }
            if (value1.GetType() == typeof(double) && value2.GetType() == typeof(double))
            {
                if ((double)tempValue2 != 0.0)
                { 
                     Console.WriteLine((double)tempValue1 / (double)tempValue2);
                }
                else
                {
                    Console.WriteLine("на ноль делить нельзя!");
                }
                return;
            }
            if (value1.GetType() == typeof(char) && value2.GetType() == typeof(char))
            {
                if ((char)tempValue2 != 0)
                {
                    Console.WriteLine((char)((char)tempValue1 / (char)tempValue2));
                }
                else
                {
                    Console.WriteLine("На ноль делить нельзя!");
                }
                return;
            }
            if (value1.GetType() == typeof(string) && value2.GetType() == typeof(string))
            {
                string str1 = (string)tempValue1;
                string str2 = (string)tempValue2;

                if (str2.Length != 0)
                {
                    Console.WriteLine(str1.Length/str2.Length);
                }
                else
                {
                    Console.WriteLine("На ноль делить нельзя!");
                }
                return;
            }
            Console.WriteLine("Для этого типа нет реализации");
        }
    }
}
