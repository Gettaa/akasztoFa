using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akasztoFa {

	public class Jatek {

		public string ValasztottSzo { get; private set; }
		public Jatekos ValasztottJatekos { get; private set; }
		public int max_hibaszam;
		public int hibaszam;

		public Jatek(string jatekosNev, char tipus, int enteredSzam) {
			max_hibaszam = enteredSzam;
			ValasztottSzo = Adatok.Szavak
				.Where(s => s.Tipus == tipus)
				.OrderBy(s => Guid.NewGuid())
				.Select(s => s.Text)
				.First()
				.ToLower()
			;
			if (Adatok.Jatekosok.Where(s => s.Nev == jatekosNev).Count() == 0) 
				Adatok.Jatekosok.Add(new Jatekos($"{jatekosNev};0;0;0;0;0;0"));
			ValasztottJatekos = Adatok.Jatekosok.Where(s => s.Nev == jatekosNev).First();
		}

		public bool ContainsChar(char ch) {
			ch = ch.ToString().ToLower().ToCharArray()[0];
			return ValasztottSzo.ToCharArray().Contains(ch);
		}

		public void CheckGuess(string guess) {
			guess = guess.ToLower();
			if (guess == ValasztottSzo) {
				// success
			} else { hibaszam = max_hibaszam; }
		}
	}
}
