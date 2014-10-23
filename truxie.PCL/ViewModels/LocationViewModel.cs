using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Services.Geolocation;


namespace truxie.PCL
 {

	public class LocationViewModel : BaseViewModel {
		public IGeolocator geolocator;

		public string testing;

		public LocationViewModel ()
		{
			geolocator = DependencyService.Get<IGeolocator>();
			testing = "ghjg";
		}
			
//		public override void OnAppearing() {
//			geolocator.PositionChanged += this.OnPositionChanged;
//			geolocator.StartListening(1, 10, false);
//		}
//
//
//		public override void OnDisappearing() {
//			this.geolocator.PositionChanged -= this.OnPositionChanged;
//			this.geolocator.StopListening();
//		}


		private void OnPositionChanged(object sender, PositionEventArgs e) {
			this.Latitude = e.Position.Latitude;
			this.Longitude = e.Position.Longitude;
			//this.Altitude = e.Position.Altitude;
			//this.Heading = e.Position.Heading;
		}


		private double latitude;
		public double Latitude {
			get { return this.latitude; }
			private set { this.SetProperty(ref this.latitude, value); }
		}


		private double longitude;
		public double Longitude {
			get { return this.longitude; }
			private set { this.SetProperty(ref this.longitude, value); }
		}


		private double altitude;
		public double Altitude {
			get { return this.altitude; }
			private set { this.SetProperty(ref this.altitude, value); }
		}


		private double heading;
		public double Heading {
			get { return this.heading; }
			private set { this.SetProperty(ref this.heading, value); }
		}
	}
}