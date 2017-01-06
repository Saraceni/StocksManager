using System;
namespace StocksManager
{
	public class FinanceQuotes
	{
		public int count { get; set; }
		public string created { get; set; }
		public string lang { get; set; }
		public Results results { get; set; }

		public override string ToString()
		{
			return string.Format("[FinanceQuotes: count={0}, created={1}, lang={2}]", count, created, lang);
		}
	}
}
