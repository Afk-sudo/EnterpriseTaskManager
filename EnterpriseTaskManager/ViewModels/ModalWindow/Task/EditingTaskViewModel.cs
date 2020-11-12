using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class EditingTaskViewModel : BasicDataOfTask
    {
        public Task EditableTask;
        public CustomCommand EditTaskCommand => new CustomCommand(EditTask);
        public EditingTaskViewModel(Task task)
        {
            WindowName = "Edditing task";
            LoadData(task);
            LoadDataFromDatabase();
            EditableTask = task;
        }
        private void EditTask()
        {
            try
            {
                ValidateData();
                EditableTask.TaskName = TaskName;
                EditableTask.Description = Description;
                EditableTask.TaskStatus = TaskStatus;
                EditableTask.TaskCategory = TaskCategory;
                EditableTask.CheifEmployee = CheifEmployee;
                App.Database.Tasks.Update(EditableTask);
                App.Database.SaveChanges();
                OnClosingAllModalWindows();
            }
            catch(Exception exception)
            {
                OnExcitationException(exception.Message);
            }
        }
    }
}
