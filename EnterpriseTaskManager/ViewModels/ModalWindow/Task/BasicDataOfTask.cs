using EnterpriseTaskManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class BasicDataOfTask : ModalWindow
    {
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
        public List<TaskStatus> TasksStatuses { get; set; }
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
        public List<TaskCategory> TasksCategoryes { get; set; }
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
        public List<Employee> Employees { get; set; }

        public BasicDataOfTask()
        {
            LoadDataFromDatabase();
        }
        public void LoadData(Task task)
        {
            TaskName = task.TaskName;
            Description = task.Description;
            TaskStatus = task.TaskStatus;
            TaskCategory = task.TaskCategory;
            CheifEmployee = task.CheifEmployee;
        }
        public void LoadDataFromDatabase()
        {
            TasksStatuses = new List<TaskStatus>();
            TasksCategoryes = new List<TaskCategory>();
            Employees = new List<Employee>();

            var tasksStatuses = App.Database.TaskStatuses;
            foreach (var taskStatus in tasksStatuses)
                TasksStatuses.Add(taskStatus);

            var tasksCategoryes = App.Database.TaskCategoryes;
            foreach (var taskCategory in tasksCategoryes)
                TasksCategoryes.Add(taskCategory);

            var employees = App.Database.Employees.Include(e => e.TaskEmployee);
            foreach (var employee in employees)
                Employees.Add(employee);

        }
        public void ValidateData()
        {
            if (string.IsNullOrEmpty(TaskName))
                throw new Exception("Task name cannot be empty");
            if (string.IsNullOrEmpty(Description))
                throw new Exception("Description cannot be empty");
            if (TaskStatus == null)
                throw new Exception("Task status cannot be empty");
            if (TaskCategory == null)
                throw new Exception("Task category cannot be empty");
        }
    }
}
