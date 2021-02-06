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
        AShape s;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (a == default(Point))
            //    a = new Point(e.X, e.Y);
            //else
            //    b = new Point(e.X, e.Y);
            //if (b != default(Point))
            //{
            //    s = new CSegment(a, b);
            //    s.Draw(g);
            //    a = default(Point);
            //    b = default(Point);
            //}

            s = new CCircle(e.X, e.Y, 100);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (s != null)
            {
                g.Clear(Color.WhiteSmoke);
                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract)
                {
                    int sz;
                    if (e.KeyCode == Keys.Add)
                        sz = 25;
                    else sz = -25;
                    s.Resize(sz);
                }
                else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                {
                    s.Move(e.KeyCode - Keys.NumPad0, 50);
                }
                else if (e.KeyCode == Keys.C)
                {
                    s.Chng_clr(-1);
                }
                s.Draw(g);
            }
        }
    }
}
