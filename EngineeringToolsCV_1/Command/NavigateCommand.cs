using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.Command
{
    public class NavigateCommand<TViewModel> : ViewModelCommand where TViewModel : ViewModelBase
    {

        private readonly INavigateService<TViewModel> _navigateService;

        public NavigateCommand(INavigateService<TViewModel> navigateService)
        {
            _navigateService = navigateService;
        }

        public override void Execute(object parameter)
        {
            _navigateService.Navigate();
        }
    }
}
