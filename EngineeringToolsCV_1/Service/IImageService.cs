using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace EngineeringToolsCV_1.Service
{
	public interface IImageService
	{
		byte[] ConvertToBytes(string path);
		string FileName (string path);

	   string FileExtension(string path);
		ImageSource LoadImage(string path);

	}
}
