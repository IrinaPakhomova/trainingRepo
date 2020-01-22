using System;
using System.Collections.Generic;

namespace Company.Shop.RentArea
{
    class ServiceRent:IServiceRent
    {
        private List<Rent> rents = new List<Rent>();
        public void AddRent(Rent rent)
        {
            if (ExistRent(rent))
            {
                Console.WriteLine("Такое помещение уже есть в списке");
            }
            else
            {
                rents.Add(rent);
            }
        }
        public bool ExistRent(Rent newRent)
        {
            foreach (Rent item in rents)
            {
                if (item.Equals(newRent))
                {
                    return true;
                }
            }
            return false;
        }
        public List<Rent> getAllRent() 
        {
            return rents;
        }
        public decimal countValueAllRent() 
        {
            decimal value = 0;
            foreach (Rent item in rents) 
            {
                value += item.Price;
            }
            return value;
        }
    }
}
