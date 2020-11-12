using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseTaskManager.ViewModels
{
    public class RegistrationWindowViewModel 
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmePassword { get; set; }
        public CustomCommand RegistrateCommand => new CustomCommand(Registrate);
        public event Action<string> ExcitationException;
        public event Action OpeninigManagerWindow;
        private void Registrate()
        {
            try
            {
                ValidateData();
                MainUser mainUser = new MainUser(Name, Login, Password);
                App.Database.MainUsers.Add(mainUser);
                App.Database.SaveChanges();
                OpeninigManagerWindow?.Invoke();
            }
            catch(Exception exception)
            {
                ExcitationException?.Invoke(exception.Message);
            }
        }
        private void ValidateData()
        {
            if (string.IsNullOrEmpty(Name))
                throw new Exception("Name cannot be empty");
            if (string.IsNullOrEmpty(Login))
                throw new Exception("Login cannot be empty");
            if (string.IsNullOrEmpty(Password))
                throw new Exception("Password cannot be empty");
            if (string.IsNullOrEmpty(ConfirmePassword))
                throw new Exception("Confirme password cannot be empty");
            if(Password != ConfirmePassword)
                throw new Exception("Password and confirme do not match");

        }
    }
}
