using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace truxie.PCL
{
	public class NearbyNowViewModel : BaseViewModel
	{
		public event Action<string,string> DisplayErrorAction;

		private readonly IGeoLocator location;
		WebService Service;

		public ObservableCollection<VendorEvent> Items{ get; set; }

		public NearbyNowViewModel ()
		{
			this.location = new GeoLocator ();
			Service = new WebService ();
			Title = "nearby now";
			Icon = "slideout.png";
			Items = new ObservableCollection<VendorEvent> ();
			IsBusy = false;
		}

		private async void OnPositionChanged (object sender, PositionEventArgs e)
		{
			if (IsBusy)
				return;
			this.UserLatitude = e.Position.Latitude;
			this.UserLongitude = e.Position.Longitude;
			if (DisplayErrorAction != null)
				DisplayErrorAction ("Current Location", string.Format("Latitude:{0} \r\nLongitude:{1}",this.UserLatitude,this.UserLongitude));
			await ExecuteDataLoadCommand ();
		}

		double UserLatitude {
			get;
			set;
		}

		double UserLongitude {
			get;
			set;
		}

		private Command refreshCommand;

		public Command RefreshCommand {
			get { return refreshCommand ?? (refreshCommand = new Command (async () => await ExecuteDataLoadCommand ())); }
		}

		private Command dataLoadCommand;

		public Command DataLoadCommand {
			get { return dataLoadCommand ?? (dataLoadCommand = new Command (async () => await ExecuteDataLoadCommand ())); }
		}

		private Command appearingCommand;

		public Command AppearingCommand {
			get { return appearingCommand ?? (appearingCommand = new Command ( () =>  ExecuteAppearingCommand ())); }
		}

		private Command disappearingCommand;

		public Command DisappearingCommand {
			get { return disappearingCommand ?? (disappearingCommand = new Command ( () =>  ExecuteDisappearingCommand ())); }
		}

		private  void ExecuteAppearingCommand ()
		{
			this.location.PositionChanged += this.OnPositionChanged;
			this.location.StartListening (60000, 50, true);
		}

		private void ExecuteDisappearingCommand ()
		{
			this.location.PositionChanged -= this.OnPositionChanged;
			this.location.StopListening ();
		}

		private async Task ExecuteDataLoadCommand ()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			// This list is so short that we should always just do a clear and fill.  No refreshing, no scrolling down.
			Items.Clear ();

			var res = await Service.GetNearbyVendorEventList (UserLatitude.ToString(), UserLongitude.ToString());//("35.994033", "-78.898619");

			if (res.HasError) {
				if (DisplayErrorAction != null)
					DisplayErrorAction ("Load VendorEvents", res.Error);
			} else {
				foreach (var item in res.VendorEvents) {
					Items.Add (item);
				}
			}
			IsBusy = false;
		}


	}
}


