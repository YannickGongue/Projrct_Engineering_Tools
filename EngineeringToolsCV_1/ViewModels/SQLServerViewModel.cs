using EngineeringToolsCV_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace EngineeringToolsCV_1.Views
{
    public class SQLServerViewModel : ViewModelBase
    {
        private ObservableCollection<string> listServerTyp;
        private ObservableCollection<string> listServerName;
        private ObservableCollection<string> listAuthentifizierung;
        private ObservableCollection<string> listOfDatabase;

        private string username;
        private string passwort;
        private bool setUsernameEnable;
        private bool setPasswortEnable;

        public ObservableCollection<string> ListServerTyp
        {
            get
            {
                return this.listServerTyp;
            }

            set
            {
                this.listServerTyp = value;
                OnPropertyChanged(nameof(ListServerTyp));
            }
        }

        public ObservableCollection<string> ListServerName
        {
            get
            {
                return this.listServerName;
            }

            set
            {
                this.listServerName = value;
                OnPropertyChanged(nameof(ListServerName));
            }
        }

        public ObservableCollection<string> ListAuthentifizierung
        {
            get
            {
                return this.listAuthentifizierung;
            }

            set
            {
                this.listAuthentifizierung = value;
                OnPropertyChanged(nameof(ListAuthentifizierung));
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Passwort
        {
            get
            {
                return this.passwort;
            }

            set
            {
                this.passwort = value;
                OnPropertyChanged(nameof(Passwort));
            }
        }

        public bool SetPasswortEnable
        {
            get
            {
                return this.setPasswortEnable;
            }

            set
            {
                this.setPasswortEnable = value;
                OnPropertyChanged(nameof(SetPasswortEnable));
            }
        }

        public bool SetUsernameEnable
        {
            get
            {
                return this.setUsernameEnable;
            }

            set
            {
                this.setUsernameEnable = value;
                OnPropertyChanged(nameof(SetUsernameEnable));
            }
        }

        public ObservableCollection<string> ListOfDatabases
        {
            get
            {
                return this.listOfDatabase;
            }

            set
            {
                this.listOfDatabase = value;
                OnPropertyChanged(nameof(ListOfDatabases));
            }
        }

        public  string ConnectionString { get; set; }


        public SQLServerViewModel()
        {
            this.ListServerTyp = new ObservableCollection<string>
            {
                "Datenbank Engine",
                "Analysis Service",
                "Reporting Service",
                "Integration Service"
            };

            this.ListAuthentifizierung = new ObservableCollection<string>
            {
                "Windows Authentication",
                "SQl Server Authentication"
            };

            this.ListServerName = new ObservableCollection<string>
            {
                ".",
                "(local)",
                @".\SQLEXPRESS",
                string.Format(@"{0}\SQLEXPRESS",Environment.MachineName),
                @"(localdb)\MSSQLLocalDB"
            };

            ListOfDatabases = new ObservableCollection<string>();

            this.SetUsernameEnable = false;
            this.SetPasswortEnable = false;
        }
    }
}
