using System.Collections.Generic;

namespace ServiceLib
{
    public class AnaliseServices
    {
        public decimal AnalyseFinancialCondition(Storage st)
        {
            decimal money = 0;
            List<OperationEntity> allList = st.ReadDataFromStorage();
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