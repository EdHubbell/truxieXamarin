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
}

