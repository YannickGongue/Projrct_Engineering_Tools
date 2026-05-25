using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Repositories;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.Views;

namespace EngineeringToolsCV_1.ViewModels
{
    public class LoginViewModel : ViewModelBase
    { 
        private IAuthenticationService _authenticationService;
        private INavigationBarService _navigatinBarService;
        private IDialogService _dialogService;
        private IMessageService _messageService;
        private IImageService _imageService;
        private IStudentInfo _StudentInfo;
        private IStudentWorkInfo _StudentWorkInfo;
		  private MStudentWorkInfo _mStudentWorkInfo;
        private MStudentInformations _mStudentInformations;
		  private string password;
        private string username;
       
        private bool setActivedWindow;
        private bool userResetEnabled;


        public ViewModelCommand NavigateLoginCommand { get; }
        public ICommand RegisterCommand { get; set; }
        public ICommand UserResetCommand { get; set; }


        public bool UserResetEnabled
        {
            get { return this.userResetEnabled; }
            set
            {
                if (this.userResetEnabled != value)
                {
                    this.userResetEnabled = value;
                    this.OnPropertyChanged(nameof(UserResetEnabled));
                }
            }
        }

        public bool SetActivedWindow
        {
            get { return this.setActivedWindow; }
            set
            {
                if (this.setActivedWindow != value)
                {
                    this.setActivedWindow = value;
                    this.OnPropertyChanged(nameof(SetActivedWindow));
                }
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel(NavigationStore navigateStore,
                              IDialogService dialogService,
										IAuthenticationService authenticationService,
										INavigationBarService navigationBarService,
                              IMessageService messageService,
                              IImageService imageService,
                              IStudentInfo studentInfo,
                              IStudentWorkInfo studentWorkInfo,
                              MStudentInformations mStudentInformations,
                              MStudentWorkInfo mStudentWorkInfo)
        {
            this._authenticationService = authenticationService;
			   this._navigatinBarService = navigationBarService;
			   this._dialogService = dialogService;
			   this._messageService = messageService;
			   this._imageService = imageService;
            this._StudentInfo = studentInfo;
			   this._StudentWorkInfo = studentWorkInfo;
			   this._mStudentInformations = mStudentInformations;
			   this._mStudentWorkInfo = mStudentWorkInfo;

			   this.Username = "gonguego";
            this.Password = "dyna1605";

            this.SetActivedWindow = true;
            this.UserResetEnabled = true;

            this.NavigateLoginCommand = new NavigateLoginCommand(
                                        new LayoutNavigationService<ProfilViewModel>(navigateStore,
                                        () => new ProfilViewModel(navigateStore,
                                                                  this._navigatinBarService, 
                                                                  this._messageService,
                                                                  this._imageService,
                                                                  this._StudentInfo,
                                                                  this._mStudentInformations,
                                                                  this._StudentWorkInfo,
                                                                  this._mStudentWorkInfo), 
                                        this._navigatinBarService.CreateNavigationBar("Home -> Profil")),
                                        this._messageService, this._authenticationService);

            this.RegisterCommand = new DelegateCommand(ExecuteRegister, CanExecute);
            this.UserResetCommand = new DelegateCommand(ExecuteUserReset, CanExecute);
        }

        private async void ExecuteUserReset(object obj)
        {       
          var dt = await this._authenticationService.LoginAsync();
          this._dialogService.ShowResetPassword(dt);
          this.UserResetEnabled = false;
                     
        }

        private bool CanExecute(object obj)
        {
            return true;
        }

        private void ExecuteRegister(object obj)
        {
            this.SetActivedWindow = false;
                                  
        }
    }
}
