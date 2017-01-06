using System;
namespace StocksManager
{
	public class WsJsonResponse
	{
		public FinanceQuotes query { get; set; }

		public override string ToString()
		{
			return string.Format("[WsJsonResponse: query={0}]", query);
		}
	}
}
