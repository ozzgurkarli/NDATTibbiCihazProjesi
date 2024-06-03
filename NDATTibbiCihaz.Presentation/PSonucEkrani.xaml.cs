using NDATTibbiCihaz.Common;
using NDATTibbiCihaz.Service;
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
        private readonly SHasta sHasta = new SHasta();
        private readonly SCikti sCikti = new SCikti();

        private List<Hasta> HastaList = new List<Hasta>();

        public PSonucEkrani()
        {
            InitializeComponent();
        }

        private void ButtonHastaBilgileri_Click(object sender, RoutedEventArgs e)
        {
            sayfaGecis(new PHastaBilgileri());
        }

        private void ButtonCiktilar_Click(object sender, RoutedEventArgs e)
        {
            sayfaGecis(new PCiktilar());
        }

        private void sayfaGecis(object sayfa)
        {
            Sonuc.Content = sayfa;
        }

        private void ButtonArama_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Hasta> hastaList = sHasta.AramaHasta(new Hasta { AdSoyad = TextBoxArama.Text });
                HastaList = hastaList;

                hastaList.ForEach(x => x.AdSoyad = x.AdSoyad + "\n" + x.TCKimlikNo);

                ListViewHastalar.ItemsSource = hastaList.Select(x=> x.AdSoyad);

                hastaList.ForEach(x => x.AdSoyad = x.AdSoyad.Substring(0, x.AdSoyad.Length - 12));
            }
            catch(Exception ex)
            {
                MessageBox.Show(caption: "Arama Hata", messageBoxText: ex.Message);
            }
        }

        private void ListViewHastalar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListViewHastalar.SelectedIndex != -1)
            {
                Havuz.Hasta = HastaList[ListViewHastalar.SelectedIndex];
                Havuz.Ciktilar = sCikti.GetirCiktilarTCKIle(new Cikti { HastaTCKimlikNo = Havuz.Hasta.TCKimlikNo });
                gorunurlukButonlar(true);
                sayfaGecis(new PHastaBilgileri());
            }
        }

        private void gorunurlukButonlar(bool flag)
        {
            if (flag)
            {
                ButtonHastaBilgileri.Visibility = Visibility.Visible;
                ButtonCiktilar.Visibility = Visibility.Visible;
            }
            else
            {
                ButtonHastaBilgileri.Visibility = Visibility.Hidden;
                ButtonCiktilar.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SayfaGecis(new PAnaMenu());
        }
    }
}
