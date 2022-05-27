using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator2._0
{
    public partial class Form1 : Form
    {
        double firstNumber;
        double secondNumber = 0;
        string operation = "";
        //string unarOperator;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        private void Percent_Button(object sender, EventArgs e)
        {
            var temp = firstNumber / 100 * secondNumber;
            textBox1.Text = temp.ToString();
            button21.PerformClick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NumberButton(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (textBox1.Text == "0" || textBox1.Text.Equals("не число"))
            {
                textBox1.Text = button.Text;
            }
            else
            {
                textBox1.Text += button.Text;
            }

        }

        private void BinaryOperation(object sender, EventArgs e)
        {
            Button button = sender as Button;
            firstNumber = Convert.ToDouble(textBox1.Text);
            textBox2.Text = textBox1.Text + button.Text;
            operation = button.Text;
            textBox1.Text = "0";
        }

        private void ChangingOperand(object sender, EventArgs e)
        {
            if (operation == "")
            {
                firstNumber = Convert.ToDouble(textBox1.Text);
            }
            else
            {
                secondNumber = Convert.ToDouble(textBox1.Text);
            }
        }


        private void EqualButton(object sender, EventArgs e)
        {
            if (operation == "")
            {
                textBox2.Text = textBox1.Text + "=";
            }
            else
            {
                double result = 0.0;
                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        textBox2.Text = firstNumber.ToString() + "+" + secondNumber.ToString() + "=";
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        textBox2.Text = firstNumber.ToString() + "-" + secondNumber.ToString() + "=";
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        textBox2.Text = firstNumber.ToString() + "*" + secondNumber.ToString() + "=";
                        break;
                    case "/":
                        result = firstNumber / secondNumber;
                        textBox2.Text = firstNumber.ToString() + "/" + secondNumber.ToString() + "=";
                        break;
                }
                firstNumber = result;
                var temp = operation;
                operation = "";
                textBox1.Text = Convert.ToString(result);
                operation = temp;
            }
        }

        private void C_Button(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            operation = "";
            textBox1.Text = "0";
            textBox2.Text = "";
        }

        private bool isThereAFuckingZapataya(string str)
        {
            if (str.Contains(',')) return true;
            return false;
        }

        private void ValidateInput(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (!e.KeyChar.Equals(','))
                {
                    e.Handled = true;
                }
                else
                {
                    if (isThereAFuckingZapataya(textBox1.Text))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void FuckingZapataya_Button(object sender, EventArgs e)
        {
            if (!isThereAFuckingZapataya(textBox1.Text))
            {
                textBox1.Text += ',';
            }
        }

        private void CE_Button(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void Delete_Button(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 2)
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            else if (textBox1.Text.Length > 1)
            {
                if (textBox1.Text[0] == '-') textBox1.Text = "0";
                else textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            else
            {
                textBox1.Text = "0";
            }
        }

        private void Unar_Buttons(object sender, EventArgs e)
        {
            Button button = sender as Button;
            double temp = Convert.ToDouble(textBox1.Text);
            switch (button.Text)
            {
                case "x^2":
                    temp = temp * temp;
                    break;
                case "sqrt":
                    temp = Math.Sqrt(temp);
                    break;
                case "1/x":
                    temp = 1 / temp;
                    break;
                case "+/-":
                    temp *= -1;
                    break;
            }
            textBox1.Text = temp.ToString();
        }

        private void FuckingMinasAdinButton(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToDouble(textBox1.Text) * -1).ToString();
        }
    }
}
