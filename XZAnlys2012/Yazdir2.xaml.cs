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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Math;

namespace XZAnlys2012
{
    public partial class Yazdir2 : Window
    {
        public Yazdir2()
        {
            InitializeComponent();
            this.MaxHeight = System.Windows.SystemParameters.WorkArea.Height;
            this.MaxWidth = System.Windows.SystemParameters.WorkArea.Width;
        }

        public string yaz2kbrm { get; set; }
        public string yaz2ubrm { get; set; }
        public int yaz2dgmsay { get; set; }
        public double[] yaz2depu { get; set; }
        public double[] yaz2depv { get; set; }
        public double[] yaz2depteta { get; set; }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FixedDocument document = CreateFixedDocument();
            yazdir2.Document = document;
        }

        int hrcbk = 15;
        int syf;

        private FixedDocument CreateFixedDocument()
        {
            FixedDocument fixedDocument = new FixedDocument();
            fixedDocument.DocumentPaginator.PageSize = new Size(96 * 8, 96 * 11.5);

            if (yaz2dgmsay > hrcbk)
            {
                if (yaz2dgmsay % hrcbk != 0)
                {
                    syf = yaz2dgmsay / hrcbk + 1;
                }
                else
                    syf = yaz2dgmsay / hrcbk;
            }
            else
                syf = 1;

            for (int i = 0; i < syf; i++)
            {
                PageContent page = new PageContent();
                FixedPage fixedPage = CreateOneFixedPage();
                ((IAddChild)page).AddChild(fixedPage);
                fixedDocument.Pages.Add(page);
            }
            return fixedDocument;
        }

        int i = 0;
        int say = 0;

        private FixedPage CreateOneFixedPage()
        {
            FixedPage page = new FixedPage();
            page.Height = 96 * 8;
            page.Width = 96 * 11.5;

            DockPanel rpbaslik = new DockPanel();

            Image rplogo = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/images/xz.png")),
                Height = 75,
                Width = 75
            };
            DockPanel.SetDock(rplogo, Dock.Left);
            rpbaslik.Children.Add(rplogo);

            TextBlock rplogoyazi = new TextBlock();
            rplogoyazi.Text = "XZAnlys2012";
            rplogoyazi.Style = (Style)FindResource("rplogoyazi");
            DockPanel.SetDock(rplogoyazi, Dock.Left);
            rpbaslik.Children.Add(rplogoyazi);

            FixedPage.SetLeft(rpbaslik, 30);
            FixedPage.SetTop(rpbaslik, 30);
            page.Children.Add((UIElement)rpbaslik);

            TextBlock rpsyfno = new TextBlock();
            rpsyfno.Text = "Sayfa : " + (i + 1).ToString() + "/" + syf.ToString();
            rpsyfno.Style = (Style)FindResource("rpsyfno");
            FixedPage.SetRight(rpsyfno, 30);
            FixedPage.SetTop(rpsyfno, 60);
            page.Children.Add((UIElement)rpsyfno);

            Rectangle rpcizgi = new Rectangle();
            rpcizgi.Style = (Style)FindResource("rpcizgi");
            FixedPage.SetLeft(rpcizgi, 30);
            FixedPage.SetRight(rpcizgi, 30);
            FixedPage.SetTop(rpcizgi, 120);
            page.Children.Add((UIElement)rpcizgi);

            TextBlock rpcbkbaslik = new TextBlock();
            rpcbkbaslik.Text = "Sistemin Deplasmanları";
            rpcbkbaslik.Style = (Style)FindResource("textblocklar");
            rpcbkbaslik.Width = 200;
            FixedPage.SetLeft(rpcbkbaslik, 30);
            FixedPage.SetTop(rpcbkbaslik, 137);
            page.Children.Add((UIElement)rpcbkbaslik);

            TextBlock rpdepusc = new TextBlock();
            rpdepusc.Text = "U(" + yaz2ubrm + ")";
            rpdepusc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(rpdepusc, 150);
            FixedPage.SetTop(rpdepusc, 182);
            page.Children.Add((UIElement)rpdepusc);

            TextBlock rpdepvsc = new TextBlock();
            rpdepvsc.Text = "V(" + yaz2ubrm + ")";
            rpdepvsc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(rpdepvsc, 275);
            FixedPage.SetTop(rpdepvsc, 182);
            page.Children.Add((UIElement)rpdepvsc);

            TextBlock rpdeptetasc = new TextBlock();
            rpdeptetasc.Text = "Teta(" + yaz2ubrm + ")";
            rpdeptetasc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(rpdeptetasc, 400);
            FixedPage.SetTop(rpdeptetasc, 182);
            page.Children.Add((UIElement)rpdeptetasc);

            Grid rpdgmnolar = new Grid();
            rpdgmnolar.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(rpdgmnolar, 30);
            FixedPage.SetTop(rpdgmnolar, 227);
            page.Children.Add((UIElement)rpdgmnolar);

            Grid rpdepular = new Grid();
            rpdepular.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(rpdepular, 150);
            FixedPage.SetTop(rpdepular, 227);
            page.Children.Add((UIElement)rpdepular);

            Grid rpdepvler = new Grid();
            rpdepvler.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(rpdepvler, 275);
            FixedPage.SetTop(rpdepvler, 227);
            page.Children.Add((UIElement)rpdepvler);

            Grid rpdeptetalar = new Grid();
            rpdeptetalar.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(rpdeptetalar, 400);
            FixedPage.SetTop(rpdeptetalar, 227);
            page.Children.Add((UIElement)rpdeptetalar);

            TextBlock[] rpdgmno, rpdepu, rpdepv, rpdepteta;

            rpdgmno = new TextBlock[yaz2dgmsay];
            rpdepu = new TextBlock[yaz2dgmsay];
            rpdepv = new TextBlock[yaz2dgmsay];
            rpdepteta = new TextBlock[yaz2dgmsay];
          
            for (int k = 0; k < hrcbk; k++)
            {
                if ((i == (syf - 1)) && yaz2dgmsay % hrcbk != 0)
                {
                    hrcbk = yaz2dgmsay - (13 * (syf - 1));
                }

                double konumust = k * 40;

                rpdgmno[k] = new TextBlock
                {
                    Name = "rpdgmno" + k.ToString(),
                    Text = (say + 1).ToString() + " . Düğüm",
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar")
                };
                rpdgmnolar.Children.Add(rpdgmno[k]);

                rpdepu[k] = new TextBlock
                {
                    Name = "delx" + i.ToString(),
                    Text = Convert.ToString(Round(yaz2depu[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                rpdepular.Children.Add(rpdepu[k]);

                rpdepv[k] = new TextBlock
                {
                    Name = "dely" + i.ToString(),
                    Text = Convert.ToString(Round(yaz2depv[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                rpdepvler.Children.Add(rpdepv[k]);

                rpdepteta[k] = new TextBlock
                {
                    Name = "delx" + i.ToString(),
                    Text = Convert.ToString(Round(yaz2depteta[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                rpdeptetalar.Children.Add(rpdepteta[k]);

                say++;
            }
            i++;
            Size sz = new Size(96 * 11.7, 96 * 8.3);
            page.Measure(sz);
            page.Arrange(new Rect(new Point(), sz));
            page.UpdateLayout();
            return page;
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

        private void PAlt_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void PUst_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
                this.WindowState = WindowState.Normal;
        }

        private void PKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
