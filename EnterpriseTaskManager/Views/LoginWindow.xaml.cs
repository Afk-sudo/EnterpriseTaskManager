using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EnterpriseTaskManager.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindowViewModel LoginWindowViewModel;
        public LoginWindow()
        {
            InitializeComponent();
            LoginWindowViewModel = new LoginWindowViewModel();
            this.DataContext = LoginWindowViewModel;
            LoginWindowViewModel.OpeningWindowForEmployee += OpenWindowForEmployee;
            LoginWindowViewModel.OpeningWindowForManager += OpenWindowForManager;
            LoginWindowViewModel.ExcitationException += DisplayExceptionMessage;
        }
        private void DisplayExceptionMessage(string exceptionMessage)
        {
            MessageBox.Show(exceptionMessage);
        }

        private void OpenWindowForManager()
        {
            WindowForManager windowForManager = new WindowForManager();
            windowForManager.Show();
            this.Close();
        }

        private void OpenWindowForEmployee(Employee employee)
        {
            WindowForEmployee windowForEmployee = new WindowForEmployee(employee);
            windowForEmployee.Show();
            this.Close();
        }

        private void OpenRegistrationWindow(object sender, RoutedEventArgs eventArgs)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
