using System;

namespace truxie.Shared
{
	public class Tweets
	{
		public Tweets ()
		{
		}


		public ulong StatusID { get; set; }

		public string ScreenName { get; set; }

		public string Text { get; set; }

		public string Date { get; set; }
		public string UserImage { get; set; }
	}
}

