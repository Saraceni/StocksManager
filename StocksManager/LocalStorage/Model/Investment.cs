using System;
using SQLite;

namespace StocksManager
{
	public class Investment
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[MaxLength(8)]
		public string Symbol { get; set; }
		public string CompanyName { get; set; }
		public string Currency { get; set; }
		public DateTime Time { get; set; }
		public decimal Price { get; set; }
		public decimal Quantity { get; set; }
	}
}
