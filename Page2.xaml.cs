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
		public static Jatek jatek;
		public static List<Label> labellList;

		public Page2()
		{
			InitializeComponent();
			jatek = new Jatek(Page1.jatekosNev, Page1.Mode, Page1.hibaSzam);
			Console.WriteLine(jatek.ValasztottSzo);
			labellList = new List<Label> {
				betu1, betu2, betu3, betu4, betu5,
				betu6, betu7, betu8, betu9, betu10,
				betu11, betu12, betu13
			};
			labellList.ForEach(l => l.Visibility = Visibility.Hidden);
			labellList.RemoveRange(jatek.ValasztottSzo.Length, labellList.Count - jatek.ValasztottSzo.Length);
			labellList.TrimExcess();
			labellList.ForEach(l => l.Visibility = Visibility.Visible);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			jatek.CheckWord(fulltipp.Text);
		}

		private void betutipp_TextChanged(object sender, TextChangedEventArgs e) {
			if (betutipp.Text.Length > 0) jatek.CheckChar(betutipp.Text.ToLower().First());
			if (betutipp.Text.Length > 1) betutipp.Text = "";
		}
	}
}
