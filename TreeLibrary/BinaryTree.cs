//----------------------------------------------------------------------------
// <copyright file="BinaryTree.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A binary tree data structure class.
// </description>
// <version>v0.9.5 2018-08-05T21:15:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    /// <summary>
    /// A binary tree data structure class.
    /// </summary>
    /// <typeparam name="T">
    /// The type of data contained in the tree nodes.
    /// </typeparam>
    public class BinaryTree<T>
        : TreeBase<IBinaryTreeNode<T>, T>
        , IBinaryTree<T>
    {
    }
}
