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
using System.Text;
using System.Threading;


namespace DSInnovation
{
	public class socket
	{
		TcpClient tcpclient;
		NetworkStream stream;
		ASCIIEncoding encoder;
		Thread receptionThread;


		public socket ()
		{
			Console.WriteLine("try connection");
			tcpclient = new TcpClient();
			encoder = new ASCIIEncoding();

			try {
				//adresse ip
				tcpclient.Connect( IPAddress.Parse("192.168.1.3"), 27015 );
				stream = tcpclient.GetStream();
				receptionThread = new Thread( new ThreadStart(reception));
				receptionThread.Start();
			} catch (Exception e) {
				Console.WriteLine( "Connection error, code : 1\n"+e.Message );
			}

			sendMessage( "addFamily:ca" );
		}

		public void reception() {

		}

		public void sendMessage( string message) {
			byte[] buffer = encoder.GetBytes( message );
			stream.Write ( buffer, 0, buffer.Length );
			stream.Flush ();
		}
	}
}

