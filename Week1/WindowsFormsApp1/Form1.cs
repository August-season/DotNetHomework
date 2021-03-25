using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        private double num1 = 0;
        private double num2;
        private string sign;
        private double res;
        private bool check = true;
        private double ans = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (check == true)
                {
                    Button b = (Button)sender;
                    textBox1.Text += b.Text;
                    num1 = double.Parse(textBox1.Text);

                }
                else if (check == false)
                {
                    Button b = (Button)sender;
                    textBox1.Text += b.Text;
                    num2 = double.Parse(textBox1.Text);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num1 = double.Parse(textBox1.Text);
            }
            else
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num2 = double.Parse(textBox1.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num1 = double.Parse(textBox1.Text);
            }
            else
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num2 = double.Parse(textBox1.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num1 = double.Parse(textBox1.Text);
            }
            else
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num2 = double.Parse(textBox1.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num1 = double.Parse(textBox1.Text);
            }
            else
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num2 = double.Parse(textBox1.Text);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num1 = double.Parse(textBox1.Text);
            }
            else
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num2 = double.Parse(textBox1.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num1 = double.Parse(textBox1.Text);
            }
            else
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num2 = double.Parse(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num1 = double.Parse(textBox1.Text);
            }
            else
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num2 = double.Parse(textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num1 = double.Parse(textBox1.Text);
            }
            else
            {
                Button b = (Button)sender;
                textBox1.Text += b.Text;
                num2 = double.Parse(textBox1.Text);
            }
        }



        private void button11_Click(object sender, EventArgs e)//加法
        {
            sign = "+";
            textBox1.Text = "";
            check = false;
        }        
               
        private void button12_Click(object sender, EventArgs e)//减法
        {
            sign = "-";
            textBox1.Text = "";
            check = false;
        }

        private void button14_Click(object sender, EventArgs e)//乘法
        {
            sign = "*";
            textBox1.Text = "";
            check = false;
        }

        private void button13_Click(object sender, EventArgs e)//除法
        {
            sign = "/";
            textBox1.Text = "";
            check = false;
        }

        private void button18_Click(object sender, EventArgs e)//等于号
        {
            check = true;
            switch (sign)
            {
                case "+":
                    res = num1 + num2;
                    break;
                case "-":
                    res = num1 - num2;
                    break;
                case "*":
                    res = num1 * num2;
                    break;
                case "/":
                    res = num1 / num2;
                    break;
            }
            num1 = res;
            ans = num1;
            textBox1.Text = res.ToString();

        }

        private void button16_Click(object sender, EventArgs e)//AC清除所有数据
        {
            textBox1.Text = "";
            num1 = 0;
            num2 = 0;
            res = 0;
            ans = 0;
        }
        private void button15_Click(object sender, EventArgs e)//小数点
        {
            if (textBox1.Text != "")
            {
                if (check == true)
                {
                    Button b = (Button)sender;
                    textBox1.Text += b.Text;
                    num1 = double.Parse(textBox1.Text);

                }
                else if (check == false)
                {
                    Button b = (Button)sender;
                    textBox1.Text += b.Text;
                    num2 = double.Parse(textBox1.Text);
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)//清除当前数据CE
        {
            textBox1.Text = "";
            num1 = 0;
            num2 = 0;
            res = 0;
        }
    }
}
