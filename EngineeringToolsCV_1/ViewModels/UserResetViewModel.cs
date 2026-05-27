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

		  public UserResetViewModel(IUserInfo userInfo, MUser mUser)
        {
            this._userInfo = userInfo;
			   this._mUser = mUser;
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
            this.dt = new DataTable();
			   this.SetBackground = Brushes.AliceBlue;
            this.SetIsEnabled = false;
             dt =   await this._userInfo.SearchUserInfoAsync(this.SetEmail);
            if (dt.Rows.Count > 0)
            {
                this._vmNewPassword.StrBenutzname = dt.Rows[0]["User_Id"].ToString();
                this._vmNewPassword.StrPassword = dt.Rows[0]["Passwort"].ToString();
            }
            this.newPassword = new NewPassword();
            this.newPassword.DataContext = this._vmNewPassword;
            this.newPassword.Show();
            
        }
    }
}
