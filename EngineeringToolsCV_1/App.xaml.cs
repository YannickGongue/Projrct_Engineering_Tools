using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.ViewModels;
using EngineeringToolsCV_1.Views;
using EngineeringToolsCV_1.DatabaseManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using EngineeringToolsCV_1.Repositories;
using EngineeringToolsCV_1.IRepository;
using Microsoft.Extensions.DependencyInjection;

namespace EngineeringToolsCV_1
{
    /// <summaruserLoginy>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private string strServer;
        private string strDbname;
        private string strSecurity;
        private AppSetting setting;
        private string connectionString;
        private MainWindow mainWindow;
        private NavigationStore navigationStore;
        private NavigationBarViewModel _NavigationBar;
        private SQLServerView ServerView;
        private RegisterViewModel _vmRegister;
        private UserResetViewModel _vmUserReset;
        private ErrorMessageViewModel _vmDialogMessage; 
        private MStudentInformations _mStudent;
        private MUser mUser;
        private MUserWorkInfo _mUserWorkInfo;
        private LoginViewModel VmLogin;
        private NewPassordViewModel _vmNewPassword;
        private DbManager dbManager;
        private UserInfos _userInfo;
        private UserWorkInfo _userWorkInfo;
        private SqlConnectionFactory sqlcon;
        private DBName dbName;
        private readonly IServiceProvider _serviceProvider;


      public App()
      {
         IServiceCollection services = new ServiceCollection();
         ConfigureServices(services);

         _serviceProvider = services.BuildServiceProvider();
      }

      private void ConfigureServices(IServiceCollection services)
		{

			string strConnectionString = ConfigurationManager
												  .ConnectionStrings["ConnectionString"]
												  .ConnectionString;
         services.AddSingleton(new SqlConnectionFactory(strConnectionString));
			
           services.AddSingleton<DBName>();
           services.AddSingleton<UserInfos>();
         services.AddSingleton<UserWorkInfo>();
			services.AddSingleton<DbManager>();

			services.AddSingleton<NavigationStore>();
         
         services.AddSingleton<ErrorMessageViewModel>();

			services.AddTransient<MUser>();
			services.AddTransient<MStudentInformations>();
			services.AddTransient<MUserWorkInfo>();

			services.AddSingleton<MainWindow>();

			services.AddTransient<LoginViewModel>();
			services.AddTransient<RegisterViewModel>();
			services.AddTransient<UserResetViewModel>();
         services.AddTransient<NewPassordViewModel>();
			
			services.AddTransient<HomeViewModel>();



         this._vmDialogMessage = new ErrorMessageViewModel();
         this.dbName = new DBName();
         this.sqlcon = new SqlConnectionFactory(strConnectionString);
         this._userInfo = new UserInfos(this.sqlcon, this.dbName);
         this._userWorkInfo = new UserWorkInfo(this.sqlcon, this.dbName);
         this.dbManager = new DbManager(this._userInfo, this._userWorkInfo);
         this.mUser = new MUser();
         this._mUserWorkInfo = new MUserWorkInfo();
         this._vmNewPassword = new NewPassordViewModel();
         this.VmLogin = new LoginViewModel(this.navigationStore, this.mUser, this._vmUserReset, this._mStudent, this.dbManager, this.dbName, this._vmDialogMessage, this._mUserWorkInfo);
         this._mStudent = new MStudentInformations();
         this._vmRegister = new RegisterViewModel(this.VmLogin, this.mUser, this.dbManager, this.dbName, this._vmDialogMessage);
         this._vmUserReset = new UserResetViewModel(this._vmNewPassword, this.dbManager, this.dbName, this.mUser);
         this.navigationStore = new NavigationStore();
         this.mainWindow = new MainWindow();
         this._NavigationBar = new NavigationBarViewModel("Home");
            this.ServerView = new SQLServerView(this._vmRegister,this._vmUserReset,this._mStudent,this.mUser,this.dbManager,this.dbName,this._vmDialogMessage,this._mUserWorkInfo);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {  
            
            if(Environment.MachineName.Equals("DESKTOP-5FKC835"))
            {
                setting = new AppSetting();
                strServer = @"(localdb)\MSSQLLocalDB";
                strDbname = "Lebenslauf";
                strSecurity = "SSPI";
                connectionString = String.Format("{0} {1} {2}", "server =" + strServer, "; Integrated Security =" + strSecurity, "; Initial Catalog =" + strDbname);
                setting.saveConnectionString("ConnectionString", connectionString);
               
                this.CreateHomeView();
            }
            else
            {
                ServerView.Show();
            }
        }

        private void CreateHomeView()
        {
            INavigateService<HomeViewModel> homeNavigationService = new LayoutNavigationService<HomeViewModel>(this.navigationStore,
                        () => new HomeViewModel(this.navigationStore, this._vmRegister, this._vmUserReset,this._mStudent,this.mUser,this.dbManager,this.dbName,this._vmDialogMessage,this._mUserWorkInfo), this._NavigationBar);
            homeNavigationService.Navigate();
            this.mainWindow.DataContext = new mainViewModel(this.navigationStore, this._vmRegister,this._vmUserReset,this._mStudent,this.mUser,this.dbManager,this.dbName,this._vmDialogMessage,this._mUserWorkInfo);
            this.mainWindow.Show();
        }        
    }
}
