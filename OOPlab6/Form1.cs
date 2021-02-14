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
        const int res = 25;
        const int mov = 50;
        CCircle first = null;
        CCircle curverpol = null;
        List<Point> v = new List<Point>();
        DoublyLinkedList shapes = new DoublyLinkedList();
        AShape current;
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
                        if (current != null)
                        {
                            current.Chng_clr(0);
                            current.Draw(g);
                        }
                        shapes.Current.Shape.Chng_clr(4);
                        shapes.Current.Shape.Draw(g);
                        current = shapes.Current.Shape;
                    }
            }

            if (shapeIndex == 1)
            {
                s = new CCircle(e.X, e.Y, 100);
                s.Chng_clr(4);
                s.Draw(g);
                shapes.Push_back(s);
                if (current != null)
                {
                    current.Chng_clr(0);
                    current.Draw(g);
                }
                current = s;
            }

            if (shapeIndex == 2)
            {
                if (a == default(Point))
                    a = new Point(e.X, e.Y);
                else
                    b = new Point(e.X, e.Y);
                if (b != default(Point))
                {
                    s = new CSegment(a, b);
                    a = default(Point);
                    b = default(Point);
                    s.Chng_clr(4);
                    s.Draw(g);
                    shapes.Push_back(s);
                    if (current != null)
                    {
                        current.Chng_clr(0);
                        current.Draw(g);
                    }
                    current = s;
                }
            }
            
            if (shapeIndex == 3)
            {
                Point cur = new Point(e.X, e.Y);
                curverpol = new CCircle(cur, 5);
                curverpol.Draw(g);
                if (first == null)
                {
                    first = new CCircle(cur, 5);
                    first.Chng_clr(-1);
                    first.Draw(g);
                }
                if (first.Contains(cur) && cur != first.Center)
                {
                    v.Add(first.Center);
                    cur = default(Point);
                    first = null;
                    s = new Polygon(v);
                    Draw_all_shapes();
                    s.Chng_clr(4);
                    s.Draw(g);
                    shapes.Push_back(s);
                    if (current != null)
                    {
                        current.Chng_clr(0);
                        current.Draw(g);
                    }
                    current = s;
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
                    current.Resize(sz);
                }
                else if (e.KeyCode >= Keys.NumPad0 && 
                    e.KeyCode <= Keys.NumPad9)
                {
                    current.Move(e.KeyCode - Keys.NumPad0, mov);
                }
                else if (e.KeyCode == Keys.C)
                {
                    current.Chng_clr(-1);
                }
                Draw_all_shapes();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "X = " + e.X.ToString() + " ; " + "Y = " +
                e.Y.ToString() + " ;     W = " +
                g.VisibleClipBounds.Width.ToString() + " ; H = " +
                g.VisibleClipBounds.Height.ToString();
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
            shapeIndex = -1;
        }
    }
}
