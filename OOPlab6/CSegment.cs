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
        private double angle;
        
        public CSegment(Point a, Point b)
        {
            _a = new Point(a.X, a.Y);
            _b = new Point(b.X, b.Y);
            _m = new Point((_a.X + _b.X) / 2, (_a.Y + _b.Y) / 2);
            int dx = Math.Abs(_a.X - _m.X);
            int dy = Math.Abs(_a.Y - _m.Y);
            try
            {
                angle = Math.Atan((dy + .0) / dx);
            }
            catch (DivideByZeroException)
            {
                angle = Math.Asin(1);
            }
        }

        public override void Chng_clr(int color)
        {
            throw new NotImplementedException();
        }

        public override void Chng_sz(int size)
        {
            int l = (int)Math.Sqrt((_a.X - _b.X) * (_a.X - _b.X) + 
                (_a.Y - _b.Y) * (_a.Y - _b.Y));
            if (l > 60 && size < 0 || size > 0)
            {
                int r = l / 2 + size;
                _a = new Point(_m.X - (int)(r * Math.Cos(angle)), 
                    _m.Y - (int)(r * Math.Sin(angle)));
                _b = new Point(_m.X + (int)(r * Math.Cos(angle)), 
                    _m.Y + (int)(r * Math.Sin(angle)));
            }
        }

        public override void Move(int destination)
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics g)
        {
            //Brush b = new SolidBrush(Color.Green);
            Pen p = new Pen(Color.Green);
            g.DrawLine(p, _a, _b);
        }
    }
}
