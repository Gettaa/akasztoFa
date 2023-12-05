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
		public static List<Szo> List { get; private set; } = new List<Szo>();
		public static void General(string[] args) {
			string[] szavakFajl = File.ReadAllLines("szavak.txt", Encoding.UTF8);
			foreach (string sor in szavakFajl) List.Add(new Szo(sor));
			Console.WriteLine(List.Select(a => a.Text).First());
		}
	}
}