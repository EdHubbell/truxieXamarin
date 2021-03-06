﻿using System;
using Xamarin.Forms;
using System.Linq;

namespace truxie.PCL
{
	public class TruckTweetsView : BaseView
	{
		private TruckTweetsViewModel ViewModel {
			get { return BindingContext as TruckTweetsViewModel; }
		}

		public TruckTweetsView ()
		{

			BindingContext = new TruckTweetsViewModel ();

			var refresh = new ToolbarItem {
				Command = ViewModel.RefreshCommand,
				Icon = "refresh.png",
				Name = "refresh",
				Priority = 0
			};

			ToolbarItems.Add (refresh);

			var refreshList = new PullToRefreshListView {
				RefreshCommand = ViewModel.RefreshCommand,
				Message = "loading..."
			};

			refreshList.ItemTemplate = new DataTemplate (typeof(TweetCell));
			refreshList.HasUnevenRows = true;

			refreshList.SetBinding<TruckTweetsViewModel> (PullToRefreshListView.IsRefreshingProperty, vm => vm.IsBusy);
			refreshList.SetBinding<TruckTweetsViewModel> (PullToRefreshListView.ItemsSourceProperty, vm => vm.Items);

			refreshList.ItemTapped += (sender, args) => {
				if (refreshList.SelectedItem == null)
					return;

				var tweets = refreshList.SelectedItem as TruckTweet;

				SubTruckTweetPage ContentPage=new SubTruckTweetPage(tweets);
				Navigation.PushAsync(ContentPage);

				refreshList.SelectedItem = null;
			};

			refreshList.ItemAppearing += (object sender, ItemVisibilityEventArgs e) => {

				var list = (sender as PullToRefreshListView).ItemsSource.OfType<TruckTweet> ().ToList ();

				if (list.Count==ViewModel.CurItemNumber && list [list.Count - 1] == e.Item) {
					ViewModel.DataLoadCommand.Execute (null);
				}
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

	public class SubTruckTweetPage : ContentPage
	{
		PullToRefreshListView refreshList;

		public SubTruckTweetPage(TruckTweet tweet){
			Title = tweet.User.ScreenName;
			NavigationPage.SetBackButtonTitle (this,"Back");

			BindingContext = new TruckTweetsViewModel (){CurrentUser=tweet.User.ScreenName,CurrentUserID=tweet.User.Id };

			var refresh = new ToolbarItem {
				Command = ViewModel.RefreshCommand,
				Icon = "refresh.png",
				Name = "refresh",
				Priority = 0
			};

			ToolbarItems.Add (refresh);

			refreshList = new PullToRefreshListView {
				RefreshCommand = ViewModel.RefreshCommand,
				Message = "loading..."
			};

			refreshList.ItemTemplate = new DataTemplate (typeof(TweetCell));
			refreshList.HasUnevenRows = true;

			refreshList.SetBinding<TruckTweetsViewModel> (PullToRefreshListView.IsRefreshingProperty, vm => vm.IsBusy);
			refreshList.SetBinding<TruckTweetsViewModel> (PullToRefreshListView.ItemsSourceProperty, vm => vm.Items);

			refreshList.ItemTapped += refreshList_HandleItemTapped;

			refreshList.ItemAppearing += refreshList_HandleItemAppearing; ;

			Content = refreshList;
		}

		void refreshList_HandleItemAppearing (object sender, ItemVisibilityEventArgs e)
		{
			var list = (sender as PullToRefreshListView).ItemsSource.OfType<TruckTweet> ().ToList ();

			if (list.Count==ViewModel.CurItemNumber && list [list.Count - 1] == e.Item) {
				ViewModel.DataLoadCommand.Execute (null);
			}
		}

		void refreshList_HandleItemTapped (object sender, ItemTappedEventArgs e)
		{
			if (refreshList.SelectedItem == null)
				return;

			var tweets = refreshList.SelectedItem as TruckTweet;
			SubTruckTweetPage ContentPage=new SubTruckTweetPage(tweets);
			Navigation.PushAsync(ContentPage);
			refreshList.SelectedItem = null;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			if (ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy)
				return;

			ViewModel.RefreshCommand.Execute (null);

		}

		private TruckTweetsViewModel ViewModel {
			get { return BindingContext as TruckTweetsViewModel; }
		}
	}
}

