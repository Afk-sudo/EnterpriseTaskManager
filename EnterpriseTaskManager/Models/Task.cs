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
        public string Description
        {
            get => _description;
            set
            {
                if (_description == value)
                    return;
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        private string _description;
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
        public Employee CheifEmployee 
        {
            get => _cheifEmployee;
            set
            {
                if (_cheifEmployee == value)
                    return;
                _cheifEmployee = value;
                OnPropertyChanged("CheifEmployee");
            }
        }
        private Employee _cheifEmployee;
        public Task() 
        {
        }
        public Task(string taskName, string description, TaskStatus taskStatus, TaskCategory taskCategory, Employee cheifEmployee)
        {
            TaskName = taskName;
            Description = description;
            TaskStatus = taskStatus;
            TaskCategory = taskCategory;
            CheifEmployee = cheifEmployee;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
