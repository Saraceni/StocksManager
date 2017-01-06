using System;
using System.Text;

namespace StocksManager
{
	public class YahooEndpoint
	{
		// YQL
		private static string StockInfoUrl = "https://query.yahooapis.com/v1/public/yql";
		private static string StockInfoQueryString = "select * from yahoo.finance.quotes where symbol = \"{0}\"";
		private static string StockInfoEnvironmentString = "store://datatables.org/alltableswithkeys";

		public static Uri GetStockInfoUri(string symbol)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(StockInfoUrl);
			stringBuilder.Append("?");
			stringBuilder.Append("q=");
			stringBuilder.Append(string.Format(StockInfoQueryString, symbol));
			stringBuilder.Append("&format=json&env=");
			stringBuilder.Append(StockInfoEnvironmentString);
			return new Uri(stringBuilder.ToString());
		}

		// http://autoc.finance.yahoo.com/autoc
		private static string FindStockUrl = "http://autoc.finance.yahoo.com/autoc";
		private static string FindStockParams = "callback=YAHOO.Finance.SymbolSuggest.ssCallback&region=us&lang=en";
		private static string FindStockQueryParams = "query={0}";

		public static Uri GetFindStockUri(string name)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(FindStockUrl);
			stringBuilder.Append("?");
			stringBuilder.Append(string.Format(FindStockQueryParams, name));
			stringBuilder.Append("&");
			stringBuilder.Append(FindStockParams);
			return new Uri(stringBuilder.ToString());
		}

	}
}
