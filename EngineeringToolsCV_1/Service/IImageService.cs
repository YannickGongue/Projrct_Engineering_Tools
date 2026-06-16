using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EngineeringToolsCV_1.Service
{
	public interface IImageService
	{
		byte[] ConvertToBytes(string path);
		string FileName (string path);
	   string FileExtension(string path);
		ImageSource LoadImage(OpenFileDialog dialog);
		BitmapImage ConvertToImage(byte[] imageData);

	}
}
