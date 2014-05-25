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
using System.Collections.Generic;

namespace DSInnovation
{
	public class Famille
	{
		private int _id;
		private static int idStatic = 0;
		private int _dbid;
		private string _nom;
		private string _adresse;
		private int _points;
		private List<Membre> membre;


		public Famille(int dbid, string nom, string adresse, int points) {
			this._id = idStatic;
			this._nom = nom;
			this._adresse = adresse;
			this._points = points;
			this._dbid = dbid;
			membre = new List<Membre>();
			idStatic++;
		}

		public string Nom {
			get { return this._nom; }
			set { this._nom = value; }
		}

		public string Adresse {
			get { return this._adresse; }
			set { this._adresse = value; }
		}

		public int Points {
			get { return this._points; }
			set { this._points = value; }
		}

		public int Id {
			get { return this._id; }
		}

		public int Dbid {
			get { return this._dbid; }
		}

		public void AddMembre( string prenom, int genre ) {
			this.membre.Add(new Membre(prenom, genre));
		}

		public string GetMembre( int index ) {
			return this.membre[index].Prenom;
		}

		public int GetTailleListeMembre {
			get { return membre.Count; }
		}
	}

	public class Membre
	{
		private string _prenom;
		private int _genre;

		public Membre ( string prenom, int genre ) {
			this._genre = genre;
			this._prenom = prenom;
		}

		public string Prenom {
			get { return this._prenom; }
			set { this._prenom = value; }
		}

		public int Genre {
			get { return this._genre; }
			set { this._genre = value; }
		}
	}
}

