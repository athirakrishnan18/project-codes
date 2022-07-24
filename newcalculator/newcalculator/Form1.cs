using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newcalculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;     /*Initializing varialbe */
        String OperationPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            if((textBox_result.Text =="0") || (isOperationPerformed))
                textBox_result.Clear();
            isOperationPerformed = false;

            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_result.Text.Contains("."))
                    textBox_result.Text = textBox_result.Text + button.Text;
            }
            else 
            textBox_result.Text = textBox_result.Text + button.Text;
        }

        private void operator_button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue!= 0)
            {
                button19.PerformClick();
                OperationPerformed = button.Text;
                label_current_operation.Text = resultValue + " " + OperationPerformed;
                isOperationPerformed = true;
            }
            else { 

            OperationPerformed = button.Text;
            resultValue = Double.Parse(textBox_result.Text);
            label_current_operation.Text = resultValue + " " + OperationPerformed;
            isOperationPerformed = true;
            }
        }

        private void button_ce_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
            resultValue = 0;
        }

        private void button_equalto_Click(object sender, EventArgs e)
        {
            switch (OperationPerformed)
            {
                case "+":
                    textBox_result.Text = (resultValue + Double.Parse(textBox_result.Text)).ToString();
                    break;

                case "-":
                    textBox_result.Text = (resultValue - Double.Parse(textBox_result.Text)).ToString();
                    break;

                case "*":
                    textBox_result.Text = (resultValue * Double.Parse(textBox_result.Text)).ToString();
                    break;

                case "/":
                    textBox_result.Text = (resultValue / Double.Parse(textBox_result.Text)).ToString();
                    break;
                    default:
                    break;
            }
            resultValue = Double.Parse(textBox_result.Text);
            label_current_operation.Text = "";
        }
    }
}
