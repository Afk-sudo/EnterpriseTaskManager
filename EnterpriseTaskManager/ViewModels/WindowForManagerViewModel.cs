using EnterpriseTaskManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EnterpriseTaskManager.ViewModels
{
    public class WindowForManagerViewModel
    {
        public BindingList<Employee> OfficeEmployees { get; set; }
        public BindingList<Employee> RemoteEmployees { get; set; }

        public WindowForManagerViewModel()
        {

        }
        private void LoadEmployees()
        {

        }
    }
}
