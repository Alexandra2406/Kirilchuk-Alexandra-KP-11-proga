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
    public partial class Window3 : Window
    {
        private void ToMainW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        Dictionary<string, string> Operation; 
        string number2 = ""; 

        public Window3()
        {
            InitializeComponent();            
           
            Button9.Click += new RoutedEventHandler(Number_Click);
            Button8.Click += new RoutedEventHandler(Number_Click);
            Button7.Click += new RoutedEventHandler(Number_Click);
            Button6.Click += new RoutedEventHandler(Number_Click);
            Button5.Click += new RoutedEventHandler(Number_Click);
            Button4.Click += new RoutedEventHandler(Number_Click);
            Button3.Click += new RoutedEventHandler(Number_Click);
            Button2.Click += new RoutedEventHandler(Number_Click);
            Button1.Click += new RoutedEventHandler(Number_Click);
            Button0.Click += new RoutedEventHandler(Number_Click);

            Divide.Click += new RoutedEventHandler(Operator_Click);
            Multiply.Click += new RoutedEventHandler(Operator_Click);
            Minus.Click += new RoutedEventHandler(Operator_Click);
            Plus.Click += new RoutedEventHandler(Operator_Click);

            Clean.Click += Clean_Click;
            Equals.Click += Equals_Click;

            Operation = new Dictionary<string, string>();
        }       
      
        private void Number_Click(object sender, RoutedEventArgs e) 
        {
            var num = sender as Button;
            string opr = "";
            if (!Operation.TryGetValue("Operator", out opr))
            {
                if (Content.Text == "")
                {
                    Content.Text = num.Content.ToString();
                    Operation.Add("Num1", num.Content.ToString());
                }
                else
                {
                    Content.Text += num.Content.ToString();
                    Operation["Num1"] = Content.Text;
                }
            }
            else
            {
                if (number2 == "")
                {
                    Content.Text += num.Content.ToString();
                    number2 += num.Content.ToString();
                    Operation.Add("Num2", num.Content.ToString());
                }
                else
                {
                    Content.Text += num.Content.ToString();
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
                if (Content.Text == "")
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
                Content.Text += opr.Content.ToString();
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
                Content.Text += "=";
                string str1 = "", str2 = "", opr = "";
                if (Operation.TryGetValue("Num1", out str1) && Operation.TryGetValue("Operator", out opr) && Operation.TryGetValue("Num2", out str2))
                {
                    int num1 = int.Parse(str1);
                    int num2 = int.Parse(str2);
                    switch (opr)
                    {
                        case "+":
                            Content.Text = (num1 + num2).ToString();
                            break;
                        case "-":
                            Content.Text = (num1 - num2).ToString();
                            break;
                        case "*":
                            Content.Text = (num1 * num2).ToString();
                            break;
                        case "/":
                            Content.Text = (num1 / num2).ToString();
                            break;
                    }
                    Operation.Clear();
                    number2 = "";
                    Operation.Add("Num1", Content.Text);
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
            Content.Text = "";
            number2 = "";
        }
    }
}
