using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class CheckCompletenessOfBinaryTree
    {
        /**
         * 
         * Given a binary tree, determine if it is a complete binary tree.

Definition of a complete binary tree from Wikipedia:
In a complete binary tree every level, except possibly the last, is completely filled, 
        and all nodes in the last level are as far left as possible.
        It can have between 1 and 2h nodes inclusive at the last level h.

        Apply BFS
        For every node, add it to the queue
        Pop the queue and add its left and right , until node popped is a null

        keep popping the queue till the first element is null;

        if at the end , the queue is empty, it is a complete binary tree.

         * */
        public bool IsCompleteTree(TreeNode root)
        {
            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0 && queue.Peek() != null)
            {
                var element = queue.Dequeue();
                queue.Enqueue(element.left);
                queue.Enqueue(element.right);
            }


            while (queue.Count > 0 && queue.Peek() == null)
            {
                queue.Dequeue();
            }

            return queue.Count == 0;
        }
    }
}
