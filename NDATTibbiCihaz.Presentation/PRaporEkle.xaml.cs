using NDATTibbiCihaz.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NDATTibbiCihaz.Presentation
{
    /// <summary>
    /// Interaction logic for PRaporEkle.xaml
    /// </summary>
    public partial class PRaporEkle : Window
    {
        public bool Success { get; set; }
        public Rapor Rapor { get; set; }

        Cikti Cikti = new Cikti();
        string Yorum = null;

        public PRaporEkle(Cikti cikti)
        {
            InitializeComponent();
            this.Cikti = cikti;
        }

        private void btnRaporOlustur_Click(object sender, RoutedEventArgs e)
        {
            Rapor = new Rapor { Yorum = new TextRange(txtBoxYorum.Document.ContentStart, txtBoxYorum.Document.ContentEnd).Text, CiktiId = Cikti.Id, DoktorId = Havuz.Doktor.Id, RaporTarihi = DateTime.Now};
            Success = true;
            Close();
        }
    }
}
