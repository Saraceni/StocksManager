using System;
namespace StocksManager
{
	public class WsSearchJsonResponse
	{
		public SearchResultSet ResultSet;

		public override string ToString()
		{
			return string.Format("[WsSearchJsonResponse]");
		}
	}
}
