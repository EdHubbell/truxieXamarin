using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using LinqToTwitter;
using System.Threading.Tasks;
using System.Linq;
using truxie.Portable;

namespace truxie.Shared
{
	public class TwittesViewModel : BaseViewModel
	{
		WebService Service;
		public ObservableCollection<Tweets> Items{ get; set; }
		int CurItemNumber = 0;

		public TwittesViewModel ()
		{
			CurItemNumber = 0;
			Service = new WebService ();
			Title = "truck tweets";
			Icon = "slideout.png";
			Items = new ObservableCollection<Tweets> ();
			IsBusy = false;
		}

		private Command refreshCommand;
		public Command RefreshCommand
		{
			get { return refreshCommand ?? (refreshCommand = new Command (async ()=> await ExecuteRefreshCommand())); }
		}

		private async Task ExecuteRefreshCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			Items.Clear ();

			//await Task.Run(()=>{ Service.GetTweetsData("35.994033", "-78.898619", 0, 20); });
			var res = await Service.GetTweetsData("35.994033", "-78.898619", 0, 20);
			CurItemNumber = 20;
			// Test Data
			Tweets _item1 = new Tweets ();
			_item1.ScreenName = "NCBullkogi";
			_item1.Text = "@SoniaH81";
			_item1.UserImage = "http://pbs.twimg.com/profile_images/775609928/Bulkogi_Sticker_36x15_normal.jpg";

			Items.Add (_item1);

			IsBusy = false;
		}

		private Command dataLoadCommand;
		public Command DataLoadCommand
		{
			get { return dataLoadCommand ?? (dataLoadCommand = new Command (async ()=> await ExecuteDataLoadCommand())); }
		}

		private async Task ExecuteDataLoadCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			await Task.Run(()=>{ Service.GetTweetsData("35.994033", "-78.898619", CurItemNumber, 20); });
			CurItemNumber += 20;

			// Test Data
			Tweets _item1 = new Tweets ();
			_item1.ScreenName = "NCBullkogi";
			_item1.Text = "@SoniaH81";
			_item1.UserImage = "http://pbs.twimg.com/profile_images/775609928/Bulkogi_Sticker_36x15_normal.jpg";

			Items.Add (_item1);

			IsBusy = false;
		}
	}
}

