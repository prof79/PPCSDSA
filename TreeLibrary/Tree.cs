//----------------------------------------------------------------------------
// <copyright file="Tree.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A simple general tree class.
// </description>
// <version>v0.9.5 2018-08-04T21:05:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    /// <summary>
    /// A simple general tree class.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data contained in the tree nodes.
    /// </typeparam>
    public class Tree<T>
        : TreeBase<ITreeNode<T>, T>
        , ITree<T>
    {
    }
}
