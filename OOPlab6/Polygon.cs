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
        }

        protected override void Move_all_points(int dx, int dy)
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
            if (!Fits())
            {
                vert.Clear();
                foreach (Point i in oldPoints)
                    vert.Add(i);
            }
        }

        protected override void Draw_shape(Graphics g, Pen p)
        {
            Point prev = vert.Last();
            foreach (Point i in vert)
            {
                g.DrawLine(p, prev, i);
                prev = i;
            }
        }

        protected override bool Fits()
        {
            foreach (Point i in vert)
                if (!(i.X >= 0 && i.X <= w && i.Y >= 0 && i.Y <= h))
                    return false;
            return true;
        }

        public override void Resize(int sz)
        {
            throw new NotImplementedException();
        }

        public override bool Contains(Point p)
        {
            throw new NotImplementedException();
        }
    }
}
