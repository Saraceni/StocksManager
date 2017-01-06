using System;
namespace StocksManager
{
	public class SearchResultSet
	{
		public string Query { get; set; }
		public SearchResult[] Result { get; set; }

		public override string ToString()
		{
			return string.Format("[SearchResultSet: Query={0}, Result={1}]", Query, Result);
		}
	}
}
