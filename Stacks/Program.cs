//----------------------------------------------------------------------------
// <copyright file="Program.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      The main program class for the "Stacks" (and Tower of Hanoi) console demos.
// </description>
// <version>v1.0.0 2018-06-05T01:14:00+02</version>
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
    using System.Text;

    //using Util;

    using static System.Console;

    /// <summary>
    /// The main program class for the "Stacks" (and Tower of Hanoi) console demos.
    /// </summary>
    internal static class Program
    {
        #region Fields

        private static readonly Random _random = new Random();

        #endregion

        /// <summary>
        /// The main method of the program.
        /// </summary>
        /// <param name="args">
        /// The program arguments supplied on the command-line.
        /// </param>
        private static void Main(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            WriteLine();
            WriteLine("*** STACK DEMOS ***");
            WriteLine();

            // Reversing demo
            StackReverse();

            WriteLine();

            // Tower of Hanoi simulation
            HanoiTowerSimulation();

            WriteLine();
        }

        /// <summary>
        /// Reverses a string using a stack.
        /// </summary>
        private static void StackReverse()
        {
            WriteLine("REVERSING TEXT USING STACK");
            WriteLine();

            while (true)
            {
                Write("Enter some text or nothing to quit: ");

                var input = ReadLine().Trim();

                WriteLine();

                // Quit on empty input
                if (String.IsNullOrWhiteSpace(input))
                {
                    WriteLine("Quitting ...");
                    break;
                }

                WriteLine($"Input: {input}");

                var stack = new Stack<char>();

                foreach (var ch in input)
                {
                    stack.Push(ch);
                }

                var sb = new StringBuilder(input.Length);

                while (stack.Count > 0)
                {
                    sb.Append(stack.Pop());
                }

                var output = sb.ToString();

                WriteLine($"Output: {output}");

                WriteLine();
            }

            WriteLine();
        }

        /// <summary>
        /// Simulates a Tower of Hanoi game.
        /// </summary>
        private static void HanoiTowerSimulation()
        {
            WriteLine("TOWER OF HANOI");
            WriteLine();

            var tower = new HanoiTower();

            tower.Run();

            WriteLine();
        }
    }
}
