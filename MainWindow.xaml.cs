using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Net_ININ3_PR1_z1
{

    public partial class MainWindow : Window
    {
        Model model = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = model;
        }

        private void Cyfra(object sender, RoutedEventArgs e)
        {
            model.DopiszCyfrę(
                (string)((Button)sender).Content
                );
        }

        private void ZmianaZnaku(object sender, RoutedEventArgs e)
        {
            model.ZmieńZnak();
        }

        private void Przecinek(object sender, RoutedEventArgs e)
        {
            model.Przecinek();
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            model.UsuńZnak();
        }

        private void Zerowanie(object sender, RoutedEventArgs e)
        {
            model.Zeruj();
        }

        private void Resetowanie(object sender, RoutedEventArgs e)
        {
            model.Resetuj();
        }

        private void DzielenieModulo(object sender, RoutedEventArgs e)
        {
            model.DzielModulo();
        }

        private void Dodawanie(object sender, RoutedEventArgs e)
        {
            model.Dodaj();
        }

        private void Odejmowanie(object sender, RoutedEventArgs e)
        {
            model.Odejmij();
        }

        private void Mnozenie(object sender, RoutedEventArgs e)
        {
            model.Pomnoz();
        }

        private void Dzielenie(object sender, RoutedEventArgs e)
        {
            model.Podziel();
        }

        private void Potegowanie(object sender, RoutedEventArgs e)
        {
            model.Poteguj();
        }

        private void Pierwiastkowanie(object sender, RoutedEventArgs e)
        {
            model.Pierwiastkuj();
        }

        private void Odwrotnosci(object sender, RoutedEventArgs e)
        {
            model.WezOdwrotnosc();
        }

        private void ObliczanieWyniku(object sender, RoutedEventArgs e)
        {
            model.ObliczWynik();
        }
    }
}
