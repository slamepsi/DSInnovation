using System;
using Gtk;

namespace DSInnovation
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// test22
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
