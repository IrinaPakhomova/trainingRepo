using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Shop.Workers
{
    public enum Position
    {
        Manger = 1,
        Accounter = 2, 
        Loader = 3,
        Seller = 4,
        Purchaser = 5
    } 
    public class Worker
    {
        
        public string FirstName { get; set; }
     
        public string LastName { get; set; }

        public Position EmployeePosition { get; set; }

        public decimal Salary { get; set; }

        public Worker(string firstName, string lastName, Position employeePosition, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            EmployeePosition = employeePosition;
            Salary = salary;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Worker worker = (Worker)obj;
            return (worker.FirstName == this.FirstName && worker.LastName==this.LastName);
        }

        public override string ToString()
        {
            return "Фамилия: " + this.FirstName + " " + this.LastName + "; Должность: " + this.EmployeePosition + "; Зарплата: " + this.Salary;
        }
    }
}
