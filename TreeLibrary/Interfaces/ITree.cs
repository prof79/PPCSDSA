//----------------------------------------------------------------------------
// <copyright file="ITree.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A generic interface for general tree structures.
// </description>
// <version>v0.9.5 2018-08-05T21:04:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    /// <summary>
    /// A generic interface for general tree structures.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data in the tree nodes.
    /// </typeparam>
    public interface ITree<T>
        : ITreeBase<ITreeNode<T>, T>
    {
    }
}
