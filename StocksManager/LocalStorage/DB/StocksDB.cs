using System;
using Xamarin.Forms;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StocksManager
{
	public class StocksDB
	{
		// Singleton Pattern
		static StocksDB database;

		public static StocksDB Database
		{
			get
			{
				if (database == null)
				{
					database = new StocksDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("StockSQLite.db3"));
				}

				return database;
			}
		}

		private SQLiteAsyncConnection conn;

		public StocksDB(string dbPath)
		{
			conn = new SQLiteAsyncConnection(dbPath);
			conn.CreateTableAsync<Investment>().Wait();
		}

		public Task<List<Investment>> GetInvestmentsAsync()
		{
			return conn.Table<Investment>().ToListAsync();
		}

		public Task<int> SaveInvestmentAsync(Investment investment)
		{
			if (investment.Id != 0) { return conn.UpdateAsync(investment); }
			else { return conn.InsertAsync(investment); }
		}

		public Task<int> DeleteInvestmentsAsync(Investment investment)
		{
			return conn.DeleteAsync(investment);
		}
	}
}
