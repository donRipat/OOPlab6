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

        public void Draw(Graphics g)
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
            Draw_shape(g, p);
        }

        protected abstract void Draw_shape(Graphics g, Pen p);

        public void Chng_clr(int clr)
        {
            if (clr < 0)
                ++_color;
            else
                _color = clr;
            _color %= 4;
        }

        public abstract bool Resize(int sz);

        public abstract bool Contains(Point p);

        public bool Move(int destination, int distance)
        {
            int d = (int)(distance / 1.414);
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

        protected abstract bool Move_all_points(int dx, int dy);

        protected abstract bool Fits();
    }
}
