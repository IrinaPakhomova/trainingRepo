using System;
using System.Collections.Generic;
using System.IO;

namespace TestProject.Users.DataAccessLayer
{
    public class UserData : IUserData
    {
        private Data storage = Data.getInstance();

        public bool AddUser(User user)
        {
            User someUser = GetUser(user.Name);
            if (someUser == null)
            {
                storage.AddDataToStorage(user);
                if (File.Exists(user.Name + ".txt"))
                {
                    File.Delete(user.Name + ".txt");
                }
                File.Create(user.Name + ".txt").Close();
                return true;
            }
            else
            {
                Console.WriteLine("Такой пользователь существует");
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            List<User> users = storage.ReadUsersFromStorage();
            User someUser = GetUser(user.Name);
            if (user.Equals(someUser))
            {
                users.Remove(someUser);
                storage.ReWriteStorage(users);
                if (File.Exists(user.Name))
                {
                    File.Delete(user.Name);
                }
                return true;
            }
            else
            {
                Console.WriteLine("Такого пользователя не существует");
                return false;
            }
        }

        public User EditUSer(User user, string password)
        {
            List<User> users = storage.ReadUsersFromStorage();
            User changesUser = GetUser(user.Name);
            changesUser.Password = password;
            users.Remove(user);
            users.Add(changesUser);
            storage.ReWriteStorage(users);
            Console.WriteLine("Пароль успешно изменен");
            return changesUser;
        }

        public User GetUser(string name)
        {
            List<User> users = storage.ReadUsersFromStorage();
            foreach (User item in users)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
