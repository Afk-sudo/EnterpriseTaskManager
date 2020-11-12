using EnterpriseTaskManager.ViewModels.ModalWindow;
using MaterialDesignThemes.Wpf;
using System;
using EnterpriseTaskManager.Models;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using EnterpriseTaskManager.ViewModels.ModalWindow;

namespace EnterpriseTaskManager.Views
{
    public partial class WindowForManager : Window
    {
        private bool _isOfficeWorkerListVisibly = true;
        private bool _isInProcessActivitieListVisible = true;
        private bool _isCanInteractableWithDataGrid = false;
        public WindowForManager()
        {
            InitializeComponent();
        }
        private void OnWindowLoaded(object sender, EventArgs eventArgs)
        {
            this.DataContext = App.MainViewModel;
            AddPositionButton.MouseLeftButtonUp += OpenModalWindowAdditingPosition;
            AddEmployeeButton.MouseLeftButtonUp += OpenModalWindowAdditingEmployee;
            AddTaskButton.MouseLeftButtonUp += OpenAddTaskWindow;
            AddTaskStatusButton.MouseLeftButtonUp += OpenAddTaskStatus;
            AddTaskCategoryButton.MouseLeftButtonUp += OpenAddTaskCategory;
        }
        private void OpenModalWindowAdditingPosition(object sender, MouseButtonEventArgs eventArgs)
        {
            AddPositionViewModel addPositionViewModel = new AddPositionViewModel();
            addPositionViewModel.ClosingAllModalWindows += CloseAllModalWindows;
            addPositionViewModel.ExcitationException += DisplayExceptionMessage;
            DialogHost.Show(addPositionViewModel, "RootDialog");            
        }
        private void OpenModalWindowAdditingEmployee(object sender, MouseButtonEventArgs eventArgs)
        {
            AddEmployeeViewModel addEmployeeViewModel = new AddEmployeeViewModel();
            addEmployeeViewModel.ClosingAllModalWindows += CloseAllModalWindows;
            addEmployeeViewModel.ExcitationException += DisplayExceptionMessage;
            addEmployeeViewModel.AddingEmployee += AddEmployee;
            DialogHost.Show(addEmployeeViewModel, "RootDialog");
        }
        private void AddEmployee(Employee employee)
        {
            App.MainViewModel.AddEmployeeInViewModel(employee);
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
        private void ShowOfficeWorkerList(object sender, RoutedEventArgs eventArgs)
        {
            OfficeWorkerList.Visibility = Visibility.Visible;
            RemoteWorkersList.Visibility = Visibility.Collapsed;
            _isOfficeWorkerListVisibly = true;
            OfficeWorkerButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d6d7da"));
            RemoteWorekerButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#586875"));
        }
        private void ShowRemoteWorkersList(object sender, RoutedEventArgs eventArgs)
        {
            RemoteWorkersList.Visibility = Visibility.Visible;
            OfficeWorkerList.Visibility = Visibility.Collapsed;
            _isOfficeWorkerListVisibly = false;
            OfficeWorkerButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#586875"));
            RemoteWorekerButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d6d7da"));
        }
        private void OpenEditingEmployeeWindow(object sender, RoutedEventArgs eventArgs)
        {
            Employee employee = null;
            if (_isOfficeWorkerListVisibly == true)
                employee = (Employee)OfficeWorkerList.SelectedItem;
            else
                employee = (Employee)RemoteWorkersList.SelectedItem;
            EditEmployeeViewModel editingEmployee = new EditEmployeeViewModel(employee);
            editingEmployee.ExcitationException += DisplayExceptionMessage;
            editingEmployee.ClosingAllModalWindows += CloseAllModalWindows;
            editingEmployee.EditingEmployee += EditEmployee;
            DialogHost.Show(editingEmployee, "RootDialog");
        }
        private void EditEmployee(Employee employee, bool isChangeTypeWorker)
        {
            if (isChangeTypeWorker == false)
                return;

            if (employee.TypeWorkerByLocation == "Office worker")
            {
                App.MainViewModel.RemoteWorkers.Remove(employee);
                App.MainViewModel.OfficeWorkers.Add(employee);
            }
            else if(employee.TypeWorkerByLocation == "Remote worker")
            {
                App.MainViewModel.OfficeWorkers.Remove(employee);
                App.MainViewModel.RemoteWorkers.Add(employee);
            }
        }
        private void OpenDetailsEmployeeWindow(object sender, RoutedEventArgs eventArgs)
        {
            Employee employee = null;
            if (_isOfficeWorkerListVisibly == true)
                employee = (Employee)OfficeWorkerList.SelectedItem;
            else
                employee = (Employee)RemoteWorkersList.SelectedItem;
            DetailsEmployeeViewModel detailsEmployee = new DetailsEmployeeViewModel(employee);
            DialogHost.Show(detailsEmployee, "RootDialog");
        }
        private async void OpeneDeleteEmployeeWindow(object sender, RoutedEventArgs eventArgs)
        {
            Employee employee = null;
            if (_isOfficeWorkerListVisibly == true)
                employee = (Employee)OfficeWorkerList.SelectedItem;
            else
                employee = (Employee)RemoteWorkersList.SelectedItem;
            DeleteEmployeeViewModel deletingModalWindow = new DeleteEmployeeViewModel(employee);
            deletingModalWindow.RemovingEmployee += DeleteEmployee;
            deletingModalWindow.ClosingAllModalWindows += CloseAllModalWindows;
            await DialogHost.Show(deletingModalWindow, "RootDialog");
        }
        private void DeleteEmployee(Employee employee)
        {
            if (_isOfficeWorkerListVisibly == true)
                App.MainViewModel.OfficeWorkers.Remove(employee);
            else
               App.MainViewModel.RemoteWorkers.Remove(employee);
            App.MainViewModel.OnPropertyChanged("AmountEmployee");
        }
        private void OpenAddTaskWindow(object sender, MouseButtonEventArgs eventArgs)
        {
            AddTaskViewModel addTaskViewModel = new AddTaskViewModel();
            addTaskViewModel.ExcitationException += DisplayExceptionMessage;
            addTaskViewModel.ClosingAllModalWindows += CloseAllModalWindows;
            DialogHost.Show(addTaskViewModel, "RootDialog");
        }
        private void OpenAddTaskStatus(object sender, MouseButtonEventArgs eventArgs)
        {
            AddTaskStatusViewModel addTaskStatusViewModel = new AddTaskStatusViewModel();
            addTaskStatusViewModel.ClosingAllModalWindows += CloseAllModalWindows;
            addTaskStatusViewModel.ExcitationException += DisplayExceptionMessage;
            DialogHost.Show(addTaskStatusViewModel, "RootDialog");
        }
        private void OpenAddTaskCategory(object sender, MouseButtonEventArgs eventArgs)
        {
            AddTaskCategoryViewModel addTaskCategoryViewModel = new AddTaskCategoryViewModel();
            addTaskCategoryViewModel.ExcitationException += DisplayExceptionMessage;
            addTaskCategoryViewModel.ClosingAllModalWindows += CloseAllModalWindows;
            DialogHost.Show(addTaskCategoryViewModel, "RootDialog");
        }
        private void OpenEditTaskWindow(object sender, RoutedEventArgs eventArgs)
        {
            Task task = (Task)ListViewTasks.SelectedItem;
            if (task == null)
                return;
            EditingTaskViewModel editingTaskViewModel = new EditingTaskViewModel(task);
            editingTaskViewModel.ExcitationException += DisplayExceptionMessage;
            editingTaskViewModel.ClosingAllModalWindows += CloseAllModalWindows;
            DialogHost.Show(editingTaskViewModel, "RootDialog");
        }
        private void OpenDeleteTaskWindow(object sender, RoutedEventArgs eventArgs)
        {
            Task task = (Task)ListViewTasks.SelectedItem;
            if (task == null)
                return;
            DeleteTaskViewModel deleteTaskViewModel = new DeleteTaskViewModel(task);
            deleteTaskViewModel.ExcitationException += DisplayExceptionMessage;
            deleteTaskViewModel.ClosingAllModalWindows += CloseAllModalWindows;
            DialogHost.Show(deleteTaskViewModel, "RootDialog");
        }
        private void OpenTaskDetailViewModel(object sender, RoutedEventArgs eventArgs)
        {
            Task task = (Task)ListViewTasks.SelectedItem;
            if (task == null)
                return;
            DetailsTaskViewModel detailsTaskViewModel = new DetailsTaskViewModel(task);
            detailsTaskViewModel.ExcitationException += DisplayExceptionMessage;
            detailsTaskViewModel.ClosingAllModalWindows += CloseAllModalWindows;
            DialogHost.Show(detailsTaskViewModel, "RootDialog");

        }
    }
}
