using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            this.MaxHeight = System.Windows.SystemParameters.WorkArea.Height;
            this.MaxWidth = System.Windows.SystemParameters.WorkArea.Width;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            SizeToContent = SizeToContent.Manual;
            Loaded -= OnLoaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Sayfa1());
        }

        private void xztasi(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        
        private void Fb_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/xzinsaat");
        }

        private void Tw_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.twitter.com/xzinsaat");
        }

        private void In_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/xzinsaat");
        }

        private void Map_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.com/maps/place/XZ+%C4%B0n%C5%9Faat/@40.838902,31.1602073,17z/data=!3m1!4b1!4m5!3m4!1s0x409d75915e44f32d:0xc90b074e18413089!8m2!3d40.838898!4d31.162396");
        }

        private void PKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PAlt_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

    }
}
