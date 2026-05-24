using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Repositories;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EngineeringToolsCV_1.ViewModels
{
    public class BerufViewModel : ViewModelBase
    {
      private INavigationBarService _navigationBarService;
      private IMessageService _messageService;
      private I
		private NavigationStore navigationStore;
        private NavigationBarViewModel navigationBar;
        private MStudentInformations _mStudentInfos;
        private MUserWorkInfo _mUserWorkInfo;
         private IMessageService _messageService;
          

        private string strTitel;
        private string strEmail;
        private string strBeschäftigung;
        private string strUnternehmen;
        private DateTime strStartDate;
        private DateTime strEndDate;
        private string strOrtTyp;
        private string strStandort;
        private string strBeschreibung;
        private string selAufgabe;
        private string strSkills;

        private bool checkTätig;
        private List<string> itemAufgabe;
        private List<string> ortTyp;
        private string selOrtTyp;


        public bool CheckTätig
        {
            get { return this.checkTätig; }
            set
            {
                this.checkTätig = value;
                OnPropertyChanged(nameof(this.CheckTätig));
            }
        }

        public string StrBeschäftigung
        {
            get { return this.strBeschäftigung; }
            set
            {
                this.strBeschäftigung = value;
                OnPropertyChanged(nameof(this.StrBeschäftigung));
            }
        }
        public string StrTitel
        {
            get { return this.strTitel; }
            set
            {
                this.strTitel = value;
                OnPropertyChanged(nameof(this.StrTitel));
            }
        }

        public string StrEmail
        {
            get { return this.strEmail; }
            set
            {
                this.strEmail = value;
                OnPropertyChanged(nameof(this.StrEmail));
            }
        }

        public string StrUnternehmen
        {
            get { return this.strUnternehmen; }
            set
            {
                this.strUnternehmen = value;
                OnPropertyChanged(nameof(this.StrUnternehmen));
            }
        }

        public DateTime StrStartDate
        {
            get { return this.strStartDate; }
            set
            {
                this.strStartDate = value;
                OnPropertyChanged(nameof(this.StrStartDate));
            }
        }

        public DateTime StrEndDate
        {
            get { return this.strEndDate; }
            set
            {
                this.strEndDate = value;
                OnPropertyChanged(nameof(this.StrEndDate));
            }
        }

        public string StrOrtTyp
        {
            get { return this.strOrtTyp; }
            set
            {
                this.strOrtTyp = value;
                OnPropertyChanged(nameof(this.StrOrtTyp));
            }
        }

        public string StrStandOrt
        {
            get { return this.strStandort; }
            set
            {
                this.strStandort = value;
                OnPropertyChanged(nameof(this.StrStandOrt));
            }
        }

        public string StrSkills
        {
            get { return this.strSkills; }
            set
            {
                this.strSkills = value;
                OnPropertyChanged(nameof(this.StrSkills));
            }
        }

        public string StrBeschreibung
        {
            get { return this.strBeschreibung; }
            set
            {
                this.strBeschreibung = value;
                OnPropertyChanged(nameof(this.StrBeschreibung));
            }
        }

        public string SelAufgabe
        {
            get { return this.selAufgabe; }
            set
            {
                this.selAufgabe = value;
                OnPropertyChanged(nameof(this.SelAufgabe));
            }
        }

        public List<string> ItemAufgabe
        {
            get { return this.itemAufgabe; }
            set
            {
                this.itemAufgabe = value;
                OnPropertyChanged(nameof(this.StrStandOrt));
            }
        }

        public string SelOrtTyp
        {
            get { return this.selOrtTyp; }
            set
            {
                this.selOrtTyp = value;
                OnPropertyChanged(nameof(this.SelOrtTyp));
            }
        }

        public List<string> ItemOrtTyp
        {
            get { return this.ortTyp; }
            set
            {
                this.ortTyp = value;
                OnPropertyChanged(nameof(this.ItemOrtTyp));
            }
        }

        public ICommand NavigateReturnCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand deleteCommand { get; set; }


        public BerufViewModel(NavigationStore navigationStore, 
                              MStudentInformations mStudentInfos,
                              DbManager dbManager,
                              DBName dbName,
                              ErrorMessageViewModel vmDialogMessage,
                              MUserWorkInfo mUserWorkInfo)
        {
            this.navigationStore = navigationStore;
            this._mStudentInfos = mStudentInfos;
            this._mUserWorkInfo = mUserWorkInfo;
            this.StrStartDate = new DateTime();
            this.StrEndDate = new DateTime();


           this.navigationBar = new NavigationBarViewModel("Home -> Dashboard");
           this.NavigateReturnCommand = new NavigateCommand<DashboardViewModel>(
               new LayoutNavigationService<DashboardViewModel>(navigationStore,
               () => new DashboardViewModel(navigationStore, this._mStudentInfos, this._dbManager,this._dbName,this._vmDialogMessage, this._mUserWorkInfo), navigationBar));

           this.SaveCommand = new DelegateCommand(ExecuteSaveMethod, CanExecute);
           this.deleteCommand = new DelegateCommand(ExecuteDeleteMethod, CanExecute);

            this.ItemAufgabe = new List<string>
            {
                "auswählen....","Vollzeit", "Teilzeit", "Selbständig",
                "freiberuflich", "befristet","Praktikum","Azubi",
                "freiwilliges soziales Jahr","Verbeamte","Duale Studium","Werkstudium"
            };

            this.ItemOrtTyp = new List<string>
            {
                "auswählen....","Vorort", "Hybrid", "Remote"              
            };

            this.CheckTätig = false;
        }

        private bool CanExecute(object arg)
        {
            return true;
        }

        private void ExecuteDeleteMethod(object obj)
        {
            throw new NotImplementedException();
        }     

        private async void ExecuteSaveMethod(object obj)
        {
            int iCount;
           
            try
            {
                //if (string.IsNullOrEmpty(StrTitel) || string.IsNullOrEmpty(StrEmail) ||
                //    string.IsNullOrEmpty(strStartDate) || string.IsNullOrEmpty(StrEndDate) ||
                //    string.IsNullOrEmpty(StrStraße) || string.IsNullOrEmpty(strNummer) || string.IsNullOrEmpty(StrPostleitzahl) ||
                //    string.IsNullOrEmpty(this.SelectedCity) || string.IsNullOrEmpty(this.strDate.ToString()))
                //{
                //    this.ColorTitle = Brushes.Red;
                //    this.ColorName = Brushes.Red;
                //    this.ColorVorname = Brushes.Red;
                //    this.ColorBirth = Brushes.Red;
                //    this.ColorEmail = Brushes.Red;
                //    this.ColorNummer = Brushes.Red;
                //    this.ColorPlz = Brushes.Red;
                //    this.ColorStraße = Brushes.Red;
                //    this.ColorCity = Brushes.Red;
                //    this.ColorDate = Brushes.Red;
                //    this.dialogMessage.ErrorMessage.Text = "die Leeren Feldern sollten ausgefüllt werden";
                //    this.dialogMessage.Show();
                //}
                //else
                //{

                this._mUserWorkInfo.Titel = this.StrTitel;
                this._mUserWorkInfo.Email = this.StrEmail;
                this._mUserWorkInfo.Firma = this.StrUnternehmen;
                this._mUserWorkInfo.StartDatum = this.StrStartDate.ToString();
                this._mUserWorkInfo.EndDatum = this.StrEndDate.ToString();
                this._mUserWorkInfo.Aufgabe = this.SelAufgabe;
                this._mUserWorkInfo.OrtType = this.StrOrtTyp;
                this._mUserWorkInfo.Standort = this.StrStandOrt;
                this._mUserWorkInfo.Skills = this.StrSkills;
                this._mUserWorkInfo.ArbeitsArt = this.StrBeschäftigung;

                    iCount = await this._dbManager.AddWorkInfosAsync(this._mUserWorkInfo);
                    if (iCount == 1)
                    {
                        this._vmDialogMessage.SetErrorMessage= "die Einträgen wurden erfolgreich in die Datenbank hinzugefügt";
                        this.dialogMessage.DataContext = this._vmDialogMessage;
                        this.dialogMessage.Show();
                    }
                //}
            }
            catch (Exception ex)
            {
                this._vmDialogMessage.SetErrorMessage = ex.Message.ToString();
                this.dialogMessage.DataContext = this._vmDialogMessage;
                this.dialogMessage.Show();
            }
        }
    }
}
