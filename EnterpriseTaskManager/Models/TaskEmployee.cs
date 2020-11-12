using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseTaskManager.Models
{
    public class TaskEmployee
    {
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public TaskEmployee() { }
        public TaskEmployee(int taskId, int empoyeeId, Task task, Employee employee)
        {
            TaskId = taskId;
            EmployeeId = empoyeeId;
            Task = task;
            Employee = employee;
        }
    }
}
