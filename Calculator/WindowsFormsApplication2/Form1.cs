/*          Creator:    Joshua M. Haddix
 *     Date Created:    5/29/2019
 *     Last Changed:    6/19/2019
 *          Version:    v0.3
 *      Description:    Non-Scientific Calculator exploring the different options for UI events in C# 
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        double result = 0;
        string operationSelection = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void numberButtonClick(object sender, EventArgs e)
        {
            if (resultBox.Text == "0")
                resultBox.Text = "";

            Button button = (Button)sender;
            resultBox.Text = resultBox.Text + button.Text;
        }

        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            resultBox.Text = "0";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            resultBox.Text = "0";
            result = 0;
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (resultBox.Text.Length == 1)
                resultBox.Text = "0";
            else                
                resultBox.Text = resultBox.Text.Remove(resultBox.Text.Length - 1);
        }

        private void operationButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationSelection = button.Text;
            result = double.Parse(resultBox.Text);
            resultBox.Text = "0";
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {

            switch (operationSelection)
            {
                case "+":
                    resultBox.Text = (result + double.Parse(resultBox.Text)).ToString();
                    break;

                case "-":
                    resultBox.Text = (result - double.Parse(resultBox.Text)).ToString();
                    break;

                case "x":
                    resultBox.Text = (result * Double.Parse(resultBox.Text)).ToString();
                    break;

                case "÷":
                    resultBox.Text = (result / double.Parse(resultBox.Text)).ToString();
                    break;

                case "xʸ":
                    double holder = result; 

                    for(int x = 1; x < double.Parse(resultBox.Text); x++)
                    {
                        result =  result * holder;
                    }
                    resultBox.Text = result.ToString();
                    break;

                default:
                    resultBox.Text = resultBox.Text;
                    break;
            }

        }

        private void buttonSquared_Click(object sender, EventArgs e)
        {
            resultBox.Text = (double.Parse(resultBox.Text) * double.Parse(resultBox.Text)).ToString();
        }

        private void buttonFactorial_Click(object sender, EventArgs e)
        {
            double holder = double.Parse(resultBox.Text);

            for(double x = (holder - 1); x >= 1 ; x--)
            {
                holder = holder * x;
            }

            resultBox.Text = holder.ToString();
        }

        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            resultBox.Text = (Math.Sqrt(double.Parse(resultBox.Text))).ToString();
        }

        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            resultBox.Text = (double.Parse(resultBox.Text) * -1).ToString();
        }

        private void hotkeyButtonPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                    hotkeyHelper(1);
                    break;

                case '2':
                    hotkeyHelper(2);
                    break;

                case '3':
                    hotkeyHelper(3);
                    break;

                case '4':
                    hotkeyHelper(4);
                    break;

                case '5':
                    hotkeyHelper(5);
                    break;

                case '6':
                    hotkeyHelper(6);
                    break;

                case '7':
                    hotkeyHelper(7);
                    break;

                case '8':
                    hotkeyHelper(8);
                    break;

                case '9':
                    hotkeyHelper(9);
                    break;

                case '0':
                    hotkeyHelper(0);
                    break;

                case '+':
                    operationSelection = "+";
                    result = double.Parse(resultBox.Text);
                    resultBox.Text = "0";
                    break;

                case '-':
                    operationSelection = "-";
                    result = double.Parse(resultBox.Text);
                    resultBox.Text = "0";
                    break;

                case '*':
                    operationSelection = "x";
                    result = double.Parse(resultBox.Text);
                    resultBox.Text = "0";
                    break;

                case '/':
                    operationSelection = "÷";
                    result = double.Parse(resultBox.Text);
                    resultBox.Text = "0";
                    break;

                case '=':
                    buttonEquals_Click(sender, e);
                    break;

                case '!':
                    buttonFactorial_Click(sender, e);
                    break;

                case '^':
                    operationSelection = "xʸ";
                    result = double.Parse(resultBox.Text);
                    resultBox.Text = "0";
                    break;

                case 'c':
                    buttonClear_Click(sender, e);
                    break;
            }       
        }

        private void hotkeyHelper(double x)
        {
            double holder = result;
            holder = (double.Parse(resultBox.Text) * 10) + x;
            resultBox.Text = holder.ToString();
        }

        /*
         * 
         * For some reason this still enters 1 when i hit enter before pressing it manually.
         * 
         * also currently there is a bug where the first number entered is repeatedly added over and over as opposed to the second number
         * 
         * */
    }
}
