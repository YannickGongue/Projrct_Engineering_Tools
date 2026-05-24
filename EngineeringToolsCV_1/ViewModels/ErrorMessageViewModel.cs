using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.ViewModels
{
    public class ErrorMessageViewModel : ViewModelBase
    {
        private string setErrorMessage;

        public string SetErrorMessage
        {
            get
            {
                return this.setErrorMessage;
            }

            set
            {
                this.setErrorMessage = value;
                OnPropertyChanged(nameof(SetErrorMessage));
            }
        }      
    }
}
