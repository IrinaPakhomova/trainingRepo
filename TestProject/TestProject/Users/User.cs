using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Users
{
    public class User
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            User user = (User)obj;
            return this.Name == user.Name && this.Password == user.Password;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "User: " + this.Name + "; Password: " + this.Password;
        }
    }
}
