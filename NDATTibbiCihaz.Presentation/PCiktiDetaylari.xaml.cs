using NDATTibbiCihaz.Common;
using NDATTibbiCihaz.Entity;
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
    /// Interaction logic for PCiktiDetaylari.xaml
    /// </summary>
    public partial class PCiktiDetaylari : Page
    {
        private readonly SRapor sRapor = new SRapor();
        Cikti Cikti = new Cikti();
        Rapor Rapor = new Rapor();
        Gorsel Gorsel = new Gorsel();
        

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
            string url = Cikti.Gorseller[0].PathGorsel;
            
            PImage.Source = new BitmapImage(new Uri(url));
        }
    }
}
