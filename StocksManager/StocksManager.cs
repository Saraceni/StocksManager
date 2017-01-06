using System;

using Xamarin.Forms;

namespace StocksManager
{
	public class App : Application
	{
		const string searchStockEntryText = "searchStockEntryText";

		public string SearchStockEntryText { get; set; }

		public App()
		{
			if (Properties.ContainsKey(searchStockEntryText))
			{
				SearchStockEntryText = (string)Properties[searchStockEntryText];
			}

			//MainPage = new MainPage();
			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			Properties[searchStockEntryText] = SearchStockEntryText;
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
