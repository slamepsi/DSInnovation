using System;
using Gtk;

namespace DSInnovation
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// test
			Application.Init ();
			new Interface();
			Application.Run ();
		}
	}
}
