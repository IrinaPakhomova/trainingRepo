using System;


namespace ServiceLib
{
    public class OperationEntity
    {
        public DateTime Date { get; set; }
        public decimal Money { get; set; }

        public OperationEntity(DateTime date, decimal money)
        {
            Date = date;
            Money = money;
        }

        public override string ToString()
        {
            return Date.ToString() + Money.ToString();
        }
    }
}

