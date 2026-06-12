
using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Repositories;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.ViewModels;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace EngineeringToolsCV_1.Command
{
    public class NavigateLoginCommand : ViewModelCommand
    {
      private IMessageService _messageService;
      private LoginViewModel _ViewModel;
      private INavigateService<ProfilViewModel> _navigateService;
      private IUserInfo _userInfo;
      private LoginViewModel _vmLogin;

		public NavigateLoginCommand(INavigateService<ProfilViewModel> navigateService,
                                    IMessageService messageService,
                                    IUserInfo userInfo,
                                    LoginViewModel vmLogin)
        {
            this._navigateService = navigateService;
            this._messageService = messageService;
            this._userInfo = userInfo;
            this._vmLogin = vmLogin;
		}

       public async override void Execute(object parameter)
       {

         try
         {

            if (await this._userInfo.LoginUserAsync(this._vmLogin.Username, this._vmLogin.Password))
            {
               this._navigateService.Navigate();
            }
            else
            {
               this._messageService.ShowErrorMessage("Ungültige Anmeldeinformationen. Bitte überprüfen Sie Ihren Benutzernamen und Ihr Passwort.");

            }
         }
         catch (Exception ex)
         {
            this._messageService.ShowErrorMessage($"Fehler beim Login:\n{ex.Message}");
         }
        }
    }
}
