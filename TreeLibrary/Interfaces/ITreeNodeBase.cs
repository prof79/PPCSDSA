//----------------------------------------------------------------------------
// <copyright file="ITreeNodeBase.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A generic base interface for a general node in a tree structure
//      independent of the tree type.
// </description>
// <version>v0.9.5 2018-08-04T23:13:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    using System.Collections.Generic;

    /// <summary>
    /// A generic base interface for a general node in a tree structure
    /// independent of the tree type.
    /// This interface encompasses the commonalities of binary and
    /// non-binary tree nodes alike.
    /// </summary>
    /// <typeparam name="TN">
    /// The type of the parent and child tree nodes which must be descendant
    /// from <see cref="ITreeNodeBase{TN, T}"/>.
    /// </typeparam>
    /// <typeparam name="T">
    /// The type of the data contained in the tree nodes.
    /// </typeparam>
    public interface ITreeNodeBase<TN, T>
        : IDataNode<T>
        where TN : ITreeNodeBase<TN, T>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the parent node.
        /// </summary>
        TN Parent { get; set; }

        /// <summary>
        /// Gets a list of the child nodes.
        /// </summary>
        IEnumerable<TN> Children { get; }

        /// <summary>
        /// Gets the depth of a node.
        /// The depth of a node is the number of edges from
        /// the tree's root node to the node.
        /// (From Wikipedia)
        /// </summary>
        int Depth { get; }

        /// <summary>
        /// Gets the level of the node.
        /// The level of a node is defined as:
        /// 1 + the number of edges between the node and the root.
        /// (From Wikipedia)
        /// </summary>
        int Level { get; }

        /// <summary>
        /// Gets the height of the node.
        /// The height of a node is the number of edges on the
        /// longest path between that node and a leaf.
        /// (From Wikipedia)
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Gets the degree of the node.
        /// For a given node, its number of children.
        /// A leaf is necessarily degree zero.
        /// (From Wikipedia)
        /// </summary>
        int Degree { get; }

        /// <summary>
        /// Gets the total number of descendants (children and their children,
        /// recursively) of this node.
        /// </summary>
        int NumberOfDescendants { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Get an abbreviation-based descriptor string for the node in a tree
        /// for learning and debugging purposes.
        /// </summary>
        /// <returns>
        /// A string with characters denoting node type.
        /// Binary nodes: "R" - root, "RI" - right inner, "LI" - left inner,
        /// "R" - right, "L" - left.
        /// Other nodes: "N" - node.
        /// Not a tree node object: "ERR" - error.
        /// </returns>
        string GetTreeNodeTypeDescriptor();

        #endregion
    }
}
