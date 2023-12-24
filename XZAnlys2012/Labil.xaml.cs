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
    /// <summary>
    /// Labil.xaml etkileşim mantığı
    /// </summary>
    public partial class Labil : Page
    {
        public Labil()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = 400;
            Application.Current.MainWindow.Height = 170;
            Application.Current.MainWindow.MaxHeight = SystemParameters.WorkArea.Height;

            Application.Current.MainWindow.Left = (SystemParameters.WorkArea.Width - Application.Current.MainWindow.Width) / 2;
            Application.Current.MainWindow.Top = (SystemParameters.WorkArea.Height - Application.Current.MainWindow.Height) / 2;
        }

        private void Bastan_Click(object sender, RoutedEventArgs e)
        {
            Sayfa1 sayfa1 = new Sayfa1();
            NavigationService.Navigate(sayfa1);
        }

        private void Kapat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
