//----------------------------------------------------------------------------
// <copyright file="CircularLinkedListExtensions.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Extension methods for circular linked lists based on
//      CircularLinkedList<T>.
// </description>
// <version>v1.0.0 2018-06-03T02:47:42+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.Lists
{
    using System.Collections.Generic;

    /// <summary>
    /// Extension methods for circular linked lists based on
    /// <see cref="CircularLinkedList{T}"/>.
    /// </summary>
    public static class CircularLinkedListExtensions
    {
        #region Extension Methods

        /// <summary>
        /// Get the previous item node in a circular linked list.
        /// Will wrap from the first element to the last element of the list.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the node items in the list.
        /// </typeparam>
        /// <param name="node">
        /// The node to retrieve the previous item node for.
        /// </param>
        /// <returns>
        /// The previous item node.
        /// </returns>
        public static LinkedListNode<T> Previous<T>(this LinkedListNode<T> node)
            => node?.Previous ?? node?.List?.Last;

        /// <summary>
        /// Get the next item node in a circular linked list.
        /// Will wrap from the last element to the first element of the list.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the node items in the list.
        /// </typeparam>
        /// <param name="node">
        /// The node to retrieve the next item node for.
        /// </param>
        /// <returns>
        /// The next item node.
        /// </returns>
        public static LinkedListNode<T> Next<T>(this LinkedListNode<T> node)
            => node?.Next ?? node?.List?.First;

        #endregion
    }
}
