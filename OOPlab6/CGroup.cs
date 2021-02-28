using System;
using System.Drawing;
using System.IO;

namespace OOPlab6
{
    class CGroup : AShape
    {
        protected DoublyLinkedList shapes;
        Pen p;

        public CGroup()
        {
            shapes = new DoublyLinkedList();
        }

        public CGroup(CGroup gr)
        {
            shapes = new DoublyLinkedList();
            gr.shapes.Set_current_first();
            for (bool cond = !gr.shapes.Is_empty(); cond;
                cond = gr.shapes.Step_forward())
                shapes.Push_back(gr.shapes.Current.Shape.Clone());
        }

        public void Add(AShape s)
        {
            shapes.Push_back(s);
        }

        public int Count { get => shapes.Count; }

        public override bool Contains(PointF p)
        {
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                if (shapes.Current.Shape.Contains(p))
                    return true;
            return false;
        }

        public override bool Resize(int sz)
        {
            DoublyLinkedList oldShapes = new DoublyLinkedList();
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                oldShapes.Push_back(shapes.Current.Shape.Clone());

            bool res = true;
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                if (!shapes.Current.Shape.Resize(sz))
                {
                    res = false;
                    break;
                }
            if (!res)
                shapes = oldShapes;
            return res;
        }

        public override bool Move_all_points(double dx, double dy)
        {
            DoublyLinkedList oldShapes = new DoublyLinkedList();
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                oldShapes.Push_back(shapes.Current.Shape.Clone());

            bool res = true;
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                if (!shapes.Current.Shape.Move_all_points(dx, dy))
                {
                    res = false;
                    break;
                }
            if (!res)
                shapes = oldShapes;
            return res;
        }

        public override bool Fits()
        {
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                if (!shapes.Current.Shape.Fits())
                    return false;
            return true;
        }

        public override void Draw(Graphics g, int width)
        {
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
            {
                if (shapes.Current.Shape.color == 0)
                    p = new Pen(Color.Green);
                else if (shapes.Current.Shape.color == 1)
                    p = new Pen(Color.Purple);
                else if (shapes.Current.Shape.color == 2)
                    p = new Pen(Color.Blue);
                else if (shapes.Current.Shape.color == 3)
                    p = new Pen(Color.Orange);
                else if (shapes.Current.Shape.color == 4)
                    p = new Pen(Color.Red);
                else
                    p = new Pen(Color.Black);
                p.Width = width;
                shapes.Current.Shape.Draw_shape(g, p);
            }
        }

        public override void Draw(Graphics g, int width, int color)
        {
            if (color == 0)
                p = new Pen(Color.Green);
            else if (color == 1)
                p = new Pen(Color.Purple);
            else if (color == 2)
                p = new Pen(Color.Blue);
            else if (color == 3)
                p = new Pen(Color.Orange);
            else if (color == 4)
                p = new Pen(Color.Red);
            else
                p = new Pen(Color.Black);
            p.Width = width;
            Draw_shape(g, p);
        }

        public override void Draw_shape(Graphics g, Pen p)
        {
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                shapes.Current.Shape.Draw_shape(g, p);
        }

        public override void Chng_clr(int clr)
        {
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                shapes.Current.Shape.Chng_clr(clr);
        }

        public override DoublyLinkedList Ungroup()
        {
            return shapes;
        }

        public override AShape Clone()
        {
            return new CGroup(this);
        }

        public override bool Save(StreamWriter sw)
        {
            try
            {
                sw.WriteLine("G");
                if (!shapes.SaveShapes(sw))
                    return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Load(StreamReader sr)
        {
            try
            {
                if (!shapes.LoadShapes(sr))
                    return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
