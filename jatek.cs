using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akasztoFa {

	public class Jatek {
		public string ValasztottSzo { get; private set; }
		public Jatekos ValasztottJatekos { get; private set; }
		public Jatek(string jatekosNev, char tipus) {

			// itt error (lista nem tartalmaz elemeket)
			ValasztottSzo = Adatok.Szavak
				.Where(s => s.Tipus == tipus)
				.Select(s => s.Text)
				.OrderBy(s => Guid.NewGuid())
				.First()
			;
			if (Adatok.Jatekosok.Where(s => s.Nev == jatekosNev).Count() == 0) 
				Adatok.Jatekosok.Add(new Jatekos($"{jatekosNev};0;0;0;0;0;0"));
			ValasztottJatekos = Adatok.Jatekosok.Where(s => s.Nev == jatekosNev).First();
		}
	}
}
