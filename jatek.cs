using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akasztoFa {

	public class Jatek {
		public string valasztottSzo { get; private set; }
		public Jatek(string jatekosNev, char tipus) {
			valasztottSzo = Adatok.Szavak
				.Where(s => s.Tipus == tipus)
				.Select(s => s.Text)
				.OrderBy(s => Guid.NewGuid())
				.First()
			;
			var Jatekos = Adatok.Jatekosok.Where(s => s.Nev == jatekosNev);
			if (Jatekos.Count() == 0) Adatok.Jatekosok.Add(new Jatekos($"{jatekosNev};0;0;0;0;0;0"));
		}
	}
}
