using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPlab6
{
    class TreeViewer
    {
        private TreeView treeView;

        private DoublyLinkedList observers;

        public TreeViewer(TreeView tree)
        {
            treeView = tree;
        }

        public void SubjChanged(DoublyLinkedList L)
        {
            treeView.BeginUpdate();
            treeView.Nodes[0].Nodes.Clear();
            int i = 0;
            L.Set_current_first();
            for (bool cond = !L.Is_empty(); cond;
                cond = L.Step_forward())
            {
                TreeNode node = new TreeNode();
                treeView.Nodes[0].Nodes.Add(node);
                if (L.Current.Shape != null)
                    treeView.SelectedNode = node;
                ProcessNode(treeView.Nodes[0].Nodes[i++],
                    L.Current.Shape);

            }
            treeView.EndUpdate();
        }

        protected void ProcessNode(TreeNode tn, AShape a)
        {
            if (a != null)
                tn.Text = a.ToString().Substring(8);
            CGroup gr = a as CGroup;
            if (gr != null)
            {
                DoublyLinkedList L = gr.Shapes;
                int i = 0;
                L.Set_current_first();
                for (bool cond = !L.Is_empty(); cond;
                cond = L.Step_forward())
                {
                    tn.Nodes.Add(new TreeNode());
                    ProcessNode(tn.Nodes[i++], L.Current.Shape);
                }
            }
        }

        public void AddObs(DoublyLinkedList L)
        {
            observers = L;
        }

        private void Notify()
        {
            if (observers != null)
                observers.SubjChanged(this);
        }

        public void SelectedChanged()
        {
            Notify();
        }

        public TreeView TreeView { get => treeView; }
    }
}
