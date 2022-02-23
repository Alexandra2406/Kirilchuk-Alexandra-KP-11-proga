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

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GRID();
            ToWin1_.Click += ToWin1_Click;
            ToWin2_.Click += ToWin2_Click_1;
            ToWin3_.Click += ToWin3_Click_1;
            ToWin4_.Click += ToWin4_Click_1;
            Exit.Click += Button_Click;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void ToWin1_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            Hide();
            w1.Show();
        }
        private void ToWin2_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            Hide();
            w2.Show();
        }
        private void ToWin3_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            Hide();
            w3.Show();
        }
        private void ToWin4_Click_1(object sender, RoutedEventArgs e)
        {
            Window4 w4 = new Window4();
            Hide();
            w4.Show();
        }
        Button ToWin1_, ToWin2_, ToWin3_, ToWin4_, Exit;
        private void GRID()
        {
            this.Title = "Menu";
            this.ResizeMode = ResizeMode.NoResize;
            Grid myGrid = new Grid();
            myGrid.Width = 800;
            myGrid.Height = 450;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Background = Brushes.LightSteelBlue;
            Label Wind = new Label();
            Wind.Content = "Menu";
            Wind.Foreground = Brushes.White;
            Wind.FontSize = 40;
            Wind.Margin = new Thickness(72, 12, 260, 0);
            Wind.VerticalAlignment = VerticalAlignment.Top;
            Wind.HorizontalAlignment = HorizontalAlignment.Center;
            Wind.Height = 62;
            Wind.Width = 445;
            myGrid.Children.Add(Wind);
            ToWin1_ = new Button();
            ToWin1_ = SettingsB(ToWin1_, 55, 240, 25, 35, 100, 0, 0, "List of Students");
            myGrid.Children.Add(ToWin1_);
            ToWin2_ = new Button();
            ToWin2_ = SettingsB(ToWin2_, 55, 240, 25, 35, 180, 0, 0, "Tic-Tac-Toe");
            myGrid.Children.Add(ToWin2_);
            ToWin3_ = new Button();
            ToWin3_ = SettingsB(ToWin3_, 55, 240, 25, 35, 260, 0, 0, "Simple calculator");
            myGrid.Children.Add(ToWin3_);
            ToWin4_ = new Button();
            ToWin4_ = SettingsB(ToWin4_, 55, 240, 25, 35, 340, 0, 0, "Data");
            myGrid.Children.Add(ToWin4_);
            Exit = new Button();
            Exit = SettingsB(Exit, 40, 115, 20, 340, 338, 0, 0, "Exit");
            myGrid.Children.Add(Exit);
            this.Content = myGrid;
            this.Show();
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
    }
}
