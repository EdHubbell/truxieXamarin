using System;

namespace truxie.PCL
{
	public class VendorEvent:Vendor
	{
		public VendorEvent ()
		{
		}


		[Newtonsoft.Json.JsonProperty ("vendorLocation")]
		public VendorLocation VendorLocation { get; set; }

		[Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
		[Newtonsoft.Json.JsonProperty ("eventStartDateTime")]
		public DateTime EventStartDateTime { get; set; } 

		[Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
		[Newtonsoft.Json.JsonProperty ("eventEndDateTime")]
		public DateTime EventEndDateTime { get; set; }


	}
}



