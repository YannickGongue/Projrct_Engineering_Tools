using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Repositories;
using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.Views;

namespace EngineeringToolsCV_1.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
       
        private string username;
        private string passwort;
        private string confirmPassword;
        private string emailAdresse;
        private LoginViewModel VmLogin;
        private DbManager _DbManager;
        private MUser mUser;
        private DBName _dbname;
        private ErrorMessageViewModel dialogMessage;
        private MessageDialog _DialogView;

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.username = value;
                this.OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return this.passwort;
            }

            set
            {
                this.passwort = value;
                this.OnPropertyChanged(nameof(Password));
            }
        }

        public string ConfirmPassword
        {
            get
            {
                return this.confirmPassword;
            }

            set
            {
                this.confirmPassword = value;
                this.OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public string EmailAdress
        {
            get
            {
                return this.emailAdresse;
            }

            set
            {
                this.emailAdresse = value;
                this.OnPropertyChanged(nameof(EmailAdress));
            }
        }

        public ICommand regCommand { get; }
        public ICommand CancelCommand { get; }

        public RegisterViewModel(LoginViewModel _vmLogin, MUser _mUser, DbManager dbManager, DBName dbname, ErrorMessageViewModel dialogMessage)
        {
            this.mUser = _mUser;
            this._DbManager = dbManager;
            this._dbname = dbname;
            this.VmLogin = _vmLogin;
            this.dialogMessage = dialogMessage;
            this._DialogView = new MessageDialog();
            this.regCommand = new DelegateCommand( regExecut, CanExecute);
            this.CancelCommand = new DelegateCommand(CancelExecut, CanExecute);

        }

        private async void regExecut(object obj)
        {                 
            this.mUser.User_Id = this.Username;
            this.mUser.Email = this.EmailAdress;
            this.mUser.Passwort = this.Password;
            this.mUser.ConfirmPasswort = this.ConfirmPassword;     

            // Bestätigung der Passwort.
            if (mUser.Passwort == mUser.ConfirmPasswort)
            {
                //sind die Datensätze eingefügt?
                if (await this._DbManager.AddUserInfo(this.mUser) == 1)
                {
                    this.dialogMessage.SetErrorMessage = "die Einträgen wurden erfolgreich in die Datenbank hinzugefügt";
                    this._DialogView.DataContext = this.dialogMessage;
                    this._DialogView.Show();
                }
            }
            else
            {
                this.dialogMessage.SetErrorMessage= "Die Passwort stimmen nicht überein";
                this._DialogView.DataContext = this.dialogMessage;
                this._DialogView.Show();
            }
        }

        private void CancelExecut(object obj)
        {
            
        }

        private bool CanExecute(object obj)
        {
            return true;
        }

       
    }
}
