using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPlab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Graphics g;

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
        }

        Point a;
        Point b;
        CSegment seg;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (a == default(Point))
                a = new Point(e.X, e.Y);
            else
                b = new Point(e.X, e.Y);
            if (b != default(Point))
            {
                seg = new CSegment(a, b);
                seg.Draw(g);
                a = default(Point);
                b = default(Point);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (seg != null)
            {
                g.Clear(Color.WhiteSmoke);
                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract)
                {
                    int s;
                    if (e.KeyCode == Keys.Add)
                        s = 25;
                    else s = -25;
                    seg.Resize(s);
                }
                else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                {
                    seg.Move(e.KeyCode - Keys.KeyCode, 50);
                }
                else if (e.KeyCode == Keys.C)
                {
                    seg.Chng_clr(-1);
                }
                seg.Draw(g);
            }
        }
    }
}
