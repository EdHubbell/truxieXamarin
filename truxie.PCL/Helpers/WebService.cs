using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Fusillade;
using ModernHttpClient;

namespace truxie.PCL
{
	public class WebService
	{
		public WebService ()
		{
		}

		static public async Task<string> GetValuesFromApi (string url)
		{
			var httpClient = new HttpClient(new NativeMessageHandler());

			Task<string> apiWebRequest = httpClient.GetStringAsync(url); // async method!

			string apiResponse = await apiWebRequest;

			return apiResponse;

		}

		static public async Task<string> GetValuesFromApiFusillade (string url)
		{

			var client = new HttpClient(NetCache.UserInitiated);
			var response = await client.GetAsync(url);
			var apiResponse = await response.Content.ReadAsStringAsync();

			return apiResponse;

		}

		static public async Task<StatusesResponse> GetCurrUserTweetsData (string currId, string currentUser)
		{
			string url = string.Format (@"http://api.truxie.com/api/v1/twitterSearch?_dc={0}&include_entities=false&result_type=recent&q={1}&count=20", currId, currentUser);

			string apiResponse = await GetValuesFromApiFusillade(url);

			StatusesResponse result = null;
			try {
				result = JsonConvert.DeserializeObject<StatusesResponse> (apiResponse);
			} catch (Exception ex) {
				var temp = ex;
			}
			return result;
		}

		static public async Task<TruckTweet[]> GetTweetsData (String userLat, String userLon, int start, int limit)
		{
			string url = string.Format (@"http://truxie.com/api/v1/truckTweets?_dc=1408411784370&userLat={0}&userLon={1}&start={2}&limit={3}", userLat, userLon, start, limit);

			string apiResponse = await GetValuesFromApiFusillade(url);

			return JsonConvert.DeserializeObject<TruckTweet[]> (apiResponse);
		}



		static public async Task<VendorCalendarEntry[]> GetVendorCalendarEntryList (String userLat, String userLon, int page)
		{
			string url = string.Format (@"http://truxie.com/api/v1/truckCalendarEntries?userLat={0}&userLon={1}&page={2}", userLat, userLon, page);

			string apiResponse = await GetValuesFromApiFusillade(url);

			return JsonConvert.DeserializeObject<VendorCalendarEntry[]> (apiResponse);
		}

		static public async Task<VendorEvent[]> GetNearbyVendorEventList (String userLat, String userLon)
		{
			string url = string.Format (@"http://truxie.com/api/v1/nearbyList?userLat={0}&userLon={1}", userLat, userLon);
			var apiResponse = await GetValuesFromApiFusillade (url);

			return JsonConvert.DeserializeObject<VendorEvent[]> (apiResponse);

		}

	}
}

