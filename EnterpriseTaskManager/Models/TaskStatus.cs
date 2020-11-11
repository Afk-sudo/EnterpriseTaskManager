using System.ComponentModel;

namespace EnterpriseTaskManager.Models
{
    public class TaskStatus : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string StatusName
        {
            get => _statusName;
            set
            {
                if (_statusName == value)
                    return;
                _statusName = value;
                OnPropertyChanged("StatusName");
            }
        }
        private string _statusName;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
