using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class DeleteTaskViewModel : ModalWindow
    {
        public Task RemovableTask;
        public CustomCommand DeleteTaskCommand => new CustomCommand(RemoveTask);
        public DeleteTaskViewModel(Task task)
        {
            WindowName = "Confirm deliting";
            RemovableTask = task;
        }
        private void RemoveTask()
        {
            if (RemovableTask == null)
                OnClosingAllModalWindows();
            App.Database.Tasks.Remove(RemovableTask);
            App.Database.SaveChanges();
            App.MainViewModel.Tasks.Remove(RemovableTask);
            OnClosingAllModalWindows();
        }
    }
}
