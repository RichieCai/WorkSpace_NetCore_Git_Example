using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class IntuitionAndApproach
    {
        public IntuitionAndApproach()
        {

        }
        int maxResult = 0;

        public int MaxPathSum(TreeNode root)
        {
            maxResult = root.val;
            DFS(root);
            return maxResult;
        }

        private int DFS(TreeNode node)
        {
            if (node == null)
                return 0;

            //get sum of left-path and right-path
            int leftPathSum = Math.Max(0, DFS(node.left));
            int rightPathSum = Math.Max(0, DFS(node.right));

            maxResult = Math.Max(maxResult, node.val + leftPathSum + rightPathSum);

            //while returning result back to upper-level, we can only consider one of the left/right path, hence we choose the one with max sum
            return (node.val + Math.Max(leftPathSum, rightPathSum));
        }

        public TreeNode setTree()
        {
            TreeNode tnodeLeft = new TreeNode();
            tnodeLeft.val = 9;
            TreeNode tnodeRight= new TreeNode();
            tnodeRight.val = 20;
            TreeNode tnodeRightLeft = new TreeNode();
            tnodeRightLeft.val = 15;
            TreeNode tnodeRightRight = new TreeNode();
            tnodeRightRight.val = 7;
            tnodeRight.left = tnodeRightLeft;
            tnodeRight.right = tnodeRightRight;

            TreeNode root = new TreeNode();
            root.val = -10;
            root.left = tnodeLeft;
            root.right = tnodeRight;
            return root;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

    }
}
