using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.Views
{
    public class LayoutNavigationService<TViewModel> : INavigateService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly NavigationBarViewModel _NavigationBarViewModel;

        public LayoutNavigationService(NavigationStore navigationStore,
                                       Func<TViewModel> createViewModel,
                                       NavigationBarViewModel navigationBarViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _NavigationBarViewModel = navigationBarViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModels = new LayoutViewModel(_NavigationBarViewModel, _createViewModel());
        }
    }
}
