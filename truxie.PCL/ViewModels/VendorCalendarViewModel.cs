using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace truxie.PCL
{
	public class VendorCalendarViewModel : BaseViewModel
	{
		WebService Service;

		public ObservableCollection<VendorCalendarEntry> Items{ get; set; }

		int CurrentPage = 1;

		public VendorCalendarViewModel ()
		{
			CurrentPage = 1;
			Service = new WebService ();
			Title = "calendar";
			Icon = "slideout.png";
			Items = new ObservableCollection<VendorCalendarEntry> ();
			IsBusy = false;
		}

		private Command refreshCommand;

		public Command RefreshCommand {
			get { return refreshCommand ?? (refreshCommand = new Command (async () => await ExecuteRefreshCommand ())); }
		}

		private async Task ExecuteRefreshCommand ()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			Items.Clear ();

			CurrentPage = 1;

			var res = await Service.GetVendorCalendarEntryList ("35.994033", "-78.898619", CurrentPage);

			CurrentPage += 1;

			foreach (var item in res) {
				Items.Add (item);
			}

			IsBusy = false;
		}

		private Command dataLoadCommand;

		public Command DataLoadCommand {
			get { return dataLoadCommand ?? (dataLoadCommand = new Command (async () => await ExecuteDataLoadCommand ())); }
		}

		private async Task ExecuteDataLoadCommand ()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			var res = await Service.GetVendorCalendarEntryList ("35.994033", "-78.898619", CurrentPage);

			CurrentPage += 1;

			foreach (var item in res) {
				Items.Add (item);
			}

			IsBusy = false;
		}
	}
}

