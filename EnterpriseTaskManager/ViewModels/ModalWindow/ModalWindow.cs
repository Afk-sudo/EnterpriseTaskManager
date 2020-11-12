    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class ModalWindow : INotifyPropertyChanged
    {
        public string WindowName
        {
            get => _windowName;
            set
            {
                if (_windowName == value)
                    return;
                _windowName = value;
                OnPropertyChanged("WindowName");
            }
        }
        private string _windowName;
        public event Action<string> ExcitationException;
        public event Action ClosingAllModalWindows;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void OnExcitationException(string exceptionMessage)
        {
            ExcitationException?.Invoke(exceptionMessage);
        }
        public void OnClosingAllModalWindows()
        {
            ClosingAllModalWindows?.Invoke();
        }
    }
}
