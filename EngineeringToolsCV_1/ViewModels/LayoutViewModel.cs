using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace EngineeringToolsCV_1.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
       private string setDate;

       private string userEmail;
       public ViewModelBase ContentViewModels { get; }       
       public NavigationBarViewModel NAvigationBarViewModel { get; }

        public string StrDate
        {
            get
            {
                return setDate;
            }

            set
            {
                setDate = value;
                OnPropertyChanged(nameof(StrDate));
            }
        }

        public string StrUserEmail
        {
            get
            {
                return this.userEmail;
            }

            set
            {
                this.userEmail = value;
                OnPropertyChanged(nameof(StrUserEmail));
            }
        }

        public LayoutViewModel(NavigationBarViewModel navigationBar, ViewModelBase contentViewModel)
        {
            ContentViewModels = contentViewModel;
            NAvigationBarViewModel = navigationBar;
            this.StrDate = DateTime.Now.ToString();
        }
       
    }
}
