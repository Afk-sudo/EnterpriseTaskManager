using EnterpriseTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class DetailsTaskViewModel : BasicDataOfTask
    {
        public DetailsTaskViewModel(Task task)
        {
            WindowName = "Details task";
            LoadData(task);
        }
    }
}
