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
        public abstract void Draw(Graphics g);
        public abstract void Chng_clr(int clr);
        public abstract void Resize(int sz);
        public void Move(int destination, int distance)
        {
            int d = (int)(distance * 1.414);
            if (destination == 1)
            {
                Move_all_points(-d, d);
            }
            if (destination == 2)
            {
                Move_all_points(0, distance);
            }
            if (destination == 3)
            {
                Move_all_points(d, d);
            }
            if (destination == 4)
            {
                Move_all_points(-distance, 0);
            }
            if (destination == 6)
            {
                Move_all_points(distance, 0);
            }
            if (destination == 7)
            {
                Move_all_points(-d, -d);
            }
            if (destination == 8)
            {
                Move_all_points(0, -distance);
            }
            if (destination == 9)
            {
                Move_all_points(d, -d);
            }
        }
        protected abstract void Move_all_points(int dx, int dy);
    }
}
