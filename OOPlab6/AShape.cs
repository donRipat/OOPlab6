using System;
using System.Drawing;
using System.IO;

namespace OOPlab6
{
    abstract class Sticky
    {
        public bool sticky = false;
        protected DoublyLinkedList obs = null;
        protected PointF min, max;

        protected PointF center;
        protected double r;

        public PointF Center { get => center; }

        public void Switch()
        {
            if (sticky)
                sticky = false;
            else sticky = true;
        }
        
        public void ChangeObservers(DoublyLinkedList L)
        {
            obs = L;
        }

        public void AddObserver(AShape s)
        {
            obs.Push_back(s);
        }

        public virtual PointF Min { get => min; }
        public virtual PointF Max { get => max; }
    }

    abstract class AShape : Sticky
    {
        protected int _color;

        protected static int w = 1006;
        protected static int h = 721;
        protected static int m = 24;

        protected bool cur = false;

        public bool isCur
        {
            get => cur;
            set { cur = value; }
        }

        public virtual void Draw(Graphics g, int width)
        {
            Pen p;
            if (_color == 0)
                p = new Pen(Color.Green);
            else if (_color == 1)
                p = new Pen(Color.Purple);
            else if (_color == 2)
                p = new Pen(Color.Blue);
            else if (_color == 3)
                p = new Pen(Color.Orange);
            else if (_color == 4)
                p = new Pen(Color.Red);
            else
                p = new Pen(Color.Black);
            p.Width = width;
            Draw_shape(g, p);
        }

        public virtual void Draw(Graphics g, int width, int color)
        {
            Pen p;
            if (color == 0)
                p = new Pen(Color.Green);
            else if (color == 1)
                p = new Pen(Color.Purple);
            else if (color == 2)
                p = new Pen(Color.Blue);
            else if (color == 3)
                p = new Pen(Color.Orange);
            else if (color == 4)
                p = new Pen(Color.Red);
            else
                p = new Pen(Color.Black);
            p.Width = width;
            Draw_shape(g, p);
        }

        public abstract void Draw_shape(Graphics g, Pen p);

        public virtual void Chng_clr(int clr)
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
            bool ans = false;
            double dx = 0, dy = 0;
            double d = distance / Math.Sqrt(2);
            if (destination == 1)
            {
                dx = -d; dy = d;
            }
            if (destination == 2)
            {
                dx = 0; dy = distance;
            }
            if (destination == 3)
            {
                dx = d; dy = d;
            }
            if (destination == 4)
            {
                dx = -distance; dy = 0;
            }
            if (destination == 6)
            {
                dx = distance; dy = 0;
            }
            if (destination == 7)
            {
                dx = -d; dy = -d;
            }
            if (destination == 8)
            {
                dx = 0; dy = -distance;
            }
            if (destination == 9)
            {
                dx = d; dy = -d;
            }
            ans = Move_all_points(dx, dy);
            if (sticky && ans)
                Notify(dx, dy);
            return ans;
        }

        protected bool Notify(double dx, double dy)
        {
            if (obs == null) return false;
            obs.Set_current_first();
            for (bool cond = !obs.Is_empty(); cond;
                cond = obs.Step_forward())
                obs.CurShape.SubjChanged(dx, dy);
            obs.Set_current_first();
            for (bool cond = !obs.Is_empty(); cond;)
            {
                if (this.CloseTo(obs.CurShape))
                    cond = obs.Step_forward();
                else if (obs.Current == obs.Head)
                {
                    obs.Delete_current();
                    cond = !obs.Is_empty();
                }
                else
                {
                    obs.Delete_current();
                    cond = obs.Step_forward();
                }
            }
            return true;
        }

        public virtual bool SubjChanged(double dx, double dy)
        {
            return Move_all_points(dx, dy);
        }

        public virtual bool CloseTo(AShape s)
        {
            double d = Math.Sqrt((center.X - s.Center.X) *
                (center.X - s.Center.X) + (center.Y - s.Center.Y) *
                (center.Y - s.Center.Y));
            return (d <= r + s.r);
        }

        public abstract bool Move_all_points(double dx, double dy);

        public abstract bool Fits();

        public int color { get => _color; }

        public abstract DoublyLinkedList Ungroup();

        public abstract AShape Clone();

        public abstract bool Save(StreamWriter sw);

        public abstract bool Load(StreamReader sr);
    }
}
