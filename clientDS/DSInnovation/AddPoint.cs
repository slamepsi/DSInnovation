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
using Gtk;

namespace DSInnovation
{
	public class AddPoint : Window
	{
		public AddPoint (int idFamily,string info) : base ("Ajout de points : " + info)
		{
			SetDefaultSize(275, 150);
			this.WindowPosition = WindowPosition.Center;

			Fixed fix = new Fixed();

			Label nombrePointLabel = new Label("Nombre de points : ");

			Entry nombrePointEntry = new Entry();
			nombrePointEntry.SetSizeRequest( 50, 25 );

			Button cancel = new Button("Annuler");
			cancel.Clicked += delegate {
				this.Destroy();
			};
			cancel.SetSizeRequest( 100, 50 );

			Button ok = new Button("Valider");
			ok.Clicked += delegate {
				try { 
					int points = int.Parse(nombrePointEntry.Text);
					if( points > 0 ) {
						MainClass.GetSocket.sendMessage("updPoints:" + idFamily + ":" + points);
						this.Destroy();
					}
				} catch {
					nombrePointEntry.Text = "";
				}
			};
			ok.SetSizeRequest( 100, 50 );

			fix.Put ( nombrePointLabel, 50, 25 );
			fix.Put ( nombrePointEntry, 175, 20 );
			fix.Put ( cancel, 25, 75 );
			fix.Put ( ok, 150, 75 );

			this.Add ( fix );

			ShowAll();
		}
	}

	public class DelPoint : Window
	{
		public DelPoint (int idFamily, string info) : base ("Enlever des points : " + info)
		{
			SetDefaultSize(275, 150);
			this.WindowPosition = WindowPosition.Center;
			
			Fixed fix = new Fixed();
			
			Label nombrePointLabel = new Label("Nombre de points : ");
			
			Entry nombrePointEntry = new Entry();
			nombrePointEntry.SetSizeRequest( 50, 25 );
			
			Button cancel = new Button("Annuler");
			cancel.Clicked += delegate {
				this.Destroy();
			};
			cancel.SetSizeRequest( 100, 50 );
			
			Button ok = new Button("Valider");
			ok.Clicked += delegate {
				try {
					int points = int.Parse(nombrePointEntry.Text);
					if( points > 0 ) {
						points *= -1;
						MainClass.GetSocket.sendMessage("updPoints:" + idFamily + ":" + points);
						this.Destroy();
					}
				} catch {
					nombrePointEntry.Text = "";
				}
			};
			ok.SetSizeRequest( 100, 50 );
			
			fix.Put ( nombrePointLabel, 50, 25 );
			fix.Put ( nombrePointEntry, 175, 20 );
			fix.Put ( cancel, 25, 75 );
			fix.Put ( ok, 150, 75 );
			
			this.Add ( fix );
			
			ShowAll();
		}
	}
}

