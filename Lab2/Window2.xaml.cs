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
using System.Windows.Controls.Primitives;
namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    ///
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            GRID();
            Choose0.Click += Choose0_Click;
            ChooseX.Click += ChooseX_Click;
            button[0, 0].Click += Button_Click;
            button[0, 1].Click += new RoutedEventHandler(Button_Click);
            button[0, 2].Click += new RoutedEventHandler(Button_Click);
            button[0, 3].Click += new RoutedEventHandler(Button_Click);
            button[0, 4].Click += new RoutedEventHandler(Button_Click);
            button[1, 0].Click += new RoutedEventHandler(Button_Click);
            button[1, 1].Click += new RoutedEventHandler(Button_Click);
            button[1, 2].Click += new RoutedEventHandler(Button_Click);
            button[1, 3].Click += new RoutedEventHandler(Button_Click);
            button[1, 4].Click += new RoutedEventHandler(Button_Click);
            button[2, 0].Click += new RoutedEventHandler(Button_Click);
            button[2, 1].Click += new RoutedEventHandler(Button_Click);
            button[2, 2].Click += new RoutedEventHandler(Button_Click);
            button[2, 3].Click += new RoutedEventHandler(Button_Click);
            button[2, 4].Click += new RoutedEventHandler(Button_Click);
            button[3, 0].Click += new RoutedEventHandler(Button_Click);
            button[3, 1].Click += new RoutedEventHandler(Button_Click);
            button[3, 2].Click += new RoutedEventHandler(Button_Click);
            button[3, 3].Click += new RoutedEventHandler(Button_Click);
            button[3, 4].Click += new RoutedEventHandler(Button_Click);
            button[4, 0].Click += new RoutedEventHandler(Button_Click);
            button[4, 1].Click += new RoutedEventHandler(Button_Click);
            button[4, 2].Click += new RoutedEventHandler(Button_Click);
            button[4, 3].Click += new RoutedEventHandler(Button_Click);
            button[4, 4].Click += new RoutedEventHandler(Button_Click);
            ToMain.Click += ToMainW_Click;
        }
        Button[,] button;
        Button Choose0, ChooseX, ToMain;
        private void GRID()
        {
            this.Title = "Tic-Tac-Toe";
            this.ResizeMode = ResizeMode.NoResize;
            Grid myGrid = new Grid();
            myGrid.Width = 800;
            myGrid.Height = 450;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Background = Brushes.LightSteelBlue;
            Label Wind = new Label();
            Wind.Content = "Tic-Tac-Toe";
            Wind.Foreground = Brushes.White;
            Wind.FontSize = 40;
            Wind.Margin = new Thickness(72, 12, 260, 0);
            Wind.VerticalAlignment = VerticalAlignment.Top;
            Wind.HorizontalAlignment = HorizontalAlignment.Center;
            Wind.Height = 62;
            Wind.Width = 445;
            myGrid.Children.Add(Wind);
            ToMain = new Button();
            ToMain = SettingsB(ToMain, 52, 170, 20, 572, 20, 0, 0, "To Main");
            myGrid.Children.Add(ToMain);
            UniformGrid Inside = new UniformGrid();
            Inside.Width = 250;
            Inside.Height = 250;
            Inside.HorizontalAlignment = HorizontalAlignment.Left;
            Inside.VerticalAlignment = VerticalAlignment.Center;
            Inside.Background = Brushes.Thistle;
            Inside.Margin = new Thickness(110, 125, 0, 55);
            Inside.Rows = 5;
            Inside.Columns = 5;            
            button = new Button[5, 5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    button[i, j] = new Button();
                    button[i, j] = Settings(button[i, j]);
                    Inside.Children.Add(button[i, j]);                    
                }
            myGrid.Children.Add(Inside); 
            Choose0 = new Button();
            Choose0 = Settings(Choose0);
            Choose0.Content = "       0       ";
            ChooseX = new Button();
            ChooseX = Settings(ChooseX);
            ChooseX.Content = "       x       ";
            ComboBox Case = new ComboBox();
            Case.Items.Add(ChooseX);
            Case.Items.Add(Choose0);
            Case.Margin = new Thickness(595, 250, 0, 0);
            Case.Height = 35;
            Case.Width = 95;
            Case.VerticalAlignment = VerticalAlignment.Top;
            myGrid.Children.Add(Case);
            Label Ch = new Label();
            Ch.Content = "Choose who you are";
            Ch.Foreground = Brushes.White;
            Ch.FontSize = 25;
            Ch.Margin = new Thickness(530, 190, 0, 0);
            Ch.VerticalAlignment = VerticalAlignment.Top;
            Ch.HorizontalAlignment = HorizontalAlignment.Center;
            Ch.RenderTransformOrigin = new Point(0.5, 0.5);
            myGrid.Children.Add(Ch);
            this.Content = myGrid;
            this.Show();
        }
        private Button Settings(Button button)
        {
            button.FontSize = 20;
            button.Background = Brushes.Thistle;
            button.Foreground = Brushes.White;
            button.BorderBrush = Brushes.White;
            button.Content = "";
            return button;
        }
        private Button SettingsB(Button button, int height, int width, int fontsize, int a, int b, int c, int d, string str)
        {
            button.Content = str;
            button.Margin = new Thickness(a, b, c, d);
            button.Height = height;
            button.Width = width;
            button.FontSize = fontsize;
            button.Background = Brushes.Thistle;
            button.Foreground = Brushes.White;
            button.BorderBrush = Brushes.White;
            button.HorizontalAlignment = HorizontalAlignment.Left;
            button.VerticalAlignment = VerticalAlignment.Top;
            return button;
        }
        private void ToMainW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        int a = -1;
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
                Result0();
            }
            else if (a == 0)
            {
                var num = sender as Button;
                num.Content = "x";
                Comp_0(ref step);
                ResultX();
            }
            else return;
        }
        public void Comp_x(ref int step)
        {
            if (step == 0)
            {
                int b = rnd.Next(5);
                if (b == 0) button[2, 2].Content = "x";
                else if (b == 1) button[0, 0].Content = "x";
                else if (b == 2) button[0, 4].Content = "x";
                else if (b == 3) button[4, 0].Content = "x";
                else if (b == 4) button[4, 4].Content = "x";
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
            if (step == 0)
            {
                if (button[3, 3].Content == "")
                {
                    button[3, 3].Content = "0";
                    step++;
                }
                else
                {
                    int b = rnd.Next(4);
                    if (b == 1) button[0, 4].Content = "0";
                    else if (b == 2) button[4, 0].Content = "0";
                    else if (b == 3) button[4, 4].Content = "0";
                    else if (b == 4) button[0, 0].Content = "0";
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
        private void ResultX()
        {
            bool flag, sta;
            for (int i = 0; i < 4; i++)
            {
                flag = true; sta = false;
                for (int j = 0; j < 4; j++)
                {
                    if (button[i, j].Content == "x" && button[i, j].Content == button[i + 1, j].Content) sta = true;
                    flag &= sta;
                }
                if (flag) { MessageBox.Show("You win!"); break; }
            }
            flag = true; sta = false;
            for (int i = 0; i < 4; i++)
            {
                flag = true; sta = false;
                for (int j = 0; j < 4; j++)
                {
                    if (button[i, j].Content == "x" && button[i, j].Content == button[i, j + 1].Content) sta = true;
                    flag &= sta;
                }
                if (flag) { MessageBox.Show("You win!"); break; }
            }
            flag = true; sta = false;
            for (int i = 0; i < 4; i++)
            {
                if (button[i, i].Content == "x" && button[i, i].Content == button[i + 1, i + 1].Content) sta = true;
                flag &= sta;
            }
            if (flag) { MessageBox.Show("You win!"); return; }
            flag = true; sta = false;
            for (int i = 0; i < 4; i++)
            {
                if (i == 0 && button[0, 4].Content == "x" && button[0, 4].Content == button[1, 3].Content) sta = true;
                else if (button[i, 4 - i].Content == "x" && button[i, 4 - i].Content == button[i + 1, 4 - i + 1].Content) sta = true;
                flag &= sta;
            }
            if (flag) { MessageBox.Show("You win!"); return; }
        }
        private void Result0()
        {
            bool flag, sta;
            for (int i = 0; i < 4; i++)
            {
                flag = true; sta = false;
                for (int j = 0; j < 4; j++)
                {
                    if (button[i, j].Content == "0" && button[i, j].Content == button[i + 1, j].Content) sta = true;
                    flag &= sta;
                }
                if (flag) { MessageBox.Show("You win!"); break; }
            }
            flag = true; sta = false;
            for (int i = 0; i < 4; i++)
            {
                flag = true; sta = false;
                for (int j = 0; j < 4; j++)
                {
                    if (button[i, j].Content == "0" && button[i, j].Content == button[i, j + 1].Content) sta = true;
                    flag &= sta;
                }
                if (flag) { MessageBox.Show("You win!"); break; }
            }
            flag = true; sta = false;
            for (int i = 0; i < 4; i++)
            {
                if (button[i, i].Content == "0" && button[i, i].Content == button[i + 1, i + 1].Content) sta = true;
                flag &= sta;
            }
            if (flag) { MessageBox.Show("You win!"); return; }
            flag = true; sta = false;
            for (int i = 0; i < 4; i++)
            {
                if(i == 0 && button[0, 4].Content == "0" && button[0, 4].Content == button[1, 3].Content) sta = true;
                else if (button[i, 4 - i].Content == "0" && button[i, 4 - i].Content == button[i + 1, 4 - i + 1].Content) sta = true;
                flag &= sta;
            }
            if (flag) { MessageBox.Show("You win!"); return; }
        }
    }
}