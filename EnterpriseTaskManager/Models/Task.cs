using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EnterpriseTaskManager.Models
{
    public class Task : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string TaskName 
        {
            get => _taskName;
            set
            {
                if (_taskName == value)
                    return;
                _taskName = value;
                OnPropertyChanged("TaskName");
            }
        }
        private string _taskName;
        public TaskStatus TaskStatus
        {
            get => _taskStatus;
            set
            {
                if (_taskStatus == value)
                    return;
                _taskStatus = value;
                OnPropertyChanged("TaskStatus");
            }
        }
        private TaskStatus _taskStatus;
        public int TaskStatusId { get; set; }
        public TaskCategory TaskCategory
        {
            get => _taskCategory;
            set
            {
                if (_taskCategory == value)
                    return;
                _taskCategory = value;
                OnPropertyChanged("TaskCategory");
            }
        }
        private TaskCategory _taskCategory;
        public int TaskCategoryId { get; set; }
        public BindingList<Employee> ResponsibleEmployees { get; set; }
       
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
