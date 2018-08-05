//----------------------------------------------------------------------------
// <copyright file="TranportationExtensions.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Extension methods for console-based output of
//      transportation symbols.
// </description>
// <version>v1.0.0 2018-05-26T00:25:11+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.Util
{
    using System;

    /// <summary>
    /// Extension methods for console-based output of
    /// transportation symbols.
    /// </summary>
    public static class TranportationExtensions
    {
        #region Extension Methods

        /// <summary>
        /// Return the appropriate console color for a specific
        /// transportation type.
        /// </summary>
        /// <param name="transportationType">
        /// The type of transportation to look up the color for.
        /// </param>
        /// <returns>
        /// A console color.
        /// </returns>
        public static ConsoleColor GetColor(this TransportationType transportationType)
        {
            switch (transportationType)
            {
                case TransportationType.Bike:
                    return ConsoleColor.DarkCyan;

                case TransportationType.Bus:
                    return ConsoleColor.DarkYellow;

                case TransportationType.Car:
                    return ConsoleColor.Red;

                case TransportationType.Subway:
                    return ConsoleColor.Blue;

                case TransportationType.Train:
                    return ConsoleColor.DarkMagenta;

                case TransportationType.Walk:
                    return ConsoleColor.DarkGreen;

                default:
                    throw new ArgumentException(nameof(transportationType));
            }
        }

        /// <summary>
        /// Return an appropriate character to represent a specific
        /// transportation type.
        /// </summary>
        /// <param name="transportationType">
        /// The type of transportation to look up the character for.
        /// </param>
        /// <returns>
        /// A character.
        /// </returns>
        public static char GetChar(this TransportationType transportationType)
        {
            switch (transportationType)
            {
                case TransportationType.Bike:
                    return 'K';

                case TransportationType.Bus:
                    return 'B';

                case TransportationType.Car:
                    return 'C';

                case TransportationType.Subway:
                    return 'U';

                case TransportationType.Train:
                    return 'T';

                case TransportationType.Walk:
                    return 'W';

                default:
                    throw new ArgumentException(nameof(transportationType));
            }
        }

        /// <summary>
        /// Prints a transporation type to the console in single-character
        /// form with color-coded background.
        /// </summary>
        /// <param name="transportationType">
        /// The transportation type to display.
        /// </param>
        public static void Write(this TransportationType transportationType)
        {
            var oldBackground = Console.BackgroundColor;
            var oldForeground = Console.ForegroundColor;

            var character = transportationType.GetChar();
            var color = transportationType.GetColor();

            Console.BackgroundColor = color;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(character);

            Console.ForegroundColor = oldForeground;
            Console.BackgroundColor = oldBackground;
        }

        #endregion
    }
}
