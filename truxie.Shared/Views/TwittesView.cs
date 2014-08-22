using System;
using Xamarin.Forms;

namespace truxie.Shared
{
	public class TwittesView : BaseView
	{
		private TwittesViewModel ViewModel
		{
			get { return BindingContext as TwittesViewModel; }
		}
		public TwittesView ()
		{
			BindingContext = new TwittesViewModel ();

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

			var cell = new DataTemplate(typeof(ListImageCell));
			cell.SetBinding (ImageCell.TextProperty, "ScreenName");
			cell.SetBinding (ImageCell.DetailProperty, "Text");
			cell.SetBinding (ImageCell.ImageSourceProperty, "UserImage");

			refreshList.ItemTemplate = cell;

			refreshList.SetBinding<TwittesViewModel> (PullToRefreshListView.IsRefreshingProperty, vm => vm.IsBusy);
			refreshList.SetBinding<TwittesViewModel> (PullToRefreshListView.ItemsSourceProperty, vm => vm.Items);

			refreshList.ItemTapped +=  (sender, args) => {
				if(refreshList.SelectedItem == null)
					return;

				var tweets = refreshList.SelectedItem as Tweets;

				refreshList.SelectedItem = null;
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

