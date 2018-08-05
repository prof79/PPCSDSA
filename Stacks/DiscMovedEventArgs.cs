//----------------------------------------------------------------------------
// <copyright file="DiscMovedEventArgs.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Event arguments for a Hanoi disc moved event.
// </description>
// <version>v1.0.0 2018-06-07T21:58:25+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.Stacks
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Event arguments for a Hanoi disc moved event.
    /// </summary>
    /// <typeparam name="T">
    /// The type of how discs are stored on the stacks ("towers")
    /// eg. <see cref="int"/>.
    /// </typeparam>
    public class DiscMovedEventArgs<T> : EventArgs
    {
        #region Fields

        #endregion

        #region Constructors

        public DiscMovedEventArgs()
        {
        }

        public DiscMovedEventArgs(int discNumber, Stack<T> fromStack, Stack<T> toStack)
        {
            DiscNumber = discNumber;
            FromStack = fromStack;
            ToStack = toStack;
        }

        #endregion

        #region Properties

        public int DiscNumber { get; private set; } = -1;

        public Stack<T> FromStack { get; private set; } = null;

        public Stack<T> ToStack { get; private set; } = null;

        private static DiscMovedEventArgs<T> _empty;

        public static new DiscMovedEventArgs<T> Empty
            => _empty ?? (_empty = new DiscMovedEventArgs<T>());

        #endregion

        #region Methods

        #endregion

        #region Event Handlers

        #endregion
    }
}
