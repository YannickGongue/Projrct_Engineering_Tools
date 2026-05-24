using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.Service
{
    public class NavigateService<TViewModel>  where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigateService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModels = _createViewModel();
        }

    }
}
