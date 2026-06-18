using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace EngineeringToolsCV_1.ViewModels
{
    public class NewPassordViewModel : INotifyPropertyChanged
    {
        private UserResetViewModel _vmUserReset;
        private IUserInfo _IuserInfo;
        private IMessageService _messageService;

		  private string strBenutzername;
        private string strPassword;
        private string strPasswordConfirm;
        private bool setActveWindow;

        public string StrBenutzname
        {
            get { return this.strBenutzername; }
            set
            {
                this.strBenutzername = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(StrBenutzname)));
            }
        }

        public string StrPassword
        {
            get { return this.strPassword; }
            set
            {
                this.strPassword = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(StrPassword)));
            }
        }

        public string StrPasswordConfirm
        {
            get { return this.strPasswordConfirm; }
            set
            {
                this.strPasswordConfirm = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(StrPasswordConfirm)));
            }
        }
        public bool SetActivedWindow
        {

            get { return this.setActveWindow; }
            set
            {
                if (this.setActveWindow != value)
                {
                    this.setActveWindow = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(SetActivedWindow)));
                }
            }
        }

        public ICommand OnResetCommand { get; set; }

		public NewPassordViewModel( IUserInfo userInfo,
                                  IMessageService messageService)
        {
            this._IuserInfo = userInfo;
            this._messageService = messageService;
			

			this.OnResetCommand = new DelegateCommand(ExecuteReset, CanExecute);
		}

		private bool CanExecute(object arg)
		{
			return true;
		}

		private async void ExecuteReset(object obj)
		{
         if( await this._IuserInfo.UpdateUserInfosAsync(this.strBenutzername, this.strPassword))
         {
            this._messageService.ShowErrorMessage("Passwort erfolgreich geändert!");
			}
      }

		public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, e);
        }
    }
}
