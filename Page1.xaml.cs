﻿using System;
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
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page {

        public char mode = 'b';
        public Page1() {
            InitializeComponent();
    }

        private void biobutton_Checked(object sender, RoutedEventArgs e) {
            modvalto.Fill = new SolidColorBrush(Color.FromRgb(163, 210, 168));
        }

        private void methbutton_Checked(object sender, RoutedEventArgs e) {
            modvalto.Fill = new SolidColorBrush(Color.FromRgb(118, 155, 189));
        }
        private void infobutton_Checked(object sender, RoutedEventArgs e) {
            modvalto.Fill = new SolidColorBrush(Color.FromRgb(121, 103, 191));
        }

        private void nextbutton_Click(object sender, RoutedEventArgs e) {
            int parsedValue = 0;
            if (int.TryParse(hibanumberask.Text, out parsedValue)) {
                Page2 page2 = new Page2();
                Console.WriteLine("kövi lap");
                NavigationService.Navigate(page2);
            }
        }
    }
}
