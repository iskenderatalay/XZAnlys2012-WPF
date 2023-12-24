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
    public partial class Sayfa2 : Page
    {
        public Sayfa2()
        {
            InitializeComponent();
        }
        public string KuvvetBirimi { get; set; }
        public string UzunlukBirimi { get; set; }
        public string CubukSayisi { get; set; }
        public string DugumSayisi { get; set; }
        public string SerbestlikDerecesi { get; set; }

        string xz1, xz2, xz3, xz4, xz5;
        int cubuksayisi, dugumsayisi, serbestlikderecesi;

        TextBlock[] cbknolaryaz, cbknolaryaz2, dgmnolaryaz, dgmnolaryaz2;

        TextBox[] cbkileryaz, cbkklaryaz, cbkalaryaz, cbkeleryaz, cbkatlaryaz, cbkpolaryaz, cbkallaryaz;
        TextBox[] cbkyukwleryaz, cbkyukpleryaz, cbkyuknleryaz, cbkyukalaryaz, cbkyuknjleryaz, cbkyukmjleryaz;

        TextBox[] dgmxleryaz, dgmyleryaz, dgmularyaz, dgmvleryaz, dgmtetalaryaz, dgmacilaryaz, dgmyukxleryaz, dgmyukyleryaz, dgmyukzleryaz;
  
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = 1050;
            Application.Current.MainWindow.Height = 800;
            Application.Current.MainWindow.MaxHeight = SystemParameters.WorkArea.Height;

            Application.Current.MainWindow.Left = (SystemParameters.WorkArea.Width - Application.Current.MainWindow.Width) / 2;
            Application.Current.MainWindow.Top = (SystemParameters.WorkArea.Height - Application.Current.MainWindow.Height) / 2;

            xz1 = KuvvetBirimi.ToString();
            xz2 = UzunlukBirimi.ToString();
            xz3 = CubukSayisi.ToString();
            xz4 = DugumSayisi.ToString();
            xz5 = SerbestlikDerecesi.ToString();

            cbkasc.Text = "A(" + xz2;
            cbkesc.Text = "E(" + xz1 + "/" + xz2;
            cbkatsc.Text = "I(" + xz2;

            cbkyukwsc.Text = "W(" + xz1 + "/" + xz2 + ")";
            cbkyukpsc.Text = "P(" + xz1 + ")";
            cbkyuknsc.Text = "N(" + xz1 + ")";
            cbkyukasc.Text = "a(" + xz2 + ")";
            cbkyuknjsc.Text = "Nj(" + xz1 + "/" + xz2 + ")";
            cbkyukmjsc.Text = "Mj(" + xz1 + "/" + xz2;

            dgmxsc.Text = "X(" + xz2 + ")";
            dgmysc.Text = "Y(" + xz2 + ")";
            dgmyukxsc.Text = "YükX(" + xz1 + ")";
            dgmyukysc.Text = "YükY(" + xz1 + ")";
            dgmyukzsc.Text = "YükZ(" + xz1 + ")";

            cubuksayisi = Convert.ToInt32(xz3);
            dugumsayisi = Convert.ToInt32(xz4);
            serbestlikderecesi = Convert.ToInt32(xz5);

            cbknolaryaz = new TextBlock[cubuksayisi];
            cbkileryaz = new TextBox[cubuksayisi];
            cbkklaryaz = new TextBox[cubuksayisi];
            cbkalaryaz = new TextBox[cubuksayisi];
            cbkeleryaz = new TextBox[cubuksayisi];
            cbkatlaryaz = new TextBox[cubuksayisi];
            cbkpolaryaz = new TextBox[cubuksayisi];
            cbkallaryaz = new TextBox[cubuksayisi];

            cbknolaryaz2 = new TextBlock[cubuksayisi];
            cbkyukwleryaz = new TextBox[cubuksayisi];
            cbkyukpleryaz = new TextBox[cubuksayisi];
            cbkyuknleryaz = new TextBox[cubuksayisi];
            cbkyukalaryaz = new TextBox[cubuksayisi];
            cbkyuknjleryaz = new TextBox[cubuksayisi];
            cbkyukmjleryaz = new TextBox[cubuksayisi];

            dgmnolaryaz = new TextBlock[dugumsayisi];
            dgmxleryaz = new TextBox[dugumsayisi];
            dgmyleryaz = new TextBox[dugumsayisi];
            dgmularyaz = new TextBox[dugumsayisi];
            dgmvleryaz = new TextBox[dugumsayisi];
            dgmtetalaryaz = new TextBox[dugumsayisi];

            dgmnolaryaz2 = new TextBlock[dugumsayisi];
            dgmacilaryaz = new TextBox[dugumsayisi];
            dgmyukxleryaz = new TextBox[dugumsayisi];
            dgmyukyleryaz = new TextBox[dugumsayisi];
            dgmyukzleryaz = new TextBox[dugumsayisi];

            for (int i = 0; i < cubuksayisi; i++)
            {
                int tab = 0000;
                double konumust = i * 40;

                cbknolaryaz[i] = new TextBlock
                {
                    Name = "cbkno" + i.ToString(),
                    Text = (i + 1).ToString() + " . Çubuk",
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar")
                };
                cbknolar.Children.Add(cbknolaryaz[i]);

                cbkileryaz[i] = new TextBox
                {
                    Name = "cbkii" + i.ToString(),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkiler.Children.Add(cbkileryaz[i]);
                cbkileryaz[0].Focus();

                cbkklaryaz[i] = new TextBox
                {
                    Name = "cbkk" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkklar.Children.Add(cbkklaryaz[i]);

                cbkalaryaz[i] = new TextBox
                {
                    Name = "cbka" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkalar.Children.Add(cbkalaryaz[i]);

                cbkeleryaz[i] = new TextBox
                {
                    Name = "cbke" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkeler.Children.Add(cbkeleryaz[i]);

                cbkatlaryaz[i] = new TextBox
                {
                    Name = "cbkat" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkatlar.Children.Add(cbkatlaryaz[i]);

                cbkpolaryaz[i] = new TextBox
                {
                    Name = "cbkpoisson" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkpolar.Children.Add(cbkpolaryaz[i]);

                cbkallaryaz[i] = new TextBox
                {
                    Name = "cbkalfa" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkallar.Children.Add(cbkallaryaz[i]);
            }

            for (int i = 0; i < cubuksayisi; i++)
            {
                int tab1 = 1111;
                double konumust = i * 40;

                cbknolaryaz2[i] = new TextBlock
                {
                    Name = "cbkno2" + i,
                    Text = (i + 1).ToString() + " . Çubuk",
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar")
                };
                cbknolar2.Children.Add(cbknolaryaz2[i]);

                cbkyukwleryaz[i] = new TextBox
                {
                    Name = "cbkyukw" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab1 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkyukwler.Children.Add(cbkyukwleryaz[i]);

                cbkyukpleryaz[i] = new TextBox
                {
                    Name = "cbkyukp" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab1 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkyukpler.Children.Add(cbkyukpleryaz[i]);

                cbkyuknleryaz[i] = new TextBox
                {
                    Name = "cbkyukn" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab1 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkyuknler.Children.Add(cbkyuknleryaz[i]);

                cbkyukalaryaz[i] = new TextBox
                {
                    Name = "cbkyuka" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab1 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkyukalar.Children.Add(cbkyukalaryaz[i]);

                cbkyuknjleryaz[i] = new TextBox
                {
                    Name = "cbkyuknj" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab1 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkyuknjler.Children.Add(cbkyuknjleryaz[i]);

                cbkyukmjleryaz[i] = new TextBox
                {
                    Name = "cbkyukmj" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab1 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                cbkyukmjler.Children.Add(cbkyukmjleryaz[i]);
            }

            for (int i = 0; i < dugumsayisi; i++)
            {
                int tab2 = 2222;
                double konumust = i * 40;

                dgmnolaryaz[i] = new TextBlock
                {
                    Name = "dgmno" + i,
                    Text = (i + 1).ToString() + " . Düğüm",
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar")
                };
                dgmnolar.Children.Add(dgmnolaryaz[i]);

                dgmxleryaz[i] = new TextBox
                {
                    Name = "dgmx" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab2 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                dgmxler.Children.Add(dgmxleryaz[i]);

                dgmyleryaz[i] = new TextBox
                {
                    Name = "dgmy" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab2 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                dgmyler.Children.Add(dgmyleryaz[i]);

                dgmularyaz[i] = new TextBox
                {
                    Name = "dgmu" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab2 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                dgmular.Children.Add(dgmularyaz[i]);

                dgmvleryaz[i] = new TextBox
                {
                    Name = "dgmv" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab2 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                dgmvler.Children.Add(dgmvleryaz[i]);

                dgmtetalaryaz[i] = new TextBox
                {
                    Name = "dgmteta" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab2 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                dgmtetalar.Children.Add(dgmtetalaryaz[i]);
            }

            for (int i = 0; i < dugumsayisi; i++)
            {
                int tab3 = 3333;
                double konumust = i * 40;

                dgmnolaryaz2[i] = new TextBlock
                {
                    Name = "dgmno2" + i,
                    Text = (i + 1).ToString() + " . Düğüm",
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar")
                };
                dgmnolar2.Children.Add(dgmnolaryaz2[i]);

                dgmacilaryaz[i] = new TextBox
                {
                    Name = "dgmyukaci" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab3 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                dgmacilar.Children.Add(dgmacilaryaz[i]);

                dgmyukxleryaz[i] = new TextBox
                {
                    Name = "dgmyukx" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab3 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                dgmyukxler.Children.Add(dgmyukxleryaz[i]);

                dgmyukyleryaz[i] = new TextBox
                {
                    Name = "dgmyuky" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab3 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                dgmyukyler.Children.Add(dgmyukyleryaz[i]);

                dgmyukzleryaz[i] = new TextBox
                {
                    Name = "dgmyukz" + i,
                    Margin = new Thickness(0, konumust, 0, 0),
                    TabIndex = tab3 + i,
                    Style = (Style)FindResource("textboxlar")
                };
                dgmyukzler.Children.Add(dgmyukzleryaz[i]);
            }
        }

        private void Temizle_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < cubuksayisi; i++)
            {
                cbkileryaz[i].Text = "";
                cbkklaryaz[i].Text = "";
                cbkalaryaz[i].Text = "";
                cbkeleryaz[i].Text = "";
                cbkatlaryaz[i].Text = "";
                cbkpolaryaz[i].Text = "";
                cbkallaryaz[i].Text = "";
                cbkyukwleryaz[i].Text = "";
                cbkyukpleryaz[i].Text = "";
                cbkyuknleryaz[i].Text = "";
                cbkyukalaryaz[i].Text = "";
                cbkyuknjleryaz[i].Text = "";
                cbkyukmjleryaz[i].Text = "";
            }

            for (int i = 0; i < dugumsayisi; i++)
            {
                dgmxleryaz[i].Text = "";
                dgmyleryaz[i].Text = "";
                dgmularyaz[i].Text = "";
                dgmvleryaz[i].Text = "";
                dgmtetalaryaz[i].Text = "";
                dgmacilaryaz[i].Text = "";
                dgmyukxleryaz[i].Text = "";
                dgmyukyleryaz[i].Text = "";
                dgmyukzleryaz[i].Text = "";
            }
        }

        int bol;

        private void Ileri_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < cubuksayisi; i++)
            {
                if ((cbkileryaz[i].Text != "") && (cbkklaryaz[i].Text != "") && (cbkalaryaz[i].Text != "") && (cbkeleryaz[i].Text != "") &&
                    (cbkatlaryaz[i].Text != "") && (cbkpolaryaz[i].Text != "") && (cbkallaryaz[i].Text != "") && (cbkyukwleryaz[i].Text != "") &&
                    (cbkyukpleryaz[i].Text != "") && (cbkyuknleryaz[i].Text != "") && (cbkyukalaryaz[i].Text != "") && (cbkyuknjleryaz[i].Text != "") &&
                    (cbkyukmjleryaz[i].Text != ""))
                {
                    bol = 0;
                }
                else bol = 1;
            }

            for (int i = 0; i < dugumsayisi; i++)
            {
                if ((dgmxleryaz[i].Text != "") && (dgmyleryaz[i].Text != "") && (dgmularyaz[i].Text != "") && (dgmvleryaz[i].Text != "") &&
                   (dgmtetalaryaz[i].Text != "") && (dgmacilaryaz[i].Text != "") && (dgmyukxleryaz[i].Text != "") && (dgmyukyleryaz[i].Text != "") && (dgmyukzleryaz[i].Text != ""))
                {
                    bol = 0;
                }
                else bol = 1;
            }

            if (bol == 0)
            {
                Sayfa3 sayfa3 = new Sayfa3();

                sayfa3.s3kuvvetbrm = KuvvetBirimi;
                sayfa3.s3uzunlukbrm = UzunlukBirimi;
                sayfa3.cbksay = cubuksayisi;
                sayfa3.dgmsay = dugumsayisi;
                sayfa3.sdsay = serbestlikderecesi;

                sayfa3.cbki = new int[cubuksayisi];
                sayfa3.cbkk = new int[cubuksayisi];
                sayfa3.cbka = new double[cubuksayisi];
                sayfa3.cbke = new double[cubuksayisi];
                sayfa3.cbkat = new double[cubuksayisi];
                sayfa3.cbkpo = new double[cubuksayisi];
                sayfa3.cbkal = new double[cubuksayisi];
                sayfa3.cbkyukw = new double[cubuksayisi];
                sayfa3.cbkyukp = new double[cubuksayisi];
                sayfa3.cbkyukn = new double[cubuksayisi];
                sayfa3.cbkyuka = new double[cubuksayisi];
                sayfa3.cbkyuknj = new double[cubuksayisi];
                sayfa3.cbkyukmj = new double[cubuksayisi];

                sayfa3.dgmx = new double[dugumsayisi];
                sayfa3.dgmy = new double[dugumsayisi];
                sayfa3.dgmu = new int[dugumsayisi];
                sayfa3.dgmv = new int[dugumsayisi];
                sayfa3.dgmteta = new int[dugumsayisi];
                sayfa3.acidgm = new double[dugumsayisi];
                sayfa3.dgmyukx = new double[dugumsayisi];
                sayfa3.dgmyuky = new double[dugumsayisi];
                sayfa3.dgmyukz = new double[dugumsayisi];

                for (int i = 0; i < cubuksayisi; i++)
                {
                    sayfa3.cbki[i] = Convert.ToInt32(cbkileryaz[i].Text);
                    sayfa3.cbkk[i] = Convert.ToInt32(cbkklaryaz[i].Text);
                    sayfa3.cbka[i] = Convert.ToDouble(cbkalaryaz[i].Text);
                    sayfa3.cbke[i] = Convert.ToDouble(cbkeleryaz[i].Text);
                    sayfa3.cbkat[i] = Convert.ToDouble(cbkatlaryaz[i].Text);
                    sayfa3.cbkpo[i] = Convert.ToDouble(cbkpolaryaz[i].Text);
                    sayfa3.cbkal[i] = Convert.ToDouble(cbkallaryaz[i].Text);
                    sayfa3.cbkyukw[i] = Convert.ToDouble(cbkyukwleryaz[i].Text);
                    sayfa3.cbkyukp[i] = Convert.ToDouble(cbkyukpleryaz[i].Text);
                    sayfa3.cbkyukn[i] = Convert.ToDouble(cbkyuknleryaz[i].Text);
                    sayfa3.cbkyuka[i] = Convert.ToDouble(cbkyukalaryaz[i].Text);
                    sayfa3.cbkyuknj[i] = Convert.ToDouble(cbkyuknjleryaz[i].Text);
                    sayfa3.cbkyukmj[i] = Convert.ToDouble(cbkyukmjleryaz[i].Text);
                }

                for (int i = 0; i < dugumsayisi; i++)
                {
                    sayfa3.dgmx[i] = Convert.ToDouble(dgmxleryaz[i].Text);
                    sayfa3.dgmy[i] = Convert.ToDouble(dgmyleryaz[i].Text);
                    sayfa3.dgmu[i] = Convert.ToInt32(dgmularyaz[i].Text);
                    sayfa3.dgmv[i] = Convert.ToInt32(dgmvleryaz[i].Text);
                    sayfa3.dgmteta[i] = Convert.ToInt32(dgmtetalaryaz[i].Text);
                    sayfa3.acidgm[i] = Convert.ToDouble(dgmacilaryaz[i].Text);
                    sayfa3.dgmyukx[i] = Convert.ToDouble(dgmyukxleryaz[i].Text);
                    sayfa3.dgmyuky[i] = Convert.ToDouble(dgmyukyleryaz[i].Text);
                    sayfa3.dgmyukz[i] = Convert.ToDouble(dgmyukzleryaz[i].Text);
                }

                NavigationService.Navigate(sayfa3);
            }
            if (bol == 1)
            {
                Window hata = new Hata();
                hata.Owner = Window.GetWindow(this);
                hata.Owner.Opacity = 0.35;
                hata.ShowDialog();
            }
        }

        private void Kapat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
