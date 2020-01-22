using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Shop.Workers
{
    public class ServiceWorkers : IServiceWorkers
    {
        private List<Worker> workers;
        //private List<Position> freePositions = new List<Position> {Position.Accounter, Position.Loader, Position.Manger, Position.Purchaser, Position.Seller};
        public ServiceWorkers()
        {
            workers = new List<Worker>();
        }
        public void AddNewWorker(Worker worker)
        {
            if (worker != null && !ExistWorker(worker))
            {
                workers.Add(worker);
                Console.WriteLine($"Сотрудник {worker} нанят");
            }
            else 
            {
                Console.WriteLine("Такой работник уже работает!");
            }
        }
        public List<Worker> GetListOfWorker() 
        {
            return workers;
        }

        public bool ExistWorker(Worker worker) 
        {
            foreach (Worker item in workers) 
            {
                if (item.Equals(worker)) 
                {
                    return true;
                }
            }
            return false; 
        }

        public decimal SalaryWorkerCosts() 
        {
            decimal value = 0;
            foreach (Worker item in workers)
            {
                value += item.Salary;
            }
            return value;
        }
    }
}
