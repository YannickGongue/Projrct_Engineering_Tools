using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.ViewModels;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EngineeringToolsCV_1.Service
{
	public class DialogService : IDialogService
	{
		private DBName _dbName;
		private RegisterView register;
		private UserResetView _UserResetView;
		private RegisterViewModel _vmRegister;
		private UserResetViewModel _vmUserReset; 

		public DialogService(RegisterViewModel vmRegister, 
			                  UserResetViewModel vmUserReset,
									DBName dbName)
		{
			this._vmRegister = vmRegister;
			this._vmUserReset = vmUserReset;
			this._dbName = dbName;
		}

		public void ShowRegister()
		{
			this.register = new RegisterView();
			this.register.DataContext = this._vmRegister;
			
			this.register.Show();
		}

		public void ShowResetPassword(DataTable dt)
		{
			this._UserResetView = new UserResetView();
			this._vmUserReset.SetEmail = dt.Rows[0][this._dbName.strEmail].ToString();
			this._UserResetView.DataContext = this._vmUserReset;
			this._UserResetView.Show();
		}
	}
}
