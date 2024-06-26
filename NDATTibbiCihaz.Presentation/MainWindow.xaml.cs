﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            SayfaGecis(new PGiris());  // bittiginde burayı acmayı unutma
            //SayfaGecis(new PAnaMenu());
        }

        public static void SayfaGecis(object sayfa)
        {
            var mainWindow = Application.Current.MainWindow;
            mainWindow.Content = sayfa;
        }
    }
}
