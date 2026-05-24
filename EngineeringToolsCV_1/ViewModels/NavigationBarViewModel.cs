using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private string setFormat;
        public string SetFormat
        {
            get
            {
                return setFormat;
            }

            set
            {
                setFormat = value;
                OnPropertyChanged(nameof(SetFormat));
            }
        }

        public NavigationBarViewModel(string setFormat)
        {
            SetFormat = setFormat;
        }
    }
}
