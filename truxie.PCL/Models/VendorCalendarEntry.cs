using System;

namespace truxie.PCL
{

	public class VendorCalendarEntry:Response
	{
		public VendorCalendarEntry ()
		{
		}

		// These names are messed up - Need to get things squared away into one naming convention.
		// So trying to start that here.  Evenually, the API will use the same names as this code, so 
		// the mapping here will be more intuitve

		[Newtonsoft.Json.JsonProperty ("twitImageUrl")]
		public string ImageUrl{ get; set; }

		[Newtonsoft.Json.JsonProperty ("truckName")]
		public string VendorName { get; set; }

		[Newtonsoft.Json.JsonProperty ("start.dateTime")]
		public DateTime StartDateTime { get; set; }

		[Newtonsoft.Json.JsonProperty ("end.dateTime")]
		public DateTime EndDateTime { get; set; }

		[Newtonsoft.Json.JsonProperty ("location")]
		public string Location { get; set; }

		[Newtonsoft.Json.JsonProperty ("description")]
		public string Description { get; set; }

		[Newtonsoft.Json.JsonProperty ("summary")]
		public string Summary { get; set; }


	}

}