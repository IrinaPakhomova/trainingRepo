using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ServiceLib;

namespace UIProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int operation = 0;
            
            const string info = "\nФинансовый помощник поможет вам учитывать расходы и доходы.\n1 - Ввести операцию дохода\n2 - Ввести операцию расхода" +
                                 "\n3 - Информация по операциям дохода\n4 - Информация по операциям расхода \n5 - Анализ расходов и доходов\n\n9 - Выход из программы" +
                                 "\nВведите номер операции:";
            List<OperationEntity> list;
            decimal finance;
            do
            {
                Console.Write(info);
                if (int.TryParse(Console.ReadLine(), out operation))
                {
                    switch (operation)
                    {
                        case 1:
                        case 2: WorkWithIncomingData(operation); break;
                        case 3:
                            {
                                list = Income.GetListIncome();
                                VisualisationData.OutputDataToTable(list);
                                Console.ReadKey();
                                break;
                            }
                        case 4:
                            {
                                list = Expense.GetListExpense();
                                VisualisationData.OutputDataToTable(list);
                                Console.ReadKey();
                                break;
                            }
                        case 5:
                            {
                                finance = AnaliseServices.AnalyseFinancialCondition();
                                if (finance < 0)
                                {
                                    Console.WriteLine($"Надо быть немного экономнее. Твой долг: {-1*finance}");
                                }
                                else
                                {
                                    Console.WriteLine($"На твоем счете на текущий момент:{finance}");
                                }
                                Console.ReadKey();
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

            } while (operation != 9);

            Console.WriteLine("Вы покидаете программу!");
            Console.ReadKey();

        }
        private static void WorkWithIncomingData(int operation)
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
                Console.Write("Введите корректно данные!\nВведите сумму расхода:");
            }

            if (operation == 1)
            {
                Income.InputIncome(date, money);
            }
            if (operation == 2)
            {
                Expense.InputExpense(date, money);
            }
            Console.WriteLine("\nДля продолжения  нажмите любую клавишу...");
            Console.ReadKey();

        }

        static bool TryParseMydate(string str, out DateTime date)
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
