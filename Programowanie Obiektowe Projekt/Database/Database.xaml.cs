using System;
using System.Collections.Generic;
using System.Data;
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
            dtJednostkiPredkosci.Rows.Add("km/h", 1);
            dtJednostkiPredkosci.Rows.Add("mph", 1.61);
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
    }
}

