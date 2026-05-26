using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.ViewModels;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace EngineeringToolsCV_1.Service
{
	public class DialogService : IDialogService
	{
		private DBName _dbName;
		private RegisterView register;
		private UserResetView _UserResetView;
		private RegisterViewModel _vmRegister;
		private UserResetViewModel _vmUserReset; 

		public void Show(Window window)
		{
			window.Show();
		}
		
	}
}
