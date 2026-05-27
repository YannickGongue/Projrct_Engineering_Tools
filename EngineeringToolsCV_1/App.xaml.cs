using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.ViewModels;
using EngineeringToolsCV_1.Views;
using EngineeringToolsCV_1.DatabaseManager;
using System;
using System.Configuration;
using System.Windows;
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
                
        private readonly IServiceProvider _serviceProvider;


      public App()
      {
			setting = new AppSetting();
			strServer = @"(localdb)\MSSQLLocalDB";
			strDbname = "Lebenslauf";
			strSecurity = "SSPI";
			connectionString = String.Format("{0} {1} {2}", "server =" + strServer, "; Integrated Security =" + strSecurity, "; Initial Catalog =" + strDbname);
			setting.saveConnectionString("ConnectionString", connectionString);

			IServiceCollection services = new ServiceCollection();
         ConfigureServices(services);

         _serviceProvider = services.BuildServiceProvider();
      }

      private void ConfigureServices(IServiceCollection services)
		{

			string strConnectionString = ConfigurationManager
												  .ConnectionStrings["ConnectionString"]
												  .ConnectionString;
         services.AddSingleton<IConnectionFactory>(new SqlConnectionFactory(strConnectionString));			
         services.AddSingleton<DBName>();
			services.AddSingleton<NavigationStore>();
			services.AddSingleton<MainWindow>();

			services.AddTransient<MUser>();
			services.AddTransient<MStudentInformations>();
			services.AddTransient<MStudentWorkInfo>();
			services.AddTransient<ErrorMessageViewModel>();
			services.AddTransient<HomeViewModel>();
			services.AddTransient<mainViewModel>();
			services.AddTransient<LoginViewModel>();
			services.AddTransient<RegisterViewModel>();
			services.AddTransient<UserResetViewModel>();
         services.AddTransient<NewPassordViewModel>();		

			services.AddTransient<IUserInfo, UserInfo>();
			services.AddTransient<IStudentInfo, StudentInfos>();
			services.AddTransient<IStudentWorkInfo,StudentWorkInfo>();
			services.AddTransient<IImageService, ImageService>();
			services.AddTransient<IFileDialogService,FileDialogService>();
			services.AddTransient<IMessageService, MessageService>();
			services.AddTransient<INavigationBarService, NavigationBarService>();
			services.AddTransient<SQLServerView>();

		}

		private void Application_Startup(object sender, StartupEventArgs e)
      {  
            
            if(Environment.MachineName.Equals("DESKTOP-5FKC835"))
            {           
                this.CreateHomeView();
            }
            else
            {
				   var serverView =_serviceProvider.GetRequiredService<SQLServerView>();

			     	serverView.Show();
			   }
      }     

		private void CreateHomeView()
		{
			var navigationStore =_serviceProvider.GetRequiredService<NavigationStore>();

			var mainWindow =_serviceProvider.GetRequiredService<MainWindow>();

			var homeViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();

			navigationStore.CurrentViewModels = homeViewModel;

			mainWindow.DataContext =_serviceProvider.GetRequiredService<mainViewModel>();

			mainWindow.Show();
		}
	}
}
