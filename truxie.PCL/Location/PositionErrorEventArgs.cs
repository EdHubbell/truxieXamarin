using System;

namespace truxie.PCL
{
	public enum GeoLocationError {
		PositionUnavailable,
		Unauthorized
	}


	public class PositionErrorEventArgs : EventArgs {
		public GeoLocationError Error { get; private set; }

		public PositionErrorEventArgs(GeoLocationError error) {
			this.Error = error;
		}
	}
}