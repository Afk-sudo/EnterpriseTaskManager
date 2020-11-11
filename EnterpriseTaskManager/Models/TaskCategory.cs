using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EnterpriseTaskManager.Models
{
    public class TaskCategory : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string CategoryName
        {
            get => _categoryName;
            set
            {
                if (_categoryName == value)
                    return;
                _categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }
        private string _categoryName;
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
