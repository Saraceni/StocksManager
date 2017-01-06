using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StocksManager
{
	public class APIService
	{
		HttpClient client;


		public APIService() 
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}

		public async Task<WsSearchJsonResponse> SearchStockName(string symbol)
		{
			var response = await client.GetAsync(YahooEndpoint.GetFindStockUri(symbol));
			WsSearchJsonResponse jsonResponse = null;

			if (response.IsSuccessStatusCode)
			{
				String content = await response.Content.ReadAsStringAsync();
				content = content.Substring("YAHOO.Finance.SymbolSuggest.ssCallback(".Length);
				content = content.Remove(content.Length - ");".Length);

				jsonResponse = JsonConvert.DeserializeObject<WsSearchJsonResponse>(content);
			}

			return jsonResponse;
		}

		public async Task<WsJsonResponse> GetStockData(string symbol)
		{
  			var response = await client.GetAsync(YahooEndpoint.GetStockInfoUri(symbol));
			WsJsonResponse jsonResponse = null;

			if (response.IsSuccessStatusCode)
			{
				String content = await response.Content.ReadAsStringAsync();
				jsonResponse = JsonConvert.DeserializeObject<WsJsonResponse>(content);
			}

			return jsonResponse;
		}
	}
}
