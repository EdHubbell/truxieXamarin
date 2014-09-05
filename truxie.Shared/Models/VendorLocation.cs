using System;

namespace truxie.Shared
{
	public class VendorLocation
	{
		public VendorLocation ()
		{
		}

		public string Id { get; set; }
		public GeoJson GeoJson { get; set; }
		public string LocName { get; set; }

		//public string TruckId { get; set; }
		//public string TruckName { get; set; }

	}
}

