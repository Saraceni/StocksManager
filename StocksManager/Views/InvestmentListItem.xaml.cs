using System;
using System.Globalization;
using Xamarin.Forms;

namespace StocksManager
{

	public partial class InvestmentListItem : ContentView
	{
		private Investment investment;
		private Quote quote;
		private InvestmentSelected callback;
		private APIService apiService = new APIService();

		public InvestmentListItem()
		{
			InitializeComponent();
		}

		async void getServerData()
		{
			activityIndicator.IsRunning = true;
			var result = await apiService.GetStockData(investment.Symbol);
			this.quote = result.query.results.quote;
			activityIndicator.IsRunning = false;
			updateUIWithServerData();
		}

		public InvestmentListItem(Investment investment, InvestmentSelected callback)
		{
			InitializeComponent();
			this.callback = callback;
			this.investment = investment;
			updateUIWithLocalData();
			getServerData();
		}

		private void updateUIWithServerData()
		{
			NumberFormatInfo numInfo = NumberFormatInfo.CurrentInfo;
			Char separator = numInfo.CurrencyDecimalSeparator.ToCharArray()[0];

			Double tradePrice = Double.Parse(quote.LastTradePriceOnly.Replace('.', separator));
			Double finalCurrentPrice = tradePrice * (Double) investment.Quantity;

			Double finalReturnVal = finalCurrentPrice - Double.Parse(investVal.Text);
			Color textColor = Color.Default;
			if (finalReturnVal > 0) { textColor = Color.Green; }
			else if (finalReturnVal < 0) { textColor = Color.Red; }

			returnVal.TextColor = textColor;
			currency2.TextColor = textColor;

			returnVal.Text = finalReturnVal.ToString();
		}

		private void updateUIWithLocalData()
		{
			symbol.Text = investment.Symbol;
			company.Text = investment.CompanyName;

			currency1.Text = investment.Currency;
			currency2.Text = investment.Currency;

			investVal.Text = (investment.Price * investment.Quantity).ToString();
		}

		public void DeleteClicked(object sender, EventArgs args)
		{
			this.callback.OnInvestmentSelected(investment);
		}

		public interface InvestmentSelected { void OnInvestmentSelected(Investment investment); }
	}
}
