using System;

namespace truxie.Shared
{
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
}