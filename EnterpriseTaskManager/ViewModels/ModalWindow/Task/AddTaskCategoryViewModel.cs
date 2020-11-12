using System;
using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class AddTaskCategoryViewModel : ModalWindow
    {
        public string CategoryName { get; set; }
        public CustomCommand AddTaskCommand => new CustomCommand(AddTaskCategory);
        public AddTaskCategoryViewModel()
        {
            WindowName = "Additing category task";
        }
        private void AddTaskCategory()
        {
            try
            {
                ValidateData();
                TaskCategory taskCategory = new TaskCategory(CategoryName);
                App.Database.TaskCategoryes.Add(taskCategory);
                App.Database.SaveChanges();
                OnClosingAllModalWindows();
            }
            catch (Exception exception)
            {
                OnExcitationException(exception.Message);
            }
        }
        private void ValidateData()
        {
            if (string.IsNullOrEmpty(CategoryName))
                throw new Exception("Category name cannot be empty");
        }
    }
}
