using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace truxie.PCL
{
	public class TruckTweetsViewModel : BaseViewModel
	{
		//WebService Service;

		public ObservableCollection<TruckTweet> Items{ get; set; }

		public int CurItemNumber = 0;

		public TruckTweetsViewModel ()
		{
			CurItemNumber = 0;
			//Service = new WebService ();
			Title = "truck tweets";
			Icon = "slideout.png";
			Items = new ObservableCollection<TruckTweet> ();
			IsBusy = false;
		}

		private Command refreshCommand;

		public Command RefreshCommand {
			get { return refreshCommand ?? (refreshCommand = new Command (async () => await ExecuteDataLoadCommand (true))); }
		}

		private Command dataLoadCommand;

		public Command DataLoadCommand {
			get { return dataLoadCommand ?? (dataLoadCommand = new Command (async () => await ExecuteDataLoadCommand (false))); }
		}


		private async Task ExecuteDataLoadCommand ( bool bRefresh)
		{
			if (IsBusy)
				return;

			IsBusy = true;

			if (bRefresh)
			{
				CurItemNumber = 0;
				Items.Clear ();
			}

			//await Task.Run(()=>{ Service.GetTweetsData("35.994033", "-78.898619", 0, 20); });

			if (string.IsNullOrEmpty (CurrentUser) && string.IsNullOrEmpty (CurrentUserID)) {
				var res = await WebService.GetTweetsData ("35.994033", "-78.898619", CurItemNumber, 20);
				foreach (var item in res) {
					Items.Add (item);
				}
//			} else {
//				var res2 = await WebService.GetCurrUserTweetsData (CurrentUserID, CurrentUser);
//				if(res2!=null)
//				foreach (var item in res2.Statuses) {
//						Items.Add (item);
//				}
			}

			CurItemNumber += 20;

			IsBusy = false;
		}

		public string CurrentUser {
			get;
			set;
		}
		public string CurrentUserID {
			get;
			set;
		}
	}
}

