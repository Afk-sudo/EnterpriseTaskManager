using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EnterpriseTaskManager.ViewModels.Command
{
    public class CustomCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;
        public CustomCommand(Action execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _execute?.Invoke();
    }
}
