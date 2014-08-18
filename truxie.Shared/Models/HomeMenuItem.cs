using System;

namespace truxie.Shared
{
	public enum MenuType
	{
		About,
		Blog,
		Twitter, 
		NearbyNow, 
		Local, 
		Tweets, 
		Calendar, 
		UserTools, 
		MyLocation
	}
	public class HomeMenuItem : BaseModel
	{
		public HomeMenuItem ()
		{
			MenuType = MenuType.About;
		}
		public string Icon {get;set;}
		public MenuType MenuType { get; set; }
	}
}

