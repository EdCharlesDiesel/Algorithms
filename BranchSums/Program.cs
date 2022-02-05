//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BranchSums
//{
//    using System.Collections.Generic;
//public class Program {
// public class BinaryTree {
// public int value;
// public BinaryTree left;
// public BinaryTree right;
// public BinaryTree(int value) {
// this.value = value;
// this.left = null;
// this.right = null;
// }
// }
// // O(n) time | O(n) space - where n is the number of nodes in the Bi
// public static List<int> BranchSums(BinaryTree root) {
// List<int> sums = new List<int>();
// calculateBranchSums(root, 0, sums);
// return sums;
// }
// public static void calculateBranchSums(BinaryTree node, int runningS
// if (node == null) return;
// int newRunningSum = runningSum + node.value;
// if (node.left == null && node.right == null) {
// sums.Add(newRunningSum);
// return;
// }
//1
//2
//3