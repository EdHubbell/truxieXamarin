using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

namespace truxieAndroid
{
	[Activity (Label = "truxie", MainLauncher = true)]
	public class MainActivity : AndroidActivity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);


			Forms.Init(this, bundle);

			SetPage (truxie.Shared.truxieApp.RootPage);
		}
	}
}


