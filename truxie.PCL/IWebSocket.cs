using System;

namespace truxie.PCL
{
	public interface IWebSocket
	{

		DateTime LastActiveTime{ get;}

		bool EnableAutoSendPing{ get; set;}

		int AutoSendPingInterval { get; set; }

		bool SupportBinary { get;}

		bool Handshaked { get; private set; }

		// IProxyConnector Proxy { get; set; }

		// EndPoint m_HttpConnectProxy;

		// EndPoint HttpConnectProxy { get;}

		//		protected IClientCommandReader<WebSocketCommandInfo> CommandReader { get; private set; }



		//TcpClientSession CreateClient(string uri);

		void client_DataReceived(object sender, DataEventArgs e);

		void client_Error(object sender, ErrorEventArgs e);

		void client_Closed(object sender, EventArgs e);

		void client_Connected(object sender, EventArgs e);

		int ReceiveBufferSize { get; set;}

		void Open();

		void OnConnected();

		event EventHandler Opened;

//		event EventHandler<MessageReceivedEventArgs> MessageReceived;

//		event EventHandler<DataReceivedEventArgs> DataReceived;

		void Send(string message);

		void Send(byte[] data, int offset, int length);

//		void Send(IList<ArraySegment<byte>> segments);

		void Close();
		void Close(string reason);
		void Close(int statusCode, string reason);

		event EventHandler Closed;


//		event EventHandler<ErrorEventArgs> Error;

	}
}

