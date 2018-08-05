//----------------------------------------------------------------------------
// <copyright file="ITreeNode.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A generic interface for a tree node in a non-binary,
//      general tree potentially having multiple child nodes.
// </description>
// <version>v0.9.5 2018-08-04T23:18:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    using System.Collections.Generic;

    /// <summary>
    /// A generic interface for a tree node in a non-binary tree,
    /// general tree potentially having multiple child nodes.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data contained in the tree nodes.
    /// </typeparam>
    public interface ITreeNode<T>
        : ITreeNodeBase<ITreeNode<T>, T>
    {
        #region Methods

        void AddChild(ITreeNode<T> child);
        bool RemoveChild(ITreeNode<T> child);

        void AddRange(IEnumerable<ITreeNode<T>> children);

        #endregion
    }
}
