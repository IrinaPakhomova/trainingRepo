using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib
{
   public class AnaliseServices
    {
       public static decimal AnalyseFinancialCondition()
        {
            decimal money = 0;
            List<OperationEntity> allList = Storage.ReadDataFromStorage();
            if (allList is null)
            {
               return 0;
            }
            foreach (OperationEntity item in allList)
            {
                money += item.Money;
            }
            return money;
        }
    }
}
