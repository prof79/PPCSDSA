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
// <version>v0.9.6 2018-08-07T23:45:00+02</version>
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

        /// <summary>
        /// Find some data in a binary search tree using binary search.
        /// </summary>
        /// <param name="data">
        /// The data to search for.
        /// </param>
        /// <param name="lastNodeVisited">
        /// Will be filled with the last node visited. If the return value
        /// is "true" than this is the matching node or result.
        /// In case of "false" this is the last node investigated before
        /// stopping the search. Having this reference is essential
        /// for node insertion and removal scenarios.
        /// </param>
        /// <param name="safetyCheck">
        /// Check whether the (sub-)tree is a valid binary search tree
        /// at all before searching. Throws <see cref="InvalidOperationException"/>
        /// if invalid. This is a costly operation of O(n)
        /// for valid trees but spares you an extra check of
        /// "IsValidSearchTree" if you had done so anyway.
        /// </param>
        /// <returns>
        /// True if the data was found otherwise false.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the (sub-)tree is not a valid binary search tree by
        /// definition AND "safetyCheck" was set to "true".
        /// </exception>
        bool Find(
            T data,
            out IBinarySearchTreeNode<T> lastNodeVisited,
            bool safetyCheck = false);
    }
}
