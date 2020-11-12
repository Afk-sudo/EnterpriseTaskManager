using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;
using System;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class AddTaskViewModel : BasicDataOfTask
    {
        public CustomCommand AddTaskCommand => new CustomCommand(AddTask);
        public AddTaskViewModel()
        {
            WindowName = "Additing task";
        }
        private void AddTask()
        {
            try
            {
                ValidateData();
                Task task = new Task(TaskName, Description, TaskStatus, TaskCategory, CheifEmployee);
                App.Database.Tasks.Add(task);
                App.Database.SaveChanges();
                App.MainViewModel.Tasks.Add(task);
                OnClosingAllModalWindows();
            }
            catch(Exception exception)
            {
                OnExcitationException(exception.Message);
            }
        }
    }
}
