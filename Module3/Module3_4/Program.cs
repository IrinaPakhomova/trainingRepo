using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string number;
            int numInt;
            decimal numDouble;
            bool checkInt, checkDouble;

            Console.Write("Please, enter a number > 0:");
            number = Console.ReadLine();

            checkInt = int.TryParse(number, out numInt);
            checkDouble = decimal.TryParse(number, out numDouble);

            if (checkDouble && numDouble < 0)
            {
                Console.WriteLine("Data is not correct!");
            }
            else
            {
                if (checkInt)
                {
                    Console.WriteLine("New number is " + reverseInt(numInt));
                }
                else 
                {
                    Console.WriteLine("New number is " + reverseDouble(numDouble));
                }
            }
            Console.ReadKey();
        }

        static long reverseInt(long numInt)
        {
            long numIntVerse = 0;
            while (numInt > 0)
            {
                numIntVerse *= 10;
                numIntVerse += numInt % 10;
                numInt = numInt / 10;
            }

            return numIntVerse;
        }
      
        static decimal reverseDouble(decimal numDouble)
          {
            int countReal = 0;
            long poz = 1;
            long num;
            decimal check;
            
            do
            {
                poz *= 10;
                num = (long)(numDouble * poz);
                check = numDouble * poz - (decimal)num;
                countReal++;
            }
            while (check > 0);

            long tempNum = num;
            int countAll = 0;
            while (tempNum > 0) {
                tempNum /= 10;
                countAll++;
            }
            //reverse number
            tempNum = reverseInt(num);

            int count = countAll - countReal;
            numDouble = (decimal)tempNum;
            while (count > 0)
            {
                numDouble /= 10;
                count--;
            }

            return numDouble;
        }
    }
}
