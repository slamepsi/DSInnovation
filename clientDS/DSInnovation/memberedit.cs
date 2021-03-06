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
	public class memberedit : Window
	{
		public memberedit (int idFamily, int idMember) : base("Membre edit")
		{
			SetDefaultSize(275, 250);
			this.WindowPosition = WindowPosition.Center;

			Fixed fix = new Fixed();
			
			Label texteInfo = new Label("Modifier le membre : " + Interface.familleListe[idFamily].GetMembre(idMember).Prenom);

			Label prenomLabel = new Label("Prénom : ");
			Entry prenomEntry = new Entry(Interface.familleListe[idFamily].GetMembre(idMember).Prenom);
			prenomEntry.SetSizeRequest( 100, 25 );

			Label genreLabel = new Label("Genre : ");
			ComboBox genreComboBox = new ComboBox(new String[] {"Homme", "Femme"});
			genreComboBox.Active = Interface.familleListe[idFamily].GetMembre(idMember).Genre;
			
			Button cancel = new Button("Annuler");
			cancel.Clicked += delegate {
				this.Destroy();
			};
			cancel.SetSizeRequest( 100, 50 );
			
			Button ok = new Button("Valider");
			ok.Clicked += delegate {
				try { 
					if( prenomEntry.Text.Length > 2 ) {
						MainClass.GetSocket.sendMessage("updMember:" +
						                                Interface.familleListe[idFamily].Dbid + ":" + 
						                                Interface.familleListe[idFamily].GetMembre(idMember).Dbid + ":" +
						                                prenomEntry.Text.Replace(':', '_') + ":" +
						                                genreComboBox.Active);
						this.Destroy();
					}
				} catch {
					prenomEntry.Text = "";
				}
			};
			ok.SetSizeRequest( 100, 50 );

			Button del = new Button("Supprimer");
			del.SetSizeRequest( 100, 30 );
			del.Clicked += delegate {
				MainClass.GetSocket.sendMessage("delMember" + ":" +
				                                Interface.familleListe[idFamily].Dbid + ":" +
				                                Interface.familleListe[idFamily].GetMembre(idMember).Dbid);
				this.Destroy();
			};
			
			fix.Put ( texteInfo, 50, 25 );
			fix.Put ( prenomLabel, 75, 65 );
			fix.Put ( prenomEntry, 130, 60 );
			fix.Put ( genreLabel, 75, 100 );
			fix.Put ( genreComboBox, 130, 93 );
			fix.Put ( cancel, 25, 135 );
			fix.Put ( ok, 150, 135 );
			fix.Put ( del, 89, 200 );
			
			this.Add ( fix );
			
			ShowAll();
		}
	}
}

