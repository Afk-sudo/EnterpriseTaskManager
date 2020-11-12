using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class ChangeStatusViewModel : BasicDataOfTask
    {
        public Task AssignedTask { get; set; }
        public CustomCommand ChangeStatusCommand => new CustomCommand(ChangeStatus);
        public ChangeStatusViewModel(Task task)
        {
            WindowName = "Change status ";
            AssignedTask = task;
            LoadData(task);
        }
        private void ChangeStatus()
        {
            AssignedTask.TaskStatus = TaskStatus;
            App.Database.Tasks.Update(AssignedTask);
        }
    }
}
