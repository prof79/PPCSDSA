//----------------------------------------------------------------------------
// <copyright file="Program.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      The main program class for the "Binary Trees" console demos.
// </description>
// <version>v0.9.4 2018-08-07T23:58:00+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.BinaryTrees
{
    using System;
    using System.Linq;

    using at.markusegger.Lab.Library.DataStructures;
    using at.markusegger.Lab.Library.DataStructures.Extensions;
    //using Util;

    using static System.Console;

    /// <summary>
    /// The main program class for the "Binary Trees" console demos.
    /// </summary>
    internal static class Program
    {
        #region Fields

        private static readonly Random _random = new Random();

        #endregion

        /// <summary>
        /// The main method of the "Binary Trees" demo program.
        /// </summary>
        /// <param name="args">
        /// The program arguments supplied on the command-line.
        /// </param>
        private static void Main(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            WriteLine();
            WriteLine("*** BINARY TREE DEMOS ***");
            WriteLine();

            // Show the sample binary tree with numbers from the
            // book's introduction to binary trees.
            SampleBinaryTreeDemo();

            WriteLine();

            // Binary tree pre-order traversal demo
            BinaryTreePreOrderDemo();

            WriteLine();

            // Binary tree in-order traversal demo
            BinaryTreeInOrderDemo();

            WriteLine();

            // Binary tree post-order traversal demo
            BinaryTreePostOrderDemo();

            WriteLine();

            // Binary tree level-order traversal demo
            BinaryTreeLevelOrderDemo();

            WriteLine();

            // Examine binary search trees.
            SampleBinarySearchTreeDemos();

            WriteLine();
        }

        #region Demo Methods

        /// <summary>
        /// Simple binary tree demo just printing the demo tree.
        /// </summary>
        private static void SampleBinaryTreeDemo()
        {
            WriteLine("SAMPLE BINARY TREE DEMO");
            WriteLine();

            var tree = CreateBookSampleBinaryTree();

            WriteLine(tree);

            WriteLine();
        }

        /// <summary>
        /// Simple binary search tree demos examining various BSTs.
        /// </summary>
        private static void SampleBinarySearchTreeDemos()
        {
            IBinarySearchTreeNode<int> resultNode = null;
            var result = false;

            WriteLine("SAMPLE BINARY SEARCH TREE DEMOS");
            WriteLine();

            var invalidTree = CreateBookSampleBinarySearchTree();

            WriteLine(invalidTree);

            WriteLine($"Is valid BST? {invalidTree.Root.IsValidSearchTree}");

            WriteLine();
            WriteLine();

            var validTree1 = CreateValidBinarySearchTree1();

            WriteLine(validTree1);

            WriteLine($"Is valid BST? {validTree1.Root.IsValidSearchTree}");

            var v1data1 = 47;
            var v1data2 = 43;

            result = validTree1.Root.Find(v1data1, out resultNode);
            WriteLine($"Search for {v1data1}: Found = {result}, Node = '{resultNode}'.");

            result = validTree1.Root.Find(v1data2, out resultNode);
            WriteLine($"Search for {v1data2}: Found = {result}, Node = '{resultNode}'.");

            WriteLine();
            WriteLine();

            var validTree2 = CreateValidBinarySearchTree2();

            WriteLine(validTree2);

            WriteLine($"Is valid BST? {validTree2.Root.IsValidSearchTree}");

            var v2data1 = 60;
            var v2data2 = 73;

            result = validTree2.Root.Find(v2data1, out resultNode);
            WriteLine($"Search for {v2data1}: Found = {result}, Node = '{resultNode}'.");

            result = validTree2.Root.Find(v2data2, out resultNode);
            WriteLine($"Search for {v2data2}: Found = {result}, Node = '{resultNode}'.");

            WriteLine();
        }

        /// <summary>
        /// A helper method to generalize the common steps of binary tree
        /// traversal and demo output.
        /// </summary>
        /// <param name="caption">
        /// The title of the traversal that is being performed.
        /// </param>
        /// <param name="traversalMode">
        /// The algorithm to use for traversing the tree.
        /// </param>
        private static void BinaryTreeTraversalDemo(string caption, TreeTraversalMode traversalMode)
        {
            var captionUpper = caption.ToUpper();
            var captionCapitalized = captionUpper.First() + caption.ToLower().Substring(1);

            WriteLine($"BINARY TREE {captionUpper} TRAVERSAL DEMO");
            WriteLine();

            var tree = CreateBookSampleBinaryTree();

            WriteLine(tree);

            WriteLine();

            WriteLine($"{captionCapitalized} traversal:");
            WriteLine();

            var traverse = tree.Root.Traverse(traversalMode);

            var orderIndex = 0;

            foreach (var node in traverse)
            {
                ++orderIndex;

                WriteLine($"#{orderIndex}: {node.Data} ({node.GetTreeNodeTypeDescriptor()})");
            }

            WriteLine();
        }

        /// <summary>
        /// Showcase binary tree pre-order (depth-first) traversal.
        /// </summary>
        private static void BinaryTreePreOrderDemo()
            => BinaryTreeTraversalDemo("pre-order", TreeTraversalMode.PreOrder);

        /// <summary>
        /// Showcase binary tree in-order (depth-first) traversal.
        /// </summary>
        private static void BinaryTreeInOrderDemo()
            => BinaryTreeTraversalDemo("in-order", TreeTraversalMode.InOrder);

        /// <summary>
        /// Showcase binary tree post-order (depth-first) traversal.
        /// </summary>
        private static void BinaryTreePostOrderDemo()
            => BinaryTreeTraversalDemo("post-order", TreeTraversalMode.PostOrder);

        /// <summary>
        /// Showcase binary tree level-order (breadth-first) traversal.
        /// </summary>
        private static void BinaryTreeLevelOrderDemo()
            => BinaryTreeTraversalDemo("level-order", TreeTraversalMode.LevelOrder);

        #endregion

        #region Helper Methods

        /// <summary>
        /// Create a sample binary tree structure of integer number
        /// nodes like in the book.
        /// </summary>
        /// <returns>
        /// A binary tree of integer numbers.
        /// </returns>
        private static BinaryTree<int> CreateBookSampleBinaryTree()
        {
            var tree = new BinaryTree<int>();

            // 1st level
            var one = new BinaryTreeNode<int> { Data = 1 };

            // 2nd level
            var nine = new BinaryTreeNode<int> { Data = 9 };
            var four = new BinaryTreeNode<int> { Data = 4 };

            // 3rd level
            var five = new BinaryTreeNode<int> { Data = 5 };
            var six = new BinaryTreeNode<int> { Data = 6 };
            var two = new BinaryTreeNode<int> { Data = 2 };

            // 4th level
            var three = new BinaryTreeNode<int> { Data = 3 };
            var seven = new BinaryTreeNode<int> { Data = 7 };

            // 5th level
            var eight = new BinaryTreeNode<int> { Data = 8 };

            // Build tree structure
            tree.Root = one;

            one.Left = nine;
            one.Right = four;

            nine.Left = five;
            nine.Right = six;

            four.Right = two;

            six.Left = three;

            two.Left = seven;

            seven.Right = eight;

            return tree;
        }

        /// <summary>
        /// Create a sample binary search tree structure of integer number
        /// nodes. This is based on the first binary tree in the book thus
        /// yielding an invalid BST (it's a binary tree but not a BST).
        /// </summary>
        /// <returns>
        /// An invalid binary search tree of integer numbers.
        /// </returns>
        private static BinarySearchTree<int> CreateBookSampleBinarySearchTree()
        {
            var tree = new BinarySearchTree<int>();

            // 1st level
            var one = new BinarySearchTreeNode<int> { Data = 1 };

            // 2nd level
            var nine = new BinarySearchTreeNode<int> { Data = 9 };
            var four = new BinarySearchTreeNode<int> { Data = 4 };

            // 3rd level
            var five = new BinarySearchTreeNode<int> { Data = 5 };
            var six = new BinarySearchTreeNode<int> { Data = 6 };
            var two = new BinarySearchTreeNode<int> { Data = 2 };

            // 4th level
            var three = new BinarySearchTreeNode<int> { Data = 3 };
            var seven = new BinarySearchTreeNode<int> { Data = 7 };

            // 5th level
            var eight = new BinarySearchTreeNode<int> { Data = 8 };

            // Build tree structure
            tree.Root = one;

            one.Left = nine;
            one.Right = four;

            nine.Left = five;
            nine.Right = six;

            four.Right = two;

            six.Left = three;

            two.Left = seven;

            seven.Right = eight;

            return tree;
        }

        /// <summary>
        /// Create a valid sample binary search tree.
        /// This is the 1st sample BST from the book.
        /// </summary>
        /// <returns>
        /// A valid binary search tree of integer numbers.
        /// </returns>
        private static BinarySearchTree<int> CreateValidBinarySearchTree1()
        {
            var tree = new BinarySearchTree<int>();

            // 1st level
            var fifty = new BinarySearchTreeNode<int> { Data = 50 };

            // 2nd level
            var fourty = new BinarySearchTreeNode<int> { Data = 40 };
            var sixty = new BinarySearchTreeNode<int> { Data = 60 };

            // 3rd level
            var thirty = new BinarySearchTreeNode<int> { Data = 30 };
            var fourtyFive = new BinarySearchTreeNode<int> { Data = 45 };
            var eighty = new BinarySearchTreeNode<int> { Data = 80 };

            // 4th level
            var fourtyThree = new BinarySearchTreeNode<int> { Data = 43 };
            var seventy = new BinarySearchTreeNode<int> { Data = 70 };
            var ninety = new BinarySearchTreeNode<int> { Data = 90 };

            // 5th level
            var sixtyFive = new BinarySearchTreeNode<int> { Data = 65 };
            var seventyFive = new BinarySearchTreeNode<int> { Data = 75 };
            var hundred = new BinarySearchTreeNode<int> { Data = 100 };

            // Build tree structure
            // 1st level
            tree.Root = fifty;

            // 2nd level
            fifty.Left = fourty;
            fifty.Right = sixty;

            // 3rd level
            fourty.Left = thirty;
            fourty.Right = fourtyFive;

            sixty.Right = eighty;

            // 4th level
            fourtyFive.Left = fourtyThree;

            eighty.Left = seventy;
            eighty.Right = ninety;

            // 5th level
            seventy.Left = sixtyFive;
            seventy.Right = seventyFive;

            ninety.Right = hundred;

            return tree;
        }

        /// <summary>
        /// Create a valid sample binary search tree.
        /// This is the 2nd sample BST from the book.
        /// </summary>
        /// <returns>
        /// A valid binary search tree of integer numbers.
        /// </returns>
        private static BinarySearchTree<int> CreateValidBinarySearchTree2()
        {
            var tree = new BinarySearchTree<int>();

            // 1st level
            var ninety = new BinarySearchTreeNode<int> { Data = 90 };

            // 2nd level
            var fourty = new BinarySearchTreeNode<int> { Data = 40 };

            // 3rd level
            var sixty = new BinarySearchTreeNode<int> { Data = 60 };

            // 4th level
            var fifty = new BinarySearchTreeNode<int> { Data = 50 };
            var seventy = new BinarySearchTreeNode<int> { Data = 70 };

            // 5th level
            var fiftyFive = new BinarySearchTreeNode<int> { Data = 55 };
            var eighty = new BinarySearchTreeNode<int> { Data = 80 };

            // Build tree structure
            // 1st level
            tree.Root = ninety;

            // 2nd level
            ninety.Left = fourty;

            // 3rd level
            fourty.Right = sixty;

            // 4th level
            sixty.Left = fifty;
            sixty.Right = seventy;

            // 5th level
            fifty.Right = fiftyFive;

            seventy.Right = eighty;

            return tree;
        }

        #endregion
    }
}
