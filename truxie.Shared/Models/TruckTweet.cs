using System;

namespace truxie.Shared
{
	public class TruckTweet
	{
		public TruckTweet ()
		{
		}

		public ulong StatusID { get; set; }

		public string ScreenName { get; set; }

		public string Text { get; set; }

		DateTime date = DateTime.MinValue;

		public DateTime Date { 
			get{ return date; }
			set {
				date = value;
				DateString = ParseDate (date);
			}
		}

		public string UserImage { get; set; }

		public string UserID { get;	set; }

		public string DateString {
			get;
			set;
		}

		string ParseDate (DateTime date)
		{
			string result = string.Empty;

			var ticks = DateTime.UtcNow.Ticks - date.Ticks;
			var timeAgo = new DateTime (ticks);

			if (timeAgo.Month > 0 && timeAgo.Year > 1) {
				result = date.ToString ("d MMM");
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

			return result;
		}
	}
}

