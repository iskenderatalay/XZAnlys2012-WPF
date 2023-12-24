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
    public partial class Yazdir3 : Window
    {
        public Yazdir3()
        {
            InitializeComponent();
            this.MaxHeight = System.Windows.SystemParameters.WorkArea.Height;
            this.MaxWidth = System.Windows.SystemParameters.WorkArea.Width;
        }
        public string yaz3kbrm { get; set; }
        public string yaz3ubrm { get; set; }
        public int yaz3cbksay { get; set; }
        public double[] yaz3cbkkuvni { get; set; }
        public double[] yaz3cbkkuvsi { get; set; }
        public double[] yaz3cbkkuvmi { get; set; }
        public double[] yaz3cbkkuvnk { get; set; }
        public double[] yaz3cbkkuvsk { get; set; }
        public double[] yaz3cbkkuvmk { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FixedDocument document = CreateFixedDocument();
            yazdir3.Document = document;
        }

        int hrcbk = 15;
        int syf;

        private FixedDocument CreateFixedDocument()
        {
            FixedDocument fixedDocument = new FixedDocument();
            fixedDocument.DocumentPaginator.PageSize = new Size(96 * 8, 96 * 11.5);

            if (yaz3cbksay > hrcbk)
            {
                if (yaz3cbksay % hrcbk != 0)
                {
                    syf = yaz3cbksay / hrcbk + 1;
                }
                else
                    syf = yaz3cbksay / hrcbk;
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
            rpcbkbaslik.Text = "Çubuk Kuvvetleri";
            rpcbkbaslik.Style = (Style)FindResource("textblocklar");
            rpcbkbaslik.Width = 200;
            FixedPage.SetLeft(rpcbkbaslik, 30);
            FixedPage.SetTop(rpcbkbaslik, 137);
            page.Children.Add((UIElement)rpcbkbaslik);

            TextBlock cbkkuvnisc = new TextBlock();
            cbkkuvnisc.Text = "Ni(" + yaz3kbrm + ")";
            cbkkuvnisc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(cbkkuvnisc, 150);
            FixedPage.SetTop(cbkkuvnisc, 182);
            page.Children.Add((UIElement)cbkkuvnisc);

            TextBlock cbkkuvsisc = new TextBlock();
            cbkkuvsisc.Text = "Si(" + yaz3kbrm + ")";
            cbkkuvsisc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(cbkkuvsisc, 275);
            FixedPage.SetTop(cbkkuvsisc, 182);
            page.Children.Add((UIElement)cbkkuvsisc);

            TextBlock cbkkuvmisc = new TextBlock();
            cbkkuvmisc.Text = "Mi(" + yaz3kbrm + yaz3ubrm + ")";
            cbkkuvmisc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(cbkkuvmisc, 400);
            FixedPage.SetTop(cbkkuvmisc, 182);
            page.Children.Add((UIElement)cbkkuvmisc);

            TextBlock cbkkuvnksc = new TextBlock();
            cbkkuvnksc.Text = "Nk(" + yaz3kbrm + ")";
            cbkkuvnksc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(cbkkuvnksc, 525);
            FixedPage.SetTop(cbkkuvnksc, 182);
            page.Children.Add((UIElement)cbkkuvnksc);

            TextBlock cbkkuvsksc = new TextBlock();
            cbkkuvsksc.Text = "Sk(" + yaz3kbrm + ")";
            cbkkuvsksc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(cbkkuvsksc, 650);
            FixedPage.SetTop(cbkkuvsksc, 182);
            page.Children.Add((UIElement)cbkkuvsksc);

            TextBlock cbkkuvmksc = new TextBlock();
            cbkkuvmksc.Text = "Mk(" + yaz3kbrm + yaz3ubrm + ")";
            cbkkuvmksc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(cbkkuvmksc, 775);
            FixedPage.SetTop(cbkkuvmksc, 182);
            page.Children.Add((UIElement)cbkkuvmksc);

            Grid rpcbknolar = new Grid();
            rpcbknolar.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(rpcbknolar, 30);
            FixedPage.SetTop(rpcbknolar, 227);
            page.Children.Add((UIElement)rpcbknolar);

            Grid cbkkuvniler = new Grid();
            cbkkuvniler.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(cbkkuvniler, 150);
            FixedPage.SetTop(cbkkuvniler, 227);
            page.Children.Add((UIElement)cbkkuvniler);

            Grid cbkkuvsiler = new Grid();
            cbkkuvsiler.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(cbkkuvsiler, 275);
            FixedPage.SetTop(cbkkuvsiler, 227);
            page.Children.Add((UIElement)cbkkuvsiler);

            Grid cbkkuvmiler = new Grid();
            cbkkuvmiler.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(cbkkuvmiler, 400);
            FixedPage.SetTop(cbkkuvmiler, 227);
            page.Children.Add((UIElement)cbkkuvmiler);

            Grid cbkkuvnklar = new Grid();
            cbkkuvnklar.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(cbkkuvnklar, 525);
            FixedPage.SetTop(cbkkuvnklar, 227);
            page.Children.Add((UIElement)cbkkuvnklar);

            Grid cbkkuvsklar = new Grid();
            cbkkuvsklar.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(cbkkuvsklar, 650);
            FixedPage.SetTop(cbkkuvsklar, 227);
            page.Children.Add((UIElement)cbkkuvsklar);

            Grid cbkkuvmklar = new Grid();
            cbkkuvmklar.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(cbkkuvmklar, 775);
            FixedPage.SetTop(cbkkuvmklar, 227);
            page.Children.Add((UIElement)cbkkuvmklar);


            TextBlock[] rpcbkno, rpcbkkuvni, rpcbkkuvsi, rpcbkkuvmi, rpcbkkuvnk, rpcbkkuvsk, rpcbkkuvmk;

            rpcbkno = new TextBlock[yaz3cbksay];
            rpcbkkuvni = new TextBlock[yaz3cbksay];
            rpcbkkuvsi = new TextBlock[yaz3cbksay];
            rpcbkkuvmi = new TextBlock[yaz3cbksay];
            rpcbkkuvnk = new TextBlock[yaz3cbksay];
            rpcbkkuvsk = new TextBlock[yaz3cbksay];
            rpcbkkuvmk = new TextBlock[yaz3cbksay];

            for (int k = 0; k < hrcbk; k++)
            {
                if ((i == (syf - 1)) && yaz3cbksay % hrcbk != 0)
                {
                    hrcbk = yaz3cbksay - (13 * (syf - 1));
                }

                double konumust = k * 40;

                rpcbkno[k] = new TextBlock
                {
                    Name = "rpcbkno" + k.ToString(),
                    Text = (say + 1).ToString() + " . Çubuk",
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar")
                };
                rpcbknolar.Children.Add(rpcbkno[k]);

                rpcbkkuvni[k] = new TextBlock
                {
                    Name = "rpcbkkuvni" + i.ToString(),
                    Text = Convert.ToString(Round(yaz3cbkkuvni[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                cbkkuvniler.Children.Add(rpcbkkuvni[k]);

                rpcbkkuvsi[k] = new TextBlock
                {
                    Name = "rpcbkkuvsi" + i.ToString(),
                    Text = Convert.ToString(Round(yaz3cbkkuvsi[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                cbkkuvsiler.Children.Add(rpcbkkuvsi[k]);

                rpcbkkuvmi[k] = new TextBlock
                {
                    Name = "rpcbkkuvmi" + i.ToString(),
                    Text = Convert.ToString(Round(yaz3cbkkuvmi[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                cbkkuvmiler.Children.Add(rpcbkkuvmi[k]);

                rpcbkkuvnk[k] = new TextBlock
                {
                    Name = "rpcbkkuvnk" + i.ToString(),
                    Text = Convert.ToString(Round(yaz3cbkkuvnk[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                cbkkuvnklar.Children.Add(rpcbkkuvnk[k]);

                rpcbkkuvsk[k] = new TextBlock
                {
                    Name = "rpcbkkuvsk" + i.ToString(),
                    Text = Convert.ToString(Round(yaz3cbkkuvsk[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                cbkkuvsklar.Children.Add(rpcbkkuvsk[k]);

                rpcbkkuvmk[k] = new TextBlock
                {
                    Name = "rpcbkkuvmk" + i.ToString(),
                    Text = Convert.ToString(Round(yaz3cbkkuvmk[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                cbkkuvmklar.Children.Add(rpcbkkuvmk[k]);

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
