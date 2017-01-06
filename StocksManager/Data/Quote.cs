using System;
namespace StocksManager
{
	public class Quote
	{
		public string symbol { get; set; }
		public string Change { get; set; }
		public string Currency { get; set; }
		public string LastTradeDate { get; set; }
		public string PercentChange { get; set; }
		public string YearRange { get; set; }
		public string Name { get; set; }
		public string Open { get; set; }
		public string MarketCapitalization { get; set; }

		// Usar esse aqui
		public string LastTradePriceOnly { get; set; }

		public string DaysLow { get; set; }
		public string DaysHigh { get; set; }
		public string YearLow { get; set; }
		public string YearHigh { get; set; }

		public override string ToString()
		{
			return string.Format("[Quote: symbol={0}, Change={1}, Currency={2}, LastTradeDate={3}, PercentChange={4}, YearRange={5}, Name={6}, Open={7}, MarketCapitalization={8}, LastTradePriceOnly={9}, DaysLow={10}, DaysHigh={11}, YearLow={12}, YearHigh={13}]", symbol, Change, Currency, LastTradeDate, PercentChange, YearRange, Name, Open, MarketCapitalization, LastTradePriceOnly, DaysLow, DaysHigh, YearLow, YearHigh);
		}

	}
}
