using System;
using Gtk;

namespace DSInnovation
{
	class MainClass
	{
		private static socket connexion;
		public static void Main (string[] args)
		{
			connexion = new socket();
			Application.Init ();
			new Interface();
			Application.Run ();
		}

		public static socket GetSocket {
			get { return connexion; }
		}
	}
}
