using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace truxie.Shared
{
	public class NearbyNowViewModel : BaseViewModel
	{
		WebService Service;

		public ObservableCollection<VendorEvent> Items{ get; set; }

		public NearbyNowViewModel ()
		{
			Service = new WebService ();
			Title = "nearby now";
			Icon = "slideout.png";
			Items = new ObservableCollection<VendorEvent> ();
			IsBusy = false;
		}

		private Command refreshCommand;

		public Command RefreshCommand {
			get { return refreshCommand ?? (refreshCommand = new Command (async () => await ExecuteDataLoadCommand ())); }
		}

		private Command dataLoadCommand;

		public Command DataLoadCommand {
			get { return dataLoadCommand ?? (dataLoadCommand = new Command (async () => await ExecuteDataLoadCommand ())); }
		}


		private async Task ExecuteDataLoadCommand ( )
		{
			if (IsBusy)
				return;

			IsBusy = true;

			// This list is so short that we should always just do a clear and fill.  No refreshing, no scrolling down.
			Items.Clear ();

			var res = await Service.GetNearbyVendorEventList ("35.994033", "-78.898619");

			foreach (var item in res) {
				Items.Add (item);
			}

			IsBusy = false;
		}


	}
}


