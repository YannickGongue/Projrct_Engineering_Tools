
using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Repositories;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.ViewModels;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EngineeringToolsCV_1.Command
{
    public class NavigateLoginCommand : ViewModelCommand
    {
        private int iCount;
        private IMessageService _messageService;
        private IAuthenticationService _authenticationService;
        private LoginViewModel _ViewModel;
        private INavigateService<ProfilViewModel> _navigateService;

        public NavigateLoginCommand(INavigateService<ProfilViewModel> navigateService,
                                    IMessageService messageService,
                                    IAuthenticationService authenticationService)
        {
            this._navigateService = navigateService;
            this._messageService = messageService;
            this._authenticationService = authenticationService;
		}

       public async override void Execute(object parameter)
       {

         try
         {

            iCount = await this._authenticationService.LoginAsync();

            if (iCount > 0)
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
