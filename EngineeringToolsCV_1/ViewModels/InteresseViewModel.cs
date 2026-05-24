using EngineeringToolsCV_1.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.ViewModels
{
    public class InteresseViewModel : ViewModelBase
    {
        private NavigationStore navigationStore;

        public InteresseViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }
    }
}
