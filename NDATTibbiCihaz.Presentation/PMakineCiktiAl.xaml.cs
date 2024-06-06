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

        bool flag = false;
        bool calisiyor = false;

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
            MainWindow.SayfaGecis(new PAnaMenu());
        }

        private void ButtonPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog3D = new OpenFileDialog();

            //fileDialog3D.Filter =

            if (fileDialog3D.ShowDialog() == true)
            {
                Path3D = fileDialog3D.FileName;
                Name3D = fileDialog3D.SafeFileName;

                ButtonPath.IsEnabled = false;
            }

        }

        private async void ButtonCalistir_Click(object sender, RoutedEventArgs e)
        {
            if (!calisiyor)
            {
                flag = false;
                decimal taramaAcisi;
                int projSayisi;

                if (!string.IsNullOrEmpty(Path3D) && !string.IsNullOrEmpty(Name3D) && !FilePaths.IsNullOrEmpty() && !string.IsNullOrEmpty(Hasta.AdSoyad) && decimal.TryParse(TextBoxTaramaAcisi.Text, out taramaAcisi) && int.TryParse(TextBoxProj.Text, out projSayisi))
                {
                    if (projSayisi != FilePaths.Count)
                    {
                        MessageBox.Show(caption: "Çalıştırma Hata", messageBoxText: "Projeksiyon sayısı seçilen görsel sayısına eşit olmalı.");
                    }
                    else
                    {
                        calisiyor = true;
                        ButtonCalistir.Content = "Durdur";
                        for (int i = 1; i <= projSayisi; i++)
                        {
                            if (flag)
                            {
                                calisiyor = false;
                                ButtonCalistir.Content = "Çalıştır";
                                break;
                            }
                            lblCount.Content = $"{i}/{projSayisi}";
                            await Task.Delay(500);
                        }

                        calisiyor = false;
                        ButtonCalistir.Visibility = Visibility.Hidden;
                        lblCount.Content = "Tamamlandı";
                        sCikti.EkleCiktiGorsellerIle(new Cikti { CiktiTarihi = DateTime.Now, DonulenDerece = taramaAcisi, HastaTCKimlikNo = Convert.ToInt64(TextBoxTCKNo.Text), RaporId = 0, Gorseller = new List<Gorsel>() }, Path3D, Name3D, FilePaths, FileNames);
                    }
                }
                else
                {
                    MessageBox.Show(caption: "Çalıştırma Hata", messageBoxText: "Makineyi çalıştırmak için tüm alanlar doğru bir şekilde doldurulmalı.");
                }
            }
            else
            {
                flag = true;
            }
        }

        private void ButtonHastaAra_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                long tckNo = 0;

                if (long.TryParse(TextBoxTCKNo.Text, out tckNo))
                {
                    Hasta = sHasta.OkuHasta(new Hasta { TCKimlikNo = tckNo });

                    LabelTCKNo.Content = Hasta.AdSoyad;

                    TextBoxTCKNo.IsEnabled = false;
                    ButtonHastaAra.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show(caption: "Hasta Arama Hata", messageBoxText: "Hatalı format, sadece rakam giriniz.");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(caption: "Hasta Arama Hata", messageBoxText: ex.Message);
            }
        }

        private void ButtonGorsellerPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialogImage = new OpenFileDialog();

            fileDialogImage.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|" + "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            fileDialogImage.Multiselect = true;

            if (fileDialogImage.ShowDialog() == true)
            {
                FilePaths.AddRange(fileDialogImage.FileNames);
                FileNames.AddRange(fileDialogImage.SafeFileNames);

                ButtonGorsellerPath.IsEnabled = false;
            }
        }
    }
}
