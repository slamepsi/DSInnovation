using System;

namespace serverDS
{
	class MainClass
	{
		private static bool running;

		public static void Main (string[] args)
		{
			new Server();
		}

		public static bool IsRunning {
			get { return running; }
			set { running = value; }
		}
	}
}
