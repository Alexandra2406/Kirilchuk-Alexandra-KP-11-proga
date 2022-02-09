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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();


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
