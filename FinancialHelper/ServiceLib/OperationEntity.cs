using System;


namespace ServiceLib
{
    public struct OperationEntity
    {
        public DateTime Date { get; set; }
        public decimal Money { get; set; }
        public OperationEntity(DateTime date, decimal money)
        {
            Date = date;
            Money = money;
        }
        override
        public string ToString()
        {
            return Date.ToString() + Money.ToString();
        }
    }
}
