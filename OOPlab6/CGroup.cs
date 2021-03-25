using System;
using System.Drawing;
using System.IO;

namespace OOPlab6
{
    class CGroup : AShape
    {
        protected DoublyLinkedList shapes;

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
                shapes.Push_back(gr.shapes.CurShape.Clone());
            UpdateMinMax();
        }

        public DoublyLinkedList Shapes { get => shapes; }

        public void Add(AShape s)
        {
            shapes.Push_back(s);
            UpdateMinMax();
        }

        public int Count { get => shapes.Count; }

        public override bool Contains(PointF p)
        {
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                if (shapes.CurShape.Contains(p))
                    return true;
            return false;
        }

        public override bool Resize(int sz)
        {
            DoublyLinkedList oldShapes = new DoublyLinkedList();
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                oldShapes.Push_back(shapes.CurShape.Clone());

            bool res = true;
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                if (!shapes.CurShape.Resize(sz))
                {
                    res = false;
                    break;
                }
            if (!res)
                shapes = oldShapes;
            UpdateMinMax();
            return res;
        }

        public override bool Move_all_points(double dx, double dy)
        {
            DoublyLinkedList oldShapes = new DoublyLinkedList();
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                oldShapes.Push_back(shapes.CurShape.Clone());

            bool res = true;
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                if (!shapes.CurShape.Move_all_points(dx, dy))
                {
                    res = false;
                    break;
                }
            if (!res)
                shapes = oldShapes;
            UpdateMinMax();
            return res;
        }

        public override bool Fits()
        {
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                if (!shapes.CurShape.Fits())
                    return false;
            return true;
        }

        public override void Draw(Graphics g, int width)
        {
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                shapes.CurShape.Draw(g, width);
        }

        public override void Draw(Graphics g, int width, int color)
        {
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                shapes.CurShape.Draw(g, width, color);
        }

        public override void Draw_shape(Graphics g, Pen p)
        {
        }

        public override void Chng_clr(int clr)
        {
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                shapes.CurShape.Chng_clr(clr);
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
                UpdateMinMax();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool CloseTo(AShape s)
        {
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                cond = shapes.Step_forward())
                if (s.CloseTo(shapes.CurShape))
                    return true;
            return false;
        }

        public override bool SubjChanged(double dx, double dy)
        {
            DoublyLinkedList oldShapes = new DoublyLinkedList();
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                    cond = shapes.Step_forward())
                oldShapes.Push_back(shapes.CurShape.Clone());

            bool res = true;

            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                cond = shapes.Step_forward())
                if (!shapes.CurShape.SubjChanged(dx, dy))
                {
                    res = false;
                    break;
                }
            if (!res)
                shapes = oldShapes;
            UpdateMinMax();
            return res;
        }

        public void UpdateMinMax()
        {
            shapes.Set_current_first();
            for (bool cond = !shapes.Is_empty(); cond;
                cond = shapes.Step_forward())
            {
                min.X = Math.Min(shapes.CurShape.Min.X, min.X);
                min.Y = Math.Min(shapes.CurShape.Min.Y, min.Y);
                max.X = Math.Max(shapes.CurShape.Max.X, max.X);
                max.Y = Math.Max(shapes.CurShape.Max.Y, max.Y);
            }
            center = new PointF((min.X + max.X) / 2,
                (min.Y + max.Y) / 2);
            r = Math.Sqrt((min.X - max.X) * (min.X - max.X) +
                    (min.Y - max.Y) * (min.Y - max.Y)) / 2;
        }
    }
}
