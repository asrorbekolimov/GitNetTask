using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawGraph(x => 1 / Math.Sin(x), Color.Black);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawGraph(x => x * x, Color.Black);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DrawGraph(x => Math.Tan(x), Color.Blue);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void DrawGraph(Func<double, double> function, Color color)
        {
            double m = 30;
            int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;
            int xe, ye;
            double x, y;
            double step = 0.005;

            Graphics G = pictureBox1.CreateGraphics();
            G.Clear(Color.White);

            Pen myPen = new Pen(Color.Silver);
            G.DrawLine(myPen, 10, yc, 2 * xc - 10, yc);
            G.DrawLine(myPen, xc, 10, xc, 2 * yc - 10);

            myPen = new Pen(color);
            x = -Math.PI;

            while (x < Math.PI)
            {
                try
                {
                    y = function(x);
                    xe = (int)(xc + m * x);
                    ye = (int)(yc - m * y);
                    G.DrawEllipse(myPen, xe, ye, 1, 1);
                }
                catch { }

                x += step;
            }
        }
    }
}
