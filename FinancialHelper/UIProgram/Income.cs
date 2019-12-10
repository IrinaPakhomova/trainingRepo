using System;
using System.Collections.Generic;
using ServiceLib;

namespace UIProgram
{
    class Income
    {
        public static void InputIncome(DateTime date, decimal amount)
        {
            OperationEntity op = new OperationEntity(date, amount);
            Storage.WriteDataToStorage(op);
        }
        public static List<OperationEntity> GetListIncome()
        {
            List<OperationEntity> allList = Storage.ReadDataFromStorage();
            if (allList == null)
            {
                return null;
            }
            List<OperationEntity> listIncome = new List<OperationEntity>();
            foreach (OperationEntity item in allList)
            {
                if (item.Money > 0)
                {
                    listIncome.Add(item);
                }
            }
            return listIncome;
        }
    }
}
