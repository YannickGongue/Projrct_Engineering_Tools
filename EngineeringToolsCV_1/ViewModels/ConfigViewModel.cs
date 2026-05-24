using EngineeringToolsCV_1.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.ViewModels
{
    public class ConfigViewModel : ViewModelBase
    {
        private NavigationStore navigationStore;

        public ConfigViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }
    }
}
