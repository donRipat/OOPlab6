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
        
        PointF a;
        PointF b;
        AShape s;
        const int res = 25;
        const int mov = 50;
        CCircle first = null;
        CCircle curver = null;
        List<PointF> v = new List<PointF>();
        DoublyLinkedList shapes = new DoublyLinkedList();
        int shapeIndex = 0;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (shapeIndex == 0)
            {
                PointF p = new PointF(e.X, e.Y);
                shapes.Set_current_first();
                for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                    if (shapes.Current.Shape.Contains(p))
                    {
                        if (s != null)
                        {
                            s.Chng_clr(0);
                            s.Draw(g);
                        }
                        s = shapes.Current.Shape;
                        s.Chng_clr(4);
                        s.Draw(g);
                    }

                //for (int x = 0; x < 1100; x += 1)
                //    for (int y = 0; y < 800; y += 1)
                //    {
                //        PointF p = new PointF(x, y);
                //        for (bool cond = !shapes.Is_empty(); cond;
                //            cond = shapes.Step_forward())
                //            if (shapes.Current.Shape.Contains(p))
                //            {
                //                CCircle omg = new CCircle(p, 1);
                //                omg.Draw(g);
                //            }
                //    }
            }

            if (shapeIndex == 1)
            {
                if (s != null)
                {
                    s.Chng_clr(0);
                    s.Draw(g);
                }
                s = new CCircle(e.X, e.Y, 100);
                s.Chng_clr(4);
                s.Draw(g);
                shapes.Push_back(s);
            }

            if (shapeIndex == 2)
            {
                if (a == default(PointF))
                    a = new PointF(e.X, e.Y);
                else
                    b = new PointF(e.X, e.Y);
                if (b != default(PointF))
                {
                    if (s != null)
                    {
                        s.Chng_clr(0);
                        s.Draw(g);
                    }
                    s = new CSegment(a, b);
                    a = default(PointF);
                    b = default(PointF);
                    s.Chng_clr(4);
                    s.Draw(g);
                    shapes.Push_back(s);
                }
            }
            
            if (shapeIndex == 3)
            {
                PointF cur = new PointF(e.X, e.Y);
                curver = new CCircle(cur, 5);
                curver.Draw(g);
                if (first == null)
                {
                    first = new CCircle(cur, 5);
                    first.Chng_clr(-1);
                    first.Draw(g);
                }
                if (first.Contains(cur) && cur != first.Center)
                {
                    if (s != null)
                    {
                        s.Chng_clr(0);
                        s.Draw(g);
                    }
                    v.Add(first.Center);
                    cur = default(PointF);
                    first = null;
                    s = new Polygon(v);
                    Draw_all_shapes();
                    s.Chng_clr(4);
                    s.Draw(g);
                    shapes.Push_back(s);
                    v.Clear();
                }
                else
                    v.Add(cur);
            }
        }

        private void Draw_all_shapes()
        {
            g.Clear(Color.WhiteSmoke);
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond; 
                cond = shapes.Step_forward())
                shapes.Current.Shape.Draw(g);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (s != null)
            {
                g.Clear(Color.WhiteSmoke);
                if (e.KeyCode == Keys.Add || 
                    e.KeyCode == Keys.Subtract)
                {
                    int sz;
                    if (e.KeyCode == Keys.Add)
                        sz = res;
                    else sz = -res;
                    s.Resize(sz);
                }
                else if (e.KeyCode >= Keys.NumPad0 && 
                    e.KeyCode <= Keys.NumPad9)
                {
                    s.Move(e.KeyCode - Keys.NumPad0, mov);
                }
                else if (e.KeyCode == Keys.C)
                {
                    s.Chng_clr(-1);
                }
                Draw_all_shapes();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "X = " + e.X.ToString() + " ; " + "Y = " +
                e.Y.ToString();
        }

        private void circleToolStripMenuItem_Click(object sender, 
            EventArgs e)
        {
            shapeIndex = 1;
        }

        private void segmentToolStripMenuItem_Click(object sender, 
            EventArgs e)
        {
            shapeIndex = 2;
        }

        private void polygonToolStripMenuItem_Click(object sender, 
            EventArgs e)
        {
            shapeIndex = 3;
        }

        private void selectShapeToolStripMenuItem_Click(object sender, 
            EventArgs e)
        {
            shapeIndex = 0;
        }

        private void deleteShapeToolStripMenuItem_Click(object sender, 
            EventArgs e)
        {
            if (shapes.Count > 0)
            {
                shapes.Search(s);
                shapes.Delete_current();
                if (shapes.Tail != null)
                {
                    s = shapes.Tail.Shape;
                    s.Chng_clr(4);
                }
                Draw_all_shapes();
            }
        }
    }
}
