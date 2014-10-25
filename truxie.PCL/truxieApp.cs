using System;
using System.Reflection;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Mvvm;
using Xamarin.Forms.Labs.Controls;
using Xamarin.Forms.Labs.Services;
using Splat;
using ModernHttpClient;
using System.Net.Http;


namespace truxie.PCL
{
	public static class truxieApp
	{
		/// <summary>
		/// Initializes the application.
		/// </summary>
		public static void Init()
		{

			var app = Resolver.Resolve<IXFormsApp>();
			if (app == null)
			{
				return;
			}

			app.Closing += (o, e) => Debug.WriteLine("Application Closing");
			app.Error += (o, e) => Debug.WriteLine("Application Error");
			app.Initialize += (o, e) => Debug.WriteLine("Application Initialized");
			app.Resumed += (o, e) => Debug.WriteLine("Application Resumed");
			app.Rotation += (o, e) => Debug.WriteLine("Application Rotated");
			app.Startup += (o, e) => Debug.WriteLine("Application Startup");
			app.Suspended += (o, e) => Debug.WriteLine("Application Suspended");
		}

		private static Page homeView;

		public static Page RootPage
		{
			get { 
				Locator.CurrentMutable.RegisterConstant(new NativeMessageHandler(), typeof(HttpMessageHandler));

				return homeView ?? (homeView = new HomeView ()); 
			}
		}
	}


}
