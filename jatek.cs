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
		public string allapot { get; private set; } = "folyamatban";
		public bool isDuplicate { get; private set; } = false;
		private bool hasEnded = false;

		private char Tipus;

		public Jatek(string jatekosNev, char tipus, int enteredSzam) {
			max_hibaszam = enteredSzam;
			Tipus = tipus;
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

			Console.WriteLine(ValasztottSzo);
		}

		private void UpdateLabels() {
			for (int i = 0; i < Page2.labellList.Count; i++) {
				char szoch = ValasztottSzo[i];
				if (kitalalt_char.Contains(szoch)) {
					Page2.labellList[i].Content = szoch.ToString();
				}
			}
		}

		private void UpdateLabels(bool b) {
			for (int i = 0; i < Page2.labellList.Count; i++) {
				char szoch = ValasztottSzo[i];
				Page2.labellList[i].Content = szoch.ToString();
			}
		}


		private bool ContainsChar(char ch) {
			ch = char.ToLower(ch);
			return ValasztottSzo.Contains(ch);
		}

		private void SortChar(char ch) {
			if (ContainsChar(ch) && !kitalalt_char.Contains(ch)) {
				kitalalt_char.Add(ch);
				isDuplicate = false;
			}
			else if (ContainsChar(ch) && kitalalt_char.Contains(ch)) isDuplicate = true;
			if (!ContainsChar(ch) && !rossz_char.Contains(ch)) {
				rossz_char.Add(ch);
				isDuplicate = false;
			}
			else if (!ContainsChar(ch) && rossz_char.Contains(ch)) isDuplicate = true;
			rossz_char = rossz_char.Distinct().ToList();
			kitalalt_char = kitalalt_char.Distinct().ToList();
			hibaszam = rossz_char.Count;
		}

		private void Ment() {
			if (!hasEnded) {
				bool a;
				if (allapot == "vesztett") a = false;
				else if (allapot == "nyert") a = true;
				else return;

				switch (Tipus) {
					case 'b':
						if (a) ValasztottJatekos.B_Nyert++;
						else if (!a) ValasztottJatekos.B_Vesztett++;
						break;
					case 'm':
						if (a) ValasztottJatekos.M_Nyert++;
						else if (!a) ValasztottJatekos.M_Vesztett++;
						break;
					case 'i':
						if (a) ValasztottJatekos.I_Nyert++;
						else if (!a) ValasztottJatekos.I_Vesztett++;
						break;
					default:
						break;
				}
				Adatok.Ment();
				hasEnded = true;
			}
		}

		private void CheckProgress() {
			if (hibaszam >= max_hibaszam) {
				allapot = "vesztett";
				UpdateLabels(false);
				Ment();
			}
			else if (kitalalt_char.Count == ValasztottSzo.Distinct().ToList().Count) {
				allapot = "nyert";
				UpdateLabels(true);
				Ment();
			}
		}

		public void CheckChar(char ch) {
			SortChar(ch);
			UpdateLabels();
			CheckProgress();
		}

		public void CheckWord(string guess) {
			guess = guess.ToLower();
			if (guess == ValasztottSzo) {
				allapot = "nyert";
				UpdateLabels(true);
				Ment();
			}
			else {
				allapot = "vesztett";
				hibaszam = max_hibaszam;
				UpdateLabels(false);
				Ment();
			}
		}
	}
}
