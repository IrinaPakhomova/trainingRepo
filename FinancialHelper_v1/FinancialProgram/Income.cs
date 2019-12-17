using System;
using System.Collections.Generic;
using ServiceLib;

namespace FinancialProgram
{
    class Income : IInputOutputData
    {
        decimal tax ;

        public decimal Tax {
            get
            {
                return tax;
            }
        }

        public Income(): this(13)
        {
        }
        public Income(decimal tax)
        {
            this.tax = tax;
        }

        public void Input(DateTime date, decimal amount, Storage storage)
        {
            decimal valueTax = GetTax(amount, tax);
            OperationEntity op = new OperationEntity(date, amount - valueTax);
            storage.WriteDataToStorage(op);
        }

        private decimal GetTax(decimal amount, decimal tax)
        {
            return amount * tax / 100;
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
                if (item.Money > 0)
                {
                    listIncome.Add(item);
                }
            }
            return listIncome;
        }
    }
}
