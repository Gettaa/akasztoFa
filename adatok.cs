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
		public string Tipus { get; private set; }
		public Szo(string sor) {
			string[] cuccok = sor.Split(';');
			Text = cuccok[0];
			Tipus = cuccok[1];
		}
	}

	public class Jatekos {

		// jatekosok.txt feldolgozasa
		public string Nev { get; private set; }
		public int b_Nyert { get; private set; }
		public int b_Vesztett { get; private set; }
		public int m_Nyert { get; private set; }
		public int m_Vesztett { get; private set; }
		public int i_Nyert { get; private set; }
		public int i_Vesztett { get; private set; }

		public Jatekos(string sor) {
			string[] adatok = sor.Split(';');
			Nev = adatok[0];
			b_Nyert = int.Parse(adatok[1]);
			b_Vesztett = int.Parse(adatok[2]);
			m_Nyert = int.Parse(adatok[3]);
			m_Vesztett = int.Parse(adatok[4]);
			i_Nyert = int.Parse(adatok[5]);
			i_Vesztett = int.Parse(adatok[6]);
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