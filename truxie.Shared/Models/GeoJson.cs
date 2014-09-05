using System;

namespace truxie.Shared
{
	public class GeoJson
	{
		public GeoJson ()
		{
		}

		[Newtonsoft.Json.JsonProperty ("type")]
		public string Type { get; set; }

		[Newtonsoft.Json.JsonProperty ("coordinates")]
		public double[] Coordinates { get; set; }
	}
}

