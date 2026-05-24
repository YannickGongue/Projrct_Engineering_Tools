using EngineeringToolsCV_1.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.ViewModels
{
    public class FormationViewModel : ViewModelBase
    {
        private NavigationStore navigationStore;

        public FormationViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }
    }
}
