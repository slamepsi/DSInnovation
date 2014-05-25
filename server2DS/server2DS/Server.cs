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
using System.Net.Sockets;		//	Libraire nécessaire à la gestion des paquets
//using MySql.Data.MySqlClient;		//	Libraire permettant d'eécuter l'accès BDD
using System.Collections.Generic;


namespace serverDS
{
	public class Server
	{
		private static TcpListener listener;			//	On déclare une variable "écoute du paquet"
		private static Thread listenerThread;
		private static List<client> clientsList;
		
		public Server ()
		{
			clientsList = new List<client>();
			listener = new TcpListener ( IPAddress.Parse( "192.168.1.9" ), 27015 );	//	192.168.1.3
			listenerThread = new Thread( new ThreadStart(ListenForClient) );
			listenerThread.Start();								//	On appel la méthode "démarrer le traitement du paquet"
		}
		
		public static void ListenForClient() {
			listener.Start();
			
			while(MainClass.IsRunning) {
				TcpClient nouveauClient = listener.AcceptTcpClient();
				new client(nouveauClient);
			}
		}

		public static client GetClient( int index ) {
			return clientsList[index];
		}

		public static int GetCount () {
			return clientsList.Count;
		}

		public static void AddClient( client newClient ) {
			clientsList.Add ( newClient );
		}

		public static void removeClient( client delClient ) {
			clientsList.Remove( delClient );
		}
	}
}
