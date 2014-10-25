using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace truxie.PCL
{
	public class SimpleMapView: BaseView
	{

		private MapViewModel ViewModel {
			get { return BindingContext as MapViewModel; }
		}

		public SimpleMapView (Vendor vendor)
		{
			Title = vendor.VendorName;



			var refresh = new ToolbarItem {
			//	Command = ViewModel.RefreshCommand,
				Icon = "refresh.png",
				Name = "refresh",
				Priority = 0
			};

			ToolbarItems.Add (refresh);

			var map = new Map(MapSpan.FromCenterAndRadius(new Position(36, -78.32), Distance.FromMiles(0.3)))
			{
				IsShowingUser = true
			};
			var stack = new StackLayout { Spacing = 0 };
			map.VerticalOptions = LayoutOptions.FillAndExpand;

			map.HeightRequest = 100;
			map.WidthRequest = 960;

			// label shows up, but the map does not...
			Label theLabel = new Label(); 
			theLabel.Text = "fucking a";


			stack.Children.Add(map);
			stack.Children.Add(theLabel);

			Content = stack;
		}
	}
}

