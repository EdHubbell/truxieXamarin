using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace truxie.Shared
{
	public class HomeViewModel : BaseViewModel
	{
		public ObservableCollection<HomeMenuItem> MenuItems { get; set; }


		public HomeViewModel ()
		{
			CanLoadMore = true;
			Title = "nearby now";
			MenuItems = new ObservableCollection<HomeMenuItem> ();
			MenuItems.Add (new HomeMenuItem {
				Id = 0, Title = "nearby now", MenuType = MenuType.NearbyNow ,  Icon = "twitternav.png"
			});
			MenuItems.Add (new HomeMenuItem {
				Id = 1, Title = "tweets", MenuType = MenuType.Tweets,  Icon = "twitternav.png"
			});
			MenuItems.Add (new HomeMenuItem {
				Id = 2, Title = "calendar", MenuType = MenuType.Calendar,  Icon = "twitternav.png"
			});
			MenuItems.Add (new HomeMenuItem {
				Id = 3, Title = "user tools", MenuType = MenuType.UserTools,  Icon = "twitternav.png"
			});
			MenuItems.Add (new HomeMenuItem {
				Id = 4, Title = "my location", MenuType = MenuType.MyLocation,  Icon = "twitternav.png"
			});
		}

	}
}

