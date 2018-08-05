//----------------------------------------------------------------------------
// <copyright file="ArrayExtensions.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      General-purpose array extension methods.
// </description>
// <version>v1.0.0 2018-06-02T23:34:54+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.Arrays
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// General-purpose array extension methods.
    /// </summary>
    public static class ArrayExtensions
    {
        #region Extension Methods

        /// <summary>
        /// Helper method to swap two elements in an array based on
        /// their index.
        /// </summary>
        /// <typeparam name="T">
        /// The type of elements in the array.
        /// </typeparam>
        /// <param name="array">
        /// The array where elements need to be swapped.
        /// </param>
        /// <param name="indexA">
        /// The array index of an element to be swapped.
        /// </param>
        /// <param name="indexB">
        /// The array index of the other element to be swapped.
        /// </param>
        public static void Swap<T>(this T[] array, int indexA, int indexB)
        {
            var tmp = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = tmp;
        }

        /// <summary>
        /// Helper method to dump array contents to debug output.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the array elements.
        /// </typeparam>
        /// <param name="array">
        /// The array to dump.
        /// </param>
        public static void DebugPrint<T>(this T[] array)
            => Debug.WriteLine($"Array: [{String.Join(", ", array)}]");

        #endregion
    }
}
