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
using System.IO;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            GRID();
            ToMain.Click += ToMainW_Click;
            Remove.Click += Remove_Click;
            TakeNote.Click += TakeNote_Click;
        }
        TextBox SurnameAndName, ID_Node, ID_Remove;
        Button TakeNote, Remove, ToMain;
        private void GRID()
        {
            this.Title = "List of Students";
            this.ResizeMode = ResizeMode.NoResize;
            Grid myGrid = new Grid();
            myGrid.Width = 800;
            myGrid.Height = 450;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Background = Brushes.LightSteelBlue;
            SurnameAndName = new TextBox();
            SurnameAndName = SettingsT(SurnameAndName, 45, 270, 20, 65, 110, 0, 0);
            myGrid.Children.Add(SurnameAndName);
            ID_Node = new TextBox();
            ID_Node = SettingsT(ID_Node, 45, 270, 20, 65, 215, 0, 0);
            myGrid.Children.Add(ID_Node);
            ID_Remove = new TextBox();
            ID_Remove = SettingsT(ID_Remove, 45, 270, 20, 65, 320, 0, 0);
            myGrid.Children.Add(ID_Remove);
            TakeNote = new Button();
            TakeNote = SettingsB(TakeNote, 52, 170, 20, 495, 160, 0, 0, "Take Node");
            myGrid.Children.Add(TakeNote);
            Remove = new Button();
            Remove = SettingsB(Remove, 52, 170, 20, 495, 320, 0, 0, "Remove");
            myGrid.Children.Add(Remove);
            ToMain = new Button();
            ToMain = SettingsB(ToMain, 52, 170, 20, 572, 20, 0, 0, "To Main");
            myGrid.Children.Add(ToMain);
            Label Wind = new Label();
            Wind.Content = "List of Students";
            Wind.Foreground = Brushes.White;
            Wind.FontSize = 40;
            Wind.Margin = new Thickness(72, 12, 260, 0);
            Wind.VerticalAlignment = VerticalAlignment.Top;
            Wind.HorizontalAlignment = HorizontalAlignment.Center;
            Wind.Height = 62;
            Wind.Width = 445;
            myGrid.Children.Add(Wind);
            this.Content = myGrid;
            this.Show();
        }
        private TextBox SettingsT(TextBox textBox, int height, int width, int fontsize, int a, int b, int c, int d)
        {
            textBox.Margin = new Thickness(a, b, c, d);
            textBox.Height = height;
            textBox.Width = width;
            textBox.FontSize = fontsize;
            textBox.Background = Brushes.Thistle;
            textBox.Foreground = Brushes.White;
            textBox.BorderBrush = Brushes.White;
            textBox.HorizontalAlignment = HorizontalAlignment.Left;
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.VerticalAlignment = VerticalAlignment.Top;
            return textBox;
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
        private void TakeNote_Click(object sender, RoutedEventArgs e)
        {
            string NameSurname = SurnameAndName.Text;
            string ID = ID_Node.Text;
            if (string.IsNullOrEmpty(NameSurname) && string.IsNullOrEmpty(ID))
            {
                SurnameAndName.Text = "Enter Surname And Name";
                ID_Node.Text = "Enter the number of the security book";
            }
            else if (string.IsNullOrEmpty(NameSurname))
            {
                SurnameAndName.Text = "Enter Surname And Name";
            }
            else if (string.IsNullOrEmpty(ID))
            {
                ID_Node.Text = "Enter the number of the security book";
            }
            else
            {
                try
                {
                    StreamWriter FileStudent = File.AppendText("FileStudent.txt");
                    FileStudent.WriteLine(NameSurname + " " + ID);
                    FileStudent.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                SurnameAndName.Clear();
                SurnameAndName.Text = "";
                ID_Node.Clear();
                ID_Node.Text = "";
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            string ID_R = ID_Remove.Text;
            if (string.IsNullOrEmpty(ID_R))
            {
                ID_Remove.Text = "Enter the number to remove";
            }
            else
            {
                StreamReader FileStudent = new StreamReader("FileStudent.txt");
                List<string> DataStudent = new List<string>();
                while (!FileStudent.EndOfStream)
                {
                    string Line = FileStudent.ReadLine();
                    string[] Elem3 = Line.Split(' ');

                    if (!Elem3[2].Equals(ID_R))
                    {
                        DataStudent.Add(Line);
                    }

                }
                FileStudent.Close();
                StreamWriter FileStudentWriter = new StreamWriter("FileStudent.txt");
                foreach (string str in DataStudent)
                {
                    FileStudentWriter.WriteLine(str);
                }
                FileStudentWriter.Close();
                ID_Remove.Clear();
                ID_Remove.Text = "";
            }
        }
    }
}
