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
        private IFileDialogService _FiledialogService;
		  private INavigationBarService _navigationBarService;
		  private IMessageService _messageService;
		  private IStudentInfo _StudentInfo;
		  private IStudentWorkInfo _StudentWorkInfo;
		  private MStudentWorkInfo _mStudentWorkInfo;
		  private MStudentInformations _mStudentInformations;
        private MUser _mUser;
        private IImageService _imageService;
        private IUserInfo _userInfo;




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
                             IMessageService messageService,
                             INavigationBarService navigationBarService,
                             IStudentInfo studentInfo,
                             IStudentWorkInfo studentWorkInfo,
                             MStudentInformations mStudentInformations,
                             MStudentWorkInfo mStudentWorkInfo,
                             IImageService imageService,
                             IUserInfo userInfo,
                             MUser mUser,
                             IFileDialogService fileDialogService)
        {
			  this._messageService = messageService;
			  this._navigationBarService = navigationBarService;
			  this._StudentInfo = studentInfo;
			  this._StudentWorkInfo = studentWorkInfo;
			  this._mStudentInformations = mStudentInformations;
			  this._mStudentWorkInfo = mStudentWorkInfo;
			  this._imageService = imageService;
			  this._userInfo = userInfo;
			  this._mUser = mUser;
			  this._FiledialogService = fileDialogService;

            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(
                new LayoutNavigationService<LoginViewModel>(navigationStore,
                () => new LoginViewModel(navigationStore,
                                         this._navigationBarService,
                                         this._messageService,
                                         this._imageService,
                                         this._StudentInfo,
                                         this._StudentWorkInfo,
                                         this._userInfo,
                                         this._FiledialogService,
													  this._mUser,
                                         this._mStudentInformations,
                                         this._mStudentWorkInfo ),
                this._navigationBarService.CreateNavigationBar("Home")));
        }
    }
}
