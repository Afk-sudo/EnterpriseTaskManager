using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;
using System;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class AddEmployeeViewModel : BasicDataOfEmployee
    {
        public CustomCommand AddEmployeeCommand => new CustomCommand(AddEmployee);
        public event Action<Employee> AddingEmployee;
        public AddEmployeeViewModel()
        {
            WindowName = "Additing employee";
        }
        private void AddEmployee()
        {
            try
            {
                ValidateData();
                Employee employee = new Employee(FirstName, LastName, Patronymic, DateBirth, PathToPhoto, Position, TypeWorkerByLocation, Gender, Login, Password);
                App.Database.Employees.Add(employee);
                App.Database.SaveChanges();
                OnAddingEmployee(employee);
                CopyFileToPhotoDirectory(employee);
                OnClosingAllModalWindows();
            }
            catch (Exception exception)
            {
                OnExcitationException(exception.Message);
            }
        }
        private void OnAddingEmployee(Employee employee)
        {
            AddingEmployee?.Invoke(employee);
        }
    }
}
