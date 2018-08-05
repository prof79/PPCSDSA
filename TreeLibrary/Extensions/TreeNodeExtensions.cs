//----------------------------------------------------------------------------
// <copyright file="TreeNodeExtensions.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Tree node helper extension methods.
// </description>
// <version>v0.9.5 2018-08-05T19:04:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures.Extensions
{
    using System;
    using System.Linq;

    public static class TreeNodeExtensions
    {
        /// <summary>
        /// Find the largest data value in a binary search (sub)-tree.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data contained in the node.
        /// </typeparam>
        /// <param name="node">
        /// The start node to search recursively.
        /// </param>
        /// <returns>
        /// The largest object by comparison.
        /// </returns>
        public static T FindMax<T>(this IBinarySearchTreeNode<T> node)
            where T : IComparable<T>
        {
            CheckNodeArgument(node);

            // In-order traversal of a binary search tree yields a list
            // of sorted values.
            // This could also enable checks in alternate ways.
            var nodes = node.Traverse(TreeTraversalMode.InOrder);

            // We could take the last item in the list for max but just
            // to be sure, it might be an invalid BST, take it explicitly.
            return nodes
                .Select(n => n.Data)
                .Max();
        }

        /// <summary>
        /// Find the smallest data value in a binary search (sub)-tree.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data contained in the node.
        /// </typeparam>
        /// <param name="node">
        /// The start node to search recursively.
        /// </param>
        /// <returns>
        /// The smallest object by comparison.
        /// </returns>
        public static T FindMin<T>(this IBinarySearchTreeNode<T> node)
            where T : IComparable<T>
        {
            CheckNodeArgument(node);

            // In-order traversal of a binary search tree yields a list
            // of sorted values.
            // This could also enable checks in alternate ways.
            var nodes = node.Traverse(TreeTraversalMode.InOrder);

            // We could take the first item in the list for min but just
            // to be sure, it might be an invalid BST, take it explicitly.
            return nodes
                .Select(n => n.Data)
                .Min();
        }

        private static bool CheckNodeArgument<T>(IBinarySearchTreeNode<T> node)
            where T : IComparable<T>
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            else
            {
                return true;
            }
        }
    }
}
