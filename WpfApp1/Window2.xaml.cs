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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>


    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();                       
        }
        private void ToMainW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void Choose0_Click(object sender, RoutedEventArgs e)
        {
            var num = sender as Button;
            num.Content = "0";
        }
        private void ChooseX_Click(object sender, RoutedEventArgs e)
        {
            var num = sender as Button;
            num.Content = "x";
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            Container.Children.Cast<ComboBox>().ToList().ForEach(combobox =>
            {
                if (combobox.Text != "")
                {
                    if ((A.Text == "x" && A.Text == B.Text && B.Text == C.Text && C.Text == D.Text && D.Text == E.Text) || (F.Text == "x" && F.Text == G.Text && G.Text == H.Text && H.Text == I.Text && I.Text == J.Text) || (K.Text == "x" && K.Text == L.Text && L.Text == M.Text && M.Text == N.Text && N.Text == P.Text) || (Q.Text == "x" && Q.Text == R.Text && R.Text == S.Text && S.Text == T.Text && T.Text == U.Text) || (V.Text == "x" && V.Text == W.Text && W.Text == X.Text && X.Text == Y.Text && Y.Text == Z.Text))
                    {
                        Result_L.Content = "Player 'x' won";
                    }
                    else if ((A.Text == "0" && A.Text == B.Text && B.Text == C.Text && C.Text == D.Text && D.Text == E.Text) || (F.Text == "0" && F.Text == G.Text && G.Text == H.Text && H.Text == I.Text && I.Text == J.Text) || (K.Text == "0" && K.Text == L.Text && L.Text == M.Text && M.Text == N.Text && N.Text == P.Text) || (Q.Text == "0" && Q.Text == R.Text && R.Text == S.Text && S.Text == T.Text && T.Text == U.Text) || (V.Text == "09" && V.Text == W.Text && W.Text == X.Text && X.Text == Y.Text && Y.Text == Z.Text))
                    {
                        Result_L.Content = "Player '0' won";
                    }
                    else if ((A.Text == "x" && A.Text == F.Text && F.Text == K.Text && K.Text == Q.Text && Q.Text == V.Text) || (B.Text == "x" && B.Text == G.Text && G.Text == L.Text && L.Text == R.Text && R.Text == W.Text) || (C.Text == "x" && C.Text == H.Text && H.Text == M.Text && M.Text == S.Text && S.Text == X.Text) || (D.Text == "x" && D.Text == I.Text && I.Text == N.Text && N.Text == T.Text && T.Text == Y.Text) || (E.Text == "x" && E.Text == J.Text && J.Text == P.Text && P.Text == U.Text && U.Text == Z.Text))
                    {
                        Result_L.Content = "Player 'x' won";
                    }
                    else if ((A.Text == "0" && A.Text == F.Text && F.Text == K.Text && K.Text == Q.Text && Q.Text == V.Text) || (B.Text == "0" && B.Text == G.Text && G.Text == L.Text && L.Text == R.Text && R.Text == W.Text) || (C.Text == "0" && C.Text == H.Text && H.Text == M.Text && M.Text == S.Text && S.Text == X.Text) || (D.Text == "0" && D.Text == I.Text && I.Text == N.Text && N.Text == T.Text && T.Text == Y.Text) || (E.Text == "0" && E.Text == J.Text && J.Text == P.Text && P.Text == U.Text && U.Text == Z.Text))
                    {
                        Result_L.Content = "Player '0' won";
                    }
                    else if ((A.Text == "x" && A.Text == G.Text && G.Text == M.Text && M.Text == T.Text && T.Text == Z.Text) || (E.Text == "x" && E.Text == I.Text && I.Text == M.Text && M.Text == R.Text && R.Text == V.Text))
                    {
                        Result_L.Content = "Player 'x' won";
                    }
                    else if ((A.Text == "0" && A.Text == G.Text && G.Text == M.Text && M.Text == T.Text && T.Text == Z.Text) || (E.Text == "0" && E.Text == I.Text && I.Text == M.Text && M.Text == R.Text && R.Text == V.Text))
                    {
                        Result_L.Content = "Player '0' won";
                    }
                    else
                        Result_L.Content = "Dead Heat";
                }
                else
                    Result_L.Content = "The game is not over";
            });
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Container.Children.Cast<ComboBox>().ToList().ForEach(combobox =>
            {
                combobox.Text = string.Empty;
            });
            Result_L.Content = string.Empty;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Window5 w5 = new Window5();
            Hide();
            w5.Show();
        }
    }
}
