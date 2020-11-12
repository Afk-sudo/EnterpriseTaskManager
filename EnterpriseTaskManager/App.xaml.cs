using EnterpriseTaskManager.Models;
using EnterpriseTaskManager.ViewModels.ModalWindow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EnterpriseTaskManager
{
    public partial class App : Application
    {
        public static ApplicationContext Database { get; private set; }
        public const string NAME_PHOTO_DIRECOTY = "Photos";
        public static string PathToPhotoDirectory { get; private set; }
        public static MainViewModel MainViewModel { get; private set; }
        public App()
        {
            ConnectDatabase();

            //Creating directory where saving photos if not exists
            PathToPhotoDirectory = Path.Combine(Environment.CurrentDirectory, NAME_PHOTO_DIRECOTY);
            if (Directory.Exists(PathToPhotoDirectory) == false)
                Directory.CreateDirectory(PathToPhotoDirectory);
            MainViewModel = new MainViewModel();
        }
        private void ConnectDatabase()
        {
            // Creating config object 
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsetings.json");
            var config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            // Creating context options 
            var optionsBulder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBulder.UseMySql(connectionString).Options;

            //Connecting database
            Database = new ApplicationContext(options);
        }

    }
}
