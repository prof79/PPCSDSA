//----------------------------------------------------------------------------
// <copyright file="IBinaryTreeNodeBase.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A generic base interface for a basic tree node in a binary tree
//      with two children ("left" and "right").
// </description>
// <version>v0.9.7 2018-08-08T19:55:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    using System.Collections.Generic;

    /// <summary>
    /// A generic base interface for a basic tree node in a binary tree
    /// with two children ("left" and "right").
    /// </summary>
    /// <typeparam name="TNode">
    /// The type of the parent and child tree nodes which must be descendant
    /// from <see cref="IBinaryTreeNodeBase{TNode, T}"/>.
    /// </typeparam>
    /// <typeparam name="T">
    /// The type of the data contained in the tree nodes.
    /// </typeparam>
    public interface IBinaryTreeNodeBase<TNode, T>
        : ITreeNodeBase<TNode, T>
        where TNode : IBinaryTreeNodeBase<TNode, T>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the left child of the binary node.
        /// </summary>
        TNode Left { get; set; }

        /// <summary>
        /// Gets or sets the right child of the binary node.
        /// </summary>
        TNode Right { get; set; }

        #endregion

        #region Methods

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
        void TraversePreOrder(IList<TNode> nodesVisited);

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
        void TraverseInOrder(IList<TNode> nodesVisited);

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
        void TraversePostOrder(IList<TNode> nodesVisited);

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
        void TraverseLevelOrder(IList<TNode> nodesVisited);

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
        IList<TNode> Traverse(TreeTraversalMode traversalMode);

        #endregion
    }
}
