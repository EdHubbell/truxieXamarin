using System;
using WebSocket4Net;

namespace truxie.iOS
{
	public class WebSocketView
	{
		public WebSocketView ()
		{
			WebSocket testSocket = new WebSocket("", null);

			testSocket.Opened += async (object sender, EventArgs e) => 
			{
				Console.WriteLine("whoopedo");
			};


		}
	}
}

