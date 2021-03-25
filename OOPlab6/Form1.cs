using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

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
            tree = new TreeViewer(treeView1);
            shapes.AddObservers(tree);
            tree.AddObs(shapes);
            treeView1.Nodes.Add(new TreeNode("DoublyLinkedList"));
        }

        string shapesPath = @"Shapes.txt";
        int shapeIndex = 0;
        const int res = 25;
        const int mov = 20;
        const int w = 5;
        bool treeClicked = false;

        PointF a;
        PointF b;
        AShape s;
        CCircle first = null;
        CCircle curver = null;
        List<PointF> v = new List<PointF>();
        CGroup gr = new CGroup();

        DoublyLinkedList shapes = new DoublyLinkedList();
        TreeViewer tree;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            treeClicked = false;

            if (shapeIndex == 0)
            {
                PointF p = new PointF(e.X, e.Y);
                shapes.Set_current_first();
                for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                    if (shapes.Current.Shape.Contains(p))
                    {
                        if (s != null)
                            s.Draw(g, w);
                        s = shapes.Current.Shape;
                        s.Draw(g, w, 4);
                        UpdateTB();
                        return;
                    }
            }

            if (shapeIndex == 1)
            {
                if (s != null)
                    s.Draw(g, w);
                s = new CCircle(e.X, e.Y, 100);
                s.Draw(g, w, 4);
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
                        s.Draw(g, w);
                    s = new CSegment(a, b);
                    a = default(PointF);
                    b = default(PointF);
                    s.Draw(g, w, 4);
                    shapes.Push_back(s);
                }
            }
            
            if (shapeIndex == 3)
            {
                PointF cur = new PointF(e.X, e.Y);
                curver = new CCircle(cur, 5);
                curver.Draw(g, w);
                if (first == null)
                {
                    first = new CCircle(cur, 5);
                    first.Chng_clr(3);
                    first.Draw(g, w);
                }
                if (first.Contains(cur) && cur != first.Center)
                {
                    if (s != null)
                        s.Draw(g, w);
                    cur = default(PointF);
                    first = null;
                    s = new Polygon(v);
                    Draw_all_shapes();
                    s.Draw(g, w, 4);
                    shapes.Push_back(s);
                    v.Clear();
                }
                else
                    v.Add(cur);
            }

            if (shapeIndex == 4)
            {
                PointF p = new PointF(e.X, e.Y);
                shapes.Set_current_first();
                for (bool cond = !shapes.Is_empty(); cond; )
                {
                    if (shapes.Current.Shape.Contains(p))
                    {
                        gr.Add(shapes.Current.Shape);
                        shapes.Current.Shape.Draw(g, w, 3);
                        if (shapes.Current.Shape != shapes.Head.Shape)
                        {
                            shapes.Delete_current();
                            cond = shapes.Step_forward();
                        }
                        else
                        {
                            shapes.Delete_current();
                            cond = !shapes.Is_empty();
                        }
                    }
                    else
                        cond = shapes.Step_forward();
                }
            }
            UpdateTB();
        }

        private void Draw_all_shapes()
        {
            g.Clear(Color.WhiteSmoke);
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond; 
                cond = shapes.Step_forward())
                shapes.Current.Shape.Draw(g, w);
            if (s != null)
                s.Draw(g, w, 4);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (s == null)
                return;
            if (e.KeyCode == Keys.Add ||
                e.KeyCode == Keys.Subtract)
            {
                int sz;
                if (e.KeyCode == Keys.Add)
                    sz = res;
                else sz = -res;
                s.Resize(sz);
                if (s.sticky)
                    shapes.UpdateStickyShapes(s);
            }
            else if (e.KeyCode >= Keys.NumPad1 &&
                e.KeyCode <= Keys.NumPad9)
            {
                s.Move(e.KeyCode - Keys.NumPad0, mov);
                if (s.sticky)
                    shapes.UpdateStickyShapes(s);
            }
            else if (e.KeyCode == Keys.C)
            {
                s.Chng_clr(-1);
                s.Draw(g, w);
            }
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.D)
            {
                if (shapes.Count == 0)
                    return;
                shapes.Search(s);
                shapes.Delete_current();
                if (shapes.Tail != null)
                    s = shapes.Tail.Shape;
                else
                    s = null;
            }
            else if (e.KeyCode == Keys.S)
            {
                s.Switch();
            }
            if (e.KeyCode != Keys.C || e.KeyCode != Keys.S)
                Draw_all_shapes();
            UpdateTB();
            e.Handled = true;
        }

        private void UpdateTB()
        {
            if (s == null)
                return;
            if (s.sticky)
                textBox1.Text = "Sticky";
            else textBox1.Text = "Not sticky";
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Form1_KeyDown(this, e);
            return;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "x = " + e.X.ToString() + "; " + "y = " +
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
        
        private void makeGroupToolStripMenuItem_Click(object sender, 
            EventArgs e)
        {
            if (shapeIndex == 4)
            {
                shapeIndex = 0;
                shapes.Push_back(gr);
                s = gr;
                Draw_all_shapes();
                gr = new CGroup();
            }
            else
                shapeIndex = 4;
        }

        private void separateGroupToolStripMenuItem_Click
            (object sender, EventArgs e)
        {
            if (s == null)
                return;
            DoublyLinkedList ungr = s.Ungroup();
            if (ungr == null)
                return;
            shapes.Search(s);
            shapes.Delete_current();
            ungr.Set_current_first();
            for (bool cond = !ungr.Is_empty(); cond;
                cond = ungr.Step_forward())
                shapes.Push_back(ungr.Current.Shape);
            s = shapes.Head.Shape;
            Draw_all_shapes();
            shapeIndex = 0;
        }

        private void saveShapesToolStripMenuItem1_Click(object sender,
            EventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(shapesPath))
                    shapes.SaveShapes(sw);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            shapeIndex = 0;
        }

        private void loadShapesToolStripMenuItem_Click(object sender,
            EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader(shapesPath,
                    false))
                    shapes.LoadShapes(sr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (shapes.Is_empty())
                return;
            s = shapes.Tail.Shape;
            Draw_all_shapes();
            shapeIndex = 0;
        }

        private void treeView1_AfterSelect(object sender, 
            TreeViewEventArgs e)
        {
            if (treeClicked)
            {
                treeView1.SelectedNode = e.Node;
                tree.SelectedChanged();
                Draw_all_shapes();
            }
            treeClicked = false;
        }

        private void treeView1_MouseClick(object sender, 
            MouseEventArgs e)
        {
            treeClicked = true;
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
