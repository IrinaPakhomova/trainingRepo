using System;

namespace Module2_1
{
    class Program
    {
        static void Main(string[] args)
        {

            int numOfCompanies = 0;
            double tax = 0;
            double income = 0;
            bool check = false;
            Console.Write("How many companies in the country:");
            do
            {
                check = int.TryParse(Console.ReadLine(), out numOfCompanies);

                if (!check)
                {
                    Console.Write("Number of company should be integer! Try again! \nHow many companies in the country:");
                }

                if (check && (numOfCompanies < 0))
                {
                    Console.Write("Number of company should be > 0! Try again! \nHow many companies in the country:");
                }

            } while (!check || numOfCompanies < 0);

            check = false;

            Console.Write("Enter Tax(%):");
            do
            {
                check = double.TryParse(Console.ReadLine(), out tax);

                if (!check)
                {
                    Console.Write("Tax should be a number! Try again! \nEnter Tax(%):");
                }

                if (check && (tax < 0))
                {
                    Console.Write("Tax should be more than 0! Try again! \nEnter Tax(%):");
                }

            } while (!check || tax < 0);

            income = 500 * tax / 100 * numOfCompanies;
            Console.WriteLine($"\ncompanies = {numOfCompanies} , tax = {tax}% \nThe state received income: {income}$");
            Console.ReadKey();

        }
    }
}