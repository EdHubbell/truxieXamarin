using System;

namespace truxie.PCL
{
	public class Vendor:Response
	{
		public Vendor ()
		{
		}

		[Newtonsoft.Json.JsonProperty ("_id")]
		public string TruckId { get; set; }

		[Newtonsoft.Json.JsonProperty ("phone")]
		public string Phone { get; set; }

		[Newtonsoft.Json.JsonProperty ("yelp")]
		public string Yelp { get; set; }

		[Newtonsoft.Json.JsonProperty ("homepage")]
		public string Homepage { get; set; }

		[Newtonsoft.Json.JsonProperty ("facebookPage")]
		public string FacebookPage { get; set; }

		[Newtonsoft.Json.JsonProperty ("shortDesc")]
		public string ShortDesc { get; set; }

		[Newtonsoft.Json.JsonProperty ("longDesc")]
		public string LongDesc { get; set; }

		[Newtonsoft.Json.JsonProperty ("calendarUrl")]
		public string CalendarUrl { get; set; }

		[Newtonsoft.Json.JsonProperty ("customerContactEmail")]
		public string CustomerContactEmail { get; set; }

		[Newtonsoft.Json.JsonProperty ("instagramId")]
		public string InstagramId { get; set; }

		[Newtonsoft.Json.JsonProperty ("instagramUsername")]
		public string InstagramUsername { get; set; }

		[Newtonsoft.Json.JsonProperty ("twitScreenName")]
		public string TwitScreenName { get; set; }

		[Newtonsoft.Json.JsonProperty ("geotaggedTweetOptions")]
		public string GeotaggedTweetOptions { get; set; }

		[Newtonsoft.Json.JsonProperty ("truckName")]
		public string VendorName { get; set; } 

		[Newtonsoft.Json.JsonProperty ("twitImageUrl")]
		public string ImageUrl { get; set; } 

	}
}

