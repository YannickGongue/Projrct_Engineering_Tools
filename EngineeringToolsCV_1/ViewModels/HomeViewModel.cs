using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EngineeringToolsCV_1.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private INavigationBarService _navigationBarService;
        private IDialogService _dialogService;
		  private IMessageService _messageService;
        private IAuthenticationService _authenticationService;




		private string displayedImagePath = @"C:\Users\vamic\source\repos\EngineeringToolsCV_1\EngineeringToolsCV_1\Images\job-portfolio.png"; 
        public ICommand NavigateLoginCommand { get; }
       
        public string DisplayedImagePath
        {
            get { return this.displayedImagePath; }
            set 
            { 
                this.displayedImagePath = value;
                OnPropertyChanged(nameof(DisplayedImagePath));
            }
        }

        public HomeViewModel(NavigationStore navigationStore,
                             IAuthenticationService authenticationService,
                             IDialogService dialogService,
                             IMessageService messageService,
                             INavigationBarService navigationBarService)
        {
            
           this._authenticationService = authenticationService;
			this._dialogService = dialogService;
			this._messageService = messageService;
			this._navigationBarService = navigationBarService;


            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(
                new LayoutNavigationService<LoginViewModel>(navigationStore,
                () => new LoginViewModel(navigationStore,
                                         this._dialogService,
                                         this._authenticationService,
                                         this._navigationBarService,
                                         this._messageService),
                this._navigationBarService.CreateNavigationBar("Home")));
        }
    }
}
