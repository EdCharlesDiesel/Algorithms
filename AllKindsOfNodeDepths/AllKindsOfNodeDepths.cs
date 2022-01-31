﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllKindsOfNodeDepths
{
    class AllKindsOfNodeDepths
    {
        // Average case: when the tree is balanced  
        // O(nlog(n)) time | O(h) space - where n is the number of nodes in  
        // the Binary Tree and h is the height of the Binary Tree
        public static int AllKindsOfNodeDepths(BinaryTree root) { if (root == null) return 0; return AllKindsOfNodeDepths(root.left) + AllKindsOfNodeDepths(root.right) + nodeDepths(root, 0); }
        public static int nodeDepths(BinaryTree node, int depth) { if (node == null) return 0; return depth + nodeDepths(node.left, depth + 1) + nodeDepths(node.right, depth + 1); }
        public class BinaryTree
        {
            public int value; public BinaryTree left; public BinaryTree right;
            public BinaryTree(int value) { this.value = value; left = null; right = null; }
        } 
    }
}
