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

namespace akasztoFa {
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page {
        public Page3() {
            InitializeComponent();
            neveredmeny.Content = $"{Page2.jatek.ValasztottJatekos.Nev} eddigi eredményei:";
            if (Page2.jatek.allapot == "nyert") {
                winlose.Foreground = new SolidColorBrush(Colors.DarkOliveGreen);
                winlose.Content = "Győztél!";
            }
            if (Page2.jatek.allapot == "vesztett") {
                winlose.Foreground = new SolidColorBrush(Colors.DarkRed);
                winlose.Content = "Vesztettél!";
            }
            listeredmeny.Items.Add($"Biológia témakörben nyert {Page2.jatek.ValasztottJatekos.B_Nyert}, vesztett {Page2.jatek.ValasztottJatekos.B_Vesztett} játékot.");
            listeredmeny.Items.Add($"Matematika témakörben nyert {Page2.jatek.ValasztottJatekos.M_Nyert}, vesztett {Page2.jatek.ValasztottJatekos.M_Vesztett} játékot.");
            listeredmeny.Items.Add($"Informatika témakörben nyert {Page2.jatek.ValasztottJatekos.I_Nyert}, vesztett {Page2.jatek.ValasztottJatekos.I_Vesztett} játékot.");
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}
