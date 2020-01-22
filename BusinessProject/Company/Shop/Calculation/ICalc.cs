using Company.Shop.Goods;
using Company.Shop.RentArea;
using Company.Shop.Workers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Shop.Calculation
{
    interface ICalc
    {
        decimal Delta(decimal expenses, decimal income);
        decimal CountIncome(decimal priceProducts, decimal procent);
        decimal TotalFixedExpenses(decimal rent, decimal salary);
        decimal TotalVariableExpenses(decimal products);
    }
}
