using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.Service
{
	public class FileDialogService : IFileDialogService
	{
		public OpenFileDialog OpenImageFileDialog()
		{
			// Implementation for opening image file dialog
			OpenFileDialog dialog = new OpenFileDialog();

			dialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*"; ;
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			return dialog;
		}
	}
}
