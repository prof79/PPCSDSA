//----------------------------------------------------------------------------
// <copyright file="CircularLinkedList.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A circular list data structure that wraps at the beginning and
//      the end.
// </description>
// <version>v1.0.0 2018-06-03T02:31:35+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.Lists
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A circular list data structure that wraps at the beginning and
    /// the end.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class CircularLinkedList<T>
        : LinkedList<T>
    {
        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Overridden Properties

        /// <summary>
        /// The number of items in the list.
        /// A circular list can supply an almost infinite amount of items.
        /// </summary>
        public new int Count
            => First != null ? Int32.MaxValue : 0;

        #endregion

        #region Overridden Methods

        public new IEnumerator<T> GetEnumerator()
            => new CircularLinkedListEnumerator<T>(this);

        #endregion
    }
}
