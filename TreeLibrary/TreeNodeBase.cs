//----------------------------------------------------------------------------
// <copyright file="TreeNodeBase.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      An abstract and generic class for nodes in a tree structure
//      to inherit own tree node implementations from.
// </description>
// <version>v0.9.5 2018-08-05T20:48:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// An abstract and generic class for nodes in a tree structure
    /// to inherit own tree node implementations from.
    /// This class encompasses the commonalities found in both
    /// binary as well as non-binary tree nodes.
    /// </summary>
    /// <typeparam name="TN">
    /// The type of the parent and child tree nodes which must be descendant
    /// from <see cref="ITreeNodeBase{TN, T}"/>.
    /// </typeparam>
    /// <typeparam name="T">
    /// The type of the data contained in the nodes.
    /// </typeparam>
    public abstract class TreeNodeBase<TN, T>
        : ITreeNodeBase<TN, T>
        where TN : ITreeNodeBase<TN, T>
    {
        #region Fields

        private TN _parent;
        private T _data;

        #endregion

        #region Interface ITreeNodeBase<TN, T>

        /// <summary>
        /// Gets or sets the parent node.
        /// </summary>
        public TN Parent
        {
            get => _parent;

            set
            {
                if (!value.Equals(_parent))
                {
                    _parent = value;
                }
            }
        }

        /// <summary>
        /// Gets a list of the child nodes.
        /// </summary>
        public abstract IEnumerable<TN> Children { get; }

        /// <summary>
        /// Gets or sets the arbitrary data.
        /// </summary>
        public T Data
        {
            get => _data;

            set
            {
                if (!value.Equals(_data))
                {
                    _data = value;
                }
            }
        }

        /// <summary>
        /// Gets the depth of a node.
        /// The depth of a node is the number of edges from
        /// the tree's root node to the node.
        /// (From Wikipedia)
        /// </summary>
        public int Depth
        {
            get
            {
                var depth = 0;

                var current = this;

                while (null != current && current.Parent != null)
                {
                    ++depth;

                    current = current.Parent as TreeNodeBase<TN, T>;
                }

                return depth;
            }
        }

        /// <summary>
        /// Gets the level of the node.
        /// The level of a node is defined as:
        /// 1 + the number of edges between the node and the root.
        /// (From Wikipedia)
        /// </summary>
        public int Level
            => Depth + 1;

        /// <summary>
        /// Gets the height of the node.
        /// The height of a node is the number of edges on the
        /// longest path between that node and a leaf.
        /// (From Wikipedia)
        /// </summary>
        public int Height
        {
            get
            {
                // A leaf node has a height of 0.
                if (Children.Count() == 0)
                {
                    return 0;
                }
                else
                {
                    var heights =
                        Children
                            .Select(n => 1 + n.Height);

                    return heights.Max();
                }
            }
        }

        /// <summary>
        /// Gets the degree of the node.
        /// For a given node, its number of children.
        /// A leaf is necessarily degree zero.
        /// (From Wikipedia)
        /// </summary>
        public int Degree
            => Children.Count();

        /// <summary>
        /// Gets the total number of descendants (children and their children,
        /// recursively) of this node.
        /// </summary>
        public int NumberOfDescendants
        {
            get
            {
                var count = 0;

                foreach (var child in Children)
                {
                    // Count the child itself
                    ++count;

                    // Count the number of child's children
                    count += child.NumberOfDescendants;
                }

                return count;
            }
        }

        /// <summary>
        /// Get an abbreviation-based descriptor string for the node in a tree
        /// for learning and debugging purposes.
        /// </summary>
        /// <returns>
        /// A string with characters denoting node type.
        /// Binary nodes: "R" - root, "RI" - right inner, "LI" - left inner,
        /// "R" - right, "L" - left.
        /// Other nodes: "N" - node.
        /// Not a tree node object: "ERR" - error.
        /// </returns>
        public virtual string GetTreeNodeTypeDescriptor()
        {
            var stringBuilder = new StringBuilder();

            // TODO: Properly handle IBinarySearchTreeNode<T> but it is tricky to query a recursive interface ...
            if (typeof(IBinaryTreeNode<T>).IsAssignableFrom(this.GetType()))
            {
                var binaryNode = this as IBinaryTreeNode<T>;

                if (binaryNode.Parent == null)
                {
                    // Root node
                    stringBuilder
                        .Append("R");
                }
                else
                {
                    if (binaryNode.Equals(binaryNode.Parent.Left))
                    {
                        // Left node
                        stringBuilder
                            .Append("L");
                    }
                    else
                    {
                        // Right node
                        stringBuilder
                            .Append("R");
                    }

                    if (binaryNode.Height == 0)
                    {
                        // Leaf node
                        stringBuilder
                            .Append("L");
                    }
                    else
                    {
                        // Inner node
                        stringBuilder
                            .Append("I");
                    }
                }
            }
            else if (this is TN)
            {
                stringBuilder
                    .Append("N");
            }
            else
            {
                stringBuilder
                    .Append("ERR");
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region Overridden Methods

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < Depth; ++i)
            {
                stringBuilder.Append("  ");
            }

            if (Depth > 0)
            {
                stringBuilder
                    .Append("+--");
            }

            stringBuilder.Append(Data);

            stringBuilder
                .Append(" (")
                .Append(this.GetTreeNodeTypeDescriptor())
                .Append(")");

            stringBuilder.Append(Environment.NewLine);

            foreach (var child in Children)
            {
                stringBuilder.Append(child.ToString());
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}
