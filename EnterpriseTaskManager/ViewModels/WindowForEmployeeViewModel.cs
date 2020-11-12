using EnterpriseTaskManager.Models;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseTaskManager.ViewModels
{
    public class WindowForEmployeeViewModel
    {
        public Employee Employee { get; set; }

        public WindowForEmployeeViewModel(Employee employee)
        {
            Employee = employee;
        }
    }
}
