using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Text;


namespace akasztoFa {

	// szavak.txt feldolgozasa
	public class Szo {

		public string Text { get; private set; }
		public char Tipus { get; private set; }
		public Szo(string sor) {
			string[] cuccok = sor.Split(';');
			Text = cuccok[0];
			Tipus = cuccok[1].ToCharArray()[0];
		}
	}

	public class Jatekos {

		// jatekosok.txt feldolgozasa
		public string Nev { get; private set; }
		public int B_Nyert { get; private set; }
		public int B_Vesztett { get; private set; }
		public int M_Nyert { get; private set; }
		public int M_Vesztett { get; private set; }
		public int I_Nyert { get; private set; }
		public int I_Vesztett { get; private set; }

		public Jatekos(string sor) {
			string[] adatok = sor.Split(';');
			Nev = adatok[0];
			B_Nyert = int.Parse(adatok[1]);
			B_Vesztett = int.Parse(adatok[2]);
			M_Nyert = int.Parse(adatok[3]);
			M_Vesztett = int.Parse(adatok[4]);
			I_Nyert = int.Parse(adatok[5]);
			I_Vesztett = int.Parse(adatok[6]);
		}
	}

	public static class Adatok {

		public static List<Szo> Szavak = new List<Szo>();
		public static List<Jatekos> Jatekosok = new List<Jatekos>();

		public static void General() {
			string[] szavakFajl = File.ReadAllLines("szavak.txt", Encoding.UTF8);
			foreach (string sor in szavakFajl) Szavak.Add(new Szo(sor));
			string[] jatekosokFajl = File.ReadAllLines("jatekosok.txt", Encoding.UTF8);
			foreach (string sor in jatekosokFajl) Jatekosok.Add(new Jatekos(sor));
		}
	}
}