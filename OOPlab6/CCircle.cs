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
        PointF center;
        private int r;

        public CCircle()
        {
            center = new PointF();
            r = 0;
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
    }
}
