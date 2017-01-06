using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StocksManager
{
	public partial class StockSearchItem : ContentView
	{
		private SearchResult stockItem;
		private StockItemAdded callback;

		public StockSearchItem()
		{
			InitializeComponent();
		}
		                              
		public StockSearchItem(SearchResult stockItem, StockItemAdded callback)
		{
			InitializeComponent();

			this.stockItem = stockItem;
			this.symbol.Text = stockItem.symbol;
			this.company.Text = stockItem.name;
			this.callback = callback;
		}

		void OnAddItemClicked(object sender, EventArgs args)
		{
			if (callback != null)
			{
				callback.onItemAdded(stockItem);
			}
		}

		public interface StockItemAdded { void onItemAdded(SearchResult stockItem); }
	}
}
