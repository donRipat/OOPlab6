using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOPlab6
{
    class CSegment : AShape
    {
        private PointF _a, _b;
        private double _angle;
        
        public CSegment(PointF a, PointF b)
        {
            _a = new PointF(a.X, a.Y);
            _b = new PointF(b.X, b.Y);
            double dx = _a.X - _b.X;
            double dy = _a.Y - _b.Y;
            try
            {
                _angle = Math.Atan((dy + .0) / dx);
            }
            catch (DivideByZeroException)
            {
                _angle = Math.Asin(1);
            }
        }

        public override bool Resize(int size)
        {
            double l = Math.Sqrt((_a.X - _b.X) * (_a.X - _b.X) +
                    (_a.Y - _b.Y) * (_a.Y - _b.Y));
            if (l + 2 * size <= 5)
                return false;
            double r = l / 2 + size;
            double dx = r * Math.Cos(_angle);
            double dy = r * Math.Sin(_angle);
            PointF a = A;
            PointF b = B;
            PointF _m = new PointF((_a.X + _b.X) / 2, 
                (_a.Y + _b.Y) / 2);
            _a = new PointF((float)(_m.X - dx), (float)(_m.Y - dy));
            _b = new PointF((float)(_m.X + dx), (float)(_m.Y + dy));
            if (!Fits())
            {
                _a = a;
                _b = b;
                return false;
            }
            return true;
        }

        protected override bool Move_all_points(double dx, double dy)
        {
            _a = new PointF((float)(_a.X + dx), (float)(_a.Y + dy));
            _b = new PointF((float)(_b.X + dx), (float)(_b.Y + dy));
            if (!Fits())
            {
                _a = new PointF((float)(_a.X - dx), 
                    (float)(_a.Y - dy));
                _b = new PointF((float)(_b.X - dx), 
                    (float)(_b.Y - dy));
                return false;
            }
            return true;
        }

        protected override void Draw_shape(Graphics g, Pen p)
        {
            g.DrawLine(p, _a, _b);
        }

        public override bool Contains(PointF p)
        {
            double m = A.Y - Math.Tan(Angle) * A.X;
            double delta = 5;
            double d = Math.Abs(-p.X * Math.Tan(Angle) + p.Y - m) /
                Math.Sqrt(Math.Tan(Angle) * Math.Tan(Angle) + 1);
            return (d < delta && Belongs(p, delta));
        }

        private bool Belongs(PointF p, double d)
        {
            return (p.X <= A.X + d && p.X >= B.X - d || 
                p.X >= A.X - d && p.X <= B.X + d)
                && (p.Y <= A.Y + d && p.Y >= B.Y - d || 
                p.Y >= A.Y - d && p.Y <= B.Y + d);
        }

        protected override bool Fits()
        {
            return (_a.X >= 0 && _a.X <= w &&
                _a.Y >= m && _a.Y <= h &&
                _b.X >= 0 && _b.X <= w &&
                _b.Y >= m && _b.Y <= h);
        }

        public PointF Intersects(CSegment a)
        {
            double k1 = Math.Tan(a.Angle);
            double k2 = Math.Tan(this.Angle);
            double m1 = a.A.Y - k1 * a.A.X;
            double m2 = this.A.Y - k2 * this.A.X;
            PointF ans = new PointF(-1, -1);
            try
            {
                ans.X = (float)((m2 - m1) / (k1 - k2));
                ans.Y = (float)(k2 * ans.X + m2);
            }
            catch (DivideByZeroException)
            {
                ans.X = 99999;
                ans.Y = 99999;
            }
            return ans;
        }

        public PointF A { get => _a; }
        public PointF B { get => _b; }
        public double Angle { get => _angle; }
    }
}
