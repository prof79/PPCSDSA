//----------------------------------------------------------------------------
// <copyright file="BinaryTreeNode.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A class for representation of a binary tree node
//      with two children ("left" and "right").
// </description>
// <version>v0.9.5 2018-08-05T17:52:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    /// <summary>
    /// A class for representation of a binary tree node
    /// with two children ("left" and "right").
    /// </summary>
    /// <typeparam name="T">
    /// The type of data contained in the node.
    /// </typeparam>
    public class BinaryTreeNode<T>
        : BinaryTreeNodeBase<IBinaryTreeNode<T>, T>
        , IBinaryTreeNode<T>
    {
    }
}
