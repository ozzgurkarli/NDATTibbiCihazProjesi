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

namespace NDATTibbiCihaz.Presentation
{
    /// <summary>
    /// Interaction logic for PAnaMenu.xaml
    /// </summary>
    public partial class PAnaMenu : Page
    {
        public PAnaMenu()
        {
            InitializeComponent();
        }

        private void ButtonMakineyeBaglan_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SayfaGecis(new PMakineMenu());
        }

        private void ButtonSonucEkraninaBaglan_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SayfaGecis(new PSonucEkrani());
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxHosgeldiniz.Content = $"Hoşgeldiniz, {Havuz.Doktor.AdSoyad}.";
        }
    }
}
