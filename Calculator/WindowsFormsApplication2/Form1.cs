/*          Creator:    Joshua M. Haddix
 *     Date Created:    5/29/2019
 *     Last Changed:    6/26/2019
 *          Version:    v0.5
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
        //  Variables to contain the memory of the numbers choosen and the operator the user has choosen
        double memoryFirstDisplay = 0;
        string memorySecondDisplay = "";
        string operationSelection = "";


        public Form1()
        {
            InitializeComponent();
        }

        //  Click event that occurs when a number button is targeted
        //  Sender is cast as a button and the text of the button is then appended to the display
        private void numberButtonClick(object sender, EventArgs e)
        {
            if (resultBox.Text == "0")
                resultBox.Text = "";

            Button button = (Button)sender;
            resultBox.Text = resultBox.Text + button.Text;

            if(operationSelection != "")
            {
                memorySecondDisplay = memorySecondDisplay + button.Text;
            }
        }

        //  Clears the current display without clearing memory
        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            resultBox.Text = "0";
        }

        //  Clears the current display and the memory of the calculator
        private void buttonClear_Click(object sender, EventArgs e)
        {
            resultBox.Text = "0";
            memoryFirstDisplay = 0;
            memorySecondDisplay = "";
        }

        //  Deletes a single digit of the display defaulting to 0
        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (resultBox.Text.Length == 1)
                resultBox.Text = "0";
            else                
                resultBox.Text = resultBox.Text.Remove(resultBox.Text.Length - 1);
        }

        //  Casts the operation sender as a button reading the text to set the operator variable
        //  Also saves the current display to the memory
        private void operationButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationSelection = button.Text;
            memoryFirstDisplay = double.Parse(resultBox.Text);
            resultBox.Text = "0";
        }

        //  Computes the result of the memory and the current display based on the selected operator
        private void buttonEquals_Click(object sender, EventArgs e)
        {
           
            switch (operationSelection)
            {
                case "+":
                    resultBox.Text = (memoryFirstDisplay + double.Parse(memorySecondDisplay)).ToString();
                    memoryFirstDisplay = double.Parse(resultBox.Text);
                    break;

                case "-":
                    resultBox.Text = (memoryFirstDisplay - double.Parse(memorySecondDisplay)).ToString();
                    memoryFirstDisplay = double.Parse(resultBox.Text);
                    break;

                case "x":
                    resultBox.Text = (memoryFirstDisplay * Double.Parse(memorySecondDisplay)).ToString();
                    memoryFirstDisplay = double.Parse(resultBox.Text);
                    break;

                case "÷":
                    if (double.Parse(resultBox.Text) != 0)
                    {
                        resultBox.Text = (memoryFirstDisplay / double.Parse(memorySecondDisplay)).ToString();
                        memoryFirstDisplay = double.Parse(resultBox.Text);
                    }
                    else
                    {
                        resultBox.Text = "Error Div 0";
                    }
                    break;

                case "xʸ":
                    for(int x=1; x< double.Parse(memorySecondDisplay); x++)
                    {
                        memoryFirstDisplay *= memoryFirstDisplay;
                    }

                    resultBox.Text = memoryFirstDisplay.ToString();
                    break;

                default:
                    resultBox.Text = resultBox.Text;
                    break;
            }

            

        }

        //  Squares the current display
        private void buttonSquared_Click(object sender, EventArgs e)
        {
            resultBox.Text = (double.Parse(resultBox.Text) * double.Parse(resultBox.Text)).ToString();
        }


        //  Calculates the Factorial of the current display
        private void buttonFactorial_Click(object sender, EventArgs e)
        {
            double holder = double.Parse(resultBox.Text);

            for(double x = (holder - 1); x >= 1 ; x--)
            {
                holder = holder * x;
            }

            resultBox.Text = holder.ToString();
        }

        //  Calculates the Square root of the current display
        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            resultBox.Text = (Math.Sqrt(double.Parse(resultBox.Text))).ToString();
        }

        //  Changes the sign of the current display
        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            resultBox.Text = (double.Parse(resultBox.Text) * -1).ToString();
        }

        // Hotkey controls
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
                    memoryFirstDisplay = double.Parse(resultBox.Text);
                    resultBox.Text = "0";
                    break;

                case '-':
                    operationSelection = "-";
                    memoryFirstDisplay = double.Parse(resultBox.Text);
                    resultBox.Text = "0";
                    break;

                case '*':
                    operationSelection = "x";
                    memoryFirstDisplay = double.Parse(resultBox.Text);
                    resultBox.Text = "0";
                    break;

                case '/':
                    operationSelection = "÷";
                    memoryFirstDisplay = double.Parse(resultBox.Text);
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
                    memoryFirstDisplay = double.Parse(resultBox.Text);
                    resultBox.Text = "0";
                    break;

                case 'c':
                    buttonClear_Click(sender, e);
                    break;
            }       
        }

        // Helper Function to reduce code copying for hotkey controls
        private void hotkeyHelper(double x)
        {
            if (operationSelection != "")
            {
                double holder;
                holder = (double.Parse(resultBox.Text) * 10 + x);
                resultBox.Text = holder.ToString();
                memorySecondDisplay = resultBox.Text;
            }
            else
            {
                double holder = memoryFirstDisplay;
                holder = (double.Parse(resultBox.Text) * 10) + x;
                resultBox.Text = holder.ToString();
            }
            
        }

        /*
         * 
         * For some reason this still enters 1 when i hit enter before pressing it manually.
         * 
         * 
         * Future plans if I continue:
         *      - Fix entering 1 bug when pressing enter instead of following forms acceptance property
         * 
         * 
         * */
    }
}
