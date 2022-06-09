using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public DataTable dtJednostkiMairy = new DataTable();
        public DataTable dtJednostkiPredkosci = new DataTable();
        public DataTable dtPole = new DataTable();
        public DataTable dtHistoria = new DataTable();

        public MainWindow()
        {
            InitializeComponent();
            BindJednostkiMiary();
            BindJednostkiPredkosci();
            BindHistoria();
            BindPole();
        }

        private void BindJednostkiMiary()
        {
            dtJednostkiMairy.Columns.Add("Text");
            dtJednostkiMairy.Columns.Add("Value");

            dtJednostkiMairy.Rows.Add("-Wybierz-", 0);
            dtJednostkiMairy.Rows.Add("mm", 1);
            dtJednostkiMairy.Rows.Add("cm", 10);
            dtJednostkiMairy.Rows.Add("m", 1000);
            dtJednostkiMairy.Rows.Add("km", 1000000);
            dtJednostkiMairy.Rows.Add("cale", 25.4);
            dtJednostkiMairy.Rows.Add("stopy", 304.8);
            dtJednostkiMairy.Rows.Add("mile", 1609344);
        }

        private void BindJednostkiPredkosci()
        {
            dtJednostkiPredkosci.Columns.Add("Text");
            dtJednostkiPredkosci.Columns.Add("Value");

            dtJednostkiPredkosci.Rows.Add("-Wybierz-", 0);
            dtJednostkiPredkosci.Rows.Add("m/s", 1);
            dtJednostkiPredkosci.Rows.Add("km/h", 3.6);
            dtJednostkiPredkosci.Rows.Add("mph", 2.24);
        }

        private void BindPole()
        {
            dtPole.Columns.Add("Text");
            dtPole.Columns.Add("Value");

            dtPole.Rows.Add("-Wybierz-", 0);
            dtPole.Rows.Add("cm2", 0.0001);
            dtPole.Rows.Add("m2", 1);
            dtPole.Rows.Add("a", 100);
            dtPole.Rows.Add("he", 10000);
        }

        private void BindHistoria()
        {
            dtHistoria.Columns.Add("Ilość");
            dtHistoria.Columns.Add("Konwertuj Z");
            dtHistoria.Columns.Add("Konwertuj Na");
            dtHistoria.Columns.Add("ilość po konwersji");
            dtHistoria.Columns.Add("Data");

            dtHistoriaView.DataContext = dtHistoria.DefaultView;
        }

        private void Jednostki_Miary_Click(object sender, RoutedEventArgs e)
        {
            cmbZ.ItemsSource = dtJednostkiMairy.DefaultView;
            cmbZ.DisplayMemberPath = "Text";
            cmbZ.SelectedValuePath = "Value";
            cmbZ.SelectedIndex = 0;

            cmbNa.ItemsSource = dtJednostkiMairy.DefaultView;
            cmbNa.DisplayMemberPath = "Text";
            cmbNa.SelectedValuePath = "Value";
            cmbNa.SelectedIndex = 0;
        }
        private void Jednostki_Predkosci_Click(object sender, RoutedEventArgs e)
        {
            cmbZ.ItemsSource = dtJednostkiPredkosci.DefaultView;
            cmbZ.DisplayMemberPath = "Text";
            cmbZ.SelectedValuePath = "Value";
            cmbZ.SelectedIndex = 0;

            cmbNa.ItemsSource = dtJednostkiPredkosci.DefaultView;
            cmbNa.DisplayMemberPath = "Text";
            cmbNa.SelectedValuePath = "Value";
            cmbNa.SelectedIndex = 0;
        }

        private void Pole_Click(object sender, RoutedEventArgs e)
        {
            cmbZ.ItemsSource = dtPole.DefaultView;
            cmbZ.DisplayMemberPath = "Text";
            cmbZ.SelectedValuePath = "Value";
            cmbZ.SelectedIndex = 0;

            cmbNa.ItemsSource = dtPole.DefaultView;
            cmbNa.DisplayMemberPath = "Text";
            cmbNa.SelectedValuePath = "Value";
            cmbNa.SelectedIndex = 0;
        }

        private void Konwertuj_Click(object sender, RoutedEventArgs e)
        {
            double KonwValue;

            if (txtIlosc.Text == null || txtIlosc.Text.Trim() == "")
            {
                MessageBox.Show("Wprowadż wartość", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                txtIlosc.Focus();
                return;
            }
            else if (cmbZ.SelectedValue == null || cmbZ.SelectedIndex == 0)
            {
                MessageBox.Show("Wybierz jednostkę Z", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                cmbZ.Focus();
                return;
            }
            else if (cmbNa.SelectedValue == null || cmbNa.SelectedIndex == 0)
            {
                MessageBox.Show("Wybierz jednostkę Na", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                cmbNa.Focus();
                return;
            }

            if (cmbZ.Text == cmbNa.Text)
            {
                KonwValue = double.Parse(txtIlosc.Text);

                wynik.Content = KonwValue.ToString() + " " + cmbNa.Text;
                dtHistoria.Rows.Add(txtIlosc.Text, cmbZ.Text, cmbNa.Text, wynik.Content, DateTime.Now);
            }
            else
            {
                KonwValue = (double.Parse(cmbZ.SelectedValue.ToString()) * double.Parse(txtIlosc.Text)) / double.Parse(cmbNa.SelectedValue.ToString());

                wynik.Content = KonwValue.ToString() + " " + cmbNa.Text;
                dtHistoria.Rows.Add(txtIlosc.Text, cmbZ.Text, cmbNa.Text, wynik.Content, DateTime.Now);
            }
        }

        private void Wyczysc_Click(object sender, RoutedEventArgs e)
        {
            txtIlosc.Text = String.Empty;
            if (cmbZ.Items.Count > 0)
                cmbZ.SelectedIndex = 0;
            if (cmbNa.Items.Count > 0)
                cmbNa.SelectedIndex = 0;

            wynik.Content = "";
            txtIlosc.Focus();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
