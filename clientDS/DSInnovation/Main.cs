using System;
using Gtk;

namespace DSInnovation
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			new socket();
			// test
			Application.Init ();
			new Interface();
			Application.Run ();
		}
	}
}
