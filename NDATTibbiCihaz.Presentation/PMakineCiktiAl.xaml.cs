using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using NDATTibbiCihaz.Common;
using NDATTibbiCihaz.Service;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for PMakineCiktiAl.xaml
    /// </summary>
    public partial class PMakineCiktiAl : Page
    {
        private readonly SCikti sCikti = new SCikti();
        private readonly SHasta sHasta = new SHasta();

        public PMakineCiktiAl()
        {
            InitializeComponent();
        }

        Hasta Hasta = new Hasta();

        List<string> FilePaths = new List<string>();
        List<string> FileNames = new List<string>();

        string Path3D = null;
        string Name3D = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialogImage = new OpenFileDialog();

            fileDialogImage.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|" + "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            fileDialogImage.Multiselect = true;

            if (fileDialogImage.ShowDialog() == true)
            {
                FilePaths.AddRange(fileDialogImage.FileNames);
                FileNames.AddRange(fileDialogImage.SafeFileNames);
            }
            
        }

        private void ButtonPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog3D = new OpenFileDialog();

            //fileDialog3D.Filter =

            if (fileDialog3D.ShowDialog() == true)
            {
                Path3D = fileDialog3D.FileName;
                Name3D = fileDialog3D.SafeFileName;
            }

        }

        private void ButtonCalistir_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Path3D) && !string.IsNullOrEmpty(Name3D) && !FilePaths.IsNullOrEmpty())
            {
                sCikti.EkleCiktiGorsellerIle(new Cikti { CiktiTarihi = DateTime.Now, DonulenDerece = 0, HastaTCKimlikNo = 18217841219, RaporId = 0, Gorseller = new List<Gorsel>() }, Path3D, Name3D, FilePaths, FileNames);

            }
        }

        private void ButtonHastaAra_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Hasta = sHasta.OkuHasta(new Hasta { TCKimlikNo = Convert.ToInt64(TextBoxTCKNo.Text) });

                LabelTCKNo.Content = Hasta.AdSoyad;

                ButtonHastaAra.IsEnabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(caption: "Hasta Arama Hata", messageBoxText: ex.Message);
            }
        }
    }
}
