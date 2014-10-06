using System;

namespace truxie.PCL
{
	public class VendorLocation
	{
		public VendorLocation ()
		{
		}

		[Newtonsoft.Json.JsonProperty ("_id")]
		public string Id { get; set; }

		[Newtonsoft.Json.JsonProperty ("geoJSON")]
		public GeoJson GeoJson { get; set; }

		[Newtonsoft.Json.JsonProperty ("locName")]
		public string LocName { get; set; }

	}
}

