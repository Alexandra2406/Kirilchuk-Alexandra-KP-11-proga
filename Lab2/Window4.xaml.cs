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

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        private int StartWidth;
        private int StartHeight;
        private int StartFontSize, StartFontSize2;
        Label Data, Wind;
        Button ToMain;
        public Window4()
        {
            InitializeComponent();
            Data = new Label();
            StartWidth = (int)this.Width;
            StartHeight = (int)this.Height;
            StartFontSize = 35;
            Data.FontSize = StartFontSize;
            Data.Foreground = Brushes.White;
            Data.Background = Brushes.Thistle;
            Data.Margin = new Thickness(59, 180, 0, 0);
            myGrid.Children.Add(Data);
            myGrid.Background = Brushes.LightSteelBlue;
            Wind = new Label();
            Wind.Content = "Data about the developer";
            Wind.Foreground = Brushes.White;
            StartFontSize2 = 40;
            Wind.FontSize = StartFontSize2;
            Wind.Margin = new Thickness(30, 12, 65, 0);
            Wind.VerticalAlignment = VerticalAlignment.Top;
            Wind.HorizontalAlignment = HorizontalAlignment.Center;
            Wind.Height = 70;
            Wind.Width = 690;
            myGrid.Children.Add(Wind);
            ToMain = new Button();
            ToMain = SettingsB(ToMain, 52, 170, 20, 572, 20, 0, 0, "To Main");
            ToMain.Click += ToMainW_Click;
            myGrid.Children.Add(ToMain);
        }

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MyWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double val = Math.Max(1.0 * StartWidth / this.Width, 1.0 * StartHeight / this.Height);
            Data.FontSize = (int)(1.0 * StartFontSize / val);
            Data.Height = (int)this.Height/2;
            Data.Width = (int)this.Width/2 + 100;
            Data.Content = "Kirilchuk Alexandra KP-11 2022";
            Data.Margin = new Thickness((int)this.Height / 4 - 10, (int)this.Height / 4 + 15, 0, 0);
            Wind.FontSize = (int)(1.0 * StartFontSize2 / val);
            Wind.Height = (int)this.Height/2;
            Wind.Width = (int)this.Width/2 + 100;
            Wind.Margin = new Thickness(30 + (int)this.Height / 12, 12 + (int)this.Height / 10, 65 + (int)this.Height / 10, 0);
            ToMain.FontSize = (int)(1.0 * StartFontSize2 / val);
            ToMain.Height = (int)this.Height/5;
            ToMain.Width = (int)this.Width/5;
            ToMain.Margin = new Thickness((int)this.Height /2, 15 + (int)this.Height / 10, 15, 0);
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
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.VerticalAlignment = VerticalAlignment.Top;
            return button;
        }
        private void ToMainW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

    }
}
