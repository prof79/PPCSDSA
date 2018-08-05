//----------------------------------------------------------------------------
// <copyright file="QuickSortExtensions.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Implementation of Quick Sort for arrays as extension methods.
// </description>
// <version>v1.0.0 2018-06-02T22:12:30+02</version>
//
// Based on:
//
// https://en.wikipedia.org/wiki/Quicksort
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
    /// Implementation of Quick Sort for arrays.
    /// The methods are compatible for use as extension methods.
    /// </summary>
    public static class QuickSortExtensions
    {
        #region Extension Methods

        /// <summary>
        /// Sort an array using the Quick Sort algorithm.
        /// This is an immutable method that will not tamper
        /// with the original array but return a new one.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the individual array elements.
        /// Needs to implement <see cref="IComparable{T}"/>.
        /// </typeparam>
        /// <param name="array">
        /// The array to sort.
        /// </param>
        /// <returns>
        /// The sorted array.
        /// </returns>
        public static T[] QuickSort<T>(this T[] array)
            where T : IComparable<T>
        {
            var arrayCopy = (T[]) array.Clone();

            arrayCopy.QuickSort(0, arrayCopy.Length);

            return arrayCopy;
        }

        /// <summary>
        /// Worker method to perform Quick Sort on an array.
        /// Beware that this method is mutable and will modify the passed
        /// array in-place. Only elements within the sub-array of index
        /// x will be sorted where:
        /// lowerBoundInclusive &lt;= x &lt; upperBoundExclusive
        /// </summary>
        /// <typeparam name="T">
        /// The type of the individual array elements.
        /// Needs to implement <see cref="IComparable{T}"/>.
        /// </typeparam>
        /// <param name="array">
        /// The array that needs to be sorted fully or partially.
        /// </param>
        /// <param name="lowerBoundInclusive">
        /// The lower, inclusive index of the sub-array.
        /// </param>
        /// <param name="upperBoundExclusive">
        /// The upper, exclusive index of the sub-array.
        /// Being exclusive makes it natural to use analog to
        /// <see cref="Array.Length"/>.
        /// </param>
        public static void QuickSort<T>(this T[] array, int lowerBoundInclusive, int upperBoundExclusive)
            where T : IComparable<T>
        {
            Debug.WriteLine($"QuickSort: array {array.GetHashCode()}, lower {lowerBoundInclusive}, upperEx {upperBoundExclusive}");

            // Safeguard against invalid arguments
            if (lowerBoundInclusive > upperBoundExclusive)
            {
                throw new ArgumentException(
                    $"{nameof(lowerBoundInclusive)} must not be larger than {nameof(upperBoundExclusive)}.",
                    nameof(lowerBoundInclusive));
            }

            // Calculate the array length from lower and upper bounds.
            var subArrayLength = upperBoundExclusive - lowerBoundInclusive;

            // An array with one or no element is already sorted.
            // This is the base case. There is nothing to do.
            if (subArrayLength < 2)
            {
                return;
            }

            // Get the tie breaker (pivot) index.
            var pivotIndex = array.Partition(lowerBoundInclusive, upperBoundExclusive);

            // Recursively sort the lower sub-array.
            array.QuickSort(lowerBoundInclusive, pivotIndex + 1);

            // Recursively sort the upper sub-array.
            array.QuickSort(pivotIndex + 1, upperBoundExclusive);
        }

        /// <summary>
        /// Partition a sub-array based on a pivot element.
        /// Smaller elements than the pivot will be moved to the left
        /// (before) of it. This method uses the Hoare scheme and will
        /// pick the first element of the sub-array as pivot.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the individual array elements.
        /// Needs to implement <see cref="IComparable{T}"/>.
        /// </typeparam>
        /// <param name="array">
        /// The array to be partitioned.
        /// </param>
        /// <param name="lowerBoundInclusive">
        /// The lower, inclusive index of the sub-array.
        /// </param>
        /// <param name="upperBoundExclusive">
        /// The upper, exclusive index of the sub-array.
        /// Being exclusive makes it natural to use analog to
        /// <see cref="Array.Length"/>.
        /// </param>
        /// <returns>
        /// The new position (index) of the pivot element.
        /// This will yield two sub-arrays
        /// lowerBoundInclusive &lt;= x &lt; pivot index
        /// and
        /// pivot index &lt;= y &lt; upperBoundExclusive
        /// </returns>
        public static int Partition<T>(this T[] array, int lowerBoundInclusive, int upperBoundExclusive)
            where T : IComparable<T>
        {
            Debug.WriteLine($"Partition: array {array.GetHashCode()}, lower {lowerBoundInclusive}, upperEx {upperBoundExclusive}");

            // Safeguard against invalid arguments
            if (lowerBoundInclusive >= upperBoundExclusive)
            {
                throw new ArgumentException(
                    $"{nameof(lowerBoundInclusive)} must be smaller than {nameof(upperBoundExclusive)}.",
                    nameof(lowerBoundInclusive));
            }

            const int relativePivotIndex = 0;

            var pivotIndex = lowerBoundInclusive + relativePivotIndex;

            var startIndex = pivotIndex + 1;

            // Check all array elements against the pivot element.
            for (var index = startIndex; index < upperBoundExclusive; ++index)
            {
                // Has the current element a lower value than the pivot
                // element? If so move it above the pivot element.
                if (array[index].CompareTo(array[pivotIndex]) < 0)
                {
                    // Now we need to swap the lower value up the array
                    // until it is at the pivot index and the pivot value
                    // is pivot index + 1.
                    for (var swapIndex = index; swapIndex > pivotIndex; --swapIndex)
                    {
                        array.Swap(swapIndex, swapIndex - 1);
                    }

                    ++pivotIndex;
                }
            }

            return pivotIndex;
        }

        #endregion
    }
}
