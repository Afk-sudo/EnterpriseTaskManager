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
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindowViewModel RegistrationWindowViewModel { get; set; }
        public RegistrationWindow()
        {
            InitializeComponent();
            RegistrationWindowViewModel = new RegistrationWindowViewModel();
            this.DataContext = RegistrationWindowViewModel;
            RegistrationWindowViewModel.ExcitationException += DisplayExceptionMessage;
            RegistrationWindowViewModel.OpeninigManagerWindow += OpenWindowForManager;
        }
        private void OpenLoginWindow(object sender, RoutedEventArgs eventArgs)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
        private void OpenWindowForManager()
        {
            WindowForManager window = new WindowForManager();
            window.Show();
            this.Close();
        }
        private void DisplayExceptionMessage(string exceptionMessage)
        {
            MessageBox.Show(exceptionMessage);
        }
    }
}
