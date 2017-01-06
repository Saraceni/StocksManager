using System;
namespace StocksManager
{
	public class Results
	{
		public Quote quote { get; set; }

		public override string ToString()
		{
			return string.Format("[Results: quote={0}]", quote);
		}
	}
}
