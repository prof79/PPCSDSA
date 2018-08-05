//----------------------------------------------------------------------------
// <copyright file="BinarySearchTreeNode.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A basic implementation of a tree node in a binary search tree
//      with two children ("left" and "right").
//      A search tree demands a specific order and structure of child nodes.
// </description>
// <version>v0.9.5 2018-08-05T18:33:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    using System;

    using Extensions;

    /// <summary>
    /// A basic implementation of a tree node in a binary search tree
    /// with two children ("left" and "right").
    /// A search tree demands a specific order and structure of child nodes.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data contained in the tree nodes.
    /// </typeparam>
    public class BinarySearchTreeNode<T>
        : BinaryTreeNodeBase<IBinarySearchTreeNode<T>, T>
        , IBinarySearchTreeNode<T>
        where T : IComparable<T>
    {
        #region Interface IBinarySearchTreeNode<T>

        /// <summary>
        /// Gets whether this is a valid binary search
        /// (sub)-tree or not ie. all nodes follow the
        /// lesser/greater rules of a binary search tree.
        /// </summary>
        public bool IsValidSearchTree
        {
            get
            {
                // Base case - no children
                if (Degree == 0)
                {
                    return true;
                }

                // Binary search tree - all values in nodes left of the
                // current node must be smaller or equal.
                if (Left?.FindMax().CompareTo(Data) > 0)
                {
                    return false;
                }

                // Binary search tree - all values in nodes right of the
                // current node must be greater.
                if (Right?.FindMin().CompareTo(Data) < 1)
                {
                    return false;
                }

                // Else, check children sub-trees.
                var leftState = Left == null
                    || Left.IsValidSearchTree;

                var rightState = Right == null
                    || Right.IsValidSearchTree;

                return leftState && rightState;
            }
        }

        #endregion
    }
}
