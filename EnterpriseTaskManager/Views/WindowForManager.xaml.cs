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
    public partial class WindowForManager : Window
    {
        public WindowForManager()
        {
            InitializeComponent();
        }
        private void OnWindowLoaded(object sender, EventArgs eventArgs)
        {

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
        private void ShowOfficeWorkerList(object sender, RoutedEventArgs eventArgs)
        {
            OfficeWorkerList.Visibility = Visibility.Visible;
            RemoteWorkersList.Visibility = Visibility.Collapsed;
            //_isOfficeWorkerListVisibly = true;
            OfficeWorkerButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d6d7da"));
            RemoteWorekerButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#586875"));
        }
        private void ShowRemoteWorkersList(object sender, RoutedEventArgs eventArgs)
        {
            RemoteWorkersList.Visibility = Visibility.Visible;
            OfficeWorkerList.Visibility = Visibility.Collapsed;
            //_isOfficeWorkerListVisibly = false;
            OfficeWorkerButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#586875"));
            RemoteWorekerButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d6d7da"));
        }
    }
}
