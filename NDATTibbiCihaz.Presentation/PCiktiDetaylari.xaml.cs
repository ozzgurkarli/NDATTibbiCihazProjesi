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
    /// Interaction logic for PCiktiDetaylari.xaml
    /// </summary>
    public partial class PCiktiDetaylari : Page
    {
        private readonly SRapor sRapor = new SRapor();
        Cikti Cikti = new Cikti();
        Rapor Rapor = new Rapor();

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
    }
}
