using System;
namespace StocksManager
{
	public class SearchResult
	{
		public string symbol { get; set; }
		public string name { get; set; }
		public string exch { get; set; }
		public string type { get; set; }
		public string exchDisp { get; set; }
		public string typeDisp { get; set; }

		public override string ToString()
		{
			return string.Format("[SearchResult: symbol={0}, name={1}, exch={2}, type={3}, exchDisp={4}, typeDisp={5}]", symbol, name, exch, type, exchDisp, typeDisp);
		}
	}
}
