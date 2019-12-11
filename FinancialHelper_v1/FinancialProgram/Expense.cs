using System;
using System.Collections.Generic;
using ServiceLib;

namespace FinancialProgram
{
    class Expense : IInputOutputData
    {
        public void Input(DateTime date, decimal amount, Storage storage)
        {
            OperationEntity op = new OperationEntity(date, amount * (-1));
            storage.WriteDataToStorage(op);
        }

        public List<OperationEntity> GetDataOperations(Storage storage)
        {
            List<OperationEntity> allList = storage.ReadDataFromStorage();
            if (allList == null)
            {
                return null;
            }
            List<OperationEntity> listIncome = new List<OperationEntity>();
            foreach (OperationEntity item in allList)
            {
                if (item.Money < 0)
                {
                    listIncome.Add(item);
                }
            }
            return listIncome;
        }
    }
}
