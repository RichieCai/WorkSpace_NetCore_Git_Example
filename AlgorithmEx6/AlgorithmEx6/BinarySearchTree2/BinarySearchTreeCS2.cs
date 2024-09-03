using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmEx6.BinarySearchTree2
{
    public class Tree<TItem> where TItem : IComparable<TItem>
    {
        public TItem NodeData { get; set; }
        public Tree<TItem> LeftTree { get; set; }

        public Tree<TItem> RightTree { get; set; }

        public Tree(TItem nodeValue)
        { 
            this.NodeData = nodeValue;
            this.LeftTree = null;
            this.RightTree = null;
        }
        public void Insert(TItem newItem)
        {
            TItem currentNodeValue = this.NodeData;

            if (currentNodeValue.CompareTo(newItem) > 0)
            {
                if (this.LeftTree == null)
                    this.LeftTree = new Tree<TItem>(newItem);
                else
                    this.LeftTree.Insert(newItem);
            }
            else
            {
                if (this.RightTree == null)
                    this.RightTree = new Tree<TItem>(newItem);
                else
                    this.RightTree.Insert(newItem);
            }
        }

        //做一個WalkTree()方法，依左中右的順序從最下層開始找二元樹的節點。
        //這個方法是讓我們可以印出二元樹各節點的值。
        public void WalkTree()
        { 
            if(this.LeftTree!=null) this.LeftTree.WalkTree();
            Console.WriteLine(this.NodeData.ToString());
            if (this.RightTree != null) this.RightTree.WalkTree();
        }
    }
}
