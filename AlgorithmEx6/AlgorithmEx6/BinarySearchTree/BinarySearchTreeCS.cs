using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmEx6.BinarySearchTree
{
    //二元搜尋數
    public class BinarySearchTreeCS
    {
        private Node _root;
        public BinarySearchTreeCS()
        { 
        
        }

        public void Add(Node node)
        {
            if (_root == null)
                _root = node;
            else
                _root.Add(node);
        }

        ////中序遍歷
        public void midOrderSort()
        {
            if (_root != null)
                _root.midOrderSort();
            else
                Console.WriteLine("二元搜尋樹為空!");
            
        }
    }
}
