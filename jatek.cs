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
		public int max_hibaszam { get; set; }
		public List<char> kitalalt_char = new List<char>();
		public List<char> rossz_char = new List<char>();
		public int hibaszam { get; private set; }

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

		public void CheckWord(string guess) {
			guess = guess.ToLower();
			if (guess == ValasztottSzo) foreach (char ch in ValasztottSzo) CheckChar(ch);
			else { hibaszam = max_hibaszam; }
		}

		public void SortChar(char ch) {
			if (ContainsChar(ch) && !kitalalt_char.Contains(ch)) kitalalt_char.Add(ch);
			else if (ContainsChar(ch) && kitalalt_char.Contains(ch)) Console.WriteLine("Mar volt helyes tipp");
			if (!ContainsChar(ch) && !rossz_char.Contains(ch)) rossz_char.Add(ch);
			else if (!ContainsChar(ch) && rossz_char.Contains(ch)) Console.WriteLine("Mar volt hibas tipp");
		}


		public void CheckChar(char ch) {
			SortChar(ch);
			UpdateLabels();
			Console.WriteLine($"Próbált, nem helyes karakterek: {string.Join(", ", rossz_char)}");
		}

		private void UpdateLabels() {
			for (int i = 0; i < Page2.labellList.Count; i++) {
				char szoch = ValasztottSzo[i];
				if (kitalalt_char.Contains(szoch)) {
					Page2.labellList[i].Content = szoch.ToString();
				}
			}
		}
	}
}
