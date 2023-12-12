using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
	public partial class Page1 : Page {

		public static char Mode = 'b';
		public static string jatekosNev = "Guest";
		public static int hibaSzam = 14;

		public Page1() {
			InitializeComponent();
		}

		private void biobutton_Checked(object sender, RoutedEventArgs e) {
			modvalto.Fill = new SolidColorBrush(Color.FromRgb(163, 210, 168));
			Mode = 'b';
		}

		private void methbutton_Checked(object sender, RoutedEventArgs e) {
			modvalto.Fill = new SolidColorBrush(Color.FromRgb(118, 155, 189));
			Mode = 'm';
		}
		private void infobutton_Checked(object sender, RoutedEventArgs e) {
			modvalto.Fill = new SolidColorBrush(Color.FromRgb(121, 103, 191));
			Mode = 'i';
		}

		private void nextbutton_Click(object sender, RoutedEventArgs e) {
			if (int.TryParse(hibanumberask.Text, out int parsedValue) && parsedValue >= 6 && parsedValue <= 12) {
				hibaSzam = parsedValue;
				jatekosNev = playerchooser.Text.Length > 0 ? playerchooser.Text : "Guest";
				Page2 page2 = new Page2();
				NavigationService.Navigate(page2);
			} else hibanumberask.Text = "Csak szám lehet 6 és 12 között!";
		}
	}
}
