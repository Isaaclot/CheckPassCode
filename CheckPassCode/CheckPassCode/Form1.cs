using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckPassCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string Mstr = null;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //先画字符
            Random r = new Random();
            string stri = null;
            string strii = "ZXCVBNMLKJHGFDSAQWERTYUIP123456789";
            for (int i = 0; i < 5; i++)
            {
                stri += strii[r.Next(0, 34)];
            }
            Mstr = stri;

            Bitmap bmp = new Bitmap(120, 40);

            Graphics g = Graphics.FromImage(bmp);

            for (int i = 0; i < 5; i++)
            {
                string[] fonts = { "微软雅黑", "宋体", "隶书", "仿宋", "黑体" };
                Color[] colors = { Color.Pink, Color.Black, Color.Red, Color.Brown, Color.Blue };
                Point p = new Point(i * 20, 0);
                g.DrawString(stri[i].ToString(), new Font(fonts[r.Next(0, 5)].ToString(), 20, FontStyle.Bold), new SolidBrush(colors[r.Next(0, 5)]), p);
            }
            for (int i = 0; i < 20; i++)
            {
                Point p1 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                Point p2 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));

                g.DrawLine(new Pen(Brushes.SandyBrown), p1, p2);
            }
            for (int i = 0; i < 500; i++)
            {
                Point p = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                bmp.SetPixel(p.X, p.Y, Color.CadetBlue);
            }



            pictureBox1.Image = bmp;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text.ToUpper() == Mstr)
                {
                    MessageBox.Show("Login Successfully！");
                    pictureBox1_Click(sender,e);
                }
                else
                {
                    MessageBox.Show("Unfortunately，Your Input Incorrect！");
                    pictureBox1_Click(sender,e);
                }
            }
            catch
            {
                MessageBox.Show("Input Error");
                pictureBox1_Click(sender,e);
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

    }
}
