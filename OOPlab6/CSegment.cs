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
        private Point _a, _b, _m;
        private double _angle;
        
        public CSegment(Point a, Point b)
        {
            _a = new Point(a.X, a.Y);
            _b = new Point(b.X, b.Y);
            _m = new Point((_a.X + _b.X) / 2, (_a.Y + _b.Y) / 2);
            int dx = Math.Abs(_a.X - _m.X);
            int dy = Math.Abs(_a.Y - _m.Y);
            try
            {
                _angle = Math.Atan((dy + .0) / dx);
            }
            catch (DivideByZeroException)
            {
                _angle = Math.Asin(1);
            }
        }

        public override void Chng_clr(int color)
        {
            if (color < 0)
                ++_color;
            else
                _color = color;
            _color %= 4;
        }

        public override void Resize(int size)
        {
            int l = (int)Math.Sqrt((_a.X - _b.X) * (_a.X - _b.X) + 
                (_a.Y - _b.Y) * (_a.Y - _b.Y));
            if (l > 60 && size < 0 || size > 0)
            {
                int r = l / 2 + size;
                _a = new Point(_m.X - (int)(r * Math.Cos(_angle)), 
                    _m.Y - (int)(r * Math.Sin(_angle)));
                _b = new Point(_m.X + (int)(r * Math.Cos(_angle)), 
                    _m.Y + (int)(r * Math.Sin(_angle)));
            }
        }

        protected override void Move_all_points(int dx, int dy)
        {
            if (_a.X + dx >= 0 && _a.X + dx <= 1024 &&
                _a.Y + dy >= 0 && _a.Y + dy <= 768 &&
                _b.X + dx >= 0 && _b.X + dx <= 1024 &&
                _b.Y + dy >= 0 && _b.Y + dy <=768)
            {
                _a = new Point(_a.X + dx, _a.Y + dy);
                _b = new Point(_b.X + dx, _b.Y + dy);
                _m = new Point(_m.X + dx, _m.Y + dy);
            }
        }

        public override void Draw(Graphics g)
        {
            Pen p;
            if (_color == 0)
                p = new Pen(Color.Green);
            else if (_color == 1)
                p = new Pen(Color.Orange);
            else if (_color == 2)
                p = new Pen(Color.Blue);
            else
                p = new Pen(Color.Purple);
            p.Width = 3;
            g.DrawLine(p, _a, _b);
        }
    }
}
