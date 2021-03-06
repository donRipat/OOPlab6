﻿using System;
using System.Drawing;
using System.IO;

namespace OOPlab6
{
    class CSegment : AShape
    {
        private PointF _a, _b;
        private double _angle;
        
        public CSegment()
        {
            _a = new PointF();
            _b = new PointF();
            _angle = 0;
            center = new PointF();
        }
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
            center = new PointF((_a.X + _b.X) / 2,
                (_a.Y + _b.Y) / 2);
            r = Math.Sqrt((_a.X - _b.X) * (_a.X - _b.X) +
                    (_a.Y - _b.Y) * (_a.Y - _b.Y)) / 2;
        }
        public CSegment(CSegment seg)
        {
            _a = seg._a;
            _b = seg._b;
            _angle = seg._angle;
            _color = seg.color;
            center = seg.center;
            r = seg.r;
        }
        public CSegment(PointF a, PointF b, int c) : this(a, b)
        {
            _color = c;
        }

        public override bool Resize(int size)
        {
            if (r + 2 * size <= 5)
                return false;
            double d = r + size;
            double dx = d * Math.Cos(_angle);
            double dy = d * Math.Sin(_angle);
            PointF a = A;
            PointF b = B;
            PointF _m = center;
            r += size;
            _a = new PointF((float)(_m.X - dx), (float)(_m.Y - dy));
            _b = new PointF((float)(_m.X + dx), (float)(_m.Y + dy));
            if (!Fits())
            {
                r -= size;
                _a = a;
                _b = b;
                return false;
            }
            return true;
        }

        public override bool Move_all_points(double dx, double dy)
        {
            _a = new PointF((float)(_a.X + dx), (float)(_a.Y + dy));
            _b = new PointF((float)(_b.X + dx), (float)(_b.Y + dy));
            center = new PointF((float)(center.X + dx), 
                (float)(center.Y + dy));
            if (!Fits())
            {
                _a = new PointF((float)(_a.X - dx), 
                    (float)(_a.Y - dy));
                _b = new PointF((float)(_b.X - dx), 
                    (float)(_b.Y - dy));
                center = new PointF((float)(center.X - dx),
                (float)(center.Y - dy));
                return false;
            }
            return true;
        }

        public override void Draw_shape(Graphics g, Pen p)
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

        public override bool Fits()
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

        public override DoublyLinkedList Ungroup()
        {
            return null;
        }

        public override AShape Clone()
        {
            return new CSegment(this);
        }

        public override bool Save(StreamWriter sw)
        {
            try
            {
                sw.WriteLine("S");
                sw.WriteLine(color + " " + A.X + " " + A.Y + " " + 
                    B.X + " " + B.Y);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Load(StreamReader sr)
        {
            try
            {
                string[] s = sr.ReadLine().Split(' ');
                _color = int.Parse(s[0]);
                _a.X = (float)Convert.ToDouble(s[1]);
                _a.Y = (float)Convert.ToDouble(s[2]);
                _b.X = (float)Convert.ToDouble(s[3]);
                _b.Y = (float)Convert.ToDouble(s[4]);
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
                center = new PointF((_a.X + _b.X) / 2,
                    (_a.Y + _b.Y) / 2);
                r = Math.Sqrt((_a.X - _b.X) * (_a.X - _b.X) +
                    (_a.Y - _b.Y) * (_a.Y - _b.Y)) / 2;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override PointF Max
        {
            get
            {
                PointF max = new PointF();
                max.X = Math.Max(A.X, B.X);
                max.Y = Math.Max(A.Y, B.Y);
                return max;
            }
        }

        public override PointF Min
        {
            get
            {
                PointF min = new PointF();
                min.X = Math.Min(A.X, B.X);
                min.Y = Math.Min(A.Y, B.Y);
                return min;
            }
        }
    }
}
