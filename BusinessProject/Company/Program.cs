using System;
using Company.Shop;
using Company.Shop.Workers;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            Business business = new Business();
            business.Start();
            business.Process();
            Console.ReadKey();
        }
    }
}
