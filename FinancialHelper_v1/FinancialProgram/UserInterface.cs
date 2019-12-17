using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ServiceLib;

namespace FinancialProgram
{
    class UserInterface
    {
        private Storage storage;
        private IInputOutputData expense;
        private IInputOutputData income;
        private VisualisationData visualisation;
        private AnaliseServices service;

        public UserInterface()
        {
            this.storage = new Storage();
            this.expense = new Expense();
            this.income = new Income();
            this.visualisation = new VisualisationData();
            this.service = new AnaliseServices();
        }

        public void CustomerService()
        {
            int operation = 0;
            const string info = "\n1 - Ввести операцию дохода\n2 - Ввести операцию расхода\n3 - Информация по операциям дохода" +
                                "\n4 - Информация по операциям расхода \n5 - Анализ расходов и доходов\n9 - Выход из программы" +
                                "\n\n\nВведите номер операции:";
            List<OperationEntity> list;
            decimal finance;
            Console.WriteLine("\nФинансовый помощник поможет вам учитывать расходы и доходы.");
            do
            {
                Console.Write(info);
                if (int.TryParse(Console.ReadLine(), out operation))
                {
                    switch (operation)
                    {
                        case 1: SendDataToStorage(operation, income, storage); break;
                        case 2: SendDataToStorage(operation, expense, storage); break;
                        case 3:
                            {
                                list = income.GetDataOperations(storage);
                                visualisation.OutputDataToTable(list);
                                break;
                            }
                        case 4:
                            {
                                list = expense.GetDataOperations(storage);
                                visualisation.OutputDataToTable(list);
                                break;
                            }
                        case 5:
                            {
                                finance = service.AnalyseFinancialCondition(storage);
                                if (finance < 0)
                                {
                                    Console.WriteLine($"Надо быть немного экономнее. Твой долг: {-1 * finance}");
                                }
                                else
                                {
                                    Console.WriteLine($"На твоем счете на текущий момент:{finance}");
                                }
                                break;
                            }
                        case 9: break;
                        default: Console.Write("Введите номер операции:"); break;
                    }
                }
                else
                {
                    Console.Write("Введите номер операции:");

                }
                if (operation != 9)
                {
                    Console.WriteLine("\nПродолжим...");
                }
            } while (operation != 9);

            Console.WriteLine("Вы покидаете программу!");
            Console.ReadKey();
        }
        private void SendDataToStorage(int operation, IInputOutputData inputDataOperation, Storage storage)
        {
            DateTime date;
            decimal money;

            Console.WriteLine("Введите дату в формате: YYYY/MM/DD");
            while (!TryParseMydate(Console.ReadLine(), out date))
            {
                Console.WriteLine("Введите дату в формате: YYYY/MM/DD");
            }
            if (operation == 1)
            {
                Console.Write("Введите сумму поступления:");
            }
            else
            {
                Console.Write("Введите сумму расхода:");
            }
            while (!decimal.TryParse(Console.ReadLine(), out money) || money < 0)
            {
                if (operation == 1)
                {
                    Console.Write("Введите корректно данные!\nВведите сумму поступления:");
                }
                else
                {
                    Console.Write("Введите корректно данные!\nВведите сумму расхода:");
                }
            }
            inputDataOperation.Input(date, money, storage);
        }

        private bool TryParseMydate(string str, out DateTime date)
        {
            str = str.Trim();
            int year;
            int day;
            int month;
            Regex dateRegex = new Regex(@"(19|20)\d\d[/](0[1-9]|1[012])[/](0[1-9]|[12][0-9]|3[01])");
            if (dateRegex.IsMatch(str))
            {
                year = int.Parse(str.Substring(0, 4));
                month = int.Parse(str.Substring(5, 2));
                day = int.Parse(str.Substring(8, 2));
                date = new DateTime(year, month, day);
                return true;
            }
            else
            {
                date = new DateTime(1, 1, 1);
                return false;
            }
        }
    }
}
