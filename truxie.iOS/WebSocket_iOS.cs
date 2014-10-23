using System;
using truxie.PCL;

[assembly: Xamarin.Forms.Dependency (typeof (WebSocket_iOS))]

namespace truxie.iOS

{
	public class WebSocket_iOS : WebSocket4Net.WebSocket
	{
		public WebSocket_iOS (){}
	}
}

