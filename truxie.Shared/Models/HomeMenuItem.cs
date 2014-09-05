using System;

namespace truxie.Shared
{
	public enum MenuType
	{
		NearbyNow, 
		Local, 
		Tweets, 
		Calendar 
	}

	public class HomeMenuItem : BaseModel
	{
		public HomeMenuItem ()
		{
			MenuType = MenuType.NearbyNow;
		}
	
		public string Icon {get;set;}
		public MenuType MenuType { get; set; }

	}
}

