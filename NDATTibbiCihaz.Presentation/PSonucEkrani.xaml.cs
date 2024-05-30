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
    /// PSonucEkrani.xaml etkileşim mantığı
    /// </summary>
    public partial class PSonucEkrani : Page
    {
        public PSonucEkrani()
        {
            InitializeComponent();
        }

        private void ButtonTCKIleArama_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonHastaBilgileri_Click(object sender, RoutedEventArgs e)
        {
            //sayfaGecis(new SAYFAADI());
        }

        private void ButtonRapor_Click(object sender, RoutedEventArgs e)
        {
            //sayfaGecis(new SAYFAADI());
        }

        private void sayfaGecis(object sayfa)
        {
            Sonuc.Content = sayfa;
        }
    }
}
