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
        private DbManager _dbManager;
        private UserInfos userInfosRepositories;
        private MStudentInformations _mStudentInfos;
        private ErrorMessageViewModel _dialogMessage;
        private MessageDialog _DialogView;
        private DBName _dbName;
        private DataTable dtTable;
        private MUserWorkInfo _mUserWorkInfo;

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
                                    MStudentInformations mStudentInfos,
                                    DbManager dbManager,
                                    DBName dbName,
                                    ErrorMessageViewModel dialogMessage,
                                    MUserWorkInfo mUserWorkInfo)
        {
            this._mStudentInfos = mStudentInfos;
            this._dbManager = dbManager;
            this._dbName =  dbName;
            this._dialogMessage = dialogMessage;
            this._mUserWorkInfo = mUserWorkInfo;
            this._DialogView = new MessageDialog();
            this.strDate = new DateTime();
            this.dtTable = new DataTable();
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
            DataRow drRow;

            var dtTable = await this._dbManager.SearchStudentInfosAsync(this.Strsearch);

            try
            {
                if (this.dtTable.Rows.Count > 0)
                {
                    drRow = this.dtTable.Rows[0];
                    this.StrName = drRow[this._dbName.strName].ToString();
                    this.StrVorname = drRow[this._dbName.strVorname].ToString();
                    this.StrEmail = drRow[this._dbName.strEmail].ToString();
                    this.StrStraße = drRow[this._dbName.strStraße].ToString();
                    this.StrNummer = drRow[this._dbName.strNummer].ToString();
                    this.StrPostleitzahl = drRow[this._dbName.strPostleitzahl].ToString();
                    this.SelectedCity = drRow[this._dbName.strStadt].ToString();
                    //this.StrDate = Convert.ToDateTime(drRow[this._dbName.strDatum].ToString());
                    this.strLand = drRow[this._dbName.strLand].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Login:\n{ex.Message}");
            }
            
        }

        public ImageSource Foto()
        {
            ImageSource imageSourceDefault = null;
            ImageSource imageSource;
           
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    ImagePath = openFileDialog.FileName;
                    imageSource = new BitmapImage(new Uri(ImagePath));
                    return imageSource;
                } 
            }
            catch (Exception ex)
            {
                this._dialogMessage.SetErrorMessage = ex.Message.ToString();
                this._DialogView.DataContext = this._dialogMessage;
                this._DialogView.Show();
            }

            return imageSourceDefault;
        }

        public byte[] ConvertImageToByte(Image img)
        {
            MemoryStream ms = new MemoryStream();
            //img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public static string ByteArrayToHexString(byte[] bytes)
        {
            return "0x" + BitConverter.ToString(bytes).Replace("-", "");
        }

        private void ExecuteLoadMethod(object obj)
        {
            try
            {
                this.SelectedImage = this.Foto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void executeCancelCommand(NavigationStore navigationStore)
        {
            navigationBar = new NavigationBarViewModel("Home->Profil-> Dashboard");

            NavigateCancelCommand = new NavigateCommand<DashboardViewModel>(
               new LayoutNavigationService<DashboardViewModel>(navigationStore,
               () => new DashboardViewModel(navigationStore,this._mStudentInfos,this._dbManager,this._dbName,this._dialogMessage,this._mUserWorkInfo), navigationBar));
          
        }

        private bool CanExecute(object obj)
        {
            return true;
        }

        private async void ExecuteSaveMethod(object obj)
        {
            int iCount;
           
            string fileName = Path.GetFileName(ImagePath);
            string FileType = Path.GetExtension(fileName).ToLower();
            Byte[] hexData = File.ReadAllBytes(ImagePath);
                                                             
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

                    this._dialogMessage.SetErrorMessage = "die leeren Feldern sollten ausgefüllt werden";
                    this._DialogView.DataContext = this._dialogMessage;
                    this._DialogView.Show();
                }
                else
                {
                    if (await this._dbManager.AddStudentInfosAsync(this._mStudentInfos) > 0)
                    {
                        this._dialogMessage.SetErrorMessage = "die Einträgen wurden erfolgreich in die Datenbank hinzugefügt";
                        this._DialogView.DataContext = this._dialogMessage;
                        this._DialogView.Show();
                    }
                }               
            }
            catch (Exception ex)
            {
                this._dialogMessage.SetErrorMessage = ex.Message.ToString();
                this._DialogView.DataContext = this._dialogMessage;
                this._DialogView.Show();
            }
            
        }
    }
}
