using System;
using Xamarin.Forms;

namespace truxie.PCL
{
	public class HtmlView:Label
	{
		public HtmlView ()
		{
		}

		public static readonly BindableProperty HtmlProperty = 
			BindableProperty.Create<HtmlView,string> (p => p.Html, string.Empty);

		public string Html {
			get { return (string)GetValue (HtmlProperty); }
			set { SetValue (HtmlProperty, value); }
		}
	}
}

