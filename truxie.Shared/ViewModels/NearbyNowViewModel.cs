﻿using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using truxie.Portable;

namespace truxie.Shared
{
	public class NearbyNowViewModel : BaseViewModel
	{
		WebService Service;

		public ObservableCollection<VendorEvent> Items{ get; set; }

		public int CurItemNumber = 0;

		public NearbyNowViewModel ()
		{
			CurItemNumber = 0;
			Service = new WebService ();
			Title = "nearby now";
			Icon = "slideout.png";
			Items = new ObservableCollection<VendorEvent> ();
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

//			//await Task.Run(()=>{ Service.GetTweetsData("35.994033", "-78.898619", 0, 20); });
//			if (string.IsNullOrEmpty (CurrentUser) && string.IsNullOrEmpty (CurrentUserID)) {
//				var res = await Service.GetNearbyVendorEventsList ("35.994033", "-78.898619");
//				foreach (var item in res) {
//					TruckTweet newTweet = new TruckTweet {
//						UserID = item.r.Id,
//						ScreenName = item.User.ScreenName,
//						Text = item.Text,
//						UserImage = item.User.ProfileImageUrl,
//						Date=item.CreatedAt
//					};
//					Items.Add (newTweet);
//				}
//			} else {
//				var res2 = await Service.GetCurrUserTweetsData (CurrentUserID, CurrentUser);
//				if(res2!=null)
//					foreach (var item in res2.Statuses) {
//						TruckTweet newTweet = new TruckTweet {
//							UserID = item.User.Id,
//							ScreenName = item.User.ScreenName,
//							Text = item.Text,
//							UserImage = item.User.ProfileImageUrl,
//							Date=item.CreatedAt
//						};
//						Items.Add (newTweet);
//					}
//			}

			CurItemNumber = 20;

			// Test Data
			//			Tweets _item1 = new Tweets ();
			//			_item1.ScreenName = "NCBullkogi";
			//			_item1.Text = "@SoniaH81";
			//			_item1.UserImage = "http://pbs.twimg.com/profile_images/775609928/Bulkogi_Sticker_36x15_normal.jpg";
			//			Items.Add (_item1);



			IsBusy = false;
		}
//
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
			//			await Task.Run (() => {
			//				Service.GetTweetsData ("35.994033", "-78.898619", CurItemNumber, 20);
			//			});
			//			CurItemNumber += 20;
			//
			//			// Test Data
			//			TruckTweet _item1 = new TruckTweet ();
			//			_item1.ScreenName = "NCBullkogi";
			//			_item1.Text = "@SoniaH81";
			//			_item1.UserImage = "http://pbs.twimg.com/profile_images/775609928/Bulkogi_Sticker_36x15_normal.jpg";
			//
			//			Items.Add (_item1);

//			if (string.IsNullOrEmpty (CurrentUser) && string.IsNullOrEmpty (CurrentUserID)) {
//				var res = await Service.GetTweetsData ("35.994033", "-78.898619", CurItemNumber, 20);
//				foreach (var item in res) {
//					TruckTweet newTweet = new TruckTweet ();
//					newTweet.ScreenName = item.User.ScreenName;
//					newTweet.Text = item.Text;
//					newTweet.UserImage = item.User.ProfileImageUrl;
//					newTweet.Date = item.CreatedAt;
//					Items.Add (newTweet);
//				}
//			}else {
//				var res2 = await Service.GetCurrUserTweetsData (CurrentUserID, CurrentUser);
//				if(res2!=null)
//					foreach (var item in res2.Statuses) {
//						TruckTweet newTweet = new TruckTweet {
//							UserID = item.User.Id,
//							ScreenName = item.User.ScreenName,
//							Text = item.Text,
//							UserImage = item.User.ProfileImageUrl,
//							Date=item.CreatedAt
//						};
//						Items.Add (newTweet);
//					}
//			}
			CurItemNumber += 20;

			IsBusy = false;
		}
//
//		public string CurrentUser {
//			get;
//			set;
//		}
//		public string CurrentUserID {
//			get;
//			set;
//		}
	}
}
