using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class BasicDataOfPosition : ModalWindow
    {
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

        public void ValidateData()
        {
            if (string.IsNullOrEmpty(PositionName))
                throw new Exception("Position name cannot be empty");
        }
    }
}
