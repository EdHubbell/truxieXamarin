using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows;
using System.Net;
using System.Collections.ObjectModel;

namespace truxie.PCL
{	
	public partial class CalendarEntriesPage : ContentPage
	{	
		public ObservableCollection<VendorCalendarEntry> Items{ get; set; }

		int CurrentPage = 1;

		public CalendarEntriesPage ()
		{
			InitializeComponent ();

			btnRefresh.Activated  += OnRefreshActivated;

			Items = new ObservableCollection<VendorCalendarEntry>();

		}

		async void OnRefreshActivated(object sender, EventArgs args)
		{
			await DisplayAlert("YES!!!",
				"The button has been clicked - Now we try to load",
				"OK");

			CurrentPage = 1;

			var res = await WebService.GetVendorCalendarEntryList ("35.994033", "-78.898619", CurrentPage);

			CurrentPage += 1;

			foreach (var item in res) {
				Items.Add (item);
			}

			await DisplayAlert(Items.Count.ToString() + " Items",
				"And yet none of them render",
				"OK");
				

			IsBusy = false;

		}
	}
}

