using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows;
using System.Net;

namespace truxie.PCL
{	
	public partial class CalendarEntriesPage : ContentPage
	{	
		public CalendarEntriesPage ()
		{
			InitializeComponent ();

			btnRefresh.Activated  += new EventHandler(OnRefreshActivated);

		}

		async void OnRefreshActivated(object sender, EventArgs args)
		{
			await DisplayAlert("YES!!!",
				"The button has been clicked",
				"OK");
		}
	}
}

