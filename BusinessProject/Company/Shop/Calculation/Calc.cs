using Company.Shop.Goods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Shop.Calculation
{
    public class Calc : ICalc
    {
        public decimal Delta(decimal income, decimal expenses)
        {
            return income - expenses;
        }
        public decimal CountIncome(decimal priceProducts, decimal procent) 
        {
           return priceProducts * (1 + procent / 100);
        }
        public decimal TotalFixedExpenses(decimal rent, decimal salary)
        {
            return rent + salary;
        }
        public decimal TotalVariableExpenses(decimal products)
        {
            return products;
        }

    }
}
   
