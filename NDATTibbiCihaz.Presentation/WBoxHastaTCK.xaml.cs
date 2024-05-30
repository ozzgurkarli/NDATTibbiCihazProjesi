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
using System.Windows.Shapes;

namespace NDATTibbiCihaz.Presentation
{

    /// <summary>
    /// Interaction logic for WBoxHastaTCK.xaml
    /// </summary>
    public partial class WBoxHastaTCK : Window
    {
        public long HastaTCK { get; set; }

        public WBoxHastaTCK()
        {
            InitializeComponent();
        }

        private void ButtonTamam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HastaTCK = Convert.ToInt64(TextBoxTCK.Text);

                if(TextBoxTCK.Text.Length != 11)
                {
                    throw new Exception();
                }

                DialogResult = true;
            }
            catch(Exception)
            {
                MessageBox.Show(caption: "Girdi Alınamadı.", messageBoxText: "Hatalı formatta TCK girildi.");
            }
        }
    }
}
