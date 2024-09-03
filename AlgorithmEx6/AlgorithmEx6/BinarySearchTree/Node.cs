using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmEx6.BinarySearchTree
{
    //
    public class Node
    {
        private int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int iValue)
        {
            Value = iValue;
        }

        public void Add(Node node)
        {
            if (node == null) return;
            if ( node.Value< this.Value)
            {
                if(this.Left==null) this.Left = node;
                else this.Left.Add(node);
            }
            else
            {
                if (this.Right == null) this.Right = node;
                else this.Right.Add(node);
            }
        }
        //中序遍歷
        public void midOrderSort()
        { 
            if(this.Left!=null)
                this.Left.midOrderSort();
            Console.WriteLine(this.Value);
            if(this.Right!=null)
                this.Right.midOrderSort();
        }
    }
}
