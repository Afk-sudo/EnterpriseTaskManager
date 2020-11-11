using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EnterpriseTaskManager.Models
{
    public class Position : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string PositionName 
        {
            get => _positionName;
            set
            {
                if (_positionName == value)
                    return;
                _positionName = value;
                OnPropertyChanged("PositionName");
            }
        }
        private string _positionName;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
