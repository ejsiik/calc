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
            Button przycisk = sender as Button;
            string liczba = przycisk.Content.ToString();
            if (liczba == ",")
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
            FirstNumber = Convert.ToDouble(this.LCD.Text);
            this.LCD.Text = "0";
            Operation = "+";
        }

        private void subClick(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(this.LCD.Text);
            this.LCD.Text = "0";
            Operation = "-";

        }

        private void mulClick(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(this.LCD.Text);
            this.LCD.Text = "0";
            Operation = "*";
        }

        private void divClick(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(this.LCD.Text);
            this.LCD.Text = "0";
            Operation = "/";
        }

        private void equalClick(object sender, EventArgs e)
        {
            double SecondNumber;
            double Result;

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

                }
                else
                {
                    Result = (FirstNumber / SecondNumber);
                    this.LCD.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                }
            }
        }
         

        private void remove(object sender, RoutedEventArgs e) {
            this.LCD.Text = "";
        }

        private void clear(object sender, RoutedEventArgs e) {
            if (this.LCD.Text != "")
            {
                this.LCD.Text = this.LCD.Text.Remove(this.LCD.Text.Length - 1);
            }
            else
                return;
        }
    }
    //culture info zamiana kropki na przecinek!!!
}
