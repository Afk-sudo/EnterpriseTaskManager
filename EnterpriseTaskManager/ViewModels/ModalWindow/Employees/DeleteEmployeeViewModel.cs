using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class DeleteEmployeeViewModel : ModalWindow
    {
        public Employee RemovableEmployee;
        public event Action<Employee> RemovingEmployee;
        public CustomCommand DeleteEmployeeCommand => new CustomCommand(RemoveEmployee);
        public DeleteEmployeeViewModel(Employee employee)
        {
            WindowName = "Confirm deliting";
            RemovableEmployee = employee;
        }
        private void RemoveEmployee()
        {
            if (RemovableEmployee == null)
                OnClosingAllModalWindows();
            App.Database.Employees.Remove(RemovableEmployee);
            App.Database.SaveChanges();
            RemovingEmployee?.Invoke(RemovableEmployee);
            OnClosingAllModalWindows();
        }
    }
}
