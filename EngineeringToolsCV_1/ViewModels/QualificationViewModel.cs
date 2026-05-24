using EngineeringToolsCV_1.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.ViewModels
{
    public class QualificationViewModel : ViewModelBase
    {
        private NavigationStore navigationStore;

        public QualificationViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }
    }
}
