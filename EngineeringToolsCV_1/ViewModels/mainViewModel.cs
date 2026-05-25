using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.Language;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.Views;
using EngineeringToolsCV_1.DatabaseManager;

namespace EngineeringToolsCV_1.ViewModels
{
    public class mainViewModel : ViewModelBase
    {
        private bool setEnable;
        private ErrorMessageViewModel _vmDialogMessage;
        private UserResetView _userResetView;
        private RegisterViewModel _userRegister;
        private UserResetViewModel _vmUserReset;
        private NavigationStore _navigationstore;
        private NavigationBarViewModel _NavigationBar;
        private HomeViewModel homeViewModel;
        private ObservableCollection<Culture> cultureList;
        private Culture selectedCulture;
        private MStudentInformations _mStudent;
        private MUser _mUser;
        private DbManager _dbManager;
        private DBName _dbName;
        private MStudentWorkInfo _mUserWorkInfo;


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
                             RegisterViewModel userRegister,
                             UserResetViewModel vmUserReset, 
                             MStudentInformations mStudent, 
                             MUser mUser,
                             DbManager dbManager,
                             DBName dbName,
                             ErrorMessageViewModel vmDialogMessage,
                             MStudentWorkInfo mUserWorkInfo)
        {
            this._navigationstore = navigationStore;
            this._userRegister = userRegister;
            this._vmUserReset = vmUserReset;
            this._mStudent = mStudent;
            this._mUser = mUser;
            this._dbManager = dbManager;
            this._dbName = dbName;
            this._vmDialogMessage = vmDialogMessage;
            this._mUserWorkInfo = mUserWorkInfo;

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
            _NavigationBar = new NavigationBarViewModel("Home");
          
            if(navigationStore.CurrentViewModels.Equals(homeViewModel))
            {
                this.SetEnable = false;
            }
            else
            {
                this.SetEnable = true;
                HomeNavigationCommand = new NavigateCommand<HomeViewModel>(
                                        new LayoutNavigationService<HomeViewModel>(navigationStore,
                                        () => new HomeViewModel(navigationStore, this._userRegister,this._vmUserReset,this._mStudent, this._mUser,this._dbManager,this._dbName,this._vmDialogMessage,this._mUserWorkInfo), _NavigationBar));
            }
           
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModels));
        }

    }
}