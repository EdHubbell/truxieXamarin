using System;

namespace truxie.Portable
{
	public	interface IRequested
	{
		[Newtonsoft.Json.JsonIgnore]
		string URL{ get; }
	}

	public	interface IResponse
	{
		string Error{ get; set; }
	}

	public class Response:IResponse
	{
		#region IResponse implementation

		public string Error { get; set; }

		public bool HasError{ get { return !string.IsNullOrEmpty (Error); } }

		#endregion
	}

	public class User
	{
		[Newtonsoft.Json.JsonProperty ("name")]
		public string Name{ get; set; }

		[Newtonsoft.Json.JsonProperty ("screen_name")]
		public string ScreenName{ get; set; }

		[Newtonsoft.Json.JsonProperty ("id")]
		public string Id{ get; set; }

		[Newtonsoft.Json.JsonProperty ("profile_image_url")]
		public string ProfileImageUrl{ get; set; }
	}

	public class TweetResponse:Response
	{
		[Newtonsoft.Json.JsonProperty ("text")]
		public string Text{ get; set; }

		[Newtonsoft.Json.JsonProperty ("user")]
		public User User{ get; set; }

		[Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
		[Newtonsoft.Json.JsonProperty ("created_at")]
		public DateTime CreatedAt{ get; set; }

		[Newtonsoft.Json.JsonProperty ("source")]
		public string Source{ get; set; }

		[Newtonsoft.Json.JsonProperty ("foodtruck_id")]
		public string FoodtruckId{ get; set; }

		[Newtonsoft.Json.JsonProperty ("truxie_tweet_id")]
		public string TruxieTweetId{ get; set; }

		[Newtonsoft.Json.JsonProperty ("truxie_timestamp")]
		public DateTime TruxieTimestamp{ get; set; }

		public TweetResponse ()
		{

		}
	}

	public class VendorCalendarEntryResponse:Response
	{

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


		public VendorCalendarEntryResponse ()
		{

		}
	}


	public class VendorEventsListResponse:Response
	{

		public VendorEventsListResponse ()
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

	public class StatusesResponse : Response{

		[Newtonsoft.Json.JsonProperty ("statuses")]
		public TweetResponse[] Statuses{ get; set; }

//		[Newtonsoft.Json.JsonProperty ("metadata")]
//		public string Metadata{ get; set; }

//		[Newtonsoft.Json.JsonProperty ("user")]
//		public User User{ get; set; }
//
//		[Newtonsoft.Json.JsonProperty ("text")]
//		public string Text{ get; set; }
//
//		[Newtonsoft.Json.JsonProperty ("created_at")]
//		public DateTime CreatedAt{ get; set; }
//
//		[Newtonsoft.Json.JsonProperty ("source")]
//		public string Source{ get; set; }
	}
}

