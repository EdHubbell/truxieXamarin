using System;

namespace truxie.PCL
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

	public class StatusesResponse : Response{

		[Newtonsoft.Json.JsonProperty ("statuses")]
		public TruckTweet[] Statuses{ get; set; }

	}
}

