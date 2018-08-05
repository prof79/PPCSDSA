//----------------------------------------------------------------------------
// <copyright file="IBinaryTreeBase.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A generic base interface for binary tree structures.
// </description>
// <version>v0.9.5 2018-08-05T21:10:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    /// <summary>
    /// A generic base interface for binary tree structures.
    /// </summary>
    /// <typeparam name="TN">
    /// The type of the tree root node which must be descendant
    /// from <see cref="IBinaryTreeNodeBase{TN, T}"/>.
    /// </typeparam>
    /// <typeparam name="T">
    /// The type of the data in the tree nodes.
    /// </typeparam>
    public interface IBinaryTreeBase<TN, T>
        : ITreeBase<TN, T>
        where TN : IBinaryTreeNodeBase<TN, T>
    {
    }
}
