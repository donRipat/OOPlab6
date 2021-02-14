using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOPlab6
{
    class CCircle : AShape
    {
        Point center;
        private int r;

        public CCircle()
        {
            center = new Point();
            r = 0;
        }
        public CCircle(int x, int y, int r)
        {
            center = new Point(x, y);
            this.r = r;
        }
        public CCircle(Point p, int r)
        {
            center = new Point(p.X, p.Y);
            this.r = r;
        }
        public CCircle(CCircle c)
        {
            center = new Point(c.X, c.Y);
            r = c.R;
        }

        public int R { get => r; }
        public int X { get => center.X; }
        public int Y { get => center.Y; }
        public Point Center { get => center; }
        
        protected override void Draw_shape(Graphics g, Pen p)
        {
            g.DrawEllipse(p, X - R, Y - R, 2 * R, 2 * R);
        }

        protected override bool Move_all_points(double dx, double dy)
        {
            center = new Point(center.X + (int)Math.Round(dx), 
                center.Y + (int)Math.Round(dy));
            if (!Fits())
            {
                center = new Point(center.X - (int)Math.Round(dx),
                center.Y - (int)Math.Round(dy));
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

        protected override bool Fits()
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
    }
}
