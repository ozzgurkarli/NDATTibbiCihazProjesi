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
        public PMakineCiktiAl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog3D = new OpenFileDialog();
            OpenFileDialog fileDialogImage = new OpenFileDialog();

            //fileDialog3D.Filter =

            fileDialogImage.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|" + "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            fileDialogImage.Multiselect = true;

            string path3D = null;
            string name3D = null;
            if(fileDialog3D.ShowDialog() == true)
            {
                path3D = fileDialog3D.FileName;
                name3D = fileDialog3D.SafeFileName;
            }

            List<string> filePaths = new List<string>();
            List<string> fileNames = new List<string>();
            if (fileDialogImage.ShowDialog() == true)
            {
                filePaths.AddRange(fileDialogImage.FileNames);
                fileNames.AddRange(fileDialogImage.SafeFileNames);
            }

            if(!string.IsNullOrEmpty(path3D) && !string.IsNullOrEmpty(name3D) && !filePaths.IsNullOrEmpty())
            {
                sCikti.EkleCiktiGorsellerIle(new Cikti { CiktiTarihi = DateTime.Now, DonulenDerece = 0, HastaTCKimlikNo = 18217841219, RaporId = 0, Gorseller = new List<Gorsel>() }, path3D, name3D, filePaths, fileNames);

            }
            
        }
    }
}
