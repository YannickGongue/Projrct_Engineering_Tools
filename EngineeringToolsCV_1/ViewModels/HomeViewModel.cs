using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.IRepository;
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
		  private IStudentInfo _StudentInfo;
		  private IStudentWorkInfo _StudentWorkInfo;
		  private MStudentWorkInfo _mStudentWorkInfo;
		  private MStudentInformations _mStudentInformations;
        private IImageService _imageService;




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
                             INavigationBarService navigationBarService,
                             IStudentInfo studentInfo,
                             IStudentWorkInfo studentWorkInfo,
                             MStudentInformations mStudentInformations,
                             MStudentWorkInfo mStudentWorkInfo,
                             IImageService imageService)
        {
            
           this._authenticationService = authenticationService;
			  this._dialogService = dialogService;
			  this._messageService = messageService;
			  this._navigationBarService = navigationBarService;
			  this._StudentInfo = studentInfo;
			  this._StudentWorkInfo = studentWorkInfo;
			  this._mStudentInformations = mStudentInformations;
			  this._mStudentWorkInfo = mStudentWorkInfo;
			  this._imageService = imageService;

            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(
                new LayoutNavigationService<LoginViewModel>(navigationStore,
                () => new LoginViewModel(navigationStore,
                                         this._dialogService,
                                         this._authenticationService,
                                         this._navigationBarService,
                                         this._messageService,
                                         this._imageService,
                                         this._StudentInfo,
                                         this._StudentWorkInfo,
                                         this._mStudentInformations,
                                         this._mStudentWorkInfo),
                this._navigationBarService.CreateNavigationBar("Home")));
        }
    }
}
