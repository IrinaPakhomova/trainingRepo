using System;
using TestProject.Calculator;
using TestProject.Users;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            bool exitflag = false;
            User user = null;
            do
            {
                if (user == null)
                {
                    user = ui.processStart();
                }
                if (user != null)
                {
                    ui.Calculation();
                    Console.WriteLine("Вы хотите выйти из программы? (Y) \n Если нет то нажмите любую клавишу");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        exitflag = true;
                    }
                }
                else
                {
                    Console.WriteLine("Вы хотите выйти из программы? (Y) \n Если нет то нажмите любую клавишу");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        exitflag = true;
                    }
                }
            } while (!exitflag);
            Console.WriteLine("Вы покидаете программу!");
            Console.ReadKey();

        }
    }
}
