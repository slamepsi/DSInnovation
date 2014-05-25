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
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace serverDS
{
	public class methode
	{
		private static MySqlCommand cmd;

	/*	// // // // // // // // // // // // // // // // // // // // // //
		// // // // //	    METHODE AJOUTER FAMILLE     // // // // // //
		// // // // // // // // // // // // // // // // // // // // // //	*/

		public static void add_family(string nom, string adresse)
		{
			cmd = new MySqlCommand();

			cmd.Connection = database.GetConnexion;
			cmd.CommandText = "INSERT INTO family (nom, adresse, points) VALUES (@Nom, @Adresse, 0)";
			cmd.Prepare();

			cmd.Parameters.AddWithValue("@Nom", nom);
			cmd.Parameters.AddWithValue("@Adresse", adresse);

			cmd.ExecuteNonQuery();

			// je récupére le code de ce que je viens d'insérer
			cmd = new MySqlCommand();
			cmd.Connection = database.GetConnexion;
			cmd.CommandText = "SELECT * FROM family WHERE nom = @Nom AND adresse = @Adresse";

			cmd.Prepare();
			
			cmd.Parameters.AddWithValue("@nom", nom);
			cmd.Parameters.AddWithValue("@Adresse", adresse);
			
			MySqlDataReader reader = cmd.ExecuteReader();

			reader.Read();
			client.broadcast("CreateFamily:"+ reader.GetInt16(0) + ":" + nom + ":" + adresse + ":0" );
			reader.Close();
			Console.WriteLine("Famille créée");
		}

	/*	// // // // // // // // // // // // // // // // // // // // // //
		// // // // //	    METHODE AJOUTER MEMBRE      // // // // // //
		// // // // // // // // // // // // // // // // // // // // // //	*/

		public static void add_member(int id, string prenom, int genre)
		{
			cmd = new MySqlCommand();

			cmd.Connection = database.GetConnexion;
			cmd.CommandText = "INSERT INTO member (codeFamille, prenom, genre) VALUES (@id, @Prenom, @Genre)";
			cmd.Prepare();

			cmd.Parameters.AddWithValue("@id", id);
			cmd.Parameters.AddWithValue("@Prenom", prenom);
			cmd.Parameters.AddWithValue("@Genre", genre);

			cmd.ExecuteNonQuery();

			client.broadcast("CreateMember:" + id + ":" + prenom + ":" + genre );

			Console.WriteLine("Membre ajouté");
		}

	/*	// // // // // // // // // // // // // // // // // // // // // //
		// // // // //    METHODE SUPPRIMER FAMILLE     // // // // // //
		// // // // // // // // // // // // // // // // // // // // // //	*/

		public static void del_family(int code, string nom)
		{
			cmd = new MySqlCommand();

			cmd.Connection = database.GetConnexion;
			cmd.CommandText = "DELETE FROM family WHERE nom = '@Nom' XOR code = '@id'";
			cmd.Prepare();

			cmd.Parameters.AddWithValue("@Nom", nom);
			cmd.Parameters.AddWithValue("@id", code);

			cmd.ExecuteNonQuery();

			Console.WriteLine("Famille supprimée");
		}

	/*	// // // // // // // // // // // // // // // // // // // // // //
		// // // // //     METHODE SUPPRIMER MEMBRE     // // // // // //
		// // // // // // // // // // // // // // // // // // // // // //	*/

		public static void del_member(int id, string prenom)
		{
			cmd = new MySqlCommand();
			
			cmd.Connection = database.GetConnexion;
			cmd.CommandText = "DELETE FROM member WHERE prenom = '@Prenom' XOR id = '@id'";
			cmd.Prepare();

			cmd.Parameters.AddWithValue("@id", id);
			cmd.Parameters.AddWithValue("@Prenom", prenom);

			cmd.ExecuteNonQuery();

			Console.WriteLine("Membre supprimé");
		}

	/*	// // // // // // // // // // // // // // // // // // // // // //
		// // // // //     METHODE MODIFIER FAMILLE     // // // // // //
		// // // // // // // // // // // // // // // // // // // // // //	*/

		public static void upd_family(string nom, string adresse)
		{
			cmd = new MySqlCommand();

			cmd.Connection = database.GetConnexion;
			cmd.CommandText = "UPDATE family (nom, adresse) VALUES (@Nom, @Adresse)";
			cmd.Prepare();

			cmd.Parameters.AddWithValue("@Nom", nom);
			cmd.Parameters.AddWithValue("@Adresse", adresse);

			cmd.ExecuteNonQuery();

			Console.WriteLine("Famille modifiée");
		}

	/*	// // // // // // // // // // // // // // // // // // // // // //
		// // // // //     METHODE MODIFIER MEMBRE      // // // // // //
		// // // // // // // // // // // // // // // // // // // // // //	*/

		public static void upd_member(string prenom, int genre)
		{
			cmd = new MySqlCommand();
			
			cmd.Connection = database.GetConnexion;
			cmd.CommandText = "UPDATE member (prenom, genre) VALUES (@Prenom, @Genre)";
			cmd.Prepare();

			cmd.Parameters.AddWithValue("@Prenom", prenom);
			cmd.Parameters.AddWithValue("@Genre", genre);

			cmd.ExecuteNonQuery();

			Console.WriteLine("Membre modifié");
		}

	/*	// // // // // // // // // // // // // // // // // // // // // //
		// // // // //     METHODE MODIFIER POINTS      // // // // // //
		// // // // // // // // // // // // // // // // // // // // // //	*/

		public static void upd_point(int points)
		{
			cmd = new MySqlCommand();

			cmd.Connection = database.GetConnexion;
			cmd.CommandText = "UPDATE family (points) VALUES (@Points)";
			cmd.Prepare();

			cmd.Parameters.AddWithValue("@Points", points);

			cmd.ExecuteNonQuery();

			//client.broadcast("UpdatePoints:" + points);

			Console.WriteLine("Points modifiés");
		}

	/*	// // // // // // // // // // // // // // // // // // // // // //
		// // //   METHODE ENVOYER TOUS LES PAQUETS AUX CLIENTS  // // //
		// // // // // // // // // // // // // // // // // // // // // //	*/

		public static List<string> SendAllInfo ()
		{
			cmd = new MySqlCommand();

			cmd.Connection = database.GetConnexion;
			cmd.CommandText = "SELECT * FROM family";
			cmd.Prepare();

			MySqlDataReader reader = cmd.ExecuteReader();

			List<string> information = new List<string>();
			List<int> informationCode = new List<int>();
			while ( reader.Read() )
			{
				informationCode.Add(reader.GetInt16(0));
				information.Add( "infoDb:" + reader.GetInt16(0) + ":" +reader.GetString(1) + ":" + 
					reader.GetString(2) + ":" + reader.GetInt16(3));

			}
			reader.Close();

			for(int i = 0; i < information.Count; i++) {
				cmd = new MySqlCommand();
				
				cmd.Connection = database.GetConnexion;
				cmd.CommandText = "SELECT * FROM member WHERE codeFamille = @code";
				cmd.Prepare();

				cmd.Parameters.AddWithValue("@code", informationCode[i]);
				
				reader = cmd.ExecuteReader();

				while( reader.Read() ) {
					information[i] += ":" + reader.GetString(2) + ":" + reader.GetInt16(3);
				}

				reader.Close();

			}
			Console.WriteLine(information.Count);
			return information;
		}
	}
}