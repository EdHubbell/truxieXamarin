using System;
using Xamarin.Forms;
using System.Linq;

namespace truxie.Shared
{
	public class NearbyNowView: BaseView
	{

		private NearbyNowViewModel ViewModel {
			get { return BindingContext as NearbyNowViewModel; }
		}

		public NearbyNowView ()
		{

			BindingContext = new NearbyNowViewModel ();

			var refresh = new ToolbarItem {
				Command = ViewModel.RefreshCommand,
				Icon = "refresh.png",
				Name = "refresh",
				Priority = 0
			};

			ToolbarItems.Add (refresh);

			var stack = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness (0, 8, 0, 8)
			};

			var refreshList = new PullToRefreshListView {
				RefreshCommand = ViewModel.DataLoadCommand,
				Message = "loading..."
			};

			refreshList.ItemTemplate = new DataTemplate (typeof(TweetCell));
			refreshList.HasUnevenRows = true;

			refreshList.SetBinding<NearbyNowViewModel> (PullToRefreshListView.IsRefreshingProperty, vm => vm.IsBusy);
			refreshList.SetBinding<NearbyNowViewModel> (PullToRefreshListView.ItemsSourceProperty, vm => vm.Items);

			//NavigationPage.SetHasNavigationBar(this,true);

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

