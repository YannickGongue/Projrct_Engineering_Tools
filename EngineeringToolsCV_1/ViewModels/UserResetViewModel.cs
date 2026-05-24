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

namespace EngineeringToolsCV_1.ViewModels
{
    public class UserResetViewModel : ViewModelBase
    {
        private NewPassordViewModel _vmNewPassword;
        private MUser _mUser;
        private DbManager _dbManager;
        private DBName _dbName;
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

		public UserResetViewModel(NewPassordViewModel vmNewPassword, DbManager dbManager, DBName dbName, MUser mUser)
        {
            this._vmNewPassword = vmNewPassword;
            this._dbManager = dbManager;
            this._dbName = dbName;
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
           
            this.SetBackground = Brushes.AliceBlue;
            this.SetIsEnabled = false;
            var dtTable = await this._dbManager.GetUserInfoAsync(this._mUser.Id, this._mUser.Passwort);
            if (dtTable.Rows.Count > 0)
            {
                this._vmNewPassword.StrBenutzname = dtTable.Rows[0][this._dbName.strId].ToString();
                this._vmNewPassword.StrPassword = dtTable.Rows[0][this._dbName.StrPasswort].ToString();
            }
            this.newPassword = new NewPassword();
            this.newPassword.DataContext = this._vmNewPassword;
            this.newPassword.Show();
            
        }
    }
}
