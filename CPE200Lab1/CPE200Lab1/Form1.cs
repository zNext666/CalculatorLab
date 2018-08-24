using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {

        Boolean isOperation = false;
        float result;
        String Operation;
        float num1, num2;
        String pervOperation;
        public Form1()
        {
            InitializeComponent();
            lblDisplay.AutoEllipsis = true;
            lblDisplay.AutoSize = true;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(lblDisplay.Text == "0" || isOperation)
            {
                lblDisplay.Text = "";
            }
            isOperation = false;

            if (lblDisplay.Text.Length < 8)
            {
                if (button.Text == ".")
                {
                    if (!lblDisplay.Text.Contains("."))
                    {
                        if(lblDisplay.Text == "")
                        {
                            lblDisplay.Text += "0";
                            lblDisplay.Text += button.Text;
                        }
                        else
                        {
                            lblDisplay.Text += button.Text;
                        }
                        
                    }
                }
                else
                {
                    lblDisplay.Text += button.Text;
                }


            }
            
        }

        private void btn_operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (result != 0 && isOperation)
            {
                btnEqual.PerformClick();
                Operation = button.Text;
                ResultDis.Text = result.ToString();
                isOperation = true;
            }
            else
            {
                Operation = button.Text;
                result = float.Parse(lblDisplay.Text);
                ResultDis.Text = result.ToString();
                isOperation = true;
                num2 = result;
            }
            pervOperation = Operation;
                
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (Operation)
            {
                case "+":
                    {
                        if (lblDisplay.Text == result.ToString()) 
                        {

                            lblDisplay.Text = (result + num2).ToString();
                        }
                        else
                        {
                            num2 = float.Parse(lblDisplay.Text);
                            lblDisplay.Text = (result + (float)Math.Round(float.Parse(lblDisplay.Text), 8)).ToString();
                        }
                        break;
                    }
                case "-":
                    {
                        if(lblDisplay.Text == result.ToString())
                        {
                            lblDisplay.Text = (result - num2).ToString();
                        }
                        else
                        {
                            num2 = float.Parse(lblDisplay.Text);
                            lblDisplay.Text = (result - (float)Math.Round(float.Parse(lblDisplay.Text), 8)).ToString();
                        }
                        
                        break;
                    }
                case "X":
                    {
                        if(lblDisplay.Text == result.ToString())
                        {
                            lblDisplay.Text = (result * num2).ToString();
                        }
                        else
                        {
                            num2 = float.Parse(lblDisplay.Text);
                            lblDisplay.Text = (result * (float)Math.Round(float.Parse(lblDisplay.Text), 8)).ToString();
                        }
                        
                        break;
                    }
                case "÷":
                    {
                        if(lblDisplay.Text == result.ToString())
                        {
                            lblDisplay.Text = (result / num2).ToString();
                        }
                        else
                        {
                            num2 = float.Parse(lblDisplay.Text);
                            lblDisplay.Text = (result / (float)Math.Round(float.Parse(lblDisplay.Text), 8)).ToString();
                        }
                   
                        break;
                    }
                case "%":
                    {
                        break;
                    }

            }
            //ResultDis.Text = "Result : " + result.ToString();
            result = (float)Math.Round(float.Parse(lblDisplay.Text), 8);
            ResultDis.Text = lblDisplay.Text;
            //ResultDis.Text = "";
            //isOperation = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            result = 0;
            lblDisplay.Text = "0";
            ResultDis.Text = "";
            num2 = 0;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            float in1 = 0;
            in1 = float.Parse(ResultDis.Text);
            float in2 = float.Parse(lblDisplay.Text);
            lblDisplay.Text = (result + (in2 / 100) * in1).ToString();
            ResultDis.Text = lblDisplay.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

    }
}
