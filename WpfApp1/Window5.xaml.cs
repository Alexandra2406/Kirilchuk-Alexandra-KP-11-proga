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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        private void ToMainW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        public Window5()
        {
            InitializeComponent();
        }
        int a;
        private void Choose0_Click(object sender, RoutedEventArgs e)
        {
            a = 1;
            Comp_x(ref step);
        }
        private void ChooseX_Click(object sender, RoutedEventArgs e)
        {
            a = 0;
        }
        int step = 0;
        Random rnd = new Random();

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (a == 1)
            {
                var num = sender as Button;
                num.Content = "0";
                Comp_x(ref step);
                Result();
            }
            else if (a == 0)
            {
                var num = sender as Button;
                num.Content = "x";
                Comp_0(ref step);
                Result();
            }
        }
        public void Comp_x(ref int step)
        {
            Button[,] button = new Button[5, 5]
       {
            { A, B, C, D, E },
            { F, G, H, I, J },
            { K, L, M, N, P },
            { Q, R, S, T, U },
            { V, W, X, Y, Z }
       };
            if (step == 0)
            {
                int b = rnd.Next(5);
                if (b == 0) M.Content = "x";
                else if (b == 1) A.Content = "x";
                else if (b == 2) E.Content = "x";
                else if (b == 3) V.Content = "x";
                else if (b == 4) Z.Content = "x";
                step++;
            }
            else if (step > 0)
            {
                bool b = true;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i == j)
                        {
                            if (i <= 2 && button[i, j].Content == button[i + 1, j + 1] && button[i, j].Content == "0" && button[i + 2, j + 2].Content == "") { button[i + 2, j + 2].Content = "x"; b = false; break; }
                            else if (i >= 3 && button[i, j].Content == button[i + 1, j + 1] && button[i, j].Content == "0" && button[i - 1, j - 1].Content == "") { button[i - 1, j - 1].Content = "x"; b = false; break; }

                        }
                        else if (i + 1 == j - 1)
                        {
                            if (i < 2 && j > 2 && button[i + 1, j - 1].Content == button[i + 2, j - 2] && button[i + 1, j - 1].Content == "0" && button[i + 3, j - 3].Content == "") { button[i + 3, j - 3].Content = "x"; b = false; break; }
                            else if (i >= 2 && j <= 2 && button[i + 1, j - 1].Content == button[i + 2, j - 2] && button[i + 1, j - 1].Content == "0" && button[i - 1, j + 1].Content == "") { button[i - 1, j + 1].Content = "x"; b = false; break; }
                        }
                        else if (i <= 2 && button[i, j].Content == button[i + 1, j].Content && button[i, j].Content == "0" && button[i + 2, j].Content == "") { button[i + 2, j].Content = "x"; b = false; break; }
                        else if (i < 2 && button[i, j].Content == button[i + 1, j].Content && button[i, j].Content == "0" && button[i + 3, j].Content == "") { button[i + 3, j].Content = "x"; b = false; break; }
                        else if (i >= 3 && button[i, j].Content == button[i + 1, j].Content && button[i, j].Content == "0" && button[i - 1, j].Content == "") { button[i - 1, j].Content = "x"; b = false; break; }
                        else if (i >= 3 && button[i, j].Content == button[i + 1, j].Content && button[i, j].Content == "0" && button[i - 2, j].Content == "") { button[i - 2, j].Content = "x"; b = false; break; }
                        else if (j <= 2 && button[i, j].Content == button[i, j + 1].Content && button[i, j].Content == "0" && button[i, j + 2].Content == "") { button[i, j + 2].Content = "x"; b = false; break; }
                        else if (j < 2 && button[i, j].Content == button[i, j + 1].Content && button[i, j].Content == "0" && button[i, j + 3].Content == "") { button[i, j + 3].Content = "x"; b = false; break; }
                        else if (j >= 3 && button[i, j].Content == button[i, j + 1].Content && button[i, j].Content == "0" && button[i, j - 1].Content == "") { button[i, j - 1].Content = "x"; b = false; break; }
                        else if (j >= 3 && button[i, j].Content == button[i, j + 1].Content && button[i, j].Content == "0" && button[i, j - 2].Content == "") { button[i, j - 2].Content = "x"; b = false; break; }

                    }
                }
                if (b)
                {
                    int i = rnd.Next(5); int j = rnd.Next(5);
                    if (button[i, j].Content == "") { button[i, j].Content = "x"; }
                    else return;
                }
            }

        }
        private void Comp_0(ref int step)
        {
            Button[,] button = new Button[5, 5]
     {
            { A, B, C, D, E },
            { F, G, H, I, J },
            { K, L, M, N, P },
            { Q, R, S, T, U },
            { V, W, X, Y, Z }
     };
            if (step == 0)
            {
                if (M.Content == "")
                {
                    M.Content = "0";
                    step++;
                }
                else
                {
                    int b = rnd.Next(4);
                    if (b == 1) A.Content = "0";
                    else if (b == 2) E.Content = "0";
                    else if (b == 3) V.Content = "0";
                    else if (b == 4) Z.Content = "0";
                    step++;
                }
            }
            else if (step > 0)
            {
                bool b = true;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i == j)
                        {
                            if (i <= 2 && button[i, j].Content == button[i + 1, j + 1] && button[i, j].Content == "x" && button[i + 2, j + 2].Content == "") { button[i + 2, j + 2].Content = "0"; b = false; break; }
                            else if (i >= 3 && button[i, j].Content == button[i + 1, j + 1] && button[i, j].Content == "x" && button[i - 1, j - 1].Content == "") { button[i - 1, j - 1].Content = "0"; b = false; break; }

                        }
                        else if (i + 1 == j - 1)
                        {
                            if (i < 2 && j > 2 && button[i + 1, j - 1].Content == button[i + 2, j - 2] && button[i + 1, j - 1].Content == "x" && button[i + 3, j - 3].Content == "") { button[i + 3, j - 3].Content = "x"; b = false; break; }
                            else if (i >= 2 && j <= 2 && button[i + 1, j - 1].Content == button[i + 2, j - 2] && button[i + 1, j - 1].Content == "x" && button[i - 1, j + 1].Content == "") { button[i - 1, j + 1].Content = "x"; b = false; break; }
                        }
                        else if (i <= 2 && button[i, j].Content == button[i + 1, j].Content && button[i, j].Content == "x" && button[i + 2, j].Content == "") { button[i + 2, j].Content = "0"; b = false; break; }
                        else if (i < 2 && button[i, j].Content == button[i + 1, j].Content && button[i, j].Content == "x" && button[i + 3, j].Content == "") { button[i + 3, j].Content = "0"; b = false; break; }
                        else if (i >= 3 && button[i, j].Content == button[i + 1, j].Content && button[i, j].Content == "x" && button[i - 1, j].Content == "") { button[i - 1, j].Content = "0"; b = false; break; }
                        else if (i >= 3 && button[i, j].Content == button[i + 1, j].Content && button[i, j].Content == "x" && button[i - 2, j].Content == "") { button[i - 2, j].Content = "0"; b = false; break; }
                        else if (j <= 2 && button[i, j].Content == button[i, j + 1].Content && button[i, j].Content == "x" && button[i, j + 2].Content == "") { button[i, j + 2].Content = "0"; b = false; break; }
                        else if (j < 2 && button[i, j].Content == button[i, j + 1].Content && button[i, j].Content == "x" && button[i, j + 3].Content == "") { button[i, j + 3].Content = "0"; b = false; break; }
                        else if (j >= 3 && button[i, j].Content == button[i, j + 1].Content && button[i, j].Content == "x" && button[i, j - 1].Content == "") { button[i, j - 1].Content = "0"; b = false; break; }
                        else if (j >= 3 && button[i, j].Content == button[i, j + 1].Content && button[i, j].Content == "x" && button[i, j - 2].Content == "") { button[i, j - 2].Content = "0"; b = false; break; }

                    }
                }
                if (b)
                {
                    int i = rnd.Next(5); int j = rnd.Next(5);
                    if (button[i, j].Content == "") { button[i, j].Content = "0"; }
                    else return;
                }
            }
        }
        private void Result()
        {

            if ((A.Content == "x" && A.Content == B.Content && B.Content == C.Content && C.Content == D.Content && D.Content == E.Content) || (F.Content == "x" && F.Content == G.Content && G.Content == H.Content && H.Content == I.Content && I.Content == J.Content) || (K.Content == "x" && K.Content == L.Content && L.Content == M.Content && M.Content == N.Content && N.Content == P.Content) || (Q.Content == "x" && Q.Content == R.Content && R.Content == S.Content && S.Content == T.Content && T.Content == U.Content) || (V.Content == "x" && V.Content == W.Content && W.Content == X.Content && X.Content == Y.Content && Y.Content == Z.Content))
            {
                MessageBox.Show("Player 'x' won", "Result");
            }
            else if ((A.Content == "0" && A.Content == B.Content && B.Content == C.Content && C.Content == D.Content && D.Content == E.Content) || (F.Content == "0" && F.Content == G.Content && G.Content == H.Content && H.Content == I.Content && I.Content == J.Content) || (K.Content == "0" && K.Content == L.Content && L.Content == M.Content && M.Content == N.Content && N.Content == P.Content) || (Q.Content == "0" && Q.Content == R.Content && R.Content == S.Content && S.Content == T.Content && T.Content == U.Content) || (V.Content == "0" && V.Content == W.Content && W.Content == X.Content && X.Content == Y.Content && Y.Content == Z.Content))
            {
                MessageBox.Show("Player '0' won", "Result");
            }
            else if ((A.Content == "x" && A.Content == F.Content && F.Content == K.Content && K.Content == Q.Content && Q.Content == V.Content) || (B.Content == "x" && B.Content == G.Content && G.Content == L.Content && L.Content == R.Content && R.Content == W.Content) || (C.Content == "x" && C.Content == H.Content && H.Content == M.Content && M.Content == S.Content && S.Content == X.Content) || (D.Content == "x" && D.Content == I.Content && I.Content == N.Content && N.Content == T.Content && T.Content == Y.Content) || (E.Content == "x" && E.Content == J.Content && J.Content == P.Content && P.Content == U.Content && U.Content == Z.Content))
            {
                MessageBox.Show("Player 'x' won", "Result");
            }
            else if ((A.Content == "0" && A.Content == F.Content && F.Content == K.Content && K.Content == Q.Content && Q.Content == V.Content) || (B.Content == "0" && B.Content == G.Content && G.Content == L.Content && L.Content == R.Content && R.Content == W.Content) || (C.Content == "0" && C.Content == H.Content && H.Content == M.Content && M.Content == S.Content && S.Content == X.Content) || (D.Content == "0" && D.Content == I.Content && I.Content == N.Content && N.Content == T.Content && T.Content == Y.Content) || (E.Content == "0" && E.Content == J.Content && J.Content == P.Content && P.Content == U.Content && U.Content == Z.Content))
            {
                MessageBox.Show("Player '0' won", "Result");
            }
            else if ((A.Content == "x" && A.Content == G.Content && G.Content == M.Content && M.Content == T.Content && T.Content == Z.Content) || (E.Content == "x" && E.Content == I.Content && I.Content == M.Content && M.Content == R.Content && R.Content == V.Content))
            {
                MessageBox.Show("Player 'x' won", "Result");
            }
            else if ((A.Content == "0" && A.Content == G.Content && G.Content == M.Content && M.Content == T.Content && T.Content == Z.Content) || (E.Content == "0" && E.Content == I.Content && I.Content == M.Content && M.Content == R.Content && R.Content == V.Content))
            {
                MessageBox.Show("Player '0' won", "Result");
            }
            else if(A.Content != "" && B.Content != "" && C.Content != "" && D.Content != "" && E.Content != "" && F.Content != "" && G.Content != "" && H.Content != "" && I.Content != "" && J.Content != "" && K.Content != "" && L.Content != "" && M.Content != "" && N.Content != "" && P.Content != "" && Q.Content != "" && R.Content != "" && S.Content != "" && T.Content != "" && U.Content != "" && V.Content != "" && W.Content != "" && X.Content != "" && Y.Content != "" && Z.Content != "" )
                MessageBox.Show("Dead Heat", "Result");
        }
    }
}
    
