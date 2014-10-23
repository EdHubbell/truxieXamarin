using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using truxie.PCL; 
using Xamarin.Forms.Labs.Droid;

namespace truxieAndroid
{
	[Activity (Label = "truxie", MainLauncher = true)]
	public class MainActivity : XFormsApplicationDroid
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			MeasurementManager.Measurement = new truxie.Android.MeasurementHelper ();
			Forms.Init(this, bundle);

			SetPage (truxie.PCL.truxieApp.RootPage);
		}
	}
}


