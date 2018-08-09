//----------------------------------------------------------------------------
// <copyright file="ITreeBase.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A generic base interface for general tree structures.
// </description>
// <version>v0.9.7 2018-08-08T19:56:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    /// <summary>
    /// A generic base interface for general tree structures.
    /// </summary>
    /// <typeparam name="TNode">
    /// The type of the tree root node which must be descendant
    /// from <see cref="ITreeNodeBase{TN, T}"/>.
    /// </typeparam>
    /// <typeparam name="T">
    /// The type of the data in the tree nodes.
    /// </typeparam>
    public interface ITreeBase<TNode, T>
        where TNode : ITreeNodeBase<TNode, T>
    {
        /// <summary>
        /// Gets or sets the root node of the tree.
        /// </summary>
        TNode Root { get; set; }

        /// <summary>
        /// Gets whether the tree is empty (no root node)
        /// or not.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Gets the height of the tree.
        /// The height of a node is the number of edges on the
        /// longest path between that node and a leaf.
        /// The height of a tree is the height of its root node.
        /// (From Wikipedia)
        /// The height of an empty tree is commonly assumed to
        /// be -1.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Gets the total number of nodes in the tree.
        /// </summary>
        int TotalNodeCount { get; }
    }
}
