﻿//----------------------------------------------------------------------------
// <copyright file="BinaryTreeNodeBase.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      An abstract base class for representation of a binary tree node
//      with two children ("left" and "right").
// </description>
// <version>v0.9.7 2018-08-08T20:00:00+02</version>
//
// Btw I love Daniel Earwicker! That was mindboggling ...
// https://stackoverflow.com/questions/693463/operator-as-and-generic-classes#693469
//
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An abstract base class for representation of a binary tree node
    /// with two children ("left" and "right").
    /// </summary>
    /// <typeparam name="TNode">
    /// The type of the parent and child tree nodes which must be descendant
    /// from <see cref="IBinaryTreeNodeBase{TNode, T}"/>.
    /// </typeparam>
    /// <typeparam name="T">
    /// The type of data contained in the node.
    /// </typeparam>
    public abstract class BinaryTreeNodeBase<TNode, T>
        : TreeNodeBase<TNode, T>
        , IBinaryTreeNodeBase<TNode, T>
        where TNode : class, IBinaryTreeNodeBase<TNode, T>
    {
        #region Fields

        protected TNode _left;
        protected TNode _right;

        #endregion

        #region Interface ITreeNodeBase<TNode, T>

        public override IEnumerable<TNode> Children
        {
            get
            {
                if (null != _left)
                {
                    yield return _left;
                }

                if (null != _right)
                {
                    yield return _right;
                }
            }
        }

        #endregion

        #region Interface IBinaryTreeNodeBase<TNode, T> Properties

        /// <summary>
        /// Gets or sets the left child of the binary node.
        /// </summary>
        public TNode Left
        {
            get => _left;

            set
            {
                if (!value.Equals(_left))
                {
                    value.Parent = this as TNode;

                    _left = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the right child of the binary node.
        /// </summary>
        public TNode Right
        {
            get => _right;

            set
            {
                if (!value.Equals(_right))
                {
                    value.Parent = this as TNode;

                    _right = value;
                }
            }
        }

        #endregion

        #region Interface IBinaryTreeNodeBase<TNode, T> Methods

        /// <summary>
        /// Perform a pre-order traversal of a binary tree node.
        /// </summary>
        /// <param name="nodesVisited">
        /// A list to be filled with nodes in visitation order.
        /// </param>
        /// <remarks>
        /// This is a depth-first algorithm.
        /// Pre-order traversal processes the current node, then the
        /// left child and its children and finally the right node and
        /// its children.
        /// Pre-order refers to when the current node will be processed -
        /// before all child nodes.
        /// </remarks>
        public void TraversePreOrder(IList<TNode> nodesVisited)
            => TraversePreOrder(this as TNode, nodesVisited);

        /// <summary>
        /// Perform a in-order traversal of a binary tree node.
        /// </summary>
        /// <param name="nodesVisited">
        /// A list to be filled with nodes in visitation order.
        /// </param>
        /// <remarks>
        /// This is a depth-first algorithm.
        /// In-order traversal processes the left child and its children,
        /// then the current node and finally the right node and its children.
        /// In-order refers to when the current node will be processed -
        /// in-between the left and right child nodes.
        /// </remarks>
        public void TraverseInOrder(IList<TNode> nodesVisited)
            => TraverseInOrder(this as TNode, nodesVisited);

        /// <summary>
        /// Perform a post-order traversal of a binary tree node.
        /// </summary>
        /// <param name="nodesVisited">
        /// A list to be filled with nodes in visitation order.
        /// </param>
        /// <remarks>
        /// This is a depth-first algorithm.
        /// Post-order traversal processes the left child and its children,
        /// then the right node and its children and finally the current node.
        /// Post-order refers to when the current node will be processed -
        /// after all child nodes.
        /// </remarks>
        public void TraversePostOrder(IList<TNode> nodesVisited)
            => TraversePostOrder(this as TNode, nodesVisited);

        /// <summary>
        /// Perform a level-order traversal of a binary tree node.
        /// </summary>
        /// <param name="nodesVisited">
        /// A list to be filled with nodes in visitation order.
        /// </param>
        /// <remarks>
        /// This is a breadth-first algorithm.
        /// Level-order traversal processes the current node and then
        /// all of its children in a in loop using a queue until there
        /// are no child nodes left.
        /// This yields a path like serpentines from top to bottom and
        /// left to right.
        /// </remarks>
        public void TraverseLevelOrder(IList<TNode> nodesVisited)
            => TraverseLevelOrder(this as TNode, nodesVisited);

        /// <summary>
        /// Traverse this binary tree node and children recursively
        /// in a defined order.
        /// </summary>
        /// <param name="traversalMode">
        /// The depth- or breadth-first algorithm to use for traversal.
        /// </param>
        /// <returns>
        /// A list filled with the tree nodes in visitation order.
        /// </returns>
        public IList<TNode> Traverse(TreeTraversalMode traversalMode)
        {
            var nodes = new List<TNode>();

            switch (traversalMode)
            {
                case TreeTraversalMode.PreOrder:
                    TraversePreOrder(this as TNode, nodes);
                    break;

                case TreeTraversalMode.InOrder:
                    TraverseInOrder(this as TNode, nodes);
                    break;

                case TreeTraversalMode.PostOrder:
                    TraversePostOrder(this as TNode, nodes);
                    break;

                case TreeTraversalMode.LevelOrder:
                    TraverseLevelOrder(this as TNode, nodes);
                    break;

                default:
                    throw new Exception(
                        $"Developer logic error, \"{traversalMode}\" as a member of \"{traversalMode.GetType()}\" not accounted for.");
            }

            return nodes;
        }

        #endregion

        #region Static Traversal Methods

        /// <summary>
        /// Perform a pre-order traversal of a binary tree node.
        /// </summary>
        /// <param name="startNode">
        /// The start node to traverse downwards.
        /// </param>
        /// <param name="nodesVisited">
        /// A list to be filled with nodes in visitation order.
        /// </param>
        /// <remarks>
        /// This is a depth-first algorithm.
        /// Pre-order traversal processes the current node, then the
        /// left child and its children and finally the right node and
        /// its children.
        /// Pre-order refers to when the current node will be processed -
        /// before all child nodes.
        /// </remarks>
        public static void TraversePreOrder(
            TNode startNode,
            IList<TNode> nodesVisited)
        {
            CheckTraversalArguments(startNode, nodesVisited);

            if (startNode != null)
            {
                nodesVisited.Add(startNode);

                TraversePreOrder(startNode.Left, nodesVisited);

                TraversePreOrder(startNode.Right, nodesVisited);
            }
        }

        /// <summary>
        /// Perform a in-order traversal of a binary tree node.
        /// </summary>
        /// <param name="startNode">
        /// The start node to traverse downwards.
        /// </param>
        /// <param name="nodesVisited">
        /// A list to be filled with nodes in visitation order.
        /// </param>
        /// <remarks>
        /// This is a depth-first algorithm.
        /// In-order traversal processes the left child and its children,
        /// then the current node and finally the right node and its children.
        /// In-order refers to when the current node will be processed -
        /// in-between the left and right child nodes.
        /// </remarks>
        public static void TraverseInOrder(
            TNode startNode,
            IList<TNode> nodesVisited)
        {
            CheckTraversalArguments(startNode, nodesVisited);

            if (startNode != null)
            {
                TraverseInOrder(startNode.Left, nodesVisited);

                nodesVisited.Add(startNode);

                TraverseInOrder(startNode.Right, nodesVisited);
            }
        }

        /// <summary>
        /// Perform a post-order traversal of a binary tree node.
        /// </summary>
        /// <param name="startNode">
        /// The start node to traverse downwards.
        /// </param>
        /// <param name="nodesVisited">
        /// A list to be filled with nodes in visitation order.
        /// </param>
        /// <remarks>
        /// This is a depth-first algorithm.
        /// Post-order traversal processes the left child and its children,
        /// then the right node and its children and finally the current node.
        /// Post-order refers to when the current node will be processed -
        /// after all child nodes.
        /// </remarks>
        public static void TraversePostOrder(
            TNode startNode,
            IList<TNode> nodesVisited)
        {
            CheckTraversalArguments(startNode, nodesVisited);

            if (startNode != null)
            {
                TraversePostOrder(startNode.Left, nodesVisited);

                TraversePostOrder(startNode.Right, nodesVisited);

                nodesVisited.Add(startNode);
            }
        }

        /// <summary>
        /// Perform a level-order traversal of a binary tree node.
        /// </summary>
        /// <param name="startNode">
        /// The start node to traverse downwards.
        /// </param>
        /// <param name="nodesVisited">
        /// A list to be filled with nodes in visitation order.
        /// </param>
        /// <remarks>
        /// This is a breadth-first algorithm.
        /// Level-order traversal processes the current node and then
        /// all of its children in a in loop using a queue until there
        /// are no child nodes left.
        /// This yields a path like serpentines from top to bottom and
        /// left to right.
        /// </remarks>
        public static void TraverseLevelOrder(
            TNode startNode,
            IList<TNode> nodesVisited)
        {
            CheckTraversalArguments(startNode, nodesVisited);

            if (startNode != null)
            {
                var levelQueue = new Queue<TNode>();

                levelQueue.Enqueue(startNode);

                do
                {
                    var currentNode = levelQueue.Dequeue();

                    nodesVisited.Add(currentNode);

                    foreach (var child in currentNode.Children)
                    {
                        levelQueue.Enqueue(child);
                    }
                }
                while (levelQueue.Count > 0);
            }
        }

        #endregion

        #region Static Helper Methods

        private static bool CheckTraversalArguments(TNode startNode, IList<TNode> nodesVisited)
        {
            if (nodesVisited == null)
            {
                throw new ArgumentNullException(
                    $"The '{nameof(nodesVisited)}' list argument must not be null.",
                    nameof(nodesVisited));
            }

            return true;
        }

        #endregion
    }
}
