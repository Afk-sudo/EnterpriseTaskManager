using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class AddPositionViewModel : BasicDataOfPosition
    {
        public CustomCommand AddPositionCommand => new CustomCommand(AddPosition);
        public event Action<Position> AddingPosition;
        public AddPositionViewModel()
        {
            WindowName = "Additing position";
        }
        private void AddPosition()
        {
            try
            {
                ValidateData();
                Position position = new Position(PositionName);
                App.Database.Positions.Add(position);
                App.Database.SaveChanges();
                OnClosingAllModalWindows();
            }
            catch(Exception exception)
            {
                OnExcitationException(exception.Message);
            }
        }
        private void OnAddingPosition(Position position)
        {
            AddingPosition?.Invoke(position);
        }
    }
}
