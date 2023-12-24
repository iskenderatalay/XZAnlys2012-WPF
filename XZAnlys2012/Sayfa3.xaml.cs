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
using static System.Math;

namespace XZAnlys2012
{
    public partial class Sayfa3 : Page
    {
        public Sayfa3()
        {
            InitializeComponent();
        }
        public string s3kuvvetbrm { get; set; }
        public string s3uzunlukbrm { get; set; }
        public int cbksay { get; set; }
        public int dgmsay { get; set; }
        public int sdsay { get; set; }
        public int[] cbki { get; set; }
        public int[] cbkk { get; set; }
        public double[] cbka { get; set; }
        public double[] cbke { get; set; }
        public double[] cbkat { get; set; }
        public double[] cbkpo { get; set; }
        public double[] cbkal { get; set; }
        public double[] cbkyukw { get; set; }
        public double[] cbkyukp { get; set; }
        public double[] cbkyukn { get; set; }
        public double[] cbkyuka { get; set; }
        public double[] cbkyuknj { get; set; }
        public double[] cbkyukmj { get; set; }
        public double[] dgmx { get; set; }
        public double[] dgmy { get; set; }
        public int[] dgmu { get; set; }
        public int[] dgmv { get; set; }
        public int[] dgmteta { get; set; }
        public double[] acidgm { get; set; }
        public double[] dgmyukx { get; set; }
        public double[] dgmyuky { get; set; }
        public double[] dgmyukz { get; set; }

        int pivotkol, rep, Xyeni;
        double pivot, rep1, eksiilecarp;
        int[] Xizle;
        double[] delx, dely, L, aci, acidgmrad, g, nu, kata, katb, katc, Pj, Qj, Qt, X, Xu, Xv, Xteta;

        int[,] Dj;
        double[,] Q, Sj, S, Djyeni, qussu, qussucizgi, qcubuk;

        TextBlock[] cbknolaryaz, delxtosc, delytosc, Ltosc, acitosc, gtosc, nutosc, dgmnolaryaz, deputosc, depvtosc, deptetatosc, cbknolaryaz2, cbkkuvnitosc, cbkkuvsitosc, cbkkuvmitosc, cbkkuvnktosc, cbkkuvsktosc, cbkkuvmktosc;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = 1030;
            Application.Current.MainWindow.MaxHeight = SystemParameters.WorkArea.Height;

            Application.Current.MainWindow.Left = (SystemParameters.WorkArea.Width - Application.Current.MainWindow.Width) / 2;
            Application.Current.MainWindow.Top = (SystemParameters.WorkArea.Height - Application.Current.MainWindow.Height) / 2;

            delx = new double[cbksay];
            dely = new double[cbksay];
            L = new double[cbksay];
            aci = new double[cbksay];
            acidgmrad = new double[dgmsay];
            Dj = new int[cbksay, 6];
            g = new double[cbksay];
            nu = new double[cbksay];
            kata = new double[cbksay];
            katb = new double[cbksay];
            katc = new double[cbksay];
            Q = new double[cbksay, 6];
            Pj = new double[sdsay];
            Sj = new double[6, 6];
            S = new double[sdsay, sdsay];
            Qj = new double[sdsay];
            Qt = new double[sdsay];
            Xizle = new int[sdsay];
            X = new double[sdsay];
            Djyeni = new double[cbksay, 6];
            qussu = new double[cbksay, 6];
            qussucizgi = new double[cbksay, 6];
            qcubuk = new double[cbksay, 6];
            Xu = new double[dgmsay];
            Xv = new double[dgmsay];
            Xteta = new double[dgmsay];

            for (int i = 0; i < dgmsay; i++)
            {
                acidgmrad[i] = acidgm[i] * PI / 180;
            }

            for (int i = 0; i < cbksay; i++)
            {
                delx[i] = dgmx[cbkk[i] - 1] - dgmx[cbki[i] - 1];
                dely[i] = dgmy[cbkk[i] - 1] - dgmy[cbki[i] - 1];
                L[i] = Sqrt(Pow(delx[i], 2) + Pow(dely[i], 2));

                aci[i] = Atan(dely[i] / delx[i]);
                if (delx[i] > 0 && dely[i] == 0)
                    aci[i] = 0;
                if (delx[i] < 0 && dely[i] == 0)
                    aci[i] = PI;
                if (delx[i] == 0 && dely[i] < 0)
                    aci[i] = 3 * PI / 2;
                if (delx[i] == 0 && dely[i] > 0)
                    aci[i] = PI / 2;
                if (delx[i] < 0 && dely[i] > 0)
                    aci[i] = aci[i] + PI;
                if (delx[i] < 0 && dely[i] < 0)
                    aci[i] = aci[i] + PI;
                if (delx[i] > 0 && dely[i] < 0)
                    aci[i] = aci[i] + 2 * PI;

                Dj[i, 0] = dgmu[cbki[i] - 1];
                Dj[i, 1] = dgmv[cbki[i] - 1];
                Dj[i, 2] = dgmteta[cbki[i] - 1];
                Dj[i, 3] = dgmu[cbkk[i] - 1];
                Dj[i, 4] = dgmv[cbkk[i] - 1];
                Dj[i, 5] = dgmteta[cbkk[i] - 1];

                g[i] = cbke[i] / (2 + (2 * cbkpo[i]));
                nu[i] = (cbkal[i] * cbke[i] * cbkat[i]) / (cbka[i] * g[i] * Pow(L[i], 2));
                kata[i] = (1.0 - (6.0 * nu[i])) / (1.0 + (12.0 * nu[i]));
                katb[i] = (1.0 + (3.0 * nu[i])) / (1.0 + (12.0 * nu[i]));
                katc[i] = 1.0 / (1.0 + (12.0 * nu[i]));
            }

            for (int i = 0; i < cbksay; i++)
            {
                Q[i, 0] = (Cos(aci[i] - acidgmrad[cbki[i] - 1]) * ((cbkyukn[i] * (L[i] - cbkyuka[i]) / L[i]) + ((cbkyuknj[i] * L[i]) / 2.0))) - (Sin(aci[i] - acidgmrad[cbki[i] - 1]) * ((cbkyukw[i] * L[i] / 2.0) + (((cbkyukp[i] * Pow(L[i] - cbkyuka[i], 2.0) * ((3.0 * cbkyuka[i]) + (L[i] - cbkyuka[i]))) + (12.0 * cbkyukp[i] * (L[i] - cbkyuka[i]) * (Pow(L[i], 2.0) * nu[i])) / (Pow(L[i], 3.0) * (1.0 + (12.0 * nu[i])))) - ((6.0 * cbkyukmj[i] * cbkyuka[i] * (L[i] - cbkyuka[i])) / (Pow(L[i], 3.0) * (1.0 + (12.0 * nu[i])))))));
                Q[i, 1] = (Sin(aci[i] - acidgmrad[cbki[i] - 1]) * ((cbkyukn[i] * (L[i] - cbkyuka[i]) / L[i]) + ((cbkyuknj[i] * L[i]) / 2.0))) + (Cos(aci[i] - acidgmrad[cbki[i] - 1]) * ((cbkyukw[i] * L[i] / 2.0) + (((cbkyukp[i] * Pow(L[i] - cbkyuka[i], 2.0) * ((3.0 * cbkyuka[i]) + (L[i] - cbkyuka[i]))) + (12.0 * cbkyukp[i] * (L[i] - cbkyuka[i]) * Pow(L[i], 2.0) * nu[i])) / (Pow(L[i], 3.0) * (1.0 + (12.0 * nu[i])))) - ((6.0 * cbkyukmj[i] * cbkyuka[i] * (L[i] - cbkyuka[i])) / (Pow(L[i], 3.0) * (1.0 + (12.0 * nu[i]))))));
                Q[i, 2] = ((cbkyukw[i] * Pow(L[i], 2.0)) / 12.0) + (((cbkyukp[i] * Pow(L[i] - cbkyuka[i], 2.0) * cbkyuka[i]) + (cbkyukp[i] * (L[i] - cbkyuka[i]) * cbkyuka[i] * 6.0 * nu[i] * L[i])) / (Pow(L[i], 2.0) + (12.0 * Pow(L[i], 2.0) * nu[i]))) + (((cbkyukmj[i] * (L[i] - cbkyuka[i])) / Pow(L[i], 2.0)) * (((L[i] - (3.0 * cbkyuka[i])) + (12.0 * L[i] * nu[i])) / (1.0 + (12.0 * nu[i]))));
                Q[i, 3] = (Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * ((cbkyukn[i] * cbkyuka[i] / L[i]) + ((cbkyuknj[i] * L[i]) / 2.0))) - (Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * ((cbkyukw[i] * L[i] / 2.0) + (((cbkyukp[i] * Pow(cbkyuka[i], 2.0) * ((3.0 * (L[i] - cbkyuka[i])) + cbkyuka[i])) + (12.0 * cbkyukp[i] * (L[i] - cbkyuka[i]) * Pow(L[i], 2.0) * nu[i])) / (Pow(L[i], 3.0) * (1.0 + (12.0 * nu[i])))) + ((6.0 * cbkyukmj[i] * cbkyuka[i] * (L[i] - cbkyuka[i])) / (Pow(L[i], 3.0) * (1.0 + (12.0 * nu[i]))))));
                Q[i, 4] = (Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * ((cbkyukn[i] * cbkyuka[i] / L[i]) + ((cbkyuknj[i] * L[i]) / 2.0))) + (Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * ((cbkyukw[i] * L[i] / 2.0) + (((cbkyukp[i] * Pow(cbkyuka[i], 2.0) * ((3.0 * (L[i] - cbkyuka[i])) + cbkyuka[i])) + (12.0 * cbkyukp[i] * (L[i] - cbkyuka[i]) * Pow(L[i], 2.0) * nu[i])) / (Pow(L[i], 3.0) * (1.0 + (12.0 * nu[i])))) + ((6.0 * cbkyukmj[i] * cbkyuka[i] * (L[i] - cbkyuka[i])) / (Pow(L[i], 3.0) * (1.0 + (12.0 * nu[i]))))));
                Q[i, 5] = (-(cbkyukw[i] * Pow(L[i], 2.0)) / 12.0) - (((cbkyukp[i] * Pow(cbkyuka[i], 2.0) * (L[i] - cbkyuka[i])) + (cbkyukp[i] * (L[i] - cbkyuka[i]) * cbkyuka[i] * 6.0 * nu[i] * L[i])) / (Pow(L[i], 2.0) + (12.0 * Pow(L[i], 2.0) * nu[i]))) + (((cbkyukmj[i] * cbkyuka[i]) / Pow(L[i], 2.0)) * ((((3.0 * cbkyuka[i]) - (2.0 * L[i])) + (12.0 * L[i] * nu[i])) / (1.0 + (12.0 * nu[i]))));
            }

            for (int i = 0; i < dgmsay; i++)
            {
                if (dgmyukx[i] != 0)
                {
                    int a = i;
                    int b = dgmu[a];
                    Pj[b - 1] = dgmyukx[i];
                }
                if (dgmyuky[i] != 0)
                {
                    int a = i;
                    int b = dgmv[a];
                    Pj[b - 1] = dgmyuky[i];
                }
                if (dgmyukz[i] != 0)
                {
                    int a = i;
                    int b = dgmteta[a];
                    Pj[b - 1] = dgmyukz[i];
                }
            }

            for (int i = 0; i < sdsay; i++)
            {
                for (int j = 0; j < sdsay; j++)
                    S[i, j] = 0;
            }

            for (int i = 0; i < cbksay; i++)
            {
                Sj[0, 0] = (Pow(Cos(aci[i] - acidgmrad[cbki[i] - 1]), 2.0) * (cbke[i] * cbka[i]) / L[i]) + (Pow(Sin(aci[i] - acidgmrad[cbki[i] - 1]), 2.0) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0) * katc[i]));
                Sj[0, 1] = (Sin(aci[i] - acidgmrad[cbki[i] - 1]) * Cos(aci[i] - acidgmrad[cbki[i] - 1]) * (cbke[i] * cbka[i]) / L[i]) - (Sin(aci[i] - acidgmrad[cbki[i] - 1]) * Cos(aci[i] - acidgmrad[cbki[i] - 1]) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * katc[i]);
                Sj[0, 2] = -(Sin(aci[i] - acidgmrad[cbki[i] - 1]) * ((6.0 * cbke[i] * cbkat[i]) / Pow(L[i], 2.0)) * katc[i]);
                Sj[0, 3] = ((Cos(aci[i] - acidgmrad[cbki[i] - 1]) * Cos(aci[i] - acidgmrad[cbkk[i] - 1])) * (-cbke[i] * cbka[i]) / L[i]) - ((Sin(aci[i] - acidgmrad[cbki[i] - 1]) * Sin(aci[i] - acidgmrad[cbkk[i] - 1])) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * katc[i]);
                Sj[0, 4] = ((Cos(aci[i] - acidgmrad[cbki[i] - 1]) * Sin(aci[i] - acidgmrad[cbkk[i] - 1])) * (-cbke[i] * cbka[i]) / L[i]) + ((Sin(aci[i] - acidgmrad[cbki[i] - 1]) * Cos(aci[i] - acidgmrad[cbkk[i] - 1])) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * katc[i]);
                Sj[0, 5] = Sj[0, 2];
                Sj[1, 0] = ((Cos(aci[i] - acidgmrad[cbki[i] - 1]) * Sin(aci[i] - acidgmrad[cbki[i] - 1])) * (cbke[i] * cbka[i]) / L[i]) - ((Sin(aci[i] - acidgmrad[cbki[i] - 1]) * Cos(aci[i] - acidgmrad[cbki[i] - 1])) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * katc[i]);
                Sj[1, 1] = (Pow(Sin(aci[i] - acidgmrad[cbki[i] - 1]), 2.0) * (cbke[i] * cbka[i]) / L[i]) + (Pow(Cos(aci[i] - acidgmrad[cbki[i] - 1]), 2.0) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0) * katc[i]));
                Sj[1, 2] = (Cos(aci[i] - acidgmrad[cbki[i] - 1]) * ((6.0 * cbke[i] * cbkat[i]) / Pow(L[i], 2.0)) * katc[i]);
                Sj[1, 3] = ((-Sin(aci[i] - acidgmrad[cbki[i] - 1]) * Cos(aci[i] - acidgmrad[cbkk[i] - 1])) * (cbke[i] * cbka[i]) / L[i]) + (Cos(aci[i] - acidgmrad[cbki[i] - 1]) * Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * katc[i]);
                Sj[1, 4] = ((-Sin(aci[i] - acidgmrad[cbki[i] - 1]) * Sin(aci[i] - acidgmrad[cbkk[i] - 1])) * (cbke[i] * cbka[i]) / L[i]) - (Cos(aci[i] - acidgmrad[cbki[i] - 1]) * Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * katc[i]);
                Sj[1, 5] = Sj[1, 2];
                Sj[2, 0] = Sj[0, 2];
                Sj[2, 1] = Sj[1, 5];
                Sj[2, 2] = (4.0 * cbke[i] * cbkat[i] / L[i]) * katb[i];
                Sj[2, 3] = (Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * ((6.0 * cbke[i] * cbkat[i]) / Pow(L[i], 2.0)) * katc[i]);
                Sj[2, 4] = -(Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * ((6.0 * cbke[i] * cbkat[i]) / Pow(L[i], 2.0)) * katc[i]);
                Sj[2, 5] = (2.0 * cbke[i] * cbkat[i] / L[i]) * kata[i];
                Sj[3, 0] = (-(Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * Cos(aci[i] - acidgmrad[cbki[i] - 1])) * (cbke[i] * cbka[i]) / L[i]) - ((Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * Sin(aci[i] - acidgmrad[cbki[i] - 1])) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * katc[i]);
                Sj[3, 1] = (-(Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * Sin(aci[i] - acidgmrad[cbki[i] - 1])) * (cbke[i] * cbka[i]) / L[i]) + ((Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * Cos(aci[i] - acidgmrad[cbki[i] - 1])) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * katc[i]);
                Sj[3, 2] = (Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * ((6.0 * cbke[i] * cbkat[i]) / Pow(L[i], 2.0)) * (1.0 / (1.0 + (12.0 * nu[i]))));
                Sj[3, 3] = (Pow(Cos(aci[i] - acidgmrad[cbkk[i] - 1]), 2.0) * (cbke[i] * cbka[i]) / L[i]) + (Pow(Sin(aci[i] - acidgmrad[cbkk[i] - 1]), 2.0) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * (1.0 / (1.0 + (12.0 * nu[i]))));
                Sj[3, 4] = ((Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * Sin(aci[i] - acidgmrad[cbkk[i] - 1])) * (cbke[i] * cbka[i]) / L[i]) - ((Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * Cos(aci[i] - acidgmrad[cbkk[i] - 1])) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * katc[i]);
                Sj[3, 5] = Sj[3, 2];
                Sj[4, 0] = ((-Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * Cos(aci[i] - acidgmrad[cbki[i] - 1])) * (cbke[i] * cbka[i]) / L[i]) + (Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * Sin(aci[i] - acidgmrad[cbki[i] - 1]) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * katc[i]);
                Sj[4, 1] = ((-Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * Sin(aci[i] - acidgmrad[cbki[i] - 1])) * (cbke[i] * cbka[i]) / L[i]) - (Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * Cos(aci[i] - acidgmrad[cbki[i] - 1]) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * katc[i]);
                Sj[4, 2] = -(Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * ((6.0 * cbke[i] * cbkat[i]) / Pow(L[i], 2.0)) * katc[i]);
                Sj[4, 3] = ((Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * Cos(aci[i] - acidgmrad[cbkk[i] - 1])) * (cbke[i] * cbka[i]) / L[i]) - (Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0)) * katc[i]);
                Sj[4, 4] = (Pow(Sin(aci[i] - acidgmrad[cbkk[i] - 1]), 2.0) * (cbke[i] * cbka[i]) / L[i]) + (Pow(Cos(aci[i] - acidgmrad[cbkk[i] - 1]), 2.0) * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0) * katc[i]));
                Sj[4, 5] = Sj[4, 2];
                Sj[5, 0] = Sj[0, 2];
                Sj[5, 1] = Sj[1, 2];
                Sj[5, 2] = Sj[2, 5];
                Sj[5, 3] = Sj[2, 3];
                Sj[5, 4] = Sj[4, 2];
                Sj[5, 5] = Sj[2, 2];

                for (int i1 = 0; i1 < 6; i1++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        int sx = Dj[i, i1];
                        int sy = Dj[i, j];
                        if (sx == 0) continue;
                        if (sy == 0) continue;
                        {
                            S[sx - 1, sy - 1] = S[sx - 1, sy - 1] + Sj[i1, j];
                        }
                    }
                }
            }

            for (int i = 0; i < sdsay; i++)
                Qj[i] = 0;

            for (int i = 0; i < cbksay; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int qx = Dj[i, j];
                    if (qx == 0) continue;
                    Qj[qx - 1] = Qj[qx - 1] + Q[i, j];
                }
            }

            for (int i = 0; i < sdsay; i++)
                Qt[i] = Pj[i] - Qj[i];

            for (int i = 0; i < sdsay; i++)
                Xizle[i] = i + 1;

            for (int i = 0; i < sdsay; i++)
            {
                pivot = S[i, i];
                pivotkol = i;
                for (int j = i + 1; j < sdsay; j++)
                {
                    if (Abs(pivot) < Abs(S[i, j]))
                    {
                        pivot = S[i, j];
                        pivotkol = j;
                    }
                }

                if (Abs(pivot) <= Abs(Pow(10.0, -10.0)))
                {
                    Labil labil = new Labil();
                    NavigationService.Navigate(labil);
                }

                for (int j = 0; j < sdsay; j++)
                {
                    rep1 = S[j, pivotkol];
                    S[j, pivotkol] = S[j, i];
                    S[j, i] = rep1;
                }

                rep = Xizle[pivotkol];
                Xizle[pivotkol] = Xizle[i];
                Xizle[i] = rep;
                if (pivot == 0) continue;

                for (int j = 0; j < sdsay; j++)
                    S[i, j] = S[i, j] / pivot;

                Qt[i] = Qt[i] / pivot;

                for (int j = i + 1; j < sdsay; j++)
                {
                    eksiilecarp = -(S[j, i]);
                    Qt[j] = Qt[j] + Qt[i] * eksiilecarp;
                    for (int j1 = 0; j1 < sdsay; j1++)
                        S[j, j1] = S[i, j1] * eksiilecarp + S[j, j1];
                }
            }

            for (int i = sdsay - 1; i >= 0; i--)
            {
                Xyeni = Xizle[i];
                X[Xyeni - 1] = Qt[i];
                for (int j = sdsay - 1; j >= 0; j--)
                    Qt[j] = Qt[j] - S[j, i] * X[Xyeni - 1];
            }

            for (int i = 0; i < dgmsay; i++)
            {
                Xu[i] = 0;
                Xv[i] = 0;
                Xteta[i] = 0;
            }

            for (int i = 0; i < dgmsay; i++)
            {
                if (dgmu[i] != 0)
                    Xu[i] = X[dgmu[i] - 1];

                if (dgmv[i] != 0)
                    Xv[i] = X[dgmv[i] - 1];

                if (dgmteta[i] != 0)
                    Xteta[i] = X[dgmteta[i] - 1];
            }

            for (int i = 0; i < cbksay; i++)
            {
                for (int j = 0; j < 6; j++)
                    Djyeni[i, j] = 0;
            }

            for (int i = 0; i < cbksay; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (Dj[i, j] == 0) continue;
                    Djyeni[i, j] = X[Dj[i, j] - 1];
                }
            }

            for (int i = 0; i < cbksay; i++)
            {
                qussucizgi[i, 0] = (cbkyukn[i] * (L[i] - cbkyuka[i]) / L[i]) + ((cbkyuknj[i] * L[i]) / 2.0);
                qussucizgi[i, 1] = (cbkyukw[i] * L[i] / 2.0) + (((cbkyukp[i] * Pow((L[i] - cbkyuka[i]), 2.0) * ((3.0 * cbkyuka[i]) + (L[i] - cbkyuka[i]))) + (12.0 * cbkyukp[i] * (L[i] - cbkyuka[i]) * Pow(L[i], 2.0) * nu[i])) / (Pow(L[i], 3.0) * (1.0 + (12.0 * nu[i])))) - ((6.0 * cbkyukmj[i] * cbkyuka[i] * (L[i] - cbkyuka[i])) / (Pow(L[i], 3.0) * (1.0 + (12.0 * nu[i]))));
                qussucizgi[i, 2] = ((cbkyukw[i] * Pow(L[i], 2.0)) / 12.0) + (((cbkyukp[i] * Pow((L[i] - cbkyuka[i]), 2.0) * cbkyuka[i]) + (cbkyukp[i] * (L[i] - cbkyuka[i]) * cbkyuka[i] * 6.0 * nu[i] * L[i])) / (Pow(L[i], 2.0) + (12.0 * Pow(L[i], 2.0) * nu[i]))) + (((cbkyukmj[i] * (L[i] - cbkyuka[i])) / Pow(L[i], 2.0)) * (((L[i] - (3 * cbkyuka[i])) + (12.0 * L[i] * nu[i])) / (1.0 + (12.0 * nu[i]))));
                qussucizgi[i, 3] = (cbkyukn[i] * cbkyuka[i] / L[i]) + ((cbkyuknj[i] * L[i]) / 2.0);
                qussucizgi[i, 4] = (cbkyukw[i] * L[i] / 2.0) + (((cbkyukp[i] * Pow(cbkyuka[i], 2.0) * ((3.0 * (L[i] - cbkyuka[i])) + cbkyuka[i])) + (12.0 * cbkyukp[i] * (L[i] - cbkyuka[i]) * Pow(L[i], 2.0) * nu[i])) / (Pow(L[i], 3.0) * (1.0 + (12.0 * nu[i])))) + ((6.0 * cbkyukmj[i] * cbkyuka[i] * (L[i] - cbkyuka[i])) / (Pow(L[i], 3.0) * (1.0 + (12.0 * nu[i]))));
                qussucizgi[i, 5] = (-(cbkyukw[i] * Pow(L[i], 2.0)) / 12.0) - (((cbkyukp[i] * Pow(cbkyuka[i], 2.0) * (L[i] - cbkyuka[i])) + (cbkyukp[i] * (L[i] - cbkyuka[i]) * cbkyuka[i] * 6.0 * nu[i] * L[i])) / (Pow(L[i], 2.0) + (12.0 * Pow(L[i], 2.0) * nu[i]))) + (((cbkyukmj[i] * cbkyuka[i]) / Pow(L[i], 2.0)) * ((((3 * cbkyuka[i]) - (2.0 * L[i])) + (12.0 * L[i] * nu[i])) / (1.0 + (12.0 * nu[i]))));

                qussu[i, 0] = ((cbka[i] * cbke[i]) / L[i]) * ((Cos(aci[i] - acidgmrad[cbki[i] - 1]) * Djyeni[i, 0]) + (Sin(aci[i] - acidgmrad[cbki[i] - 1]) * Djyeni[i, 1]) - (Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * Djyeni[i, 3]) - (Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * Djyeni[i, 4]));
                qussu[i, 1] = (katc[i] * ((12.0 * cbke[i] * cbkat[i]) / Pow(L[i], 3.0))) * ((-Sin(aci[i] - acidgmrad[cbki[i] - 1]) * Djyeni[i, 0]) + (Cos(aci[i] - acidgmrad[cbki[i] - 1]) * Djyeni[i, 1]) + (Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * Djyeni[i, 3]) - (Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * Djyeni[i, 4])) + ((katc[i] * ((6.0 * cbke[i] * cbkat[i]) / Pow(L[i], 2.0))) * (Djyeni[i, 2] + Djyeni[i, 5]));
                qussu[i, 2] = (katc[i] * ((6.0 * cbke[i] * cbkat[i]) / Pow(L[i], 2.0))) * ((-Sin(aci[i] - acidgmrad[cbki[i] - 1]) * Djyeni[i, 0]) + (Cos(aci[i] - acidgmrad[cbki[i] - 1]) * Djyeni[i, 1]) + (Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * Djyeni[i, 3]) - (Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * Djyeni[i, 4])) + (katb[i] * ((4 * cbke[i] * cbkat[i]) / L[i]) * Djyeni[i, 2]) + (kata[i] * ((2 * cbke[i] * cbkat[i]) / L[i]) * Djyeni[i, 5]);
                qussu[i, 3] = -qussu[i, 0];
                qussu[i, 4] = -qussu[i, 1];
                qussu[i, 5] = (katc[i] * ((6.0 * cbke[i] * cbkat[i]) / Pow(L[i], 2.0))) * ((-Sin(aci[i] - acidgmrad[cbki[i] - 1]) * Djyeni[i, 0]) + (Cos(aci[i] - acidgmrad[cbki[i] - 1]) * Djyeni[i, 1]) + (Sin(aci[i] - acidgmrad[cbkk[i] - 1]) * Djyeni[i, 3]) - (Cos(aci[i] - acidgmrad[cbkk[i] - 1]) * Djyeni[i, 4])) + (katb[i] * (4 * cbke[i] * cbkat[i] / L[i]) * Djyeni[i, 5]) + (kata[i] * ((2 * cbke[i] * cbkat[i]) / L[i]) * Djyeni[i, 2]);

                qcubuk[i, 0] = qussucizgi[i, 0] + qussu[i, 0];
                qcubuk[i, 1] = qussucizgi[i, 1] + qussu[i, 1];
                qcubuk[i, 2] = qussucizgi[i, 2] + qussu[i, 2];
                qcubuk[i, 3] = qussucizgi[i, 3] + qussu[i, 3];
                qcubuk[i, 4] = qussucizgi[i, 4] + qussu[i, 4];
                qcubuk[i, 5] = qussucizgi[i, 5] + qussu[i, 5];
            }

            //sonuclar

            cbknolaryaz = new TextBlock[cbksay];
            delxtosc = new TextBlock[cbksay];
            delytosc = new TextBlock[cbksay];
            Ltosc = new TextBlock[cbksay];
            acitosc = new TextBlock[cbksay];
            gtosc = new TextBlock[cbksay];
            nutosc = new TextBlock[cbksay];

            delxsc.Text = "DelX(" + s3uzunlukbrm + ")";
            delysc.Text = "DelY(" + s3uzunlukbrm + ")";
            Lsc.Text = "L(" + s3uzunlukbrm + ")";
            gsc.Text = "G(" + s3kuvvetbrm + "/" + s3uzunlukbrm;

            dgmnolaryaz = new TextBlock[dgmsay];
            deputosc = new TextBlock[dgmsay];
            depvtosc = new TextBlock[dgmsay];
            deptetatosc = new TextBlock[dgmsay];

            depusc.Text = "U(" + s3uzunlukbrm + ")";
            depvsc.Text = "V(" + s3uzunlukbrm + ")";

            cbknolaryaz2 = new TextBlock[cbksay];
            cbkkuvnitosc = new TextBlock[cbksay];
            cbkkuvsitosc = new TextBlock[cbksay];
            cbkkuvmitosc = new TextBlock[cbksay];
            cbkkuvnktosc = new TextBlock[cbksay];
            cbkkuvsktosc = new TextBlock[cbksay];
            cbkkuvmktosc = new TextBlock[cbksay];

            cbkkuvnisc.Text = "Ni(" + s3kuvvetbrm + ")";
            cbkkuvsisc.Text = "Si(" + s3kuvvetbrm + ")";
            cbkkuvmisc.Text = "Mi(" + s3kuvvetbrm + s3uzunlukbrm + ")";
            cbkkuvnksc.Text = "Nk(" + s3kuvvetbrm + ")";
            cbkkuvsksc.Text = "Sk(" + s3kuvvetbrm + ")";
            cbkkuvmksc.Text = "Mk(" + s3kuvvetbrm + s3uzunlukbrm + ")";

            for (int i = 0; i < cbksay; i++)
            {
                double konumust = i * 40;

                cbknolaryaz[i] = new TextBlock
                {
                    Name = "cbknolar" + i.ToString(),
                    Text = (i + 1).ToString() + " . Çubuk",
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar")
                };
                cbknolar.Children.Add(cbknolaryaz[i]);

                delxtosc[i] = new TextBlock
                {
                    Name = "delx" + i.ToString(),
                    Text = Convert.ToString(Round(delx[i], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                delxler.Children.Add(delxtosc[i]);

                delytosc[i] = new TextBlock
                {
                    Name = "dely" + i.ToString(),
                    Text = Convert.ToString(Round(dely[i], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                delyler.Children.Add(delytosc[i]);

                Ltosc[i] = new TextBlock
                {
                    Name = "L" + i.ToString(),
                    Text = Convert.ToString(Round(L[i], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                Ller.Children.Add(Ltosc[i]);

                acitosc[i] = new TextBlock
                {
                    Name = "Aci" + i.ToString(),
                    Text = Convert.ToString(Round(aci[i] * 180 / PI, 0)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                acilar.Children.Add(acitosc[i]);

                gtosc[i] = new TextBlock
                {
                    Name = "G" + i.ToString(),
                    Text = Convert.ToString(Round(g[i], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                gler.Children.Add(gtosc[i]);

                nutosc[i] = new TextBlock
                {
                    Name = "Aci" + i.ToString(),
                    Text = Convert.ToString(Round(nu[i], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                nular.Children.Add(nutosc[i]);
            }

            for (int i = 0; i < dgmsay; i++)
            {
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

                deputosc[i] = new TextBlock
                {
                    Name = "depu" + i.ToString(),
                    Text = Convert.ToString(Round(Xu[i], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                depular.Children.Add(deputosc[i]);

                depvtosc[i] = new TextBlock
                {
                    Name = "depv" + i.ToString(),
                    Text = Convert.ToString(Round(Xv[i], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                depvler.Children.Add(depvtosc[i]);

                deptetatosc[i] = new TextBlock
                {
                    Name = "depteta" + i.ToString(),
                    Text = Convert.ToString(Round(Xteta[i], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                deptetalar.Children.Add(deptetatosc[i]);
            }

            for (int i = 0; i < cbksay; i++)
            {
                double konumust = i * 40;

                cbknolaryaz2[i] = new TextBlock
                {
                    Name = "cbknolar2" + i.ToString(),
                    Text = (i + 1).ToString() + " . Çubuk",
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar")
                };
                cbknolar2.Children.Add(cbknolaryaz2[i]);

                cbkkuvnitosc[i] = new TextBlock
                {
                    Name = "ni" + i.ToString(),
                    Text = Convert.ToString(Round(qcubuk[i, 0], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                cbkkuvniler.Children.Add(cbkkuvnitosc[i]);

                cbkkuvsitosc[i] = new TextBlock
                {
                    Name = "si" + i.ToString(),
                    Text = Convert.ToString(Round(qcubuk[i, 1], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                cbkkuvsiler.Children.Add(cbkkuvsitosc[i]);

                cbkkuvmitosc[i] = new TextBlock
                {
                    Name = "mi" + i.ToString(),
                    Text = Convert.ToString(Round(qcubuk[i, 2], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                cbkkuvmiler.Children.Add(cbkkuvmitosc[i]);

                cbkkuvnktosc[i] = new TextBlock
                {
                    Name = "nk" + i.ToString(),
                    Text = Convert.ToString(Round(qcubuk[i, 3], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                cbkkuvnkler.Children.Add(cbkkuvnktosc[i]);

                cbkkuvsktosc[i] = new TextBlock
                {
                    Name = "sk" + i.ToString(),
                    Text = Convert.ToString(Round(qcubuk[i, 4], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                cbkkuvskler.Children.Add(cbkkuvsktosc[i]);

                cbkkuvmktosc[i] = new TextBlock
                {
                    Name = "mk" + i.ToString(),
                    Text = Convert.ToString(Round(qcubuk[i, 5], 6)),
                    Margin = new Thickness(0, konumust, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    Style = (Style)FindResource("textblocklar3")
                };
                cbkkuvmkler.Children.Add(cbkkuvmktosc[i]);
            }
        }

        private void Bastan_Click(object sender, RoutedEventArgs e)
        {
            Sayfa1 sayfa1 = new Sayfa1();
            NavigationService.Navigate(sayfa1);
        }

        private void Yazdir1_Click(object sender, RoutedEventArgs e)
        {
            Yazdir1 yazdir1 = new Yazdir1();
            yazdir1.yaz1kbrm = s3kuvvetbrm;
            yazdir1.yaz1ubrm = s3uzunlukbrm;
            yazdir1.yaz1cbksay = cbksay;
            yazdir1.yaz1delx = new double[cbksay];
            yazdir1.yaz1dely = new double[cbksay];
            yazdir1.yaz1L = new double[cbksay];
            yazdir1.yaz1aci = new double[cbksay];
            yazdir1.yaz1g = new double[cbksay];
            yazdir1.yaz1n = new double[cbksay];

            for (int i = 0; i < cbksay; i++)
            {
                yazdir1.yaz1delx[i] = delx[i];
                yazdir1.yaz1dely[i] = dely[i];
                yazdir1.yaz1L[i] = L[i];
                yazdir1.yaz1aci[i] = aci[i] * 180 / PI;
                yazdir1.yaz1g[i] = g[i];
                yazdir1.yaz1n[i] = nu[i];
            }
            yazdir1.Show();
        }

        private void Yazdir2_Click(object sender, RoutedEventArgs e)
        {
            Yazdir2 yazdir2 = new Yazdir2();
            yazdir2.yaz2kbrm = s3kuvvetbrm;
            yazdir2.yaz2ubrm = s3uzunlukbrm;
            yazdir2.yaz2dgmsay = dgmsay;
            yazdir2.yaz2depu = new double[dgmsay];
            yazdir2.yaz2depv = new double[dgmsay];
            yazdir2.yaz2depteta = new double[dgmsay];

            for (int i = 0; i < dgmsay; i++)
            {
                yazdir2.yaz2depu[i] = Xu[i];
                yazdir2.yaz2depv[i] = Xv[i];
                yazdir2.yaz2depteta[i] = Xteta[i];

            }
            yazdir2.Show();
        }

        private void Yazdir3_Click(object sender, RoutedEventArgs e)
        {
            Yazdir3 yazdir3 = new Yazdir3();
            yazdir3.yaz3kbrm = s3kuvvetbrm;
            yazdir3.yaz3ubrm = s3uzunlukbrm;
            yazdir3.yaz3cbksay = cbksay;

            yazdir3.yaz3cbkkuvni = new double[cbksay];
            yazdir3.yaz3cbkkuvsi = new double[cbksay];
            yazdir3.yaz3cbkkuvmi = new double[cbksay];
            yazdir3.yaz3cbkkuvnk = new double[cbksay];
            yazdir3.yaz3cbkkuvsk = new double[cbksay];
            yazdir3.yaz3cbkkuvmk = new double[cbksay];

            for (int i = 0; i < cbksay; i++)
            {
                yazdir3.yaz3cbkkuvni[i] = qcubuk[i, 0];
                yazdir3.yaz3cbkkuvsi[i] = qcubuk[i, 1];
                yazdir3.yaz3cbkkuvmi[i] = qcubuk[i, 2];
                yazdir3.yaz3cbkkuvnk[i] = qcubuk[i, 3];
                yazdir3.yaz3cbkkuvsk[i] = qcubuk[i, 4];
                yazdir3.yaz3cbkkuvmk[i] = qcubuk[i, 5];
            }
            yazdir3.Show();
        }

        private void Kapat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
