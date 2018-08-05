//----------------------------------------------------------------------------
// <copyright file="IBinarySearchTree.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A generic interface for binary search tree structures.
// </description>
// <version>v0.9.5 2018-08-05T21:12:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    using System;

    /// <summary>
    /// A generic interface for binary search tree structures.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data in the tree nodes.
    /// </typeparam>
    public interface IBinarySearchTree<T>
        : IBinaryTreeBase<IBinarySearchTreeNode<T>, T>
        where T : IComparable<T>
    {
    }
}
