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
        public abstract void Chng_sz(int sz);
        public abstract void Move(int destination);
    }
}
