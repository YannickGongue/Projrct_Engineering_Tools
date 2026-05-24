using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Media;

namespace EngineeringToolsCV_1.ViewModels
{
    public class NewPassordViewModel : INotifyPropertyChanged
    {
        private UserResetViewModel _vmUserReset;

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

        public NewPassordViewModel()
        {
            //this._vmUserReset = vmUserReset;
            //this._vmUserReset.SetIsEnabled = true;
            //this._vmUserReset.SetBackground = Brushes.RoyalBlue;


        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, e);
        }
    }
}
