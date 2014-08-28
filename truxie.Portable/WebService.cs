using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace truxie.Portable
{
	public class WebService
	{
		public WebService ()
		{
		}
		string base_url=string.Format(@"http://truxie.com/api/v1/truckTweets?_dc=1408411784370&userLat={0}&userLon={1}&start={2}&limit={3}", 35.994033, -78.898619, 0, 20);

		public void GetTweetsInitData(String userLat, String userLon, int start, int limit)
		{
			string url = string.Format(@"http://truxie.com/api/v1/truckTweets?_dc=1408411784370&userLat={0}&userLon={1}&start={2}&limit={3}", userLat, userLon, start, limit);
			var httpReq = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));

			httpReq.BeginGetResponse ((ar) => {
				int success = 0;
				String msg = "Cannot connect to server";

				try
				{
					var request = (HttpWebRequest)ar.AsyncState;
					using (var response = (HttpWebResponse)request.EndGetResponse (ar))     {                           

						try{
							var s = response.GetResponseStream ();

						}
						catch (Exception e)
						{
						}
					}
				}
				catch (Exception e)
				{
				}

			} , httpReq);
		}
	
		public async Task<string> GetTweetsData(String userLat, String userLon, int start, int limit)
		{
			string url=string.Format(@"http://truxie.com/api/v1/truckTweets?_dc=1408411784370&userLat={0}&userLon={1}&start={2}&limit={3}", userLat, userLon, start, limit);

			var res = await PerformRequest(url,"","GET");

			return res;
		}

		protected Task<string> PerformRequest (string url, string method = "GET")
		{
			return GetResponse (CreateRequest (url, method));
		}

		protected async Task<string> PerformRequest (string url, string json, string method = "POST")
		{
			HttpWebRequest request = CreateRequest (url, method);

			if (!"{}".Equals (json) && method != "GET") {
				using (var streamWriter = new StreamWriter (await request.GetRequestStreamAsync ())) {

					streamWriter.Write (json);
					streamWriter.Flush (); 
				}
			}

			return await GetResponse (request);
		}

//		protected virtual string BuildRequestUrl ()
//		{
//			return string url = BASE_URL;
//		}

		private HttpWebRequest CreateRequest (string url, string method)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create (url);
			request.Method = method;
			request.ContentType = "application/json";

			return request;
		}

		private async Task<string> GetResponse (HttpWebRequest request)
		{
			try {
				using (HttpWebResponse response = await request.GetResponseAsync () as HttpWebResponse) {

					if (response.StatusCode == HttpStatusCode.OK) {

						using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
							var responsestring = reader.ReadToEnd ();
							return responsestring;
						}

					} else if (response.StatusCode == HttpStatusCode.NoContent)
						return  "{ \"Error\" :\"\"}";
				}

			} catch (Exception ex) {
				return  "{ \"Error\" :\"" + ex.Message + "\"}";
			}
			return string.Empty;
		}
	}
}

