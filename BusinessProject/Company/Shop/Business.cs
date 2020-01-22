using System;
using System.Collections.Generic;
using System.Text;
using Company.Shop.Goods;
using Company.Shop.Workers;
using Company.ValidationData;
using Company.Shop.RentArea;
using Company.Shop.Calculation;

namespace Company.Shop
{
    public class Business
    {
        IServiceWorkers serviceWorkers;
        IServiceProduct serviceProduct;
        IServiceRent serviceRent;
        ICalc calculator;
        
        public Business()
        {
            serviceWorkers = new ServiceWorkers();
            serviceProduct = new ServiceProducts();
            serviceRent = new ServiceRent();
            calculator = new Calc();
        //    start();
            // Console.WriteLine("Бизнес создан:");
        }
        
        public void Process() 
        {
            Console.WriteLine("-".PadLeft(20, '-'));
            Console.WriteLine("\nПерсонал:");
            foreach (Worker worker in serviceWorkers.GetListOfWorker())
            {
                Console.WriteLine(worker);
            }
            Console.WriteLine("\nПеречень товаров:");
            foreach (Product product in serviceProduct.GetAllProducts())
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("\nАренда помещений:");
            foreach (Rent item in serviceRent.getAllRent())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-".PadLeft(20, '-'));
            decimal fixExpenses = calculator.TotalFixedExpenses(serviceRent.countValueAllRent(), serviceWorkers.SalaryWorkerCosts());
            Console.WriteLine($"Итого постоянных расходов: {fixExpenses}");
            decimal variableExpenses = calculator.TotalVariableExpenses(serviceProduct.AllProductsCosts());
            Console.WriteLine($"Итого постоянных расходов: {variableExpenses}");
            Console.WriteLine("-".PadLeft(20,'-'));
            Console.WriteLine($"Итого расходов: {fixExpenses + variableExpenses}");
            decimal incomeSales = calculator.CountIncome(serviceProduct.AllProductsCosts(), serviceProduct.GetPercent());
            Console.WriteLine($"Доходы с продаж: {incomeSales}");
            decimal saldo = calculator.Delta(incomeSales, (fixExpenses + variableExpenses));
            Console.WriteLine($"Сальдо:{saldo}");
            decimal factor = saldo / (fixExpenses + variableExpenses) * 100;
            if (factor > 20) { Console.WriteLine("Стоит рассмотреть этот бизнес"); }
            else if (factor <= 0) { Console.WriteLine("Бизнес убыточен"); }
            else { Console.WriteLine("Быстрее это дело не оправдает надежд"); }
        }
        public void Start()
        {
            Product good;
            Worker newWorker;
            Rent rent;

            Console.WriteLine("Для бизнеса надо нанять персоонал:");
            string isAdd;
            do
            {
                Console.Write("Добавим сотрудникa (Y/N): ");
                isAdd = Console.ReadLine();
                if (isAdd == "Y")
                {
                    newWorker = InputDataWorker();
                    serviceWorkers.AddNewWorker(newWorker);
                }
            }
            while (isAdd != "N");

            
            Console.WriteLine("\nДобавим товары:");
            do
            {
                Console.Write("Добавим товар (Y/N): ");
                isAdd = Console.ReadLine();
                if (isAdd == "Y")
                {
                    good = InputDataGoods();
                    serviceProduct.AddProduct(good);
                }
            }
            while (isAdd != "N");
            
            Console.WriteLine("\nДобавим аренду помещений:");
            do
            {
                Console.Write("Добавим аренду (Y/N): ");
                isAdd = Console.ReadLine();
                if (isAdd == "Y")
                {
                    rent = InputDataRentArea();
                    serviceRent.AddRent(rent);
                }
            }
            while (isAdd != "N");
            

      }
        private Worker InputDataWorker()
        {
            Console.Write("Введите фамилию:");
            string firstName = Console.ReadLine();
            Console.Write("Введите имя:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Выбирите профессию из списка:");
            for (int i = 1; i<= 5; i++) 
            {
                Console.WriteLine($"{i}.  {Enum.GetName(typeof(Position), i)}");
            }
            Position personPosition;
            do
            {
                Console.Write("Введите номер профессии:");
                if (!Validator.isCorrectIntegerData(Console.ReadLine(), 1, 5, out int position))
                {
                    Console.WriteLine("Значение должно быть от 1 до 5");
                }
                else 
                {
                    personPosition = (Position)position;
                    break;
                }

            } while (true);
            Console.Write($"Минимальная зарплата 100 рублей \nВведите зарплату:");
            decimal salary;
            do
            {
                if (!Validator.isCorrectDecimalData(Console.ReadLine(), 100, out salary))
                {
                    Console.WriteLine("Минимальная зарплата 100 рублей");
                }
                else
                {
                    break;
                }
            } while (true);

            return new Worker(firstName, lastName, personPosition, salary);
        }
        private Product InputDataGoods()
        {
            int countOfProduct;
            Console.Write("Введите наименование товара:");
            string nameOfProduct = Console.ReadLine().ToLower();
            do
            {
                Console.Write("Количество товара:");
                if (!Validator.isCorrectIntegerData(Console.ReadLine(), 0, out countOfProduct))
                {
                    Console.WriteLine("Значение должно быть больше 0!");
                }
                else
                {
                    break;
                }

            } while (true);

            Console.Write("Введите цену товара:");
            decimal priceProduct;
            do
            {
                if (!Validator.isCorrectDecimalData(Console.ReadLine(), 0, out priceProduct) && priceProduct > 0)
                {
                    Console.WriteLine("Значение должно быть больше 0!");
                }
                else
                {
                    break;
                }
            } while (true);

            return new Product(nameOfProduct, priceProduct, countOfProduct);
        }
        private Rent InputDataRentArea()
        {
            Console.Write("Введите название помещения:");
            string name = Console.ReadLine().ToLower();
            decimal priceArea;
            Console.Write("Стоимость помещения:");
            do
            {
                if (!Validator.isCorrectDecimalData(Console.ReadLine(), 0, out priceArea))
                {
                    Console.WriteLine("Значение должно быть больше 0");
                }
                else
                {
                    break;
                }
            } while (true);

            return new Rent(name, priceArea);
        }
    }
}
