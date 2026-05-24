using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EngineeringToolsCV_1.Service
{
	public class WindowService : IWindowService
	{
		private Window _instance;
		public WindowService(Window instance) {

			_instance =  instance;
		}
		public void ShowWindow()
		{
			_instance.Show();
		}	
	
	}
}
