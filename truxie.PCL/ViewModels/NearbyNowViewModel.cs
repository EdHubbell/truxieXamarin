using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Mvvm;

namespace truxie.PCL
{
	public class NearbyNowViewModel : LocationViewModel
	{
		public event Action<string,string> DisplayErrorAction;

		public ObservableCollection<VendorEvent> Items{ get; set; }

		public NearbyNowViewModel ( )
		{
			//base.Init();

			Title = "nearby now";
			Icon = "slideout.png";
			Items = new ObservableCollection<VendorEvent> ();
			IsBusy = false;
		
		}

		public override void OnAppearing() {

			base.OnAppearing();

			ExecuteDataLoadCommand();
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
//			this.location.PositionChanged += this.OnPositionChanged;
//			this.location.StartListening (60000, 50, true);
		}

		private void ExecuteDisappearingCommand ()
		{
//			this.location.PositionChanged -= this.OnPositionChanged;
//			this.location.StopListening ();
		}

		private async Task ExecuteDataLoadCommand ()
		{
	
			if (IsBusy)
				return;

			IsBusy = true;

			//this.Latitude

			System.Diagnostics.Debug.WriteLine(Latitude);
			System.Diagnostics.Debug.WriteLine (Longitude);

	//		await dialogService.AlertAsync("Test alert", "Alert Title", "CHANGE ME!");

			// This list is so short that we should always just do a clear and fill.  No refreshing, no scrolling down.
			Items.Clear ();



			//this.geolocator.StartListening ();


			var res = await WebService.GetNearbyVendorEventList (Latitude.ToString(), Longitude.ToString());//("35.994033", "-78.898619");

//			if (res.HasError) {
//				if (DisplayErrorAction != null)
//					DisplayErrorAction ("Load VendorEvents", res.Error);
//			} else {
//				foreach (var item in res.VendorEvents) {
//					Items.Add (item);
//				}
//			}
			IsBusy = false;
		}


	}
}


