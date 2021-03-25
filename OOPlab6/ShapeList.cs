using System;
using System.IO;

namespace OOPlab6
{
    class ShapeList
    {
        private int count;
        private DoublyNode head;
        private DoublyNode current;
        private DoublyNode tail;
        protected TreeViewer observers;

        public ShapeList()
        {
            head = null;
            tail = null;
            current = null;
            count = 0;
        }

        //  Search given shape and set current to it if found
        public bool Search(AShape s)
        {
            if (s != null)
            {
                DoublyNode t = current;
                Set_current_first();
                for (bool cond = !Is_empty(); cond;
                    cond = Step_forward())
                    if (Current.Shape == s)
                        return true;
                current = t;
            }
            Notify();
            return false;
        }

        //  Add new shape to the back of the list
        public bool Push_back(AShape shape)
        {
            if (shape == null)
                return false;
            DoublyNode fresh = new DoublyNode(shape);
            if (count > 0)
            {
                fresh.prev = tail;
                tail.next = fresh;
                tail = fresh;
            }
            else
            {
                tail = fresh;
                head = fresh;
            }
            current = tail;
            ++count;
            Notify();
            return true;
        }

        //  Add new shape to the front of the list
        public bool Push_front(AShape shape)
        {
            if (shape == null)
                return false;
            DoublyNode fresh = new DoublyNode(shape);
            if (count > 0)
            {
                head.prev = fresh;
                fresh.next = head;
                head = fresh;
            }
            else
            {
                tail = fresh;
                head = fresh;
            }
            current = head;
            ++count;
            Notify();
            return true;
        }

        //  Delete last shape from list
        public bool Delete_last()
        {
            if (tail == null)
                return false;
            if (count > 1)
            {
                tail.prev.next = null;
                tail = tail.prev;
                if (current == null)
                    current = tail;
            }
            else
            {
                tail = null;
                head = null;
                current = null;
            }
            --count;
            Notify();
            return true;
        }

        //  Delete current and set current to previous
        public bool Delete_current()
        {
            if (current != null)
            {
                if (current != head && current != tail)
                {
                    current.prev.next = current.next;
                    current.next.prev = current.prev;
                    current = current.prev;
                    --count;
                }
                else if (current == head)
                {
                    current = null;
                    Delete_first();
                }
                else
                {
                    current = null;
                    Delete_last();
                }
                Notify();
                return true;
            }
            return false;
        }

        //  Delete first shape from list
        public bool Delete_first()
        {
            if (head == null)
                return false;
            if (count > 1)
            {
                head.next.prev = null;
                head = head.next;
                if (current == null)
                    current = head;
            }
            else
            {
                tail = null;
                head = null;
                current = null;
            }
            --count;
            Notify();
            return true;
        }

        public void Clear()
        {
            count = 0;
            head = null;
            tail = null;
            current = null;
            Notify();
        }

        //  Move current to the next shape
        public bool Step_forward()
        {
            if (count == 0 || current.next == null)
                return false;
            current = current.next;
            return true;
        }

        //  Move current to the previous shape
        public bool Step_back()
        {
            if (count == 0 || current.prev == null)
                return false;
            current = current.prev;
            return true;
        }

        //  Set current to the head
        public bool Set_current_first()
        {
            if (head == null)
                return false;
            current = head;
            return true;
        }

        //  Set current to the tail
        public bool Set_current_last()
        {
            if (tail == null)
                return false;
            current = tail;
            return true;
        }
        
        //  Check if list is empty
        public bool Is_empty()
        {
            if (count == 0)
                return true;
            return false;
        }

        public DoublyNode Current { get => current; }
        public DoublyNode Head { get => head; }
        public DoublyNode Tail { get => tail; }
        public int Count { get => count; }
        public AShape CurShape
        {
            get
            {
                if (current != null)
                    return current.Shape;
                return null;
            }
        }
        
        public virtual AShape CreateShape(string code)
        {
            return null;
        }

        public bool LoadShapes(StreamReader sr)
        {
            try
            {
                int count = int.Parse(sr.ReadLine());
                for (int i = 0; i < count; ++i)
                {
                    string code = sr.ReadLine();
                    AShape s = CreateShape(code);
                    s.Load(sr);
                    if (s == null)
                        return false;
                    Push_back(s);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveShapes(StreamWriter sw)
        {
            try
            {
                sw.WriteLine(Count);
                Set_current_first();
                for (bool cond = !Is_empty(); cond;
                    cond = Step_forward())
                    if (!Current.Shape.Save(sw))
                        return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected virtual void Notify()
        {
            ;
        } 
    }
}
