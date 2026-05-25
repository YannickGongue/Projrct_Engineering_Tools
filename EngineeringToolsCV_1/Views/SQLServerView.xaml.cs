using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EngineeringToolsCV_1.Views
{
    /// <summary>
    /// Interaktionslogik für SQLServerView.xaml
    /// </summary>
    public partial class SQLServerView : Window
    {
        private UserResetView _userResetView;
        private DBName _dbName;
        private DbManager _dbManager;
        private MStudentInformations _mStudent;
        private MUser _mUser;
        private MainWindow mainWindow;
        private RegisterViewModel _userRegister;
        private UserResetViewModel _vmUserReset;
        private NavigationStore navigationStore;
        private NavigationBarViewModel _NavigationBar;
        private SQLServerViewModel ServerViewModel;
        private ErrorMessageViewModel _vmDialogMessage;
        private MStudentWorkInfo _mUserWorkInfo;

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public SQLServerView(RegisterViewModel userRegister ,
                             UserResetViewModel  vmUserReset,
                             MStudentInformations mStudent, 
                             MUser mUser,
                             DbManager dbManager,
                             DBName dbName,
                             ErrorMessageViewModel vmDialogMessage,
                             MStudentWorkInfo mUserWork )
        {
            InitializeComponent();
            this._userRegister = userRegister;
            this._vmUserReset = vmUserReset;
            this._mStudent = mStudent;
            this._mUser = mUser;
            this._dbManager = dbManager;
            this._dbName = dbName;
            this._vmDialogMessage = vmDialogMessage;
            this._mUserWorkInfo = mUserWork;
            this.navigationStore = new NavigationStore();
            this.mainWindow = new MainWindow();
            this._NavigationBar = new NavigationBarViewModel("Home");
            this.ServerViewModel = new SQLServerViewModel();
           
            this.cmbServerTyp.ItemsSource = ServerViewModel.ListServerTyp;
            this.CmbServername.ItemsSource = ServerViewModel.ListServerName;
            this.cmbAuthenticationType.ItemsSource = ServerViewModel.ListAuthentifizierung;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();      
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            AppSetting setting = new AppSetting();
            string connectionString = String.Format("{0} {1}", ServerViewModel.ConnectionString, "Initial Catalog =" + this.Cmbdatabase.SelectedItem.ToString());
            try
            {
                setting.saveConnectionString("ConnectionString" ,connectionString);
                MessageBox.Show("your Connection string has been succefully saved.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                this.CreateHomeView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ConnectedButton_Click(object sender, RoutedEventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            con.Close();
            MessageBox.Show("Connected to the " + this.Cmbdatabase.Text + " Successfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        
        private void CmbAuthentication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.cmbAuthenticationType.SelectedItem.ToString().Contains("SQl Server Authentication"))
            {
                this.Username.IsEnabled = true;
                this.Passwort.IsEnabled = true;

            }
            else
            {
                this.Username.IsEnabled = false;
                this.Passwort.IsEnabled = false;
            }
        }

        private void Cmbdatabase_DropDownOpened(object sender, EventArgs e)
        {
            int icount = 0;

            this.Cmbdatabase.Items.Clear();
            try
            {
                if (cmbAuthenticationType.Text.Equals("Windows Authentication"))
                {
                    this.ServerViewModel.ConnectionString = @"Server = " + this.CmbServername.Text + "; Integrated Security = SSPI;";
                    con.ConnectionString = ServerViewModel.ConnectionString;
                }
                else if (cmbAuthenticationType.Text.Equals("SQL Server Authentication"))
                {
                    this.ServerViewModel.ConnectionString = @"Server = " + this.CmbServername.Text + "; User Id =" + this.Username.Text + "; Password=" + this.Passwort.Text + ";";
                    con.ConnectionString = this.ServerViewModel.ConnectionString;
                }
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT DB_NAME(database_id) AS[Database] FROM sys.databases; ";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    this.ServerViewModel.ListOfDatabases.Insert(icount, dr["Database"].ToString());
                    icount++;
                }

                this.Cmbdatabase.ItemsSource = this.ServerViewModel.ListOfDatabases;
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OOPSSss!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //private void AddNewConnectionString()
        //{
        //    ExeConfigurationFileMap oConfigFile = new ExeConfigurationFileMap();
        //    oConfigFile.ExeConfigFilename = @"~/App.config" ;
        //    Configuration oConfiguration = ConfigurationManager.OpenMappedExeConfiguration(oConfigFile, ConfigurationUserLevel.None);
        //    //Define a connection string settings including the name and the connection string
        //    ConnectionStringSettings oConnectionSettings = new ConnectionStringSettings("ConnectionString", String.Format("{0} {1}", con.ConnectionString, "Initial Catalog =" + this.Cmbdatabase.SelectedItem.ToString()));
        //   if(!oConnectionSettings.ConnectionString.)
        //    {
        //        //Adding the connection string to the oConfiguration object
        //        oConfiguration.ConnectionStrings.ConnectionStrings.Add(oConnectionSettings);
        //    }
           
        //    //Save the new connection string settings
        //    oConfiguration.Save(ConfigurationSaveMode.Modified);
        //}

        private void CreateHomeView()
        {
            INavigateService<HomeViewModel> homeNavigationService = new LayoutNavigationService<HomeViewModel>(navigationStore,
                        () => new HomeViewModel(navigationStore,this._userRegister,this._vmUserReset,this._mStudent, this._mUser,this._dbManager,this._dbName,this._vmDialogMessage,this._mUserWorkInfo), _NavigationBar);
            homeNavigationService.Navigate();
            mainWindow.DataContext = new mainViewModel(navigationStore, this._userRegister,this._vmUserReset,this._mStudent,this._mUser,this._dbManager,this._dbName,this._vmDialogMessage,this._mUserWorkInfo);
            mainWindow.Show();
        }

        //public ObservableCollection<string> ListOfServername()
        //{
        //    //int  iServername = 0;
        //    //SqlDataSourceEnumerator instance =
        //    // SqlDataSourceEnumerator.Instance;
        //    //System.Data.DataTable table = instance.GetDataSources();
        //}

        //private void CmbServername_DropDownOpened(object sender, EventArgs e)
        //{
        //    this.ListOfServername();
        //}
    }
}
