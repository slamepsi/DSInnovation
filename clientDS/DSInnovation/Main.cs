using System;
using Gtk;

namespace DSInnovation
{
	class MainClass
	{
		private static socket connexion;
		public static void Main (string[] args)
		{
			// ceci est le model pour les socket qui crée les famille
			Interface.familleListe.Add( new Famille( "Lepretre", "1 rue des jardins de l'église Chéreng", 100 ) );
			Interface.familleListe.Add( new Famille( "Buirette", "Lille", 10 ) );
			Interface.familleListe.Add( new Famille( "Argenson", "Lambersar, rue des noobs", 50 ) );

			// ceci est le model pour les sockets qui crée les membres
			Interface.familleListe[0].AddMembre( "Alexandre", 1 );
			Interface.familleListe[0].AddMembre( "Estelle", 0 );
			Interface.familleListe[0].AddMembre( "Véronique", 0 );
			
			Interface.familleListe[1].AddMembre( "Quentin", 1 );
			
			Interface.familleListe[2].AddMembre( "Guillaume", 1 );
			Interface.familleListe[2].AddMembre( "Ses soeurs", 0 );

			//connexion = new socket();
			Application.Init ();
			new Interface();
			Application.Run ();
		}

		public static socket GetSocket {
			get { return connexion; }
		}
	}
}
