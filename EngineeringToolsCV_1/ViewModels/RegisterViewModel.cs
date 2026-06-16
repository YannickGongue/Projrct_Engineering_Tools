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
using EngineeringToolsCV_1.Service;

namespace EngineeringToolsCV_1.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
       
        private string username;
        private string passwort;
        private string confirmPassword;
        private string emailAdresse;
        private LoginViewModel VmLogin;
        private MUser mUser;
        private IMessageService _messageService;
        private IUserInfo _userInfo;
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

        public RegisterViewModel(LoginViewModel _vmLogin, 
                                 MUser _mUser, 
                                 IUserInfo userInfo,
                                 IMessageService messageService)
        {
            this._userInfo = userInfo;
            this._messageService = messageService;
			   this.mUser = _mUser;
            this.VmLogin = _vmLogin;
            this.regCommand = new DelegateCommand( regExecut, CanExecute);
            this.CancelCommand = new DelegateCommand(CancelExecut, CanExecute);

        }

        private async void regExecut(object obj)
        {                 
            this.mUser.User_Id = this.Username;
            this.mUser.Email = this.EmailAdress;
            this.mUser.Passwort = this.Password;

            // Bestätigung der Passwort.
            if (mUser.Passwort == this.ConfirmPassword)
            {
                //sind die Datensätze eingefügt?
                if (await this._userInfo.AddUserInfoAsync(this.mUser) == 1)
                {
                    this._messageService.ShowErrorMessage("die Einträgen wurden erfolgreich in die Datenbank hinzugefügt");
                }
            }
            else
            {
                this._messageService.ShowErrorMessage("Die Passwort stimmen nicht überein");
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
