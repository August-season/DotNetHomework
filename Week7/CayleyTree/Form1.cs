using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        int depth = 10;
        double length = 100;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        Pen pen = Pens.Orange;


        public Form1()
        {
            InitializeComponent();
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
        }


        private void drawCayleyTree(int n,
                double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            if (graphics != null) graphics.Clear(BackColor);
            drawCayleyTree(depth, 200, 310, length, -Math.PI / 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            graphics = CreateGraphics();
            if (graphics != null) graphics.Clear(BackColor);
            switch (comboBox1.Text)
            {
                case "黑色": pen = Pens.Black; break;
                case "蓝色": pen = Pens.Blue; break;
                case "绿色": pen = Pens.Green; break;
                case "橙色": pen = Pens.Orange; break;
                case "红色": pen = Pens.Red; break;
                default: pen = Pens.Blue; break;
            }
            try
            {
                per2 = Convert.ToDouble(numericUpDown6.Text);
                per1 = Convert.ToDouble(numericUpDown5.Text);
                th2 = Convert.ToDouble(numericUpDown4.Text);
                th1 = Convert.ToDouble(numericUpDown3.Text);
                depth = Convert.ToInt32(numericUpDown1.Text);
                length = Convert.ToDouble(numericUpDown2.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("输入数据有误，请重新输入！");
            }
            if (graphics == null) graphics = CreateGraphics();
            drawCayleyTree(depth, 200, 310, length, -Math.PI / 2);

        }
    }
}
