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
            g.DrawEllipse(p, X - R / 2, Y - R / 2, R, R);
        }

        protected override void Move_all_points(int dx, int dy)
        {
            if (center.X + dx + R >= 0 && center.X + dx + R <= 1024 &&
                center.Y + dy + R >= 0 && center.Y + dy + R <= 768)
            {
                center = new Point(center.X + dx, center.Y + dy);
            }
        }

        public override void Resize(int sz)
        {
            if (r + sz >= 10)
            r += sz;
        }

        public override bool Contains(Point p)
        {
            if (p != null)
                if (Math.Sqrt((p.X - center.X) * (p.X - center.X) +
                    (p.Y - center.Y) * (p.Y - center.Y)) < r / 2)
                    return true;
            return false;
        }
    }
}
