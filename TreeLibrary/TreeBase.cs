﻿//----------------------------------------------------------------------------
// <copyright file="TreeBase.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A simple and abstract generic tree base class.
// </description>
// <version>v0.9.5 2018-08-05T18:12:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    /// <summary>
    /// A simple and abstract generic tree base class.
    /// </summary>
    /// <typeparam name="TN">
    /// The type of the tree root node which must be descendant
    /// from <see cref="ITreeNodeBase{TN, T}"/>.
    /// </typeparam>
    /// <typeparam name="T">
    /// The type of the data contained in the tree nodes.
    /// </typeparam>
    public abstract class TreeBase<TN, T>
        : ITreeBase<TN, T>
        where TN : ITreeNodeBase<TN, T>
    {
        #region Interface ITree<TN, T>

        /// <summary>
        /// Gets or sets the root node of the tree.
        /// </summary>
        public TN Root { get; set; }

        /// <summary>
        /// Gets whether the tree is empty (no root node)
        /// or not.
        /// </summary>
        public bool IsEmpty
            => null == Root;

        /// <summary>
        /// Gets the height of the tree.
        /// The height of a node is the number of edges on the
        /// longest path between that node and a leaf.
        /// The height of a tree is the height of its root node.
        /// (From Wikipedia)
        /// The height of an empty tree is commonly assumed to
        /// be -1.
        /// </summary>
        public int Height
            => Root?.Height ?? -1;

        /// <summary>
        /// Gets the total number of nodes in the tree.
        /// </summary>
        public int TotalNodeCount
            => IsEmpty ? 0 : 1 + Root.NumberOfDescendants;

        #endregion

        #region Overridden Methods

        public override string ToString()
            => Root?.ToString();

        #endregion
    }
}
