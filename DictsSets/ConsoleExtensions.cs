//----------------------------------------------------------------------------
// <copyright file="ConsoleExtensions.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Console extension methods.
// </description>
// <version>v1.0.0 2018-06-09T01:56:45</version>
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.Util
{
    using System;

    /// <summary>
    /// Console extension methods.
    /// </summary>
    public static class ConsoleExtensions
    {
        #region Extension Methods

        /// <summary>
        /// Using-statement for colored console output and automatic
        /// backup and restore of the current foreground color.
        /// </summary>
        /// <param name="color">
        /// The <see cref="ConsoleColor"/> to be set temporarily.
        /// </param>
        /// <param name="action">
        /// The code block containing <see cref="Console.Write"/> and
        /// <see cref="Console.WriteLine"/> calls that should use
        /// the <paramref name="color"/> foreground color.
        /// Will automatically revert to the previous foreground color.
        /// </param>
        public static void UseFore(this ConsoleColor color, Action action)
        {
            var oldForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = color;

            action?.Invoke();

            Console.ForegroundColor = oldForegroundColor;
        }

        #endregion
    }
}
