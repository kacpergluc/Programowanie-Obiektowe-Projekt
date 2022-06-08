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

namespace Programowanie_Obiektowe_Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            wynik.Content = "Hello world";
        }

        private void Jednostki_Miary_Click(object sender, RoutedEventArgs e)
        {
            wynik.Content = "Hello miary click";
        }

        private void Jednostki_Predkosci_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Konwertuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Wyczysc_Click(object sender, RoutedEventArgs e)
        {
            wynik.Content = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
