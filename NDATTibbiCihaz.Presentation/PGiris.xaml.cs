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
using NDATTibbiCihaz.Common;
using System.Text.RegularExpressions;

namespace NDATTibbiCihaz.Presentation
{
    /// <summary>
    /// Interaction logic for PGiris.xaml
    /// </summary>
    public partial class PGiris : Page
    {
        Doktor Doktor = new Doktor();
        SDoktor sDoktor = new SDoktor();

        public PGiris()
        {
            InitializeComponent();
            TextBoxID.Text = string.Empty;
        }

        private void ButtonGirisYap_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxID.Text))
            {
                Doktor.Id = Convert.ToInt32(TextBoxID.Text);
            }
            Doktor.Parola = TextBoxParola.Password;
            try
            {
                sDoktor.OkuDoktor(Doktor);

                MainWindow.SayfaGecis(new PAnaMenu());
            }
            catch(Exception ex)
            {
                MessageBox.Show(caption: "Giriş Yapılamadı", messageBoxText: ex.Message);
            }
        }

        private void TextBoxID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }

        private bool IsTextAllowed(string text)
        {
            if(TextBoxID.Text.Length > 8)
            {
                return true;
            }

            return Regex.IsMatch(text, "[^0-9]+");
        }
    }
}
