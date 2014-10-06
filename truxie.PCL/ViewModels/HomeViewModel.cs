using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace truxie.PCL
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
				Id = 1, Title = "local", MenuType = MenuType.Local,  Icon = "twitternav.png"
			});
			MenuItems.Add (new HomeMenuItem {
				Id = 2, Title = "tweets", MenuType = MenuType.Tweets,  Icon = "twitternav.png"
			});
			MenuItems.Add (new HomeMenuItem {
				Id = 3, Title = "calendar", MenuType = MenuType.Calendar,  Icon = "twitternav.png"
			});
		}

	}
}

