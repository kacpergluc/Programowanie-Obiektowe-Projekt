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
        public MainWindow()
        {
            InitializeComponent();
            BindJednostkiMiary();
            BindJednostkiPredkosci();
            BindHistoria();
            BindPole();
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
                MessageBox.Show("Wprowadż wartość!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                txtIlosc.Focus();
                return;
            }
            else if (cmbZ.SelectedValue == null || cmbZ.SelectedIndex == 0)
            {
                MessageBox.Show("Wybierz jednostkę Z!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                cmbZ.Focus();
                return;
            }
            else if (cmbNa.SelectedValue == null || cmbNa.SelectedIndex == 0)
            {
                MessageBox.Show("Wybierz jednostkę Na!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                cmbNa.Focus();
                return;
            }

            if (cmbZ.Text == cmbNa.Text)
            {
                MessageBox.Show("Wybrano tą samą jednostkę!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
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
