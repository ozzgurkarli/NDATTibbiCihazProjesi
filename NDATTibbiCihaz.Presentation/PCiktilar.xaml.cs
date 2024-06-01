using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for PCiktilar.xaml
    /// </summary>
    public partial class PCiktilar : Page
    {
        private readonly SCikti sCikti = new SCikti();

        private List<Cikti> CiktiList = new List<Cikti>();

        public PCiktilar()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Havuz.Ciktilar.IsNullOrEmpty())
            {
                ListViewCiktilar.ItemsSource = CiktiList;
            }
            else
            {
                MessageBox.Show(caption: "Çıktı Hatası", messageBoxText: "Hastaya ait çıktı bulunamadı.");
            }
        }
    }
}
