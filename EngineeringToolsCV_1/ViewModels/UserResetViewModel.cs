using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.Models;
using System.Data;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Service;

namespace EngineeringToolsCV_1.ViewModels
{
    public class UserResetViewModel : ViewModelBase
    {
        private IUserInfo _userInfo;
        private IMessageService _messageService;
		  private NewPassordViewModel _vmNewPassword;
        private MUser _mUser;
        private DataTable dt;
        private NewPassword newPassword;
        private string setEmail;
        private bool setIsEnabled;
        private Brush setBackground;

        public Brush SetBackground
        {
            get
            {
                return this.setBackground;
            }
            set
            {
                this.setBackground = value;
                this.OnPropertyChanged(nameof(this.SetBackground));
            }
        }

        public bool SetIsEnabled
        {
            get
            {
                return this.setIsEnabled;
            }
            set
            {
                this.setIsEnabled = value;
                this.OnPropertyChanged(nameof(this.SetIsEnabled));
            }
        }

        public string SetEmail
        {
            get
            {
                return this.setEmail;
            }
            set
            {
                this.setEmail = value;
                this.OnPropertyChanged(nameof(this.SetEmail));
            }
        }

        public ICommand OnSearchCommand { get; set; }
        public ICommand OnResetCommand { get; set; }  

		  public UserResetViewModel(IUserInfo userInfo,
											 IMessageService messageService,
											 MUser mUser)
        {
            this._userInfo = userInfo;
			   this._mUser = mUser;
			   this._messageService = messageService;
			   this.SetBackground = Brushes.RoyalBlue;
            this.setIsEnabled = true;
            OnSearchCommand = new DelegateCommand(ExecuteSearchEmail, CanExecute);
            OnResetCommand = new DelegateCommand(ExecuteResetPassword, CanExecute); 
		}

		private void ExecuteResetPassword(object obj)
		{
			throw new NotImplementedException();
		}

		private bool CanExecute(object obj)
        {
            return true;
        }

        private async void ExecuteSearchEmail(object obj)
        {
			   this.SetBackground = Brushes.AliceBlue;
            this.SetIsEnabled = false;

            this._mUser =   await this._userInfo.SearchUserInfoAsync(this.SetEmail);
            this._vmNewPassword = new NewPassordViewModel(this._userInfo, this._messageService);
			   if (this._mUser != null)
            {
                this._vmNewPassword.StrBenutzname = this._mUser.User_Id;
                this._vmNewPassword.StrPassword = this._mUser.Passwort;
            }
            this.newPassword = new NewPassword();
            this.newPassword.DataContext = this._vmNewPassword;
            this.newPassword.Show();
            
        }
    }
}
