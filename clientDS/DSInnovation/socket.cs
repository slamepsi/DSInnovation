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
				tcpclient.Connect( IPAddress.Parse("192.168.2.1"), 27015 );
				stream = tcpclient.GetStream();
				receptionThread = new Thread( new ThreadStart(reception));
				receptionThread.Start();
			} catch (Exception e) {
				Console.WriteLine( "Connection error, code : 1\n"+e.Message );
			}
		}

		public void reception() {
			byte [] message = new byte[16384];
			int byteRead;
			int familleCourante = 0;


			while( true ) {
				byteRead = 0;
				try {
					byteRead = stream.Read(message, 0, message.Length);
				} catch {
					return;
				}

				if(byteRead == 0)
					break;

				ASCIIEncoding encoder = new ASCIIEncoding();
				string information = encoder.GetString(message, 0, byteRead);
				string[] infoSocket = information.Split(':');

				//Console.WriteLine( information );

				try {
					switch(infoSocket[0]) {
					case "infoDb":
						Interface.familleListe.Add( new Famille( int.Parse (infoSocket[1]), infoSocket[2], infoSocket[3], int.Parse (infoSocket[4]) ) );
						for(int i = 5; i < infoSocket.Length; i+=3) {
							Interface.familleListe[familleCourante].AddMembre( int.Parse (infoSocket[i]), infoSocket[i+1], int.Parse(infoSocket[i+2]) );
						}
						familleCourante++;
						Interface.refreshList();
						break;
					case "CreateFamily":
						Interface.familleListe.Add( new Famille( int.Parse (infoSocket[1]), infoSocket[2], infoSocket[3], int.Parse (infoSocket[4]) ) );
						Interface.refreshList();
						break;
					case "CreateMember":
						for( int i = 0; i < Interface.familleListe.Count; i++ ){
							if( Interface.familleListe[i].Dbid == int.Parse (infoSocket[1])) {
								Interface.familleListe[i].AddMembre( int.Parse(infoSocket[2]), infoSocket[3] ,int.Parse( infoSocket[4]) );
								break;
							}
						}
						Interface.refreshList();
						break;
					case "DeleteFamily":
						for(int i = 0; i < Interface.familleListe.Count; i++) {
							if( Interface.familleListe[i].Dbid == int.Parse(infoSocket[1]) ) {
								Famille.IdStaticDecrement();
								for( int k = i; k < Interface.familleListe.Count; k++ ) {
									Interface.familleListe[k].IdDecrement();
								}
								Interface.familleListe.RemoveAt(i);
								break;
							}
						}
						Interface.refreshList();
						break;
					case "DeleteMember":
						for(int i = 0; i < Interface.familleListe.Count; i++) {
							if( Interface.familleListe[i].Dbid == int.Parse(infoSocket[1]) ) {
								for(int j = 0; j < Interface.familleListe[i].GetTailleListeMembre; j++) {
									if(Interface.familleListe[i].GetMembre(j).Dbid == int.Parse(infoSocket[2]) ) {
										Interface.familleListe[i].DelMembre(j);
										break;
									}
								}
								break;
							}
						}
						Interface.refreshList();
						break;
					case "UpdateFamily":
						for(int i = 0; i < Interface.familleListe.Count; i++) {
							if( Interface.familleListe[i].Dbid == int.Parse(infoSocket[1]) ) {
								Interface.familleListe[i].Nom = infoSocket[2];
								Interface.familleListe[i].Adresse = infoSocket[3];
								break;
							}
						}
						Interface.refreshList();
						break;
					case "UpdateMember":
						for(int i = 0; i < Interface.familleListe.Count; i++) {
							if( Interface.familleListe[i].Dbid == int.Parse(infoSocket[1]) ) {
								for(int j = 0; j < Interface.familleListe[i].GetTailleListeMembre; j++) {
									if(Interface.familleListe[i].GetMembre(j).Dbid == int.Parse(infoSocket[2]) ) {
										Interface.familleListe[i].GetMembre(j).Prenom = infoSocket[3];
										Interface.familleListe[i].GetMembre(j).Genre = int.Parse (infoSocket[4]);
										break;
									}
								}
								break;
							}
						}
						Interface.refreshList();
						break;
					case "UpdatePoints":
						for(int i = 0; i < Interface.familleListe.Count; i++) {
							if( Interface.familleListe[i].Dbid == int.Parse(infoSocket[1]) ) {
								Interface.familleListe[i].Points = int.Parse (infoSocket[2]);
								break;
							}
						}
						Interface.refreshList();
						break;
					}
				}catch (Exception e) {
					while( Interface.familleListe.Count != 0) {
						Interface.familleListe.RemoveAt(0);
					}
					Console.WriteLine("Error(2) " + e.Message);
					sendMessage("error");
				}
			}
		}

		public void sendMessage( string message ) {
			byte[] buffer = encoder.GetBytes( message );
			NetworkStream localStream = stream;
			localStream.Write ( buffer, 0, buffer.Length );
			localStream.Flush ();
		}

		public void disconnect() {
			stream.Close();
			tcpclient.Close();
			receptionThread.Abort();
		}
	}
}

