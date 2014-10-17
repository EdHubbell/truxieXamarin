using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using Acr.XamForms.ViewModels;

namespace truxie.PCL
{
	public class HomeViewModel : ViewModel
	{
		public ObservableCollection<HomeMenuItem> MenuItems { get; set; }

		public HomeViewModel ()
		{

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
			MenuItems.Add (new HomeMenuItem {
				Id = 4, Title = "calendarXaml", MenuType = MenuType.CalendarXaml,  Icon = "twitternav.png"
			});
		}

	}
}

