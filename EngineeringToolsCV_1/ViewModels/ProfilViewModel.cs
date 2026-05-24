using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.Components;
using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.ViewModels
{
	public class ProfilViewModel: ViewModelBase
	{
		private INavigationBarService _navigationBarService;
		private IMessageService _messageService;
		

		public ViewModelCommand NavigateUpdateCommand { get; }

		public ProfilViewModel(NavigationStore navigateStore,
									  INavigationBarService navigationBarService,
								     IMessageService messageService
								)
		{
			this._navigationBarService = navigationBarService;
			this._messageService = messageService;


			this.NavigateUpdateCommand = new NavigateCommand<DashboardViewModel>(
													new LayoutNavigationService<DashboardViewModel>(navigateStore,
													() => new DashboardViewModel(navigateStore, this._mStudent, this._dbManager, this._dbName, this._vmDialogMessage, this._mUserWorkInfo), 
													this._navigationBarService.CreateNavigationBar("Home -> Profil -> Dashboard")));
		}

	}
}
   