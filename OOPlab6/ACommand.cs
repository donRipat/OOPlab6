using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPlab6
{
    abstract class ACommand
    {
        public abstract void Execute(AShape a);
        public abstract void Unexecute();
        public abstract ACommand Clone();
    }

    class CmdResize : ACommand
    {
        private AShape s;
        int size;

        public CmdResize(int sz)
        {
            size = sz;
        }

        public override void Execute(AShape shape)
        {
            s = shape;
            if (s != null)
                s.Resize(size);
        }

        public override void Unexecute()
        {
            if (s != null)
                s.Resize(-size);
        }

        public override ACommand Clone()
        {
            return new CmdResize(size);
        }
    }
}
