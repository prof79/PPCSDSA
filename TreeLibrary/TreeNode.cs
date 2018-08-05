//----------------------------------------------------------------------------
// <copyright file="TreeNode.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A generic tree node class for nodes in a non-binary tree
//      with multiple child nodes.
// </description>
// <version>v0.9.5 2018-08-05T01:34:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A generic tree node class for nodes in a non-binary tree
    /// with multiple child nodes.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data contained in the nodes.
    /// </typeparam>
    public class TreeNode<T>
        : TreeNodeBase<ITreeNode<T>, T>
        , ITreeNode<T>
    {
        #region Fields

        private readonly IList<ITreeNode<T>> _children;

        #endregion

        #region Constructors

        public TreeNode()
        {
            _children = new List<ITreeNode<T>>();
        }

        #endregion

        #region Interface ITreeNodeBase<TN, T>

        public override IEnumerable<ITreeNode<T>> Children
            => _children?.AsEnumerable();

        #endregion

        #region Interface ITreeNode<T>

        public void AddChild(ITreeNode<T> child)
        {
            // Set parent of the child accordingly
            child.Parent = this;

            // Add child to collection
            _children.Add(child);
        }

        public bool RemoveChild(ITreeNode<T> child)
            => _children.Remove(child);

        public void AddRange(IEnumerable<ITreeNode<T>> children)
        {
            foreach (var child in children)
            {
                AddChild(child);
            }
        }

        #endregion
    }
}
