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
    /// Interaction logic for PSonucEkraniAnaMenu.xaml
    /// </summary>
    public partial class PSonucEkraniAnaMenu : Page
    {
        public long HastaTCK { get; set; }

        public PSonucEkraniAnaMenu()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            hastaTCKNoAl();
        }

        private void hastaTCKNoAl()
        {
            WBoxHastaTCK box = new WBoxHastaTCK();

            if (box.ShowDialog() == true)
            {
                HastaTCK = box.HastaTCK;
            }
            else
            {
                MainWindow.SayfaGecis(new PAnaMenu());
            }
        }
    }
}
