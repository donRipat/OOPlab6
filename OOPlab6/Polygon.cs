using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOPlab6
{
    class Polygon : AShape
    {
        private List<Point> vert = new List<Point>();
        private Point min;
        private Point max;
        CSegment diagonal;

        public Polygon(List<Point> v)
        {
            foreach (Point i in v)
                vert.Add(i);

            min = vert.First();
            max = vert.First();
            foreach (Point i in vert)
            {
                if (i.X < min.X)
                    min.X = i.X;
                if (i.Y < min.Y)
                    min.Y = i.Y;
                if (i.X > max.X)
                    max.X = i.X;
                if (i.Y > max.Y)
                    max.Y = i.Y;
            }
            diagonal = new CSegment(min, max);
        }

        protected override bool Move_all_points(int dx, int dy)
        {
            List<Point> oldPoints = new List<Point>();
            foreach (Point i in vert)
                oldPoints.Add(new Point(i.X, i.Y));
            for (int i = 0; i < vert.Count; ++i)
            {
                Point t = vert.First();
                vert.RemoveAt(0);
                t.X += dx;
                t.Y += dy;
                vert.Add(t);
            }
            min = new Point(min.X + dx, min.Y + dy);
            max = new Point(max.X + dx, max.Y + dy);
            diagonal = new CSegment(min, max);
            if (!Fits())
            {
                vert.Clear();
                foreach (Point i in oldPoints)
                    vert.Add(i);
                min = new Point(min.X - dx, min.Y - dy);
                max = new Point(max.X - dx, max.Y - dy);
                diagonal = new CSegment(min, max);
                return false;
            }
            return true;
        }

        protected override void Draw_shape(Graphics g, Pen p)
        {
            Point prev = vert.First();
            foreach (Point i in vert)
            {
                g.DrawLine(p, prev, i);
                prev = i;
            }
            g.DrawLine(p, diagonal.A, diagonal.B);
        }

        protected override bool Fits()
        {
            return (min.X >= 0 && min.X <= w &&
                min.Y >= 0 && min.Y <= h &&
                max.X >= 0 && max.X <= w &&
                max.Y >= 0 && max.Y <= h);
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
                    Point t = new Point(min.X, min.Y);
                    max = min;
                    min = t;
                }
                Point m = new Point((min.X + max.X) / 2, 
                    (min.Y + max.Y) / 2);
                double sx = sz * Math.Cos(diagonal.Angle);
                double dlen = Math.Sqrt((min.X - max.X) *
                    (min.X - max.X) + (min.Y - max.Y) *
                    (min.Y - max.Y));
                if (dlen < 100)
                {
                    diagonal.Resize(-sz);
                    return false;
                }
                double dx = Math.Cos(diagonal.Angle) * dlen / 2;
                double ds = 1 + sx / dx;
                for (int i = 0; i < vert.Count; ++i)
                {
                    Point t = vert.First();
                    vert.RemoveAt(0);
                    t.X = (int)Math.Round((t.X - m.X) * ds) + m.X;
                    t.Y = (int)Math.Round((t.Y - m.Y) * ds) + m.Y;
                    if (t.X < min.X)
                        min.X = t.X;
                    if (t.Y < min.Y)
                        min.Y = t.Y;
                    if (t.X > max.X)
                        max.X = t.X;
                    if (t.Y > max.Y)
                        max.Y = t.Y;
                    vert.Add(t);
                }
                diagonal = new CSegment(min, max);
                return true;
            }
            return false;
        }

        public override bool Contains(Point p)
        {
            throw new NotImplementedException();
        }
    }
}
