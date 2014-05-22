using System;

namespace serverDS
{
	class MainClass
	{
		private static bool running;

		public static void Main (string[] args)
		{
			running = true;
			new Server();

			MainClass bdd = new MainClass();
			String str = @"server=localhost;database=dsinnov;userid=root;password=root;";
			Console.WriteLine("Connexion établie" + str);
			database.Database(str);
			Console.WriteLine("Fin de connexion" + str);
		}

		public static bool IsRunning {
			get { return running; }
			set { running = value; }
		}
	}
}
