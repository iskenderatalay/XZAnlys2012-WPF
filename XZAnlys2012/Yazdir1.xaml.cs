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
    public partial class Yazdir1 : Window
    {
        public Yazdir1()
        {
            InitializeComponent();
            this.MaxHeight = System.Windows.SystemParameters.WorkArea.Height;
            this.MaxWidth = System.Windows.SystemParameters.WorkArea.Width;
        }

        public string yaz1kbrm { get; set; }
        public string yaz1ubrm { get; set; }
        public int yaz1cbksay { get; set; }
        public double[] yaz1delx { get; set; }
        public double[] yaz1dely { get; set; }
        public double[] yaz1L { get; set; }
        public double[] yaz1aci { get; set; }
        public double[] yaz1g { get; set; }
        public double[] yaz1n { get; set; }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FixedDocument document = CreateFixedDocument();
            yazdir1.Document = document;
        }

        int hrcbk = 15;
        int syf;

        private FixedDocument CreateFixedDocument()
        {
            FixedDocument fixedDocument = new FixedDocument();
            fixedDocument.DocumentPaginator.PageSize = new Size(96 * 8, 96 * 11.5);

            if (yaz1cbksay > hrcbk)
            {
                if (yaz1cbksay % hrcbk != 0)
                {
                    syf = yaz1cbksay / hrcbk + 1;
                }
                else
                    syf = yaz1cbksay / hrcbk;
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
            rpcbkbaslik.Text = "Çubuk Değerleri";
            rpcbkbaslik.Style = (Style)FindResource("textblocklar");
            rpcbkbaslik.Width = 200;
            FixedPage.SetLeft(rpcbkbaslik, 30);
            FixedPage.SetTop(rpcbkbaslik, 137);
            page.Children.Add((UIElement)rpcbkbaslik);

            TextBlock rpdelxsc = new TextBlock();
            rpdelxsc.Text = "DelX(" + yaz1ubrm + ")";
            rpdelxsc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(rpdelxsc, 150);
            FixedPage.SetTop(rpdelxsc, 182);
            page.Children.Add((UIElement)rpdelxsc);

            TextBlock rpdelysc = new TextBlock();
            rpdelysc.Text = "DelY(" + yaz1ubrm + ")";
            rpdelysc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(rpdelysc, 275);
            FixedPage.SetTop(rpdelysc, 182);
            page.Children.Add((UIElement)rpdelysc);

            TextBlock rpLsc = new TextBlock();
            rpLsc.Text = "L(" + yaz1ubrm + ")";
            rpLsc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(rpLsc, 400);
            FixedPage.SetTop(rpLsc, 182);
            page.Children.Add((UIElement)rpLsc);

            TextBlock rpacisc = new TextBlock();
            rpacisc.Inlines.Add("Açı");
            Run run = new Run("°");
            run.FontSize = 10;
            run.BaselineAlignment = BaselineAlignment.Superscript;
            rpacisc.Inlines.Add(run);
            rpacisc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(rpacisc, 525);
            FixedPage.SetTop(rpacisc, 177);
            page.Children.Add((UIElement)rpacisc);

            TextBlock rpgsc = new TextBlock();
            rpgsc.Inlines.Add("G(" + yaz1kbrm + "/" + yaz1ubrm);
            Run run1 = new Run("2");
            run1.FontSize = 10;
            run1.BaselineAlignment = BaselineAlignment.Superscript;
            rpgsc.Inlines.Add(run1);
            rpgsc.Inlines.Add(")");
            rpgsc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(rpgsc, 650);
            FixedPage.SetTop(rpgsc, 177);
            page.Children.Add((UIElement)rpgsc);

            TextBlock rpnsc = new TextBlock();
            rpnsc.Text = "η";
            rpnsc.Style = (Style)FindResource("textblocklar3");
            FixedPage.SetLeft(rpnsc, 775);
            FixedPage.SetTop(rpnsc, 182);
            page.Children.Add((UIElement)rpnsc);

            Grid rpcbknolar = new Grid();
            rpcbknolar.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(rpcbknolar, 30);
            FixedPage.SetTop(rpcbknolar, 227);
            page.Children.Add((UIElement)rpcbknolar);

            Grid rpdelxler = new Grid();
            rpdelxler.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(rpdelxler, 150);
            FixedPage.SetTop(rpdelxler, 227);
            page.Children.Add((UIElement)rpdelxler);

            Grid rpdelyler = new Grid();
            rpdelyler.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(rpdelyler, 275);
            FixedPage.SetTop(rpdelyler, 227);
            page.Children.Add((UIElement)rpdelyler);

            Grid rpLler = new Grid();
            rpLler.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(rpLler, 400);
            FixedPage.SetTop(rpLler, 227);
            page.Children.Add((UIElement)rpLler);

            Grid rpacilar = new Grid();
            rpacilar.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(rpacilar, 525);
            FixedPage.SetTop(rpacilar, 227);
            page.Children.Add((UIElement)rpacilar);

            Grid rpgler = new Grid();
            rpgler.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(rpgler, 650);
            FixedPage.SetTop(rpgler, 227);
            page.Children.Add((UIElement)rpgler);

            Grid rpnler = new Grid();
            rpnler.Style = (Style)FindResource("s3grid");
            FixedPage.SetLeft(rpnler, 775);
            FixedPage.SetTop(rpnler, 227);
            page.Children.Add((UIElement)rpnler);

            TextBlock[] rpcbkno, rpdelx, rpdely, rpL, rpaci, rpg, rpn;

            rpcbkno = new TextBlock[yaz1cbksay];
            rpdelx = new TextBlock[yaz1cbksay];
            rpdely = new TextBlock[yaz1cbksay];
            rpL = new TextBlock[yaz1cbksay];
            rpaci = new TextBlock[yaz1cbksay];
            rpg = new TextBlock[yaz1cbksay];
            rpn = new TextBlock[yaz1cbksay];

            for (int k = 0; k < hrcbk; k++)
            {
                if ((i == (syf - 1)) && yaz1cbksay % hrcbk != 0)
                {
                    hrcbk = yaz1cbksay - (13 * (syf - 1));
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

                rpdelx[k] = new TextBlock
                {
                    Name = "delx" + i.ToString(),
                    Text = Convert.ToString(Round(yaz1delx[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                rpdelxler.Children.Add(rpdelx[k]);

                rpdely[k] = new TextBlock
                {
                    Name = "dely" + i.ToString(),
                    Text = Convert.ToString(Round(yaz1dely[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                rpdelyler.Children.Add(rpdely[k]);

                rpL[k] = new TextBlock
                {
                    Name = "L" + i.ToString(),
                    Text = Convert.ToString(Round(yaz1L[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                rpLler.Children.Add(rpL[k]);

                rpaci[k] = new TextBlock
                {
                    Name = "aci" + i.ToString(),
                    Text = Convert.ToString(Round(yaz1aci[say], 0)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                rpacilar.Children.Add(rpaci[k]);

                rpg[k] = new TextBlock
                {
                    Name = "g" + i.ToString(),
                    Text = Convert.ToString(Round(yaz1g[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                rpgler.Children.Add(rpg[k]);

                rpn[k] = new TextBlock
                {
                    Name = "n" + i.ToString(),
                    Text = Convert.ToString(Round(yaz1n[say], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                rpnler.Children.Add(rpn[k]);
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
