using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


namespace calc
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double FirstNumber;
        string Operation;


        private void numClick(object sender, RoutedEventArgs e) {
            actButtons(new List<Button>() { x, xx, xxx, y, yy, yyy, z, zz, zzz });
            Button przycisk = sender as Button;
            string liczba = przycisk.Content.ToString();
            if (this.LCD.Text == "Cannot divide by zero" || this.LCD.Text == "Cannot do this")
            {
                this.LCD.Text = liczba;
            }
            else if (liczba == ",")
            {
                if (this.LCD.Text == "0" || this.LCD.Text == null)
                {
                    this.LCD.Text = "0" + liczba;
                }
                else if (!this.LCD.Text.Contains(","))
                    this.LCD.Text = this.LCD.Text + liczba;

            }
            else if (this.LCD.Text == "0" && this.LCD.Text != null)
            {
                this.LCD.Text = liczba;
            }
            else
            {
                this.LCD.Text += liczba;
            }
        }


        private void adClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.LCD.Text))
            {
                this.LCD.Text = "0";
            }
            else
            {
                FirstNumber = Convert.ToDouble(this.LCD.Text);
                this.LCD.Text = "0";
                Operation = "+";
            }
        }

        private void subClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.LCD.Text))
            {
                this.LCD.Text = "0";
            }
            else
            {
                FirstNumber = Convert.ToDouble(this.LCD.Text);
                this.LCD.Text = "0";
                Operation = "-";
            }
        }

        private void mulClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.LCD.Text))
            {
                this.LCD.Text = "0";
            }
            else
            {
                FirstNumber = Convert.ToDouble(this.LCD.Text);
                this.LCD.Text = "0";
                Operation = "*";
            }
        }

        private void divClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.LCD.Text))
            {
                this.LCD.Text = "0";
            }
            else
            {
                FirstNumber = Convert.ToDouble(this.LCD.Text);
                this.LCD.Text = "0";
                Operation = "/";
            }
        }

        private void xClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.LCD.Text))
            {
                this.LCD.Text = "0";
            }
            else if(this.LCD.Text == "0" || this.LCD.Text=="0," || this.LCD.Text == "0,0")
            {
                this.LCD.Text = "Cannot do this";
                disButtons(new List<Button>() { x, xx, xxx, y, yy, yyy, z, zz, zzz });
            }
            else 
            {
                double Result;
                FirstNumber = Convert.ToDouble(this.LCD.Text);
                Result = (1 / FirstNumber);
                this.LCD.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
        }

        private void quaClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.LCD.Text))
            {
                this.LCD.Text = "0";
            }
            else
            {
                double Result;
                FirstNumber = Convert.ToDouble(this.LCD.Text);
                Result = (FirstNumber * FirstNumber);
                this.LCD.Text = Convert.ToString(Result);
                Operation = "2";
            }
        }

        private void disButtons(IList<Button> buttons)
        {
            foreach (var button in buttons)
            {
                button.IsEnabled=false;
            }
        }

        private void actButtons(IList<Button> buttons)
        {
            foreach (var button in buttons)
            {
                button.IsEnabled = true;
            }
        }


        private void equalClick(object sender, EventArgs e)
        {
            double SecondNumber;
            double Result;

            if (string.IsNullOrWhiteSpace(this.LCD.Text))
            {
                this.LCD.Text = "0";
            }
            else
            {
                SecondNumber = Convert.ToDouble(this.LCD.Text);

                if (Operation == "+")
                {
                    Result = (FirstNumber + SecondNumber);
                    this.LCD.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                }
                if (Operation == "-")
                {
                    Result = (FirstNumber - SecondNumber);
                    this.LCD.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                }
                if (Operation == "*")
                {
                    Result = (FirstNumber * SecondNumber);
                    this.LCD.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                }
                if (Operation == "/")
                {
                    if (SecondNumber == 0)
                    {
                        this.LCD.Text = "Cannot divide by zero";
                        disButtons(new List<Button>() { x,xx,xxx,y,yy,yyy,z,zz,zzz });
                    }
                    else
                    {
                        Result = (FirstNumber / SecondNumber);
                        this.LCD.Text = Convert.ToString(Result);
                        FirstNumber = Result;
                    }
                }
                if (Operation == "o")
                {
                    Result = (1 / SecondNumber);
                    this.LCD.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                }
                if (Operation == "2")
                {
                    Result = (SecondNumber * SecondNumber);
                    this.LCD.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                }
            }
        }

       


        private void clear(object sender, RoutedEventArgs e) {
            this.LCD.Text = "";
            actButtons(new List<Button>() { x, xx, xxx, y, yy, yyy, z, zz, zzz });
        }

        private void remove(object sender, RoutedEventArgs e) {
            if (this.LCD.Text != "")
            {
                this.LCD.Text = this.LCD.Text.Remove(this.LCD.Text.Length - 1);
            }
            else
                return;
        }

        private void div0()
        {
            this.LCD.Text = "0";
        }
    }
    //culture info zamiana kropki na przecinek!!!
}
