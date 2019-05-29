/*          Creator:    Joshua M. Haddix
 *     Date Created:    5/29/2019
 *     Last Changed:    5/29/2019
 *      Description:    Non-Scientific Calculator exploring the different options for UI events in C# 
 * 
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

        int result = 0;

        private void numberButtonClick(object sender, EventArgs e)
        {
            if (resultBox.Text == "0")
                resultBox.Clear();

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
    }
}
