using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Module4_5
{
    enum Operation
    {
        Add = 1,
        Subtract,
        Multiply,
        Divide
    }

    enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    class Program
    {
        static void Main(string[] args)
        {
            byte month;
            double num1 = 10;
            double num2 = 5;
            Console.WriteLine($"{num1}+{num2} = {MathOperation(num1, num2, Operation.Add)}");
            Console.WriteLine($"{num1}-{num2} = {MathOperation(num1, num2, Operation.Subtract)}");
            Console.WriteLine($"{num1}*{num2} = {MathOperation(num1, num2, Operation.Multiply)}");
            if (num2 != 0)
            {
                Console.WriteLine($"{num1}/{num2} = {MathOperation(num1, num2, Operation.Divide)}");
            }
            else
            {
                Console.WriteLine("You can't divide by 0!");
            }


            Console.WriteLine("=======================================================================");
            Console.WriteLine("Do you know how much days in month? Check your skils! For exit enter letter 'N' ");

            Console.Write("Enter number of month:");
            string str = Console.ReadLine();
            while (str != "N")
            {
                if (!byte.TryParse(str, out month) || month == 0 || month > 12)
                {
                    Console.Write("There is no such month! Try again! For exit enter letter 'N' \nEnter the number of the month:");
                    str = Console.ReadLine();
                }
                else
                {
                    NumberDaysInMonth((Month)month);
                    Console.Write("\nDo you want continue? For exit enter letter 'N'\nEnter the number of the month:");
                    str = Console.ReadLine();
                }
            }
        }
        static void NumberDaysInMonth(Month m)
        {
            int factor = (int)m > 7 ? 1 : 0;
            switch (((int)m + factor) % 2)
            {
                case 1:
                    Console.WriteLine($"\nIn {m} is 31 days");
                    break;
                case 0:
                    if ((int)m == 2)
                    {
                        Console.WriteLine($"\nIn {m} is 28 days");
                    }
                    else
                    {
                        Console.WriteLine($"\nIn {m} is 30 days");
                    }
                    break;
            }
        }

        static double MathOperation(double x, double y, Operation op)
        {
            switch (op)
            {
                case Operation.Add:
                    return x + y;
                case Operation.Subtract:
                    return x - y;
                case Operation.Multiply:
                    return x * y;
                case Operation.Divide:
                    return x / y;
                default: return 0;
            }
        }
    }
}