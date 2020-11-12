using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseTaskManager.Models
{
    public class MainUser
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public MainUser() { }
        public MainUser(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
        }
    }
}
