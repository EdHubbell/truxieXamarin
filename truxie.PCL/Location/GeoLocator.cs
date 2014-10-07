//using System;
//using System.Threading;
//using System.Threading.Tasks;
////using Xamarin.Geolocation;
////using Acr.XamForms.Mobile;
//using Xamarin.Forms; 
//
//#if __ANDROID__
//using Android.App;
//#endif
//
//namespace truxie.PCL
//{
//	public class Geolocator : IGeoLocator {
//		private readonly Geolocator location;
//
//		public Geolocator() {
//			#if __ANDROID__
//			this.location = new Geolocator(Application.Context);
//			#else      
//			this.location = new Xamarin.Forms.Labs.Services.Geolocation.Position();
//			#endif
//			this.location.PositionChanged += this.OnPositionChanged;
//			this.location.PositionError += this.OnPositionError;
//		}
//
//		#region Internals
//
//		private void OnPositionChanged(object sender, PositionEventArgs e) {
//			if (this.PositionChanged != null) { 
//				var pos = ToFormsPosition(e.Position);
//				this.PositionChanged(this, new PositionEventArgs(pos));
//			}
//		}
//
//
//		private void OnPositionError(object sender, PositionErrorEventArgs e) {
//			if (this.PositionError != null) {
//				var error = e.Error == GeoLocationError.Unauthorized
//					? GeoLocationError.Unauthorized
//					: GeoLocationError.PositionUnavailable;
//				this.PositionError(this, new PositionErrorEventArgs(error));
//			}
//		}
//
//
//		private static Position ToFormsPosition(Position pos) {
//			return new Position {
//				Accuracy = pos.Accuracy,
//				Altitude = pos.Altitude,
//				AltitudeAccuracy = pos.AltitudeAccuracy,
//				Heading = pos.Heading,
//				Latitude = pos.Latitude,
//				Longitude = pos.Longitude,
//				Speed = pos.Speed,
//				Timestamp = pos.Timestamp
//			};
//		}
//
//		#endregion
//
//		#region IGeoLocator Members
//
//		public double DesiredAccuracy {
//			get { return this.location.DesiredAccuracy; }
//			set { this.location.DesiredAccuracy = value; }
//		}
//
//
//		public bool IsListening {
//			get { return this.location.IsListening; }
//		}
//
//
//		public bool IsGeoLocationAvailable {
//			get { return this.location.IsGeoLocationAvailable; }
//		}
//
//
//		public bool SupportsHeading {
//			get { return this.location.SupportsHeading; }
//		}
//
//
//		public void StartListening(int minTime, double minDistance, bool includeHeading = false) {
//			this.location.StartListening(minTime, minDistance, includeHeading);
//		}
//
//
//		public void StopListening() {
//			this.location.StopListening();
//		}
//
//
//		public async Task<Position> GetPositionAsync(int timeout, bool includeHeading, CancellationToken cancelToken) {
//			var turnBackOff = false;
//			if (!this.IsListening) {
//				turnBackOff = true;
//				this.StartListening(1, 10);
//			}
//			var pos = await this.location.GetPositionAsync(timeout, includeHeading, cancelToken);
//			if (turnBackOff)
//				this.StopListening();
//
//			return ToFormsPosition(pos);
//		}
//
//		public event EventHandler<PositionEventArgs> PositionChanged;
//
//		public event EventHandler<PositionErrorEventArgs> PositionError;
//
//		#endregion
//	}
//}