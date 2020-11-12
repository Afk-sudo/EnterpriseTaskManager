using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EnterpriseTaskManager.Models
{
    public class Task : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public List<TaskEmployee> TaskEmployee { get; set; } 
        public Task() 
        {
            TaskEmployee = new List<TaskEmployee>();
        }
        public Task(string taskName, string description, TaskStatus taskStatus, TaskCategory taskCategory, Employee cheifEmployee)
        {
            TaskName = taskName;
            Description = description;
            TaskStatus = taskStatus;
            TaskCategory = taskCategory;
            CheifEmployee = cheifEmployee;
            TaskEmployee = new List<TaskEmployee>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
