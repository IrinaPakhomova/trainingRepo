using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Shop.Workers
{
    interface IServiceWorkers
    {
        void AddNewWorker(Worker worker);
        bool ExistWorker(Worker worker);
        List<Worker> GetListOfWorker();
        decimal SalaryWorkerCosts();
    }
}
