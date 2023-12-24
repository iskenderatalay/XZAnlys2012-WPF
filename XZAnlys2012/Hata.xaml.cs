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

namespace XZAnlys2012
{
    /// <summary>
    /// Hata.xaml etkileşim mantığı
    /// </summary>
    public partial class Hata : Window
    {
        public Hata()
        {
            InitializeComponent();
        }

        private void xztasi(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void PKapatHata_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    
        private void Tamam_Click(object sender, RoutedEventArgs e)
        {
            Window sahip = Window.GetWindow(this.Owner);
            sahip.Opacity = 1;
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Window sahip = Window.GetWindow(this.Owner);
                sahip.Opacity = 1;
                this.Close();
            }
        }
    }
}
