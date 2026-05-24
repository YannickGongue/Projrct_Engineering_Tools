using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Repositories;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using Microsoft.Win32;
using EngineeringToolsCV_1.DatabaseManager;
using System.Data;

namespace EngineeringToolsCV_1.ViewModels
{
    public class InformationViewModel : ViewModelBase
    {
		  private string ImagePath;
        private IImageService _imageService;
        private IMessageService _messageService;
        private INavigationBarService _navigationBarService;
		  private readonly IUserInfo _userInfo;

		private MStudentInformations _mStudentInfos;

        private string strTitle;
        private string strName;
        private string strVorname;
        private string strEmail;
        private string strStraße;
        private string strPostleitzahl;
        private string strNummer;
        private string strLand;

        private string selectedCity;
        private DateTime strDate;
        private Brush colorTitle;
        private Brush colorName;
        private Brush colorVorname;
        private Brush colorStraße;
        private Brush colorNummer;
        private Brush colorPlz;
        private Brush colorCity;
        private Brush colorBirthplace;
        private Brush colorEmail;
        private Brush colorDate;
        private ImageSource _selectedImage;
        private string strsearch;

        private ObservableCollection<string> cityList;

        private NavigationBarViewModel navigationBar;

        public ICommand NavigateCancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand NavigateSearchCommand { get; set; }

        public Brush ColorDate
        {
            get
            {
                return this.colorDate;
            }
            set
            {
                this.colorDate = value;
                OnPropertyChanged(nameof(this.ColorDate));
            }
        }


        public Brush ColorEmail
        {
            get
            {
                return this.colorEmail;
            }
            set
            {
                this.colorEmail = value;
                OnPropertyChanged(nameof(this.ColorEmail));
            }
        }

        public Brush ColorBirth
        {
            get
            {
                return this.colorBirthplace;
            }
            set
            {
                this.colorBirthplace = value;
                OnPropertyChanged(nameof(this.ColorBirth));
            }
        }

        public Brush ColorCity
        {
            get
            {
                return this.colorCity;
            }
            set
            {
                this.colorCity = value;
                OnPropertyChanged(nameof(this.ColorCity));
            }
        }

        public Brush ColorPlz
        {
            get
            {
                return this.colorPlz;
            }
            set
            {
                this.colorPlz = value;
                OnPropertyChanged(nameof(this.ColorPlz));
            }
        }

        public Brush ColorNummer
        {
            get
            {
                return this.colorNummer;
            }
            set
            {
                this.colorNummer = value;
                OnPropertyChanged(nameof(this.ColorNummer));
            }
        }

        public Brush ColorStraße
        {
            get
            {
                return this.colorStraße;
            }
            set
            {
                this.colorStraße = value;
                OnPropertyChanged(nameof(this.ColorStraße));
            }
        }

        public Brush ColorVorname
        {
            get
            {
                return this.colorVorname;
            }
            set
            {
                this.colorVorname = value;
                OnPropertyChanged(nameof(this.ColorVorname));
            }
        }

        public Brush ColorName
        {
            get
            {
                return this.colorName;
            }
            set
            {
                this.colorName = value;
                OnPropertyChanged(nameof(this.ColorName));
            }
        }

        public Brush ColorTitle
        {
            get
            {
                return this.colorTitle;
            }
            set
            {
                this.colorTitle = value;
                OnPropertyChanged(nameof(this.ColorTitle));
            }
        }

        public DateTime StrDate
        {
            get { return this.strDate; }
            set
            {
                this.strDate = value;
                this.OnPropertyChanged(nameof(this.StrDate));
            }
        }


        public string StrBirthPlace
        {
            get
            {
                return this.strLand;
            }
            set
            {
                this.strLand = value;
                OnPropertyChanged(nameof(this.StrBirthPlace));
            }
        }

        public string SelectedCity
        {
            get
            {
                return this.selectedCity;
            }
            set
            {
                this.selectedCity = value;
                OnPropertyChanged(nameof(this.SelectedCity));
            }
        }

        public string StrTitle
        {
            get
            {
                return this.strTitle;
            }
            set
            {
                this.strTitle = value;
                OnPropertyChanged(nameof(this.StrTitle));
            }
        }

        public string StrName
        {
            get
            {
                return this.strName;
            }
            set
            {
                this.strName = value;
                OnPropertyChanged(nameof(this.StrName));
            }
        }

        public string StrVorname
        {
            get
            {
                return this.strVorname;
            }
            set
            {
                this.strVorname = value;
                OnPropertyChanged(nameof(this.StrVorname));
            }
        }

        public string StrEmail
        {
            get
            {
                return this.strEmail;
            }
            set
            {
                this.strEmail = value;
                OnPropertyChanged(nameof(this.StrEmail));
            }
        }

        public string StrPostleitzahl
        {
            get
            {
                return this.strPostleitzahl;
            }
            set
            {
                this.strPostleitzahl = value;
                OnPropertyChanged(nameof(this.StrPostleitzahl));
            }
        }

        public string StrNummer
        {
            get
            {
                return this.strNummer;
            }
            set
            {
                this.strNummer = value;
                OnPropertyChanged(nameof(this.StrNummer));
            }
        }

        public string Strsearch
        {
            get
            {
                return this.strsearch;
            }
            set
            {
                this.strsearch = value;
                OnPropertyChanged(nameof(this.Strsearch));
            }
        }


        public string StrStraße
        {
            get
            {
                return this.strStraße;
            }
            set
            {
                this.strStraße = value;
                OnPropertyChanged(nameof(this.StrStraße));
            }
        }

        public ObservableCollection<string> CityList
        {
            get
            {
                return this.cityList;
            }

            set
            {
                this.cityList = value;
                OnPropertyChanged(nameof(CityList));
            }
        }

        public ImageSource SelectedImage
        {
            get => _selectedImage;
            set
            {
                _selectedImage = value;
                OnPropertyChanged(nameof(SelectedImage));
            }
        }

        public InformationViewModel(NavigationStore navigationStore,
												IImageService imageService,
												IMessageService messageService,
											   IUserInfo userInfo,
		                              INavigationBarService navigationBarService,
												MStudentInformations mStudentInfos)
        {
			this._imageService = imageService;
			this._messageService = messageService;
         this._navigationBarService = navigationBarService;
         this._userInfo = userInfo;
			this._mStudentInfos = mStudentInfos;
            this.strDate = new DateTime();
            CityList = new ObservableCollection<string>
            {
                "Salzgitter", "Braunschweig", "Hannover", "Hildesheim", "Salder"
            };

            this.ColorTitle = Brushes.Black;
            this.ColorName = Brushes.Black;
            this.ColorVorname = Brushes.Black;
            this.ColorStraße = Brushes.Black;
            this.ColorNummer = Brushes.Black;
            this.ColorPlz = Brushes.Black;
            this.ColorCity = Brushes.Black;
            this.ColorEmail = Brushes.Black;
            this.ColorDate = Brushes.Black;
            this.ColorBirth = Brushes.Black;

            this.executeCancelCommand(navigationStore);
            this.SaveCommand = new DelegateCommand(ExecuteSaveMethod, CanExecute);
            this.LoadCommand = new DelegateCommand(ExecuteLoadMethod, CanExecute);
            this.NavigateSearchCommand = new DelegateCommand(ExecuteSearchMethod, CanExecute);
        }

        private async void ExecuteSearchMethod(object obj)
        {          

             this._mStudentInfos = await this._userInfo.SearchStudentInfosAsync(this.Strsearch);

            try
            {
                if (this._mStudentInfos != null)
                {
                    this.StrName = this._mStudentInfos.Name;
                    this.StrVorname = this._mStudentInfos.Vorname;
                    this.StrEmail = this._mStudentInfos.Email;
                    this.StrStraße = this._mStudentInfos.Straße;
                    this.StrNummer = this._mStudentInfos.Straßenummer;
                    this.StrPostleitzahl = this._mStudentInfos.Postleitzahl;
                    this.SelectedCity = this._mStudentInfos.Stadt;
                    this.StrDate = Convert.ToDateTime(this._mStudentInfos.Datum);
                    this.strLand = this._mStudentInfos.Land;
                }
            }
            catch (Exception ex)
            {
				   this._messageService.ShowErrorMessage(ex.Message);
            }
            
        }

        

        private void ExecuteLoadMethod(object obj)
        {
            try
            {
                this.SelectedImage = this._imageService.LoadImage(this.ImagePath);
            }
            catch (Exception ex)
            {
				  this._messageService.ShowErrorMessage(ex.Message);
			   }
		}

        public void executeCancelCommand(NavigationStore navigationStore)
        { 

            NavigateCancelCommand = new NavigateCommand<DashboardViewModel>(
               new LayoutNavigationService<DashboardViewModel>(navigationStore,
               () => new DashboardViewModel(navigationStore,
                                            this._navigationBarService,
                                            this._messageService,
                                            this._userInfo,
                                            this._imageService,
                                            this._mStudentInfos), 
               this._navigationBarService.CreateNavigationBar("Home->Profil-> Dashboard")));
          
        }
      
        private bool CanExecute(object obj)
        {
            return true;
        }

        private async void ExecuteSaveMethod(object obj)
        {
            int iCount;
           
            string fileName = this._imageService.FileName(ImagePath);
            string FileType = this._imageService.FileExtension(ImagePath);
            Byte[] hexData = this._imageService.ConvertToBytes(ImagePath);
                                                             
            this._mStudentInfos.Id = this.StrTitle;
            this._mStudentInfos.Name = this.StrName;
            this._mStudentInfos.Vorname = this.StrVorname;
            this._mStudentInfos.Email = this.StrEmail;
            this._mStudentInfos.Straße = this.StrStraße;
            this._mStudentInfos.Straßenummer = this.StrNummer;
            this._mStudentInfos.Postleitzahl = this.StrPostleitzahl;
            this._mStudentInfos.Stadt = this.SelectedCity;
            this._mStudentInfos.Land = this.StrBirthPlace;
            this._mStudentInfos.Datum = this.StrDate.ToString("yyyy-MM-dd");
            this._mStudentInfos.FileName = fileName;
            this._mStudentInfos.ImageToByte = hexData;
            this._mStudentInfos.ContentType = FileType;

           try
            {
                if( string.IsNullOrEmpty(StrTitle) || string.IsNullOrEmpty(StrName)|| 
                    string.IsNullOrEmpty(StrVorname) || string.IsNullOrEmpty(StrEmail)|| 
                    string.IsNullOrEmpty(StrStraße) || string.IsNullOrEmpty(StrNummer) || 
                    string.IsNullOrEmpty(StrPostleitzahl) || string.IsNullOrEmpty(StrBirthPlace) ||
                    string.IsNullOrEmpty(this.SelectedCity) || string.IsNullOrEmpty(this.StrDate.ToString()))
                {
                    if (string.IsNullOrEmpty(StrTitle)){

                        this.ColorTitle = Brushes.Red;
                    }

                    if (string.IsNullOrEmpty(StrName)) {

                        this.ColorName = Brushes.Red;
                    }
                    
                    if (string.IsNullOrEmpty(StrVorname)){

                        this.ColorVorname = Brushes.Red;
                    }
                   
                    if (string.IsNullOrEmpty(StrEmail)){
                        this.ColorEmail = Brushes.Red;
                    }

                    if(string.IsNullOrEmpty(this.StrDate.ToString()))
                    {
                        this.ColorBirth = Brushes.Red;
                    }

                    if (string.IsNullOrEmpty(StrNummer))
                    {
                        this.ColorNummer = Brushes.Red;
                    }
                   
                    if(string.IsNullOrEmpty(StrPostleitzahl))
                    {
                        this.ColorPlz = Brushes.Red;
                    }
                   
                    if(string.IsNullOrEmpty(StrStraße))
                    {
                        this.ColorStraße = Brushes.Red;
                    }
                   
                    if (string.IsNullOrEmpty(this.SelectedCity))
                    {
                        this.ColorCity = Brushes.Red;
                    }
                   
                    if(string.IsNullOrEmpty(this.StrDate.ToString()))
                    {
                        this.ColorDate = Brushes.Red;
                    }

                    if (string.IsNullOrEmpty(this.StrBirthPlace))
                    {
                        this.ColorBirth = Brushes.Red;
                    }

                    this._messageService.ShowErrorMessage("die leeren Feldern sollten ausgefüllt werden");
					
                }
                else
                {
                    if (await this._userInfo.AddStudentInfosAsync(this._mStudentInfos) > 0)
                    {
                        this._messageService.ShowErrorMessage("die Einträgen wurden erfolgreich in die Datenbank hinzugefügt");
						
                    }
                }               
            }
            catch (Exception ex)
            {
                this._messageService.ShowErrorMessage(ex.Message);
				
            }
            
        }
    }
}
