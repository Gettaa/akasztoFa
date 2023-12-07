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

	// szavak.cs Linq-val való használatra készíti fel szavak.txt-t

	public class Szo {

		public string Text { get; private set; }
		public string Tipus { get; private set; }
        public Szo(string sor) {
			string[] cuccok = sor.Split(';');
			Text = cuccok[0];
			Tipus = cuccok[1];
		}
	}

	public static class Szavak {

		public static List<Szo> Lista = new List<Szo>();

		public static void General() {
			string[] szavakFajl = File.ReadAllLines("szavak.txt", Encoding.UTF8);
			foreach (string sor in szavakFajl) Lista.Add(new Szo(sor));
		}
	}
}