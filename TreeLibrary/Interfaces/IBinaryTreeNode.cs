//----------------------------------------------------------------------------
// <copyright file="IBinaryTreeNode.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A generic interface for a tree node in a general binary tree
//      with two children ("left" and "right").
// </description>
// <version>v0.9.5 2018-08-05T01:10:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    /// <summary>
    /// A generic interface for a tree node in a general binary tree
    /// with two children ("left" and "right").
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data contained in the tree nodes.
    /// </typeparam>
    public interface IBinaryTreeNode<T>
        : IBinaryTreeNodeBase<IBinaryTreeNode<T>, T>
    {
    }
}
