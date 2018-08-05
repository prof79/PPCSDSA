//----------------------------------------------------------------------------
// <copyright file="IBinarySearchTreeNode.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A generic interface for a tree node in a binary search tree
//      with two children ("left" and "right").
//      A search tree demands a specific order and structure of child nodes.
// </description>
// <version>v0.9.5 2018-08-05T18:24:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    using System;

    /// <summary>
    /// A generic interface for a tree node in a binary search tree
    /// with two children ("left" and "right").
    /// A search tree demands a specific order and structure of child nodes.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data contained in the tree nodes.
    /// </typeparam>
    public interface IBinarySearchTreeNode<T>
        : IBinaryTreeNodeBase<IBinarySearchTreeNode<T>, T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Gets whether this is a valid binary search
        /// (sub)-tree or not ie. all nodes follow the
        /// lesser/greater rules of a binary search tree.
        /// </summary>
        bool IsValidSearchTree { get; }
    }
}
