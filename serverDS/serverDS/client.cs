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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace serverDS
{
	public class client
	{
		private TcpClient tcpClient;
		private NetworkStream stream;

		public client ( object nouveauClient)
		{
			Console.WriteLine("client connected");
			tcpClient = (TcpClient) nouveauClient;
			stream = tcpClient.GetStream();

			Thread listen = new Thread( new ThreadStart(listenClient));
			listen.Start();
		}

		private void listenClient () {
			byte[] message = new byte[4096];

			while ( MainClass.IsRunning ) {
				try {
					stream.Read(message, 0, 4096);
				} catch (Exception e) {
					Console.WriteLine("Error (1) : déconnexion du client. \n-"+e.Message);
					return;
				}

				ASCIIEncoding encoder = new ASCIIEncoding();
				string information = encoder.GetString (message, 0, 4096);
				Console.WriteLine( information );
			}
		}
	}
}

