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
    }
}
