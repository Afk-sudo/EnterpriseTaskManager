using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class EditEmployeeViewModel : BasicDataOfEmployee
    {
        public Employee EditableEmployee { get; set; }
        public CustomCommand EditEmployeeCommand { get; set; }
        public event Action<Employee, bool> EditingEmployee;
        public EditEmployeeViewModel(Employee employee)
        {
            WindowName = "Editing Employee";
            EditableEmployee = employee;
            LoadData(EditableEmployee);
            EditEmployeeCommand = new CustomCommand(EditEmployee);
        }
        private void EditEmployee()
        {
            try
            {
                bool isChangeWorkerType = false;
                ValidateData();
                EditableEmployee.FirstName = FirstName;
                EditableEmployee.LastName = LastName;
                EditableEmployee.Patronymic = Patronymic;
                EditableEmployee.DateBirth = DateBirth;
                EditableEmployee.PathToPhoto = PathToPhoto;
                EditableEmployee.Position = Position;
                EditableEmployee.Gender = Gender;
                if (EditableEmployee.TypeWorkerByLocation != TypeWorkerByLocation)
                {
                    isChangeWorkerType = true;
                }
                EditableEmployee.TypeWorkerByLocation = TypeWorkerByLocation;
                App.Database.Employees.Update(EditableEmployee);
                App.Database.SaveChanges();
                CopyFileToPhotoDirectory(EditableEmployee);
                OnEditingEmployee(EditableEmployee, isChangeWorkerType);
                OnClosingAllModalWindows();
            }
            catch (Exception exception)
            {
                OnExcitationException(exception.Message);
            }
        }
        private void OnEditingEmployee(Employee employee, bool isChangeWorkerType)
        {
            EditingEmployee?.Invoke(employee, isChangeWorkerType);
        }
    }
}
