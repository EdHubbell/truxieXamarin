using System;

namespace truxie.Shared
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
		public TruckTweet[] Statuses{ get; set; }

	}
}

