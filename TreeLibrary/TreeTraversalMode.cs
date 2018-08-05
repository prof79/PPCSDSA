//----------------------------------------------------------------------------
// <copyright file="TreeNode.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      An enumeration of binary tree traversal methods.
// </description>
// <version>v0.9.2 2018-08-04T01:49:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    /// <summary>
    /// An enumeration of binary tree traversal methods.
    /// </summary>
    public enum TreeTraversalMode
    {
        PreOrder,       // Depth-first
        InOrder,        // Depth-first
        PostOrder,      // Depth-first
        LevelOrder      // Breadth-first
    }
}
