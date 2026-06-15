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
		 private IFileDialogService _FiledialogService;
		 private INavigationBarService _navigatinBarService;
        private IMessageService _messageService;
        private IImageService _imageService;
        private IStudentInfo _StudentInfo;
        private IStudentWorkInfo _StudentWorkInfo;
		  private IUserInfo _userInfo;
        private MUser _mUser;

		  private MStudentWorkInfo _mStudentWorkInfo;
        private MStudentInformations _mStudentInformations;
		  private RegisterView register;
		  private UserResetView _UserResetView;
		  private RegisterViewModel _vmRegister;
		  private UserResetViewModel _vmUserReset;
        private DBName _dbName;
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
										INavigationBarService navigationBarService,
                              IMessageService messageService,
                              IImageService imageService,
                              IStudentInfo studentInfo,
                              IStudentWorkInfo studentWorkInfo,
                              IUserInfo userInfo,
                              IFileDialogService fileDialogService,
                              MUser mUser,
										MStudentInformations mStudentInformations,
                              MStudentWorkInfo mStudentWorkInfo)
        {
			   this._navigatinBarService = navigationBarService;
			   this._messageService = messageService;
			   this._imageService = imageService;
            this._StudentInfo = studentInfo;
			   this._StudentWorkInfo = studentWorkInfo;
			   this._mStudentInformations = mStudentInformations;
			   this._mStudentWorkInfo = mStudentWorkInfo;
			   this._userInfo = userInfo;
			   this._mUser = mUser;
            this._FiledialogService = fileDialogService;

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
                                                                  this._FiledialogService,
																						this._mStudentInformations,
                                                                  this._StudentWorkInfo,
                                                                  this._mStudentWorkInfo), 
                                        this._navigatinBarService.CreateNavigationBar("Home -> Profil")),
                                        this._messageService,
                                        this._userInfo,
                                        this);

            this.RegisterCommand = new DelegateCommand(ExecuteRegister, CanExecute);
            this.UserResetCommand = new DelegateCommand(ExecuteUserReset, CanExecute);
        }

        private async void ExecuteUserReset(object obj)
        {       
           this._mUser = await this._userInfo.GetUserInfoAsync(Username, Password);
          this._dbName = new DBName();
			 this._UserResetView = new UserResetView();
          this._vmUserReset = new UserResetViewModel(this._userInfo, this._mUser);
          this._vmUserReset.SetEmail= this._mUser.Email;
			 this._UserResetView.DataContext = this._vmUserReset;
			 this._UserResetView.Show();

			this.UserResetEnabled = false;
                     
        }

        private bool CanExecute(object obj)
        {
            return true;
        }

        private void ExecuteRegister(object obj)
        {
			  this.register = new RegisterView(this);
			this._vmRegister = new RegisterViewModel(this, this._mUser, this._userInfo,this._messageService);
			   this.register.DataContext = this._vmRegister;
            this.register.Show();
			  this.SetActivedWindow = false;
                                  
        }
    }
}
