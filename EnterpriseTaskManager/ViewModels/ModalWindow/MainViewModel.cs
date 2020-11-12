using EnterpriseTaskManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class MainViewModel
    {
        public string Filter
        {
            get => _filter;
            set
            {
                if (_filter == value)
                    return;
                _filter = value;
                OnPropertyChanged("Filter");
            }
        }
        private string _filter;
        public int AmountEmployee
        {
            get => OfficeWorkers.Count + RemoteWorkers.Count;
        }
        public BindingList<Employee> OfficeWorkers { get; set; }
        public BindingList<Employee> RemoteWorkers { get; set; }
        public BindingList<Task> Tasks { get; set; }
        public List<string> Filters { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public MainViewModel()
        {
            Filter = "None";
            Filters = new List<string>() { "None", "By date" };
            LoadWorkers();
            LoadTasks();
        }
        public void AddEmployeeInViewModel(Employee employee)
        {
            if (employee.TypeWorkerByLocation == "Office worker")
                OfficeWorkers.Add(employee);
            else
                RemoteWorkers.Add(employee);
            OnPropertyChanged("AmountEmployee");
        }
        private void LoadWorkers()
        {
            OfficeWorkers = new BindingList<Employee>();
            RemoteWorkers = new BindingList<Employee>();
            var employees = App.Database.Employees.Include(employee => employee.Position);
            foreach (Employee employee in employees)
            {
                if (employee.TypeWorkerByLocation == "Office worker")
                    OfficeWorkers.Add(employee);
                else
                    RemoteWorkers.Add(employee);
            }
        }
        private void LoadTasks()
        {
            Tasks = new BindingList<Task>();

            var tasks = App.Database.Tasks.Include(task => task.TaskStatus).Include(task => task.TaskCategory);
            foreach(Task task in tasks)
            {
                Tasks.Add(task);
            }
        }
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
