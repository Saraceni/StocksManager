using System;
using Xamarin.Forms;
using System.Globalization;

namespace StocksManager
{
	public partial class AddEditStockPage : ContentPage
	{
		private SearchResult searchStockData;
		private Quote quote;
		private APIService apiService = new APIService();

		public AddEditStockPage()
		{
		}

		public AddEditStockPage(SearchResult searchStockData)
		{
			Title = "Stock Info";
			InitializeComponent();

			this.searchStockData = searchStockData;
			symbol.Text = searchStockData.symbol;
			company.Text = searchStockData.name;

			loadStockData();
		}

		async public void loadStockData()
		{
			activityIndicator.IsRunning = true;
			var result = await apiService.GetStockData(searchStockData.symbol);
			this.quote = result.query.results.quote;
			activityIndicator.IsRunning = false;
			updateUI();
		}

		private void updateUI()
		{
			NumberFormatInfo numInfo = NumberFormatInfo.CurrentInfo;
			Char separator = numInfo.CurrencyDecimalSeparator.ToCharArray()[0];

			currency1.Text = quote.Currency;
			stockPrice.Text = quote.LastTradePriceOnly.Replace('.', separator);
			currency2.Text = quote.Currency;
			total.Text = quote.LastTradePriceOnly.Replace('.', separator);
			open.Text = quote.Open.Replace('.', separator);

			String s_change = quote.Change.Replace('.', separator);
			change.Text = s_change;
			if (s_change.StartsWith("+")) { change.TextColor = Color.Green; }
			else if (s_change.StartsWith("-")) { change.TextColor = Color.Red; }
			else { change.TextColor = Color.Default; }

			String s_percentChange = quote.PercentChange.Replace('.', separator);
			percentChange.Text = s_percentChange;
			if (s_percentChange.StartsWith("+")) { percentChange.TextColor = Color.Green; }
			else if (s_percentChange.StartsWith("-")) { percentChange.TextColor = Color.Red; }
			else { percentChange.TextColor = Color.Default; }

			daysLow.Text = quote.DaysLow.Replace('.', separator);
			daysHigh.Text = quote.DaysHigh.Replace('.', separator);

			marketCapitalization.Text = quote.MarketCapitalization.Replace('.', separator);
		}

		public void NumStocksChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length == 0) { 
				total.Text = "";
				Save.IsEnabled = false;
			}
			else if (!IsAllDigits(e.NewTextValue)) { stockQuantity.Text = e.OldTextValue; }
			else if (ContainsOnlyZero(e.NewTextValue)) { stockQuantity.Text = "1"; }
			else
			{
				Save.IsEnabled = true;
				total.Text = (EntryToDouble(stockQuantity) * EntryToDouble(stockPrice)).ToString();
			}
		}

		private Double EntryToDouble(Entry entry)
		{
			return Double.Parse(entry.Text);
		}

		private bool ContainsOnlyZero(string s)
		{
			foreach (char c in s)
			{
				if (c != '0') { return false; } 
			}
			return true;
		}

		private bool IsAllDigits(string s)
		{
			foreach (char c in s)
			{
				if (!char.IsDigit(c))
					return false;
			}
			return true;
		}

		async public void CancelButton(object sender, EventArgs args)
		{
			Cancel.IsEnabled = false;
			await Navigation.PopAsync();
		}

		async public void SaveStock(object sender, EventArgs args)
		{
			Investment investment = new Investment();
			investment.CompanyName = company.Text;
			investment.Price = Decimal.Parse(stockPrice.Text);
			investment.Quantity = Decimal.Parse(stockQuantity.Text);
			investment.Symbol = symbol.Text;
			investment.Time = new DateTime();
			investment.Currency = currency1.Text;

			Save.IsEnabled = false;
			activityIndicator.IsRunning = true;

			await StocksDB.Database.SaveInvestmentAsync(investment);

			Save.IsEnabled = true;
			activityIndicator.IsRunning = false;

			Cancel.IsEnabled = false;
			await Navigation.PopAsync();
		}
	}
}
