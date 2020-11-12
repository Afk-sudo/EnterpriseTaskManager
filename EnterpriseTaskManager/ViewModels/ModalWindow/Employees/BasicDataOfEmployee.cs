
using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EnterpriseTaskManager.ViewModels.ModalWindow
{
    public class BasicDataOfEmployee : ModalWindow
    {
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == value)
                    return;
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        private string _firstName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == value)
                    return;
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        private string _lastName;
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                if (_patronymic == value)
                    return;
                _patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }
        private string _patronymic;
        public DateTime DateBirth
        {
            get => _dateBirth;
            set
            {
                if (_dateBirth == value)
                    return;
                _dateBirth = value;
                OnPropertyChanged("DateBirth");
            }
        }
        private DateTime _dateBirth = new DateTime(1990, 1, 1);
        public Position Position
        {
            get => _position;
            set
            {
                if (_position == value)
                    return;
                _position = value;
                OnPropertyChanged("Position");
            }
        }
        private Position _position;
        public string PathToPhoto
        {
            get => _pathToPhoto;
            set
            {
                if (_pathToPhoto == value)
                    return;
                _pathToPhoto = value;
                OnPropertyChanged("PathToPhoto");
            }
        }
        private string _pathToPhoto;
        public string TypeWorkerByLocation
        {
            get => _typeWorkerByLocation;
            set
            {
                if (_typeWorkerByLocation == value)
                    return;
                _typeWorkerByLocation = value;
                OnPropertyChanged("TypeWorkerByLocation");
            }
        }
        private string _typeWorkerByLocation;
        public bool IsOfficeWorker
        {
            get => _isOfficeWorker;
            set
            {
                if (_isOfficeWorker == value)
                    return;
                _isOfficeWorker = value;
                if (_isOfficeWorker == true)
                    TypeWorkerByLocation = "Office worker";
                else
                    TypeWorkerByLocation = "Remote worker";
                OnPropertyChanged("IsOfficeWorker");
            }
        }
        private bool _isOfficeWorker;
        public bool IsRemoteWorker
        {
            get => _isRemoteWorker;
            set
            {
                if (_isRemoteWorker == value)
                    return;
                _isRemoteWorker = value;
                if (_isRemoteWorker == true)
                    TypeWorkerByLocation = "Remote worker";
                else
                    TypeWorkerByLocation = "Office worker";
                OnPropertyChanged("IsRemoteWorker");
            }
        }
        private bool _isRemoteWorker;
        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender == value)
                    return;
                _gender = value;
                OnPropertyChanged("Gender");
            }
        }
        private string _gender;
        public bool IsMale
        {
            get => _isMale;
            set
            {
                if (_isMale == value)
                    return;
                _isMale = value;
                if (_isMale == true)
                    Gender = "Male";
                else
                    Gender = "Female";
                OnPropertyChanged("IsMale");
            }
        }
        private bool _isMale;
        public bool IsFemale
        {
            get => _isFemale;
            set
            {
                if (_isFemale == value)
                    return;
                _isFemale = value;
                if (_isFemale == true)
                    Gender = "Male";
                else
                    Gender = "Female";
                OnPropertyChanged("IsFemale");
            }
        }
        private bool _isFemale;
        public string Login
        {
            get => _login;
            set
            {
                if (_login == value)
                    return;
                _login = value;
                OnPropertyChanged("Password");
            }
        }
        private string _login;
        public string Password
        {
            get => _password;
            set
            {
                if (_password == value)
                    return;
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        private string _password;
        public List<Position> Positions { get; private set; }
        public CustomCommand OpenFileDialogCommand => new CustomCommand(OpenFileDialog);
        public BasicDataOfEmployee()
        {
            LoadEmployeePositions();
        }
        public void ValidateData()
        {
            if (string.IsNullOrEmpty(FirstName))
                throw new Exception("First name cannot be empty");
            if (string.IsNullOrEmpty(LastName))
                throw new Exception("Last name cannot be empty");
            if (string.IsNullOrEmpty(Patronymic))
                throw new Exception("Patronymic cannot be empty");
            if (string.IsNullOrEmpty(Login))
                throw new Exception("Login cannot be empty");
            if (string.IsNullOrEmpty(Password))
                throw new Exception("Password cannot be empty");
            if (DateBirth == null)
                throw new Exception("DateBirth cannot be empty");
            if (Position == null)
                throw new Exception("Position cannot be empty");
            if (string.IsNullOrEmpty(Gender))
                throw new Exception("Gender cannot be empty");
            if (string.IsNullOrEmpty(TypeWorkerByLocation))
                throw new Exception("Type worker by location cannot be empty");
        }
        public void LoadData(Employee employee)
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Patronymic = employee.Patronymic;
            DateBirth = employee.DateBirth;
            Position = employee.Position;
            Gender = employee.Gender;
            PathToPhoto = employee.PathToPhoto;
            if (Gender == "Male")
            {
                IsMale = true;
                IsFemale = false;
            }
            else
            {
                IsFemale = true;
                IsMale = false;
            }
            TypeWorkerByLocation = employee.TypeWorkerByLocation;
            if (TypeWorkerByLocation == "Office worker")
            {
                IsOfficeWorker = true;
                IsRemoteWorker = false;
            }
            else
            {
                IsRemoteWorker = true;
                IsOfficeWorker = false;
            }
        }
        private void LoadEmployeePositions()
        {
            Positions = new List<Position>(); 

            var positions = App.Database.Positions.ToList();
            foreach(Position position in positions)
            {
                Positions.Add(position);
            }    
        }
        public void CopyFileToPhotoDirectory(Employee employee)
        {
            try
            {
                string newPathToPhoto = (App.PathToPhotoDirectory + $"/icon{employee.Id}" + Path.GetExtension(employee.PathToPhoto));
                File.Copy(employee.PathToPhoto, newPathToPhoto, true);
                employee.PathToPhoto = newPathToPhoto;
                App.Database.Employees.Update(employee);
                App.Database.SaveChanges();
            }
            catch (Exception exception)
            {
                return;
            }
        }
        public void OpenFileDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "JPG | *.jpg | JPEG | *.jpeg | PNG | *.png | All | *";
            fileDialog.DefaultExt = "JPG | *.jpg ";
            bool? fileDialogOk = fileDialog.ShowDialog();
            if (fileDialogOk == true)
            {
                PathToPhoto = fileDialog.FileName;
            }
        }
    }
}
