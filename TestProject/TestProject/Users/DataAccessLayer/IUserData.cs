using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Users.DataAccessLayer
{
    interface IUserData
    {
        User GetUser(string name);

        bool AddUser(User user);

        User EditUSer(User user, string password);

        bool DeleteUser(User user);
    }
}
