using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StocksManager
{
	public partial class MainPage : ContentPage, InvestmentListItem.InvestmentSelected
	{
		private List<Investment> investments;

		public MainPage()
		{
			Title = "My Investments";
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			loadData();
		}

		async void loadData()
		{
			investments = await StocksDB.Database.GetInvestmentsAsync();
			updateUI();
		}

		private void updateUI()
		{
			resultContainer.Children.Clear();
			for (int i = 0; i < investments.Count; i++)
			{
				InvestmentListItem listRow = new InvestmentListItem(investments.ElementAt(i), this);
				resultContainer.Children.Add(listRow);
			}
		}

		async public void NewInvestmentClick(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new SearchStockPage());
		}

		async public void OnInvestmentSelected(Investment investment)
		{
			await StocksDB.Database.DeleteInvestmentsAsync(investment);
			loadData();
		}
	}
}
