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
        private Point _a, _b;
        private double _angle;
        
        public CSegment(Point a, Point b)
        {
            _a = new Point(a.X, a.Y);
            _b = new Point(b.X, b.Y);
            int dx = _a.X - _b.X;
            int dy = _a.Y - _b.Y;
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
            int l = (int)Math.Sqrt((_a.X - _b.X) * (_a.X - _b.X) +
                    (_a.Y - _b.Y) * (_a.Y - _b.Y));
            if (l + 2 * size <= 5)
                return false;
            int r = l / 2 + size;
            int dx = (int)Math.Round(r * Math.Cos(_angle));
            int dy = (int)Math.Round(r * Math.Sin(_angle));
            Point a = A;
            Point b = B;
            Point _m = new Point((_a.X + _b.X) / 2, 
                (_a.Y + _b.Y) / 2);
            _a = new Point(_m.X - dx, _m.Y - dy);
            _b = new Point(_m.X + dx, _m.Y + dy);
            if (!Fits())
            {
                _a = a;
                _b = b;
                return false;
            }
            return true;
        }

        protected override bool Move_all_points(int dx, int dy)
        {
            _a = new Point(_a.X + dx, _a.Y + dy);
            _b = new Point(_b.X + dx, _b.Y + dy);
            if (!Fits())
            {
                _a = new Point(_a.X - dx, _a.Y - dy);
                _b = new Point(_b.X - dx, _b.Y - dy);
                return false;
            }
            return true;
        }

        protected override void Draw_shape(Graphics g, Pen p)
        {
            g.DrawLine(p, _a, _b);
        }

        public override bool Contains(Point p)
        {
            int m = (int)(A.Y - Math.Tan(Angle) * A.X);
            int d = (int)(Math.Abs(-p.X * Math.Tan(Angle) + p.Y - m) /
                Math.Sqrt(Math.Tan(Angle) * Math.Tan(Angle) + 1));
            return (d < 10);
        }

        protected override bool Fits()
        {
            return (_a.X >= 0 && _a.X <= w &&
                _a.Y >= 0 && _a.Y <= h &&
                _b.X >= 0 && _b.X <= w &&
                _b.Y >= 0 && _b.Y <= h);
        }

        public Point A { get => _a; }
        public Point B { get => _b; }
        public double Angle { get => _angle; }
    }
}
