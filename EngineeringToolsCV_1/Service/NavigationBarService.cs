using EngineeringToolsCV_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.Service
{
	public class NavigationBarService : INavigationBarService
	{
		private NavigationBarViewModel _instance;
		private string _statusBarText;
		public NavigationBarService(string statusBarText)
		{
			_statusBarText = statusBarText;
		}
		public NavigationBarViewModel CreateNavigationBar(string statusBarText)
		{
			_instance = new NavigationBarViewModel(statusBarText);
			return _instance;
		}
	}
}
