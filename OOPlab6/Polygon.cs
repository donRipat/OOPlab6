using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;

namespace OOPlab6
{
    class Polygon : AShape
    {
        private List<PointF> vert = new List<PointF>();
        private PointF min;
        private PointF max;
        private CSegment diagonal;

        public Polygon()
        {
            vert = new List<PointF>();
            min = new PointF();
            max = new PointF();
            diagonal = new CSegment(min, max);
            center = new PointF();
        }
        public Polygon(List<PointF> v)
        {
            foreach (PointF i in v)
                vert.Add(i);
            UpdateDiagonal();
            center = new PointF((min.X + max.X) / 2,
                    (min.Y + max.Y) / 2);
            r = Math.Sqrt((min.X - max.X) * (min.X - max.X) +
                    (min.Y - max.Y) * (min.Y - max.Y)) / 2;
        }
        public Polygon(Polygon pol)
        {
            vert = pol.vert;
            min = pol.min;
            max = pol.max;
            diagonal = pol.diagonal;
            _color = pol.color;
            center = pol.center;
            r = pol.r;
        }
        public Polygon(List<PointF> v, int c) : this(v)
        {
            _color = c;
        }

        public override bool Move_all_points(double dx, double dy)
        {
            for (int i = 0; i < vert.Count; ++i)
            {
                PointF t = vert.First();
                vert.RemoveAt(0);
                t.X += (float)dx;
                t.Y += (float)dy;
                vert.Add(t);
            }
            UpdateDiagonal();
            if (!Fits())
            {
                Move_all_points(-dx, -dy);
                UpdateDiagonal();
                return false;
            }
            UpdateDiagonal();
            return true;
        }

        public override void Draw_shape(Graphics g, Pen p)
        {
            if (vert.Count == 0)
                return;
            PointF prev = vert.Last();
            foreach (PointF i in vert)
            {
                g.DrawLine(p, prev, i);
                prev = i;
            }
            //g.DrawLine(p, diagonal.A, diagonal.B);
        }

        public override bool Fits()
        {
            return (min.X >= 0 && min.X <= w &&
                min.Y >= m && min.Y <= h &&
                max.X >= 0 && max.X <= w &&
                max.Y >= m && max.Y <= h);
            //  no need to compare min.X with w etc.
        }

        public override bool Resize(int sz)
        {
            if (diagonal.Resize(sz))
            {
                min = diagonal.A;
                max = diagonal.B;
                if (max.X < min.X)
                {
                    PointF t = new PointF(min.X, min.Y);
                    max = min;
                    min = t;
                }
                PointF m = center;
                UpdateDiagonal();
                double sx = sz * Math.Cos(diagonal.Angle);
                if (r < 25)
                {
                    diagonal.Resize(-sz);
                    min = diagonal.A;
                    max = diagonal.B;
                    return false;
                }
                double dx = Math.Cos(diagonal.Angle) * r;
                double ds = 1 + sx / dx;
                for (int i = 0; i < vert.Count; ++i)
                {
                    PointF t = vert.First();
                    vert.RemoveAt(0);
                    t.X = (float)((t.X - m.X) * ds + m.X);
                    t.Y = (float)((t.Y - m.Y) * ds + m.Y);
                    vert.Add(t);
                }
                UpdateDiagonal();
                return true;
            }
            UpdateDiagonal();
            return false;
        }

        public override bool Contains(PointF p)
        {
            PointF end = new PointF(p.X + 99999, p.Y);
            CSegment ray = new CSegment(p, end);
            PointF prev = vert.Last();
            int count = 0;
            foreach (PointF i in vert)
            {
                CSegment c = new CSegment(prev, i);
                PointF isctn = ray.Intersects(c);
                if (c.Contains(isctn) && ray.Contains(isctn))
                    ++count;
                prev = i;
            }
            return (count % 2 == 1);
        }

        protected void UpdateDiagonal()
        {
            min = vert.First();
            max = vert.First();
            foreach (PointF t in vert)
            {
                if (t.X < min.X)
                    min.X = t.X;
                if (t.Y < min.Y)
                    min.Y = t.Y;
                if (t.X > max.X)
                    max.X = t.X;
                if (t.Y > max.Y)
                    max.Y = t.Y;
            }
            diagonal = new CSegment(min, max);
            center = new PointF((min.X + max.X) / 2,
                    (min.Y + max.Y) / 2);
            r = Math.Sqrt((min.X - max.X) * (min.X - max.X) +
                   (min.Y - max.Y) * (min.Y - max.Y)) / 2;
        }

        public override DoublyLinkedList Ungroup()
        {
            return null;
        }

        public override AShape Clone()
        {
            return new Polygon(vert, _color);
        }

        public override bool Save(StreamWriter sw)
        {
            try
            {
                sw.WriteLine("P");
                sw.WriteLine(vert.Count);
                sw.Write(color);
                foreach (PointF i in vert)
                    sw.Write(" " + i.X + " " + i.Y);
                sw.WriteLine();
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
                int count = int.Parse(sr.ReadLine());
                string[] s = sr.ReadLine().Split(' ');
                _color = int.Parse(s[0]);
                for (int i = 1; i <= count; ++i)
                {
                    float x = (float)Convert.ToDouble(s[2 * i - 1]);
                    float y = (float)Convert.ToDouble(s[2 * i]);
                    vert.Add(new PointF(x, y));
                }
                UpdateDiagonal();
                center = new PointF((min.X + max.X) / 2,
                    (min.Y + max.Y) / 2);
                r = Math.Sqrt((min.X - max.X) * (min.X - max.X) +
                    (min.Y - max.Y) * (min.Y - max.Y)) / 2;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
