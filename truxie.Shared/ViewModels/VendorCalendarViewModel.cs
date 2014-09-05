using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace truxie.Shared
{
	public class VendorCalendarViewModel : BaseViewModel
	{
		WebService Service;

		public ObservableCollection<VendorCalendarEntry> Items{ get; set; }

		int CurItemNumber = 0;

		public VendorCalendarViewModel ()
		{
			CurItemNumber = 0;
			Service = new WebService ();
			Title = "calendar";
			Icon = "slideout.png";
			Items = new ObservableCollection<VendorCalendarEntry> ();
			IsBusy = false;
		}

		private Command refreshCommand;

		public Command RefreshCommand {
			get { return refreshCommand ?? (refreshCommand = new Command (async () => await ExecuteRefreshCommand ())); }
		}

		private async Task ExecuteRefreshCommand ()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			Items.Clear ();

			//await Task.Run(()=>{ Service.GetTweetsData("35.994033", "-78.898619", 0, 20); });
			var res = await Service.GetVendorCalendarEntryList ("35.994033", "-78.898619", 1);
			//var tList= JsonConvert.DeserializeObject<U> (res);
			CurItemNumber = 20;
			// Test Data
			//			Tweets _item1 = new Tweets ();
			//			_item1.ScreenName = "NCBullkogi";
			//			_item1.Text = "@SoniaH81";
			//			_item1.UserImage = "http://pbs.twimg.com/profile_images/775609928/Bulkogi_Sticker_36x15_normal.jpg";
			//			Items.Add (_item1);

			foreach (var item in res) {
				VendorCalendarEntry newVendorCalendarEntry = new VendorCalendarEntry ();
				newVendorCalendarEntry.VendorName = item.VendorName;
				newVendorCalendarEntry.ImageUrl = item.ImageUrl; 
				newVendorCalendarEntry.Summary = item.Summary;
				Items.Add (newVendorCalendarEntry);
			}

			IsBusy = false;
		}

		private Command dataLoadCommand;

		public Command DataLoadCommand {
			get { return dataLoadCommand ?? (dataLoadCommand = new Command (async () => await ExecuteDataLoadCommand ())); }
		}

		private async Task ExecuteDataLoadCommand ()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			//			Test Code
			await Task.Run (() => {
				Service.GetVendorCalendarEntryList ("35.994033", "-78.898619", 1);
			});
			CurItemNumber += 20;


			IsBusy = false;
		}
	}
}

