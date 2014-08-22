using System;
using System.Net;
using System.IO;

namespace truxie.Portable
{
	public class WebService
	{
		public WebService ()
		{
		}

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
	}
}

