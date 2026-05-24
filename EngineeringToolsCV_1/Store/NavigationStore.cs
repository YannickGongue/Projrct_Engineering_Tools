using EngineeringToolsCV_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.Store
{
    public class NavigationStore : ViewModelBase
    {
        public event Action CurrentViewModelChanged;

        private ViewModelBase currentViewModel ;

        public ViewModelBase CurrentViewModels
        {
            get
            {
                return this.currentViewModel;
            }

            set
            {
                this.currentViewModel = value;              
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
