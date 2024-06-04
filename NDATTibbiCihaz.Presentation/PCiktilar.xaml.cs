using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for PCiktilar.xaml
    /// </summary>
    public partial class PCiktilar : Page
    {
        private readonly SCikti sCikti = new SCikti();

        public PCiktilar()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Havuz.Ciktilar.IsNullOrEmpty())
            {
                List<string> ciktiList = new List<string>();

                foreach(Cikti item in Havuz.Ciktilar)
                {
                    string temp = $"\n{item.CiktiTarihi.Day} {NDATTibbiCihaz.Common.Method.OrtakMetodlar.AyBul(item.CiktiTarihi.Month)} {item.CiktiTarihi.Year} Tarihli Çıktı\n";

                    if(item.RaporId == 0)
                    {
                        temp += "RAPOR YOK";
                    }
                    ciktiList.Add(temp);
                }

                ListViewCiktilar.ItemsSource = ciktiList;
            }
            else
            {
                MessageBox.Show(caption: "Çıktı Hatası", messageBoxText: "Hastaya ait çıktı bulunamadı.");
            }
        }

        private void ListViewCiktilar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListViewCiktilar.SelectedIndex != -1)
            {
                CiktiFrame.Content = new PCiktiDetaylari(Havuz.Ciktilar[ListViewCiktilar.SelectedIndex]);
            }
        }
    }
}
