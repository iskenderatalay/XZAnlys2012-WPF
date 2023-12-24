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

namespace XZAnlys2012
{
    public partial class Sayfa1 : Page
    {
        public Sayfa1()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = 474;
            Application.Current.MainWindow.Height = 390;
            Application.Current.MainWindow.MaxHeight = SystemParameters.WorkArea.Height;

            Application.Current.MainWindow.Left = (SystemParameters.WorkArea.Width - Application.Current.MainWindow.Width) / 2;
            Application.Current.MainWindow.Top = (SystemParameters.WorkArea.Height - Application.Current.MainWindow.Height) / 2;

            kuvvetbrm.Focus();
        }

        public void Ilerle()
        {
            if ((kuvvetbrm.Text != "") && (uzunlukbrm.Text != "") && (cbkno.Text != "") && (dgmno.Text != "") && (sd.Text != ""))
            {
                Sayfa2 sayfa2 = new Sayfa2();
                sayfa2.KuvvetBirimi = kuvvetbrm.Text;
                sayfa2.UzunlukBirimi = uzunlukbrm.Text;
                sayfa2.CubukSayisi = cbkno.Text;
                sayfa2.DugumSayisi = dgmno.Text;
                sayfa2.SerbestlikDerecesi = sd.Text;

                NavigationService.Navigate(sayfa2);
            }
            else
            {
                Window hata = new Hata();
                hata.Owner = Window.GetWindow(this);
                hata.Owner.Opacity = 0.35;
                hata.ShowDialog();
            }
        }

        private void Ileri_Click(object sender, RoutedEventArgs e)
        {
            Ilerle();
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Ilerle();
        }
       
        private void Temizle_Click(object sender, RoutedEventArgs e)
        {
            kuvvetbrm.Text = "";
            uzunlukbrm.Text = "";
            cbkno.Text = "";
            dgmno.Text = "";
            sd.Text = "";
        }

        private void Kapat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void Only_Number(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }
        
    }
}
