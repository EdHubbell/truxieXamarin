using System;

namespace truxie.PCL
{
	public class TruckTweet:Response
	{
		public TruckTweet ()
		{
		}

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

		[Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
		[Newtonsoft.Json.JsonProperty ("truxie_timestamp")]
		public DateTime TruxieTimestamp{ get; set; }

		public string DateAgo { 
			get{ return ParseDate(CreatedAt); }
		}

		string ParseDate (DateTime tweetDate)
		{
			string result = string.Empty;

			// added try block because time conversions are always a crapshoot.
			try
			{

				var ticks = DateTime.UtcNow.Ticks - tweetDate.Ticks;
				var timeAgo = new DateTime (ticks);

				if (timeAgo.Month > 0 && timeAgo.Year > 1) {
					result = tweetDate.ToString ("d MMM");
				} else if (timeAgo.Year > 1 && timeAgo.Day > 0 ) {
					result = string.Format ("{0}d ", timeAgo.Day);
					if (timeAgo.Hour > 0)
						result += string.Format ("{0}h ", timeAgo.Hour);
				} else if (timeAgo.Hour > 0) {
					result = string.Format ("{0}h ", timeAgo.Hour);
					if (timeAgo.Minute > 0)
						result += string.Format ("{0}m ", timeAgo.Minute);
				} else if (timeAgo.Minute > 0) {
					result = string.Format ("{0}m ", timeAgo.Minute);
					if (timeAgo.Second > 0)
						result += string.Format ("{0}s ", timeAgo.Second);
				} else {
					result = string.Format ("{0}s ", timeAgo.Second);
				}

			}

			catch 
			{
				result = string.Empty;
			}

			return result;
		}

	}
}

