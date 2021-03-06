﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseTaskManager.Models
{
    public class Employee : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName
        {
            get => _firsName;
            set
            {
                if (_firsName == value)
                    return;
                _firsName = value;
                OnPropertyChanged("FirstName");
            }
        }
        private string _firsName;
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
                OnPropertyChanged("LastName");
            }
        }
        private string _patronymic;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string FullName => $"{FirstName} {LastName}";
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
        private DateTime _dateBirth;
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
        public string Login
        {
            get => _login;
            set
            {
                if (_login == value)
                    return;
                _login = value;
                OnPropertyChanged("Login");
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
        public List<TaskEmployee> TaskEmployee { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Employee()
        {
            TaskEmployee = new List<TaskEmployee>();
        }
        public Employee(string firstName, string lastName, string patronymic, DateTime dateBirth, string pathToPhoto, Position position, string typeWorkerByLocation, string gender, string login, string password )
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            DateBirth = dateBirth;
            PathToPhoto = pathToPhoto;
            Position = position;
            TypeWorkerByLocation = typeWorkerByLocation;
            Gender = gender;
            Login = login;
            Password = password;
            TaskEmployee = new List<TaskEmployee>();
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public override string ToString() => $"{FirstName} {LastName} {Patronymic}";
    }
}
