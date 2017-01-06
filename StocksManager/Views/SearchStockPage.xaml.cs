using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StocksManager
{
	public partial class SearchStockPage : ContentPage, StockSearchItem.StockItemAdded
	{
		APIService apiService = new APIService();
		SearchResult[] searchResult;
		ActivityIndicator activityIndicator;


		public SearchStockPage()
		{
			Title = "Stock Search";
			InitializeComponent();

			activityIndicator = new ActivityIndicator
			{
				HorizontalOptions=LayoutOptions.Center,
				VerticalOptions=LayoutOptions.Center,
				IsRunning = true
			};

			searchButton.Clicked += async (sender, args) =>
			{
				searchButton.IsEnabled = false;
				showActivityIndicator();

				App app = Application.Current as App;
				app.SearchStockEntryText = stockInput.Text;

				var stockName = stockInput.Text;
				var result = await apiService.SearchStockName(stockName);
				searchResult = result.ResultSet.Result;
				showResultOnList(searchResult);

				searchButton.IsEnabled = true;
			};
		}

		private void showActivityIndicator() {
			resultContainer.Children.Clear();
			resultContainer.Children.Add(activityIndicator);
		}

		private void showResultOnList(SearchResult[] data)
		{
			resultContainer.Children.Clear();
			for (int i = 0; i < data.Length; i++)
			{
				addDataToList(data[i], resultContainer.Children);
			}
		}

		private void addDataToList(SearchResult data, IList<View> dataList)
		{
			StockSearchItem listRow = new StockSearchItem(data, this);

			dataList.Add(listRow);
		}

		async public void onItemAdded(SearchResult stockItem)
		{
			await Navigation.PushAsync(new AddEditStockPage(stockItem));
		}
	}
}
