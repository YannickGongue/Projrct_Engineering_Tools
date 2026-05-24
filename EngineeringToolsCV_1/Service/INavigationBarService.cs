using EngineeringToolsCV_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.Service
{
	public interface INavigationBarService
	{
		NavigationBarViewModel CreateNavigationBar(string statusBarText);
	}
}
