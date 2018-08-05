//----------------------------------------------------------------------------
// <copyright file="SortExtensions.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Array sorting extension methods.
// </description>
// <version>v1.0.0 2018-05-26T23:29:37+02</version>
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
    /// Array sorting extension methods.
    /// </summary>
    public static class SortExtensions
    {
        #region Extension Methods

        /// <summary>
        /// Performs Selection Sort on an array.
        /// This is an immutable operation. The original array will not be
        /// modified.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the array elements which have to implement
        /// <see cref="IComparable{T}"/>.
        /// </typeparam>
        /// <param name="array">
        /// The array to be sorted.
        /// </param>
        /// <returns>
        /// The sorted array.
        /// </returns>
        public static T[] SelectionSort<T>(this T[] array) where T : IComparable<T>
        {
            var arrayCopy = (T[]) array.Clone();

            var arrayLength = arrayCopy.Length;

            for (var sortedIndex = 0; sortedIndex < arrayLength; ++sortedIndex)
            {
                for (var index = sortedIndex + 1; index < arrayLength; ++index)
                {
                    if (arrayCopy[index].CompareTo(arrayCopy[sortedIndex]) < 0)
                    {
                        // Swap
                        arrayCopy.Swap(sortedIndex, index);
                    }
                }
            }

            return arrayCopy;
        }

        /// <summary>
        /// Performs Insertion Sort on an array.
        /// This is an immutable operation. The original array will not be
        /// modified.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the array elements which have to implement
        /// <see cref="IComparable{T}"/>.
        /// </typeparam>
        /// <param name="array">
        /// The array to be sorted.
        /// </param>
        /// <returns>
        /// The sorted array.
        /// </returns>
        public static T[] InsertionSort<T>(this T[] array) where T : IComparable<T>
        {
            var arrayCopy = (T[]) array.Clone();

            var arrayLength = arrayCopy.Length;

            var steps = 0;

            // We assume the first array element to be already sorted.
            for (var unsortedIndex = 1; unsortedIndex < arrayLength; ++unsortedIndex)
            {
                ++steps;

                // Array index for insertion based on pivot index.
                // The pivot (unsorted) index points to the first element
                // that is known to be unsorted/checked in the array.
                var index = unsortedIndex;

                // If not the first element and current element is smaller
                // than the element before it then we have to swap the two.
                // Like a sliding window the index moves with the swapped
                // element towards position 0.
                // Since there could still be larger elements before the
                // current element this is best done in a loop for arrays.
                // This will result in a repeated bottom-up swapping until
                // the current item is at the correct place with smaller
                // elements before and larger elements after.
                // Visualizing this with a set of shuffled paper tiles with
                // numbers -10 to 10 on them is key to understand the
                // algorithm and implications.
                while (index > 0
                       && arrayCopy[index].CompareTo(arrayCopy[index - 1]) < 0)
                {
                    ++steps;

                    arrayCopy.Swap(index, index - 1);

                    --index;
                }
            }

            Debug.WriteLine($"Insertion steps: {steps}");

            return arrayCopy;
        }

        /// <summary>
        /// Performs Bubble Sort on an array.
        /// This is an immutable operation. The original array will not be
        /// modified.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the array elements which have to implement
        /// <see cref="IComparable{T}"/>.
        /// </typeparam>
        /// <param name="array">
        /// The array to be sorted.
        /// </param>
        /// <returns>
        /// The sorted array.
        /// </returns>
        public static T[] BubbleSort<T>(this T[] array) where T : IComparable<T>
        {
            // The third sorting algorithm presented is bubble sort.
            // Its way of operation is very simple, because the algorithm just
            // iterates through the array and compares adjacent elements.
            // If they are located in an incorrect order, they are swapped. It
            // sounds very easy, but the algorithm is not very efficient and
            // its usage with large collections could cause performance-
            // related problems.

            // We are immutable, clone the array.
            var arrayCopy = (T[]) array.Clone();

            var arrayLength = arrayCopy.Length;

            // Shortcut - arrays with one or no element(s) do not need to be
            // sorted.
            if (arrayLength < 2)
            {
                Debug.WriteLine("Bubble sort: 0 steps");

                return arrayCopy;
            }

            var steps = 0L;

            var swapped = false;

            do
            {
                // Reset flag for new iteration
                swapped = false;

                // Careful - we look one element ahead thus index must not
                // become larger than array length minus two.
                for (var index = 0; index < (arrayLength - 1); ++index)
                {
                    ++steps;

                    if (arrayCopy[index + 1].CompareTo(arrayCopy[index]) < 0)
                    {
                        arrayCopy.Swap(index + 1, index);

                        swapped = true;
                    }
                }
            }
            while (swapped);

            Debug.WriteLine($"Bubble sort: {steps} steps");

            return arrayCopy;
        }

        #endregion
    }
}
