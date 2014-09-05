using System;
using Xamarin.Forms;

namespace truxie.Shared
{
	public class VendorCalendarView : BaseView
	{
		private VendorCalendarViewModel ViewModel
		{
			get { return BindingContext as VendorCalendarViewModel; }
		}
		public VendorCalendarView()
		{
			BindingContext = new VendorCalendarViewModel ();

			var refresh = new ToolbarItem {
				Command = ViewModel.RefreshCommand,
				Icon = "refresh.png",
				Name = "refresh",
				Priority = 0
			};

			ToolbarItems.Add (refresh);

			var stack = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(0, 8, 0, 8)
			};

			var refreshList = new PullToRefreshListView {
				RefreshCommand = ViewModel.DataLoadCommand,
				Message = "loading..."
			};

			refreshList.RowHeight = 60;

			refreshList.ItemTemplate = new DataTemplate (() => {

				Label labelVendorName=new Label{
					TextColor=Color.Black,
					BackgroundColor=Color.Transparent,
					Font = Font.SystemFontOfSize(14,FontAttributes.Bold)};
				labelVendorName.SetBinding (Label.TextProperty, "VendorName");

				Label labelLocation=new Label{
					TextColor=Color.Black,
					BackgroundColor=Color.Transparent,
					Font = Font.SystemFontOfSize(12,FontAttributes.None),
					VerticalOptions = LayoutOptions.Start,
					HorizontalOptions = LayoutOptions.FillAndExpand};
				labelLocation.SetBinding (Label.TextProperty, "Location");

				Label labelSummary=new Label{
					TextColor=Color.Black,
					BackgroundColor=Color.Transparent,
					Font = Font.SystemFontOfSize(12,FontAttributes.None),
					VerticalOptions = LayoutOptions.Start,
					HorizontalOptions = LayoutOptions.FillAndExpand};
				labelSummary.SetBinding (Label.TextProperty, "Summary");

				Image boxView=new Image(){VerticalOptions = LayoutOptions.Start,
					WidthRequest=40, HeightRequest=40};

				Button button=new Button(){
					VerticalOptions = LayoutOptions.Start,
					BorderRadius=5,
					HeightRequest=40,
					WidthRequest=40,
					BorderColor=Color.Gray,
					BorderWidth=1 };
				//button.BackgroundColor=Color.Gray;
				//button.IsEnabled=false;
				BoxView v=new BoxView(){ };

				button.SetBinding(Button.ImageProperty,"ImageUrl");
				button.Image =new FileImageSource(){};

				boxView.SetBinding (Image.SourceProperty, "ImageUrl");
				boxView.BackgroundColor=Color.Transparent;

				return new ViewCell{
					View=new StackLayout{ 
						HeightRequest=60,
						//BackgroundColor= Color.Gray,
						Padding = new Thickness(5,1,5,1),
						Orientation = StackOrientation.Horizontal,
						Children={
							boxView,
							new StackLayout{
								//BackgroundColor=Color.Green,
								Spacing = 0,
								VerticalOptions = LayoutOptions.StartAndExpand,
								HorizontalOptions = LayoutOptions.FillAndExpand,
								Orientation= StackOrientation.Vertical,
								Children={labelVendorName, labelLocation, labelSummary}
							}
						}
					}
				};
			});
			//refreshList.RowHeight = 100;
			refreshList.SetBinding<TruckTweetsViewModel> (PullToRefreshListView.IsRefreshingProperty, vm => vm.IsBusy);
			refreshList.SetBinding<TruckTweetsViewModel> (PullToRefreshListView.ItemsSourceProperty, vm => vm.Items);

			refreshList.ItemTapped +=  (sender, args) => {
//				if(refreshList.SelectedItem == null)
//					return;
//
//				var tweets = refreshList.SelectedItem as TruckTweet;
//
//				refreshList.SelectedItem = null;
			};

			Content = refreshList;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			if (ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy)
				return;

			ViewModel.RefreshCommand.Execute (null);

		}
	}
}

