using Microsoft.IdentityModel.Tokens;
using NDATTibbiCihaz.Common;
using NDATTibbiCihaz.Entity;
using NDATTibbiCihaz.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for PCiktiDetaylari.xaml
    /// </summary>
    /// 

    public partial class PCiktiDetaylari : Page

    {
        private readonly SRapor sRapor = new SRapor();
        Cikti Cikti = new Cikti();
        Rapor Rapor = new Rapor();
        Gorsel Gorsel = new Gorsel();

        private int index = 0;

        public PCiktiDetaylari()
        {
            InitializeComponent();
        }

        public PCiktiDetaylari(Cikti cikti)
        {
            InitializeComponent();
            this.Cikti = cikti;
            try
            {
                this.Rapor = sRapor.OkuRaporIdIle(new Rapor { Id = cikti.RaporId });
            }
            catch(Exception ex)
            {
                MessageBox.Show(caption: "Çıktı Hatası", messageBoxText: ex.Message);
            }
           
            
            
            
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            CTckno1.Content = Cikti.HastaTCKimlikNo;
            CAdSoyad1.Content = Havuz.Hasta.AdSoyad;
            CTarih1.Content = Cikti.CiktiTarihi;
            CDerece1.Content = Cikti.DonulenDerece;
            RId.Content = Rapor.Id!=0?Rapor.Id:null;
            RYorum.Content = !string.IsNullOrWhiteSpace(Rapor.Yorum)?Rapor.Yorum:"Rapor Bulunamadı";

            if (gorselButtonVisibility(!Cikti.Gorseller.IsNullOrEmpty()))
            {
                PImage.Source = new BitmapImage(new Uri(Cikti.Gorseller[index].PathGorsel, UriKind.Relative));
                Sayac.Content = (index + 1) + "/" + (Cikti.Gorseller.Count);
            }
            else
            {
                MessageBox.Show(caption: "Görsel Hatası", messageBoxText: "Çıktıya ait görsel bulunamadı.");
            }

        }

        private bool gorselButtonVisibility(bool flag)
        {
            if (flag)
            {
                SagaGorsel.Visibility = Visibility.Visible;
                SolaGorsel.Visibility = Visibility.Visible;
                Sayac.Visibility = Visibility.Visible;
            }
            else
            {
                SagaGorsel.Visibility = Visibility.Hidden;
                SolaGorsel.Visibility = Visibility.Hidden;
                Sayac.Visibility = Visibility.Hidden;
            }

            return flag;
        }

        private void gorselDegis(bool side)
        {
            if (side)
            {
                index = (index + 1).Equals(Cikti.Gorseller.Count) ? 0 : index + 1;
            }
            else
            {
                index = (index - 1).Equals(-1) ? Cikti.Gorseller.Count - 1 : index - 1;
            }

            PImage.Source = new BitmapImage(new Uri(Cikti.Gorseller[index].PathGorsel, UriKind.Relative));
            Sayac.Content = (index + 1) + "/" + (Cikti.Gorseller.Count);
        }

        

        private void SagaGorsel_Click(object sender, RoutedEventArgs e)
        {
            gorselDegis(true);
        }

        private void SolaGorsel_Click(object sender, RoutedEventArgs e)
        {
            gorselDegis(false);
            
        }
    }
}
