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
				Id = 0, Title = "About", MenuType = MenuType.About,  Icon = "about.png"
			});
			MenuItems.Add (new HomeMenuItem {
				Id = 1, Title = "Blog", MenuType = MenuType.Blog, Icon = "blog.png"
			});
			MenuItems.Add (new HomeMenuItem {
				Id = 2, Title = "nearby now", MenuType = MenuType.NearbyNow ,  Icon = "twitternav.png"
			});
			MenuItems.Add (new HomeMenuItem {
				Id = 3, Title = "tweets", MenuType = MenuType.Tweets,  Icon = "twitternav.png"
			});
			MenuItems.Add (new HomeMenuItem {
				Id = 4, Title = "calendar", MenuType = MenuType.Calendar,  Icon = "twitternav.png"
			});
			MenuItems.Add (new HomeMenuItem {
				Id = 5, Title = "user tools", MenuType = MenuType.UserTools,  Icon = "twitternav.png"
			});
			MenuItems.Add (new HomeMenuItem {
				Id = 6, Title = "my location", MenuType = MenuType.MyLocation,  Icon = "twitternav.png"
			});
		}

	}
}

