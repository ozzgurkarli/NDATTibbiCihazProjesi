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
    /// Interaction logic for PMakineMenu.xaml
    /// </summary>
    public partial class PMakineMenu : Page
    {
        private readonly SMakine sMakine = new SMakine();
        Makine Makine = new Makine();

        public PMakineMenu()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxMakine.Items.Clear();
            ComboBoxMakine.ItemsSource = sMakine.GetirMakineIdleri();
        }

        private void ButtonBaglan_Click(object sender, RoutedEventArgs e)
        {
            if(ComboBoxMakine.SelectedItem != null)
            {
                try
                {
                    Makine.Id = Convert.ToInt32(ComboBoxMakine.SelectedItem);
                    Makine = sMakine.OkuMakine(Makine);
                    visibilityKapakDurumu(true);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(caption: "Makineye Bağlanamadı.", messageBoxText: ex.Message);
                }
            }
            else
            {
                MessageBox.Show(caption: "Makineye Bağlanamadı.", messageBoxText: "Makine seçilmedi.");
            }
        }

        private void ButtonKapakTesti_Click(object sender, RoutedEventArgs e)
        {
            if (Makine.KapakDurumu)
            {
                LabelKapakDurumu.Content = "Başarılı";
            }
            else
            {
                LabelKapakDurumu.Content = "Başarısız";
            }
        }

        private void visibilityKapakDurumu(bool visible)
        {
            if (visible)
            {
                LabelKapakDurumu.Visibility = Visibility.Visible;
                LabelKapakDurumuText.Visibility = Visibility.Visible;
                ButtonKapakTesti.Visibility = Visibility.Visible;

                LabelKullanilabilirMakinelerText.Visibility = Visibility.Hidden;
                ComboBoxMakine.Visibility = Visibility.Hidden;
                ButtonBaglan.Visibility = Visibility.Hidden;
                ButtonBaglantiyiKes.Visibility = Visibility.Visible;
            }
        }

        private void ButtonBaglantiyiKes_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SayfaGecis(new PMakineMenu());
        }
    }
}
