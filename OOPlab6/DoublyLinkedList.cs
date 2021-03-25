using System.Windows.Forms;

namespace OOPlab6
{
    class DoublyNode
    {
        private AShape shape;
        public DoublyNode prev;
        public DoublyNode next;

        public DoublyNode(AShape shape)
        {
            this.shape = shape;
            prev = null;
            next = null;
        }

        public AShape Shape { get => shape; }
    }

    class DoublyLinkedList : ShapeList
    {
        public override AShape CreateShape(string code)
        {
            AShape ans = null;
            if (code == "C")
                ans = new CCircle();
            if (code == "S")
                ans = new CSegment();
            if (code == "P")
                ans = new Polygon();
            if (code == "G")
                ans = new CGroup();
            return ans;
        }

        public void SubjChanged(TreeViewer tree)
        {
            Set_current_first();
            foreach (TreeNode i in tree.TreeView.Nodes[0].Nodes)
            {
                ProcessNode(i);
                Step_forward();
            }
        }

        public bool ProcessNode(TreeNode i)
        {
            if (i.IsSelected)
            {
                Current.Shape.isCur = true;
                return true;
            }
            if (i.Nodes.Count > 0)
            {
                foreach (TreeNode tn in i.Nodes)
                    if (ProcessNode(tn))
                        return true;
            }
            Current.Shape.isCur = false;
            return false;
        }

        public void AddObservers(TreeViewer t)
        {
            observers = t;
        }

        protected override void Notify()
        {
            if (observers != null)
                observers.SubjChanged(this);
        }

        public void UpdateStickyShapes(AShape s)
        {
            DoublyLinkedList t = new DoublyLinkedList();
            Set_current_first();
            for (bool cond = !Is_empty(); cond; cond = Step_forward())
                if (CurShape != s && s.CloseTo(CurShape))
                    t.Push_back(CurShape);
            s.ChangeObservers(t);
        }
    }
}
