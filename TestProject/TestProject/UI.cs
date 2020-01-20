using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestProject.Calculator;
using TestProject.UserDataValidation;
using TestProject.Users;
using TestProject.Users.DataAccessLayer;

namespace TestProject
{
    public class UI
    {
        private readonly IUserData users;
        private User user;
        public UI()
        {
            users = new UserData();
        }

        public User processStart()
        {
            const string info = "Программа калькулятор доступна только залогиненому пользователю,\n поэтому пройдите регистрацию"
                              + "\nВыберите нужный пункт меню:\n 1. Регистрация нового пользователя"
                              + " \n 2. Войти в систему под пользователем"
                              + " \n 3. Удалить аккаунт \n 4. Изменить пароль пользователя";
            //\n 3. Исправить данные пользователя \n 4. Удалить пользователя \n 5.Выход из программы";

            int operation;
            Console.WriteLine(info);
            do
            {
                Console.Write("Введите номер операции:");
                if (int.TryParse(Console.ReadLine(), out operation))
                {
                    if (operation >= 1 && operation <= 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Не корректные данные");
                    }
                }
            } while (true);

            switch (operation)
            {
                case 1:
                    {
                        this.user = InputeDataUser();
                        if (!users.AddUser(user))
                        {
                            user = null;
                        }
                        break;
                    }
                case 2:
                    {
                        user = InputeDataUser();
                        if (!user.Equals(users.GetUser(user.Name)))
                        {
                            Console.WriteLine("Неверное имя пользователя или пароль!");
                            user = null;
                        }
                        break;
                    }
                case 3:
                    {
                        user = InputeDataUser();
                        if (user.Equals(users.GetUser(user.Name)))
                        {
                            users.DeleteUser(user);
                        }
                        else
                        {
                            Console.WriteLine("Такого пользователя нет!");
                        }
                        user = null;
                        break;

                    }
                case 4:
                    {
                        user = InputeDataUser();
                        if (user.Equals(users.GetUser(user.Name)))
                        {
                            bool validation_flag = false;
                            string password;
                            do
                            {
                                Console.WriteLine("Введите новый пароль:");
                                password = Console.ReadLine();
                                if (!ValidationData.isCorrectStringData(password, 3))
                                {
                                    Console.WriteLine("Пароль должен быть не менее 3 символов");
                                }
                                else
                                {
                                    validation_flag = true;
                                }
                            } while (!validation_flag);
                            users.EditUSer(user, password);
                        }
                        else
                        {
                            user = null;
                            Console.WriteLine("Такого пользователя нет!");
                        }
                        break;
                    }
            }
            return user;
        }

        public void Calculation()
        {
            if (user != null)
            {
                StringBuilder sb = new StringBuilder(DateTime.Today.ToString());
                sb.Append("\n");
                Console.WriteLine("Посчитаем теперь");
                Console.Write("Введите число a=");
                string a = Console.ReadLine();
                Console.Write("Введите число b=");
                string b = Console.ReadLine();

                ICalculator<Object> calс = new Calculator<Object>();
                bool notCalcYet = false;
                if (Int32.TryParse(a, out int resultInt1) && Int32.TryParse(b, out int resultInt2))
                {
                    sb.Append(a).Append("+").Append(b).Append("=").Append(calс.Addition(resultInt1, resultInt2)).Append("\n");
                    sb.Append(a).Append("/").Append(b).Append("=").Append(calс.Division(resultInt1, resultInt2)).Append("\n");
                    sb.Append(a).Append("*").Append(b).Append("=").Append(calс.Multiplication(resultInt1, resultInt2)).Append("\n");
                    sb.Append(a).Append("-").Append(b).Append("=").Append(calс.Subtraction(resultInt1, resultInt2)).Append("\n");
                    notCalcYet = true;
                }
                if (Double.TryParse(a, out double resultDec1) && Double.TryParse(b, out double resultDec2) && !notCalcYet)
                {
                    sb.Append(a).Append("+").Append(b).Append("=").Append(calс.Addition(resultDec1, resultDec2)).Append("\n");
                    sb.Append(a).Append("/").Append(b).Append("=").Append(calс.Division(resultDec1, resultDec2)).Append("\n");
                    sb.Append(a).Append("*").Append(b).Append("=").Append(calс.Multiplication(resultDec1, resultDec2)).Append("\n");
                    sb.Append(a).Append("-").Append(b).Append("=").Append(calс.Subtraction(resultDec1, resultDec2)).Append("\n");
                    notCalcYet = true;
                }
                if (Char.TryParse(a, out char resultChar1) && Char.TryParse(b, out char resultChar2) && !notCalcYet)
                {
                    sb.Append(a).Append("+").Append(b).Append("=").Append(calс.Addition(resultChar1, resultChar2)).Append("\n");
                    sb.Append(a).Append("/").Append(b).Append("=").Append(calс.Division(resultChar1, resultChar2)).Append("\n");
                    sb.Append(a).Append("*").Append(b).Append("=").Append(calс.Multiplication(resultChar1, resultChar2)).Append("\n");
                    sb.Append(a).Append("-").Append(b).Append("=").Append(calс.Subtraction(resultChar1, resultChar2)).Append("\n");
                    notCalcYet = true;
                }
                if (!notCalcYet)
                {
                    sb.Append(a).Append("+").Append(b).Append("=").Append(calс.Addition(a, b)).Append("\n");
                    sb.Append(a).Append("/").Append(b).Append("=").Append(calс.Division(a, b)).Append("\n");
                    sb.Append(a).Append("*").Append(b).Append("=").Append(calс.Multiplication(a, b)).Append("\n");
                    sb.Append(a).Append("-").Append(b).Append("=").Append(calс.Subtraction(a, b)).Append("\n");
                }
                string filename = user.Name + ".txt";
                using (StreamWriter sw = new StreamWriter(filename, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(sb);
                }

            }
        }

        public User InputeDataUser()
        {
            string name;
            string password;
            bool validation_flag = false;
            do
            {
                Console.Write("Введите имя пользоварителя: ");
                name = Console.ReadLine();
                if (!ValidationData.isCorrectStringData(name, 5))
                {
                    Console.WriteLine("Имя пользователя должно быть не менее 5 символов!");
                }
                else
                {
                    validation_flag = true;
                }
            } while (!validation_flag);
            validation_flag = false;
            do
            {
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();
                if (!ValidationData.isCorrectStringData(password, 3))
                {
                    Console.WriteLine("Пароль должен быть не менее 3 символов!");
                }
                else
                {
                    validation_flag = true;
                }
            } while (!validation_flag);

            User user = new User(name, password);
            return user;
        }

    }
}
