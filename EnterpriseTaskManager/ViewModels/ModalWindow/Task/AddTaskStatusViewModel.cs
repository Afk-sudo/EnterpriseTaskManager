using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;
using System;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class AddTaskStatusViewModel : ModalWindow
    {
        public string StatusName
        {
            get => _statusName;
            set
            {
                if (_statusName == value)
                    return;
                _statusName = value;
                OnPropertyChanged("StatusName");
            }
        }
        private string _statusName;
        public CustomCommand AddTaskStatusCommand => new CustomCommand(AddTaskStatus);
        public AddTaskStatusViewModel()
        {
            WindowName = "Additing task status";
        }
        private void AddTaskStatus()
        {
            try
            {
                ValidateData();
                TaskStatus taskStatus = new TaskStatus(StatusName);
                App.Database.TaskStatuses.Add(taskStatus);
                App.Database.SaveChanges();
                OnClosingAllModalWindows();
            }
            catch(Exception exception)
            {
                OnExcitationException(exception.Message);
            }
        }
        private void ValidateData()
        {
            if (string.IsNullOrEmpty(StatusName))
                throw new Exception("Status name cannot be empty");
        }
    }
}
