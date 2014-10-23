using System;
using System.Reflection;
using Xamarin.Forms;

namespace truxie.PCL
{
	public static class truxieApp
	{
		private static Page homeView;

		public static Page RootPage
		{
			get { 
				return homeView ?? (homeView = new HomeView ()); 
			}
		}
	}


}
