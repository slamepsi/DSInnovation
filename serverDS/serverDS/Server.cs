// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace serverDS
{
	public class Server
	{
		private static TcpListener listener;
		private static Thread listenerThread;


		public Server ()
		{
			listener = new TcpListener ( IPAddress.Parse( "127.0.0.1" ), 27015 );
			listenerThread = new Thread( new ThreadStart(ListenForClient));
			listenerThread.Start();
		}

		public static void ListenForClient() {
			listener.Start();

			while(MainClass.IsRunning) {
				TcpClient nouveauClient = listener.AcceptTcpClient();
				new client(nouveauClient);
			}
		}
	}
}
