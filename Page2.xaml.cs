using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace akasztoFa
{
	/// <summary>
	/// Interaction logic for Page2.xaml
	/// </summary>
	public partial class Page2 : Page
	{
		private Jatek jatek;
		private char[] szo;
		private List<char> kitalalt_char = new List<char>();
		private List<char> rossz_char = new List<char>();
		List<Label> labellList;
		public Page2()
		{
			InitializeComponent();
			jatek = new Jatek(Page1.jatekosNev, Page1.Mode, Page1.hibaSzam);
			Console.WriteLine(jatek.ValasztottSzo);
			szo = jatek.ValasztottSzo.ToCharArray();
			labellList = new List<Label> {
				betu1, betu2, betu3, betu4, betu5,
				betu6, betu7, betu8, betu9, betu10,
				betu11, betu12, betu13, betu14
			};
			labellList.RemoveRange(szo.Length, labellList.Count - szo.Length);
			labellList.TrimExcess();
			labellList.ForEach(l => l.Visibility = Visibility.Visible);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			SortChar(betutipp.Text.ToLower().First());
			for (int i = 0; i < szo.Length; i++) {
				char szoch = szo[i];
				if (kitalalt_char.Contains(szoch)) {
					labellList[i].Content = szoch.ToString();
				}
			}
		}

		private void SortChar(char ch) {
			ch = betutipp.Text.ToString().First();
			if (jatek.ContainsChar(ch) && !kitalalt_char.Contains(ch)) kitalalt_char.Add(ch);
			else if (jatek.ContainsChar(ch) && kitalalt_char.Contains(ch)) Console.WriteLine("Mar volt helyes tipp");
			if (!jatek.ContainsChar(ch) && !rossz_char.Contains(ch)) rossz_char.Add(ch);
			else if (!jatek.ContainsChar(ch) && rossz_char.Contains(ch)) Console.WriteLine("Mar volt hibas tipp");
		}
	}
}
