using System;
using System.IO;
using StocksManager.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace StocksManager.Droid
{
	public class FileHelper: IFileHelper
	{
		public string GetLocalFilePath(string filename)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}
	}
}
