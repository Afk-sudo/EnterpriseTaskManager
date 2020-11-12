using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EnterpriseTaskManager.ViewModels
{
    public class LoginWindowViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public CustomCommand LoginCommand => new CustomCommand(LogIntoAcount);
        public event Action<string> ExcitationException;
        public event Action OpeningWindowForManager;
        public event Action<Employee> OpeningWindowForEmployee;

        private void LogIntoAcount()
        {
            try
            {
                ValidateData();
                MainUser mainUser = App.Database.MainUsers.Where(user => user.Login == Login && user.Password == Password).FirstOrDefault();
                Employee employee =  App.Database.Employees.Include(employee => employee.TaskEmployee).Where(employee => employee.Login == Login && employee.Password == Password).FirstOrDefault();

                if (mainUser != null)
                {
                    OpeningWindowForManager?.Invoke();
                }
                else if (employee != null)
                {
                    OpeningWindowForEmployee?.Invoke(employee);
                }
                else
                    throw new Exception("No matches found");
            }
            catch(Exception exception)
            {
                ExcitationException?.Invoke(exception.Message);
            }
        }
        private void ValidateData()
        {
            if (string.IsNullOrEmpty(Login))
                throw new Exception("Login cannot be empty");
            if (string.IsNullOrEmpty(Password))
                throw new Exception("Password cannot be empty");
        }
    }
}
