using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
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

        public class DeleteNodeBST450
        {
            public static TreeNode DeleteNode(TreeNode root, int key)
            {
                if (root == null)
                {
                    return null;
                }

                if (root.val > key)
                {
                    root.left = DeleteNode(root.left, key);
                }
                else if (root.val < key)
                {
                    root.right = DeleteNode(root.right, key);
                }
                else
                {
                    if (root.left == null && root.right == null)
                    {
                        return null;
                    }
                    else if (root.right != null)
                    {
                        var next = Successor(root);
                        root.val = next;
                        root.right = DeleteNode(root.right, next);
                    }
                    else
                    {
                        var prev = Predecessor(root);
                        root.val = prev;
                        root.left = DeleteNode(root.left, prev);
                    }
                }

                return root;
            }

            public static int Successor(TreeNode root)
            {
                root = root.right;

                while (root.left != null)
                {
                    root = root.left;
                }

                return root.val;
            }

            public static int Predecessor(TreeNode root)
            {
                root = root.left;

                while (root.right != null)
                {
                    root = root.right;
                }

                return root.val;
            }

        }
    }
}
