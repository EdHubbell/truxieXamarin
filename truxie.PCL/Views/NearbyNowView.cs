using System;
using Xamarin.Forms;
using System.Linq;

namespace truxie.PCL
{
	public class NearbyNowView: BaseView
	{

		private NearbyNowViewModel ViewModel {
			get { return BindingContext as NearbyNowViewModel; }
		}

		public NearbyNowView ()
		{
		
			BindingContext = new NearbyNowViewModel();

			var refresh = new ToolbarItem {
				Command = ViewModel.RefreshCommand,
				Icon = "refresh.png",
				Name = "refresh",
				Priority = 0
			};

			ToolbarItems.Add (refresh);

			var refreshList = new PullToRefreshListView {
				RefreshCommand = ViewModel.DataLoadCommand,
				Message = "loading..."
			};

			refreshList.ItemTemplate = new DataTemplate (typeof(VendorEventCell));
			refreshList.HasUnevenRows = true;

			refreshList.SetBinding<NearbyNowViewModel> (PullToRefreshListView.IsRefreshingProperty, vm => vm.IsBusy);
			refreshList.SetBinding<NearbyNowViewModel> (PullToRefreshListView.ItemsSourceProperty, vm => vm.Items);

			//NavigationPage.SetHasNavigationBar(this,true);

			Content = refreshList;

			ViewModel.DisplayErrorAction+= viewModel_HandleDisplayErrorAction;
		}

		void viewModel_HandleDisplayErrorAction (string title, string message)
		{
			this.DisplayAlert (title, message, "Ok");
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			if (ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy)
				return;
//			ViewModel.AppearingCommand.Execute (null);

			//ViewModel.OnAppearing ();

			//ViewModel.RefreshCommand.Execute (null);
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			//ViewModel.DisappearingCommand.Execute (null);
		}
	}

}

