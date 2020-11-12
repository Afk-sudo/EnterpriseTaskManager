using EnterpriseTaskManager.Models;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class DetailsEmployeeViewModel : BasicDataOfEmployee
    {
        public DetailsEmployeeViewModel(Employee employee)
        {
            WindowName = "Details Employee";
            LoadData(employee);
        }
    }
}
