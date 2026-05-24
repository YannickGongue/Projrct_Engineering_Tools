using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EngineeringToolsCV_1.Service
{
	public class ImageService : IImageService
	{
		private IFileDialogService _fileDialogService;
		private IMessageService _messageService;
		private ImageSource imageSource;
		private ImageSource imageSourcedefault;
		private string ImagePath;


		public ImageService(IFileDialogService fileDialogService, 
			                 IMessageService messageService)
		{
			_fileDialogService = fileDialogService;
			_messageService = messageService;
		}

		public byte[] ConvertToBytes(string path)
		{
			return File.ReadAllBytes(path);
		}

		public string FileName(string path)
		{
			return Path.GetFileName(path);
		}

		public string FileExtension(string path)
		{
			return Path.GetExtension(path);
		}

		public ImageSource LoadImage(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return imageSourcedefault;
			}
			try
			{
				if (_fileDialogService.OpenImageFileDialog().ShowDialog() == true)
				{
					ImagePath = _fileDialogService.OpenImageFileDialog().FileName;
					imageSource = new BitmapImage(new Uri(ImagePath));
					return imageSource;
				}
			}
			catch (Exception ex)
			{
				this._messageService.ShowErrorMessage(ex.Message);
			}

			return imageSourcedefault;

		}
	}
}
