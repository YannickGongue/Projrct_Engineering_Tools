using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EngineeringToolsCV_1.Service
{
	public interface IDialogService
	{
		void ShowRegister();
		void ShowResetPassword(DataTable dt);
	}
}
