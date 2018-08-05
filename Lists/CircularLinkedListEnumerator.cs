//----------------------------------------------------------------------------
// <copyright file="CircularLinkedListEnumerator.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      An enumerator for CircularLinkedList<T>.
// </description>
// <version>v1.0.0 2018-06-03T02:30:12+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.Lists
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// An enumerator for <see cref="CircularLinkedList" />.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements in the circular linked list.
    /// </typeparam>
    public class CircularLinkedListEnumerator<T>
        : IEnumerator<T>
    {
        #region Fields

        private LinkedListNode<T> _currentItem;

        #endregion

        #region Constructors

        public CircularLinkedListEnumerator(CircularLinkedList<T> circularList)
        {
            _currentItem = circularList.First;
        }

        #endregion

        #region Interface IEnumerator<T>

        public T Current => _currentItem.Value;

        object IEnumerator.Current => _currentItem.Value;

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            _currentItem = _currentItem?.Next();

            return _currentItem != null;
        }

        public void Reset()
        {
            _currentItem = _currentItem?.List?.First;
        }

        #endregion
    }
}
