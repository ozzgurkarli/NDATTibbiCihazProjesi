using Microsoft.IdentityModel.Tokens;
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
    /// PHastaBilgileri.xaml etkileşim mantığı
    /// </summary>
    public partial class PHastaBilgileri : Page
    {
        public PHastaBilgileri()
        {
            InitializeComponent();
            Hasta_TCKNO.Content = Havuz.Hasta.TCKimlikNo;
            Hasta_Ad.Content = Havuz.Hasta.AdSoyad;
            hasta_DogumTarihi.Content = Havuz.Hasta.DogumTarihi;
            Hasta_SonZiyaret.Content = (Havuz.Ciktilar != null && Havuz.Ciktilar.Any()) ? Havuz.Ciktilar[0].CiktiTarihi : "Son ziyaret yok.";
            Hasta_CiktiSayisi.Content = (Havuz.Ciktilar != null && Havuz.Ciktilar.Any()) ? Havuz.Ciktilar.Count : "Çıktı yok.";
        }
        
    }
}
