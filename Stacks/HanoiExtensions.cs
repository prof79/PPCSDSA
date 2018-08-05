//----------------------------------------------------------------------------
// <copyright file="HanoiExtensions.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Extension methods for Hanoi component rendering.
// </description>
// <version>v1.0.0 2018-06-06T01:13:25+02</version>
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
    using System.Linq;

    /// <summary>
    /// Extension methods for Hanoi component rendering.
    /// </summary>
    public static class HanoiExtensions
    {
        #region Helper Methods

        public static IEnumerable<ConsoleColor> DiscColorWheel()
        {
            while (true)
            {
                yield return ConsoleColor.Red;

                yield return ConsoleColor.Red;

                yield return ConsoleColor.Yellow;

                yield return ConsoleColor.Yellow;

                yield return ConsoleColor.Cyan;

                yield return ConsoleColor.Cyan;

                yield return ConsoleColor.Magenta;

                yield return ConsoleColor.Magenta;

                yield return ConsoleColor.Green;

                yield return ConsoleColor.Green;
            }
        }

        #endregion

        #region Extension Methods

        public static ConsoleColor GetColor(this HanoiComponent component, int discNumber = -1)
        {
            switch (component)
            {
                case HanoiComponent.Base:
                case HanoiComponent.Peg:
                    return ConsoleColor.DarkRed;

                case HanoiComponent.Disc:
                    // Without the discNumber argument the disc will be
                    // colored uniformly with a default color.
                    // If the argument is given the disc will be colored
                    // according to the number in a repeating color
                    // scheme.
                    return discNumber < 1
                            ? ConsoleColor.Yellow
                            : DiscColorWheel().Skip(discNumber - 1).Take(1).Single();

                default:
                    throw new Exception(
                        $"Enumeration value {nameof(component)} = {component.ToString()} not handled by programmer.");
            }
        }

        public static char GetChar(this HanoiComponent component)
        {
            switch (component)
            {
                case HanoiComponent.Base:
                    //return '=';
                    return '\u25a0';

                case HanoiComponent.Peg:
                    //return '|';
                    return '\u2588';

                case HanoiComponent.Disc:
                    //return '*';
                    return '\u2588';

                default:
                    throw new Exception(
                        $"Enumeration value {nameof(component)} = {component.ToString()} not handled by programmer.");
            }
        }

        public static void Write(this HanoiComponent component, int discNumber = -1)
        {
            var oldForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = component.GetColor(discNumber);

            Console.Write(component.GetChar());

            Console.ForegroundColor = oldForegroundColor;
        }

        #endregion
    }
}
