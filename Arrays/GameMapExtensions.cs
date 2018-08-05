//----------------------------------------------------------------------------
// <copyright file="GameMapExtensions.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Extension methods for a console-based game map display.
// </description>
// <version>v1.0.0 2018-05-24T00:09:56+02</version>
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
    /// Extension methods for a console-based game map display.
    /// </summary>
    public static class GameMapExtensions
    {
        #region Extension Methods

        /// <summary>
        /// Get the console color for a game map tile of a
        /// specific terrain type.
        /// </summary>
        /// <param name="terrainType">The terrain type.</param>
        /// <returns>A console color.</returns>
        public static ConsoleColor GetColor(this TerrainType terrainType)
        {
            switch (terrainType)
            {
                case TerrainType.Grass:
                    return ConsoleColor.Green;

                case TerrainType.Sand:
                    return ConsoleColor.Yellow;

                case TerrainType.Water:
                    return ConsoleColor.DarkCyan;

                default:
                    return ConsoleColor.Gray;
            }
        }

        /// <summary>
        /// Get the character to display on the console for a game map tile of
        /// a specific terrain type.
        /// </summary>
        /// <param name="terrainType">The terrain type.</param>
        /// <returns>An unicode character. Ensure proper console output.</returns>
        public static char GetChar(this TerrainType terrainType)
        {
            switch (terrainType)
            {
                case TerrainType.Grass:
                    //return '"';
                    return '\u201c';

                case TerrainType.Sand:
                    //return 'o';
                    return '\u25cb';

                case TerrainType.Water:
                    //return '~';
                    return '\u2248';

                default:
                    //return '.';
                    return '\u25cf';
            }
        }

        #endregion
    }
}
