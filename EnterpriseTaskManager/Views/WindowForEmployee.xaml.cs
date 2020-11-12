using MaterialDesignThemes.Wpf;
using System;
using EnterpriseTaskManager.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EnterpriseTaskManager.ViewModels.ModalWindow;
using EnterpriseTaskManager.Models;

namespace EnterpriseTaskManager.Views
{
    public partial class WindowForEmployee : Window
    {
        public WindowForEmployeeViewModel WindowForEmployeeViewModel;       
        public WindowForEmployee(EnterpriseTaskManager.Models.Employee employee)
        {
            InitializeComponent();
            WindowForEmployeeViewModel = new WindowForEmployeeViewModel(employee);

        }
        private void OnWindowLoaded(object sender, EventArgs eventArgs)
        {
            this.DataContext = WindowForEmployeeViewModel;
        }
        private void CloseAllModalWindows()
        {
            DialogHost.CloseDialogCommand.Execute(null, null);
        }
        private void DisplayExceptionMessage(string exceptionMessage)
        {
            MessageBox.Show(exceptionMessage);
        }
        private void OnClickOpenGridMenu(object sender, RoutedEventArgs eventArgs)
        {
            OpenGridMenu.Visibility = Visibility.Collapsed;
            CloseGridMenu.Visibility = Visibility.Visible;
        }
        private void OnClickCloseGridMenu(object sender, RoutedEventArgs eventArgs)
        {
            CloseGridMenu.Visibility = Visibility.Collapsed;
            OpenGridMenu.Visibility = Visibility.Visible;
        }
        private void OpenChangeStatusWindow(object sender, RoutedEventArgs eventArgs)
        {
            int id = ListViewTasks.SelectedIndex;
            Task task = WindowForEmployeeViewModel.Employee.TaskEmployee[id].Task;

            if (task == null)
                return;
            ChangeStatusViewModel changeStatusViewModel = new ChangeStatusViewModel(task);
            changeStatusViewModel.ExcitationException += DisplayExceptionMessage;
            changeStatusViewModel.ClosingAllModalWindows += CloseAllModalWindows;
            DialogHost.Show(changeStatusViewModel, "RootDialog");
        }
    }
}
