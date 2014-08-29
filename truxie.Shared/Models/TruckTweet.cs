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

		public string Date { get; set; }
		public string UserImage { get; set; }
	}
}

