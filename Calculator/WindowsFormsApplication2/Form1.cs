/*          Creator:    Joshua M. Haddix
 *     Date Created:    5/29/2019
 *     Last Changed:    5/29/2019
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
        public Form1()
        {
            InitializeComponent();
        }

        double result = 0;
        string operationSelection = "";

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
    }
}
