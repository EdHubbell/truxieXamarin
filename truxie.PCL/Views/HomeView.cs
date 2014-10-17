using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Acr.XamForms.UserDialogs;
using Acr.XamForms.ViewModels;

namespace truxie.PCL
{
	public class HomeView : MasterDetailPage
	{

		private HomeViewModel _homeViewModel {
			get { return BindingContext as HomeViewModel; }
		}

		private HomeMasterView master;

//		private HomeViewModel homeViewModel;

		private Dictionary<MenuType, NavigationPage> pages;

		public HomeView ()
		{
			//InitializeComponent();

			pages = new Dictionary<MenuType, NavigationPage> ();

			this.BindingContext = new HomeViewModel();

//			_homeViewModel = new HomeViewModel ();

			Title = "Test Title";

			Master = master = new HomeMasterView (_homeViewModel);

			var homeNav = new NavigationPage (master.PageSelection) {
				BarBackgroundColor = Color.FromRgb(250, 176, 59), BarTextColor = Color.White
			};
			Detail = homeNav;

			pages.Add (MenuType.NearbyNow, homeNav);

			master.PageSelectionChanged = (menuType) => {
			
				NavigationPage newPage;
				if (pages.ContainsKey (menuType)) {
					newPage = pages [menuType];
				} else {
					newPage = new NavigationPage (master.PageSelection) {
						BarBackgroundColor = Color.FromRgb(250, 176, 59), BarTextColor = Color.White
					};
					newPage.BackgroundColor = Color.Olive;
					pages.Add (menuType, newPage);
				}

				Detail = newPage;
				Detail.Title = master.PageSelection.Title;
				IsPresented = false;
			};

			this.Icon = "slideout.png";
		}

	}


	public class HomeMasterView : ContentPage
	{
		public Action<MenuType> PageSelectionChanged;
		private Page pageSelection;
		private MenuType menuType = MenuType.NearbyNow;

		public Page PageSelection {
			get{ return pageSelection; }
			set {
				pageSelection = value; 
				if (PageSelectionChanged != null)
					PageSelectionChanged (menuType);
			}
		}

		private NearbyNowView nearbyNow;
		private TruckTweetsView truckTweets;
		private VendorCalendarView vendorCalendar;
		private CalendarEntriesPage vendorCalendarXaml;
		private HomeViewModel homeViewModel;

		public HomeMasterView (HomeViewModel homeViewModel)
		{
			BackgroundColor = Color.FromRgb (234, 234, 234);
			this.Icon = "slideout.png";
			this.homeViewModel = homeViewModel;
			this.Title = "Seriously?";


			var layout = new StackLayout { Spacing = 0 };

			var label = new ContentView {
				Padding = new Thickness (10, 36, 0, 5),
				BackgroundColor = Color.Transparent, 
				HorizontalOptions = new LayoutOptions (LayoutAlignment.Center, true),
				Content = new Label {
					Text = "Find Food",
					Font = Font.SystemFontOfSize (NamedSize.Medium),
					TextColor = Color.White
				}
			};
			label.BackgroundColor = Color.Transparent;


			layout.Children.Add (label);
		
			var listView = new ListView ();
			listView.ItemTemplate = new DataTemplate (() => {
				Label titleLabel = new Label ();

				titleLabel.SetBinding (Label.TextProperty, "Title");
				titleLabel.TextColor = Color.White;
				titleLabel.BackgroundColor = Color.Transparent;

				Image boxView = new Image ();
				boxView.SetBinding (Image.SourceProperty, "Icon");
				boxView.BackgroundColor = Color.Transparent;

				return new ViewCell {
					View = new StackLayout {
						BackgroundColor = Color.Gray,
						Padding = new Thickness (5, 1, 5, 1),
						Orientation = StackOrientation.Horizontal,
						Children = {
							boxView,
							new StackLayout {
								BackgroundColor = Color.Transparent,
								VerticalOptions = LayoutOptions.Center,
								Spacing = 0,
								Children = { titleLabel }
							}
						}
					}
				};
			});

//			var cell = new DataTemplate(typeof(ListImageCell));
//
//			cell.SetBinding (TextCell.TextProperty, HomeViewModel.TitlePropertyName);
//			cell.SetBinding (ImageCell.ImageSourceProperty, "Icon");
//			cell.SetValue (TextCell.TextColorProperty, Color.Red);
//
//			listView.ItemTemplate = cell;

			listView.ItemsSource = this.homeViewModel.MenuItems;
			if (nearbyNow == null)
				nearbyNow = new NearbyNowView ();

			PageSelection = nearbyNow;

			//Change to the correct page
			listView.ItemSelected += (sender, args) => {
				var menuItem = listView.SelectedItem as HomeMenuItem;
				menuType = menuItem.MenuType;
				switch (menuItem.MenuType) {
				case MenuType.NearbyNow:
					if (nearbyNow == null)
						nearbyNow = new NearbyNowView ();

					PageSelection = nearbyNow;
					break;
				case MenuType.Tweets:
					if (truckTweets == null)
						truckTweets = new TruckTweetsView ();

					PageSelection = truckTweets;
					break;

				case MenuType.Calendar:
					if (vendorCalendar == null)
						vendorCalendar = new VendorCalendarView();

					PageSelection = vendorCalendar;
					break;

				case MenuType.CalendarXaml:
					if (vendorCalendarXaml == null)
						vendorCalendarXaml = new CalendarEntriesPage();

					PageSelection = vendorCalendarXaml;
					break;
				}
			};

			//listView.SelectedItem = MenuItems [0];
			layout.Children.Add (listView);
			listView.BackgroundColor = Color.Gray;
			Content = layout;
		}
	}

}

