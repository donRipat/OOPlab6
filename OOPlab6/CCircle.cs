using System;
using System.Linq;
using System.Drawing;
using System.IO;

namespace OOPlab6
{
    class CCircle : AShape
    {
        private PointF center;
        private int r;

        public CCircle()
        {
            center = new PointF();
        }
        public CCircle(int x, int y, int r)
        {
            center = new PointF(x, y);
            this.r = r;
        }
        public CCircle(PointF p, int r)
        {
            center = new PointF(p.X, p.Y);
            this.r = r;
        }
        public CCircle(CCircle c)
        {
            center = new PointF((float)c.X, (float)c.Y);
            r = c.R;
            _color = c.color;
        }
        public CCircle(int x, int y, int r, int c) : this(x, y, r)
        {
            _color = c;
        }
        public CCircle(PointF p, int r, int c) : this(p, r)
        {
            _color = c;
        }

        public int R { get => r; }
        public double X { get => center.X; }
        public double Y { get => center.Y; }
        public PointF Center { get => center; }
        
        public override void Draw_shape(Graphics g, Pen p)
        {
            g.DrawEllipse(p, (float)(X - R), (float)(Y - R), 2 * R, 
                2 * R);
        }

        public override bool Move_all_points(double dx, double dy)
        {
            center = new PointF((float)(center.X + dx), 
                (float)(center.Y + dy));
            if (!Fits())
            {
                center = new PointF((float)(center.X - dx),
                (float)(center.Y - dy));
                return false;
            }
            return true;
        }

        public override bool Resize(int sz)
        {
            r += sz;
            if (!Fits() || r <= 0)
            {
                r -= sz;
                return false;
            }
            return true;
        }

        public override bool Fits()
        {
            return (center.X - R >= 0 && center.X + R <= w &&
                center.Y - R >= m && center.Y + R <= h);
        }

        public override bool Contains(PointF p)
        {
            if (p != null)
                if (Math.Sqrt((p.X - center.X) * (p.X - center.X) +
                    (p.Y - center.Y) * (p.Y - center.Y)) < R)
                    return true;
            return false;
        }

        public override DoublyLinkedList Ungroup()
        {
            return null;
        }

        public override AShape Clone()
        {
            return new CCircle(this);
        }

        public override bool Save(StreamWriter sw)
        {
            try
            {
                sw.WriteLine("C");
                sw.WriteLine(color + " " + X + " " + Y + " " + R);
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
                string[] s = sr.ReadLine().Split(' ');
                _color = int.Parse(s[0]);
                center.X = (float)Convert.ToDouble(s[1]);
                center.Y = (float)Convert.ToDouble(s[2]);
                r = int.Parse(s[3]);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
