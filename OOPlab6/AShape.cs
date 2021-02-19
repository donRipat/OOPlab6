using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOPlab6
{
    abstract class AShape
    {
        protected int _color;

        protected static int w = 1006;
        protected static int h = 721;
        protected static int m = 24;

        public void Draw(Graphics g, int width)
        {
            Pen p;
            if (_color == 0)
                p = new Pen(Color.Green);
            else if (_color == 1)
                p = new Pen(Color.Orange);
            else if (_color == 2)
                p = new Pen(Color.Blue);
            else if (_color == 3)
                p = new Pen(Color.Purple);
            else if (_color == 4)
                p = new Pen(Color.Red);
            else
                p = new Pen(Color.Black);
            p.Width = width;
            Draw_shape(g, p);
        }

        public abstract void Draw_shape(Graphics g, Pen p);

        public void Chng_clr(int clr)
        {
            if (clr < 0)
            {
                ++_color;
                _color %= 3;
            }
            else
                _color = clr;
        }

        public abstract bool Resize(int sz);

        public abstract bool Contains(PointF p);

        public bool Move(int destination, int distance)
        {
            double d = distance / Math.Sqrt(2);
            if (destination == 1)
            {
                return Move_all_points(-d, d);
            }
            if (destination == 2)
            {
                return Move_all_points(0, distance);
            }
            if (destination == 3)
            {
                return Move_all_points(d, d);
            }
            if (destination == 4)
            {
                return Move_all_points(-distance, 0);
            }
            if (destination == 6)
            {
                return Move_all_points(distance, 0);
            }
            if (destination == 7)
            {
                return Move_all_points(-d, -d);
            }
            if (destination == 8)
            {
                return Move_all_points(0, -distance);
            }
            if (destination == 9)
            {
                return Move_all_points(d, -d);
            }
            return false;
        }

        public abstract bool Move_all_points(double dx, double dy);

        public abstract bool Fits();

        public int color { get => _color; }
    }
}
