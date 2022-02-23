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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {

        public Window3()
        {
            InitializeComponent();
            GRID();
            button[0, 0].Click += new RoutedEventHandler(Number_Click);
            button[0, 1].Click += new RoutedEventHandler(Number_Click);
            button[0 ,2].Click += new RoutedEventHandler(Number_Click);
            button[1, 0].Click += new RoutedEventHandler(Number_Click);
            button[1, 1].Click += new RoutedEventHandler(Number_Click);
            button[1, 2].Click += new RoutedEventHandler(Number_Click);
            button[2, 0].Click += new RoutedEventHandler(Number_Click);
            button[2, 1].Click += new RoutedEventHandler(Number_Click);
            button[2, 2].Click += new RoutedEventHandler(Number_Click);
            button[3, 1].Click += new RoutedEventHandler(Number_Click);

            button[0, 3].Click += new RoutedEventHandler(Operator_Click);
            button[1, 3].Click += new RoutedEventHandler(Operator_Click);
            button[2, 3].Click += new RoutedEventHandler(Operator_Click);
            button[3, 3].Click += new RoutedEventHandler(Operator_Click);

            button[3, 0].Click += Clean_Click;
            button[3, 2].Click += Equals_Click;

            Operation = new Dictionary<string, string>();

            ToMain.Click += ToMainW_Click;
        }
        Button ToMain;
        Button[,] button;
        TextBlock contenT;
        Dictionary<string, string> Operation;
        string number2 = "";
        private void GRID()
        {
            this.Title = "Simple calculator";
            this.Width = 810;
            this.Height = 560;
            Grid myGrid = new Grid();
            myGrid.Width = 800;
            myGrid.Height = 550;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Background = Brushes.LightSteelBlue;
            Label Wind = new Label();
            Wind.Content = "Simple calculator";
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
            Border bor = new Border();
            bor.Margin = new Thickness(63.74, 69, 248, 0);
            bor.Padding = new Thickness(5);
            bor.Background = Brushes.Thistle;
            bor.BorderBrush = Brushes.White;
            bor.BorderThickness = new Thickness(3, 5, 3, 5);
            bor.CornerRadius = new CornerRadius(10);
            bor.VerticalAlignment = VerticalAlignment.Top;
            bor.Height = 86;
            contenT = new TextBlock();
            contenT.Height = 48;
            contenT.Width = 430;
            contenT.VerticalAlignment = VerticalAlignment.Top;
            contenT.FontSize = 30;
            contenT.Margin = new Thickness(0, 9.4, 15.6, 0);
            contenT.HorizontalAlignment = HorizontalAlignment.Right;
            contenT.FlowDirection = FlowDirection.RightToLeft;
            contenT.Background = Brushes.Thistle;
            contenT.Foreground = Brushes.White;
            bor.Child = contenT;
            myGrid.Children.Add(bor);
            UniformGrid Inside = new UniformGrid();
            Inside.Width = 300;
            Inside.Height = 300;
            Inside.HorizontalAlignment = HorizontalAlignment.Left;
            Inside.VerticalAlignment = VerticalAlignment.Center;
            Inside.Background = Brushes.Thistle;
            Inside.Margin = new Thickness(110, 125, 0, 55);
            Inside.Width = 323;
            Inside.Rows = 4;
            Inside.Columns = 4;
            button = new Button[4, 4];
            string[,] content = new string[4, 4]
            {
                 { "1", "2", "3", "/" },
                 { "4", "5", "6", "x" },
                 { "7", "8", "9", "-" },
                 { "C", "0", "=", "+" }
            };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    button[i, j] = new Button();
                    button[i, j] = Settings(button[i, j], content[i, j]);
                    Inside.Children.Add(button[i, j]);
                }
            myGrid.Children.Add(Inside);
            
            this.Content = myGrid;
            this.Show();
        }
        private Button Settings(Button button, string str)
        {
            button.Content = str;
            button.FontSize = 35;
            button.Background = Brushes.Thistle;
            button.Foreground = Brushes.White;
            button.BorderBrush = Brushes.White;
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
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var num = sender as Button;
            string opr = "";
            if (!Operation.TryGetValue("Operator", out opr))
            {
                if (contenT.Text == "")
                {
                    contenT.Text = num.Content.ToString();
                    Operation.Add("Num1", num.Content.ToString());
                }
                else
                {
                    contenT.Text += num.Content.ToString();
                    Operation["Num1"] = contenT.Text;
                }
            }
            else
            {
                if (number2 == "")
                {
                    contenT.Text += num.Content.ToString();
                    number2 += num.Content.ToString();
                    Operation.Add("Num2", num.Content.ToString());
                }
                else
                {
                    contenT.Text += num.Content.ToString();
                    number2 += num.Content.ToString();
                    Operation["Num2"] = number2;
                }
            }
        }
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var opr = sender as Button;
                if (contenT.Text == "")
                    return;

                switch (opr.Content.ToString())
                {
                    case "+":
                        Operation.Add("Operator", "+");
                        break;
                    case "—":
                        Operation.Add("Operator", "-");
                        break;
                    case "X":
                        Operation.Add("Operator", "*");
                        break;
                    case "/":
                        Operation.Add("Operator", "/");
                        break;
                }
                contenT.Text += opr.Content.ToString();
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.ToString());
            }
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contenT.Text += "=";
                string str1 = "", str2 = "", opr = "";
                if (Operation.TryGetValue("Num1", out str1) && Operation.TryGetValue("Operator", out opr) && Operation.TryGetValue("Num2", out str2))
                {
                    int num1 = int.Parse(str1);
                    int num2 = int.Parse(str2);
                    switch (opr)
                    {
                        case "+":
                            contenT.Text = (num1 + num2).ToString();
                            break;
                        case "-":
                            contenT.Text = (num1 - num2).ToString();
                            break;
                        case "*":
                            contenT.Text = (num1 * num2).ToString();
                            break;
                        case "/":
                            contenT.Text = (num1 / num2).ToString();
                            break;
                    }
                    Operation.Clear();
                    number2 = "";
                    Operation.Add("Num1", contenT.Text);
                }
                else
                {
                    return;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }
        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            Operation.Clear();
            contenT.Text = "";
            number2 = "";
        }
    }
}
