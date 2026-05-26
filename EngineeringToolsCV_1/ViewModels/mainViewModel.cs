using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Language;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace EngineeringToolsCV_1.ViewModels
{
    public class mainViewModel : ViewModelBase
    {
        private bool setEnable;
        private NavigationStore _navigationstore;
        private NavigationBarViewModel _NavigationBar;
        private HomeViewModel homeViewModel;
        private ObservableCollection<Culture> cultureList;
        private Culture selectedCulture;
        private MUser _mUser;
	     private INavigationBarService _navigationBarService;
	     private IDialogService _dialogService;
	     private IMessageService _messageService;
	     private IStudentInfo _StudentInfo;
	     private IStudentWorkInfo _StudentWorkInfo;
	     private MStudentWorkInfo _mStudentWorkInfo;
	     private MStudentInformations _mStudentInformations;
	     private IImageService _imageService;
        private IUserInfo _userInfo;


		//add a SelectedCulture property
		public Culture SelectedCulture
        {
            get
            {
                return this.selectedCulture;
            }
            set
            {
                this.selectedCulture = value;
                OnPropertyChanged(nameof(SelectedCulture));
            }
        }

        public ObservableCollection<Culture> CultureList
        {
            get
            {
                return this.cultureList;
            }
            set
            {
                this.cultureList = value;
                OnPropertyChanged(nameof(CultureList));
            }
        }
           
        public bool SetEnable
        {
            get
            {
                return this.setEnable;
            }

            set
            {
                this.setEnable = value;
                OnPropertyChanged(nameof(SetEnable));
            }
        }

        public ICommand HomeNavigationCommand { get; set; }
        public ViewModelBase CurrentViewModels => _navigationstore.CurrentViewModels;

        public mainViewModel(NavigationStore navigationStore,
									  IImageService imageService,
									  INavigationBarService navigationBarService,
									  IDialogService dialogService,
									  IMessageService messageService,
									  IStudentInfo studentInfo,
									  MStudentInformations mStudent, 
                             MUser mUser,
                             MStudentWorkInfo mStudentWorkInfo,
                             IUserInfo userInfo)
        {
            this._navigationstore = navigationStore;
            this._messageService = messageService;
			   this._dialogService = dialogService;
			   this._navigationBarService = navigationBarService;
			   this._imageService = imageService;
			   this._StudentInfo = studentInfo;
			   this._mStudentInformations = mStudent;
            this._mUser = mUser;
            this._mStudentWorkInfo = mStudentWorkInfo;
            this._userInfo = userInfo;

            this.executeCommand(navigationStore);

            cultureList = new ObservableCollection<Culture>()
            {
               new Culture() { Name = "Deutsche", Id = "de-DE"  },
               new Culture() { Name = "English", Id = "en-US" },
               new Culture() { Name = "Französisch", Id = "fr-FR" }
            };

            var culture = CultureList[0];
            SelectedCulture = culture;

            _navigationstore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
    
        private void executeCommand(NavigationStore navigationStore)
        {          
            if(navigationStore.CurrentViewModels.Equals(homeViewModel))
            {
                this.SetEnable = false;
            }
            else
            {
                this.SetEnable = true;
                HomeNavigationCommand = new NavigateCommand<HomeViewModel>(
                                        new LayoutNavigationService<HomeViewModel>(navigationStore,
                                        () => new HomeViewModel(navigationStore,
																					 this._messageService,
																					 this._navigationBarService,
																					 this._StudentInfo,
                                                                this._StudentWorkInfo,
																					 this._mStudentInformations,                                                          
                                                                this._mStudentWorkInfo,
                                                                this._imageService,
                                                                this._userInfo,
                                                                this._mUser),
                                        this._navigationBarService.CreateNavigationBar("Home")));
            }
           
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModels));
        }

    }
}