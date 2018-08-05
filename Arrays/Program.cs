//----------------------------------------------------------------------------
// <copyright file="Program.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      The main program class of the "Arrays" console demos.
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
    using System.Linq;
    using System.Text;
    using Util;

    using static System.Console;

    /// <summary>
    /// The main program class of the "Arrays" console demos.
    /// </summary>
    internal static class Program
    {
        #region Fields

        private static readonly Random _random = new Random();

        private static readonly int[] _numbers =
        {
            -11, 12, -42,
            0, 1, 90,
            68, 6, -9
        };

        private static readonly string[] _names =
        {
            "Mary", "Marcin", "Ann",
            "James", "George", "Nicole",
        };

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
            WriteLine("*** ARRAY DEMOS ***");
            WriteLine();

            // English month names demo
            EnglishMonthNames();

            WriteLine();

            // Multi-dimensional arrays
            MultiDimArrays();

            WriteLine();

            // Multiplication table
            MulTable();

            WriteLine();

            // Console-based game map sample
            GameMap();

            WriteLine();

            // Console-based transportation schedule sample
            TransportationSchedule();

            WriteLine();

            // Sorting algorithms for arrays
            SortNumbers();

            WriteLine();    
        }

        // A showcase of simple, single-dimension arrays.
        private static void EnglishMonthNames()
        {
            // Retrieve array of English month names.
            var months = DateTimeHelper.GetMonthNames();

            WriteLine("English month names:");
            WriteLine();

            foreach (var monthName in months)
            {
                WriteLine(monthName);
            }

            WriteLine();
        }

        /// <summary>
        /// A first showcase of multi-dimensional arrays
        /// using a number table.
        /// </summary>
        private static void MultiDimArrays()
        {
            var numbers = new int[,]
            {
                { 9, 5, -9 },
                { -11, 4, 0 },
                { 6, 115, 3 },
                { -12, -9, 71 },
                { 1, -6, -1 }
            };

            WriteLine($"The {nameof(numbers)} array is {numbers.GetLength(0)} by {numbers.GetLength(1)} in size.");
            WriteLine();
            WriteLine("The numbers are:");
            WriteLine();

            for (var y = 0; y < numbers.GetLength(0); ++y)
            {
                for (var x = 0; x < numbers.GetLength(1); ++x)
                {
                    Write($"{numbers[y, x],4}");
                }

                // Put a linefeed after each row.
                WriteLine();
            }

            WriteLine();
        }

        /// <summary>
        /// A second showcase of multi-dimensional arrays using pre-computation.
        /// </summary>
        private static void MulTable()
        {
            // Multiplication table.
            var mul10Table = new int[10, 10];

            // Initialize table.
            for (var y = 0; y < mul10Table.GetLength(0); ++y)
            {
                for (var x = 0; x < mul10Table.GetLength(1); ++x)
                {
                    mul10Table[y, x] =
                        (x + 1) * (y + 1);
                }
            }

            WriteLine("The multiplication table from 1 x 1 to 10 x 10 is:");
            WriteLine();

            // Print table
            for (var y = 0; y < mul10Table.GetLength(0); ++y)
            {
                for (var x = 0; x < mul10Table.GetLength(1); ++x)
                {
                    Write($"{mul10Table[y, x],4}");
                }

                // Put a linefeed after each row.
                WriteLine();
            }

            WriteLine();
        }

        /// <summary>
        /// A nice demo of how a console-based game map could be
        /// realized using multi-dimensional arrays and extension methods.
        /// </summary>
        private static void GameMap()
        {
            TerrainType[,] gameMap =
            {
                {
                    TerrainType.Sand, TerrainType.Sand, TerrainType.Sand,
                    TerrainType.Sand, TerrainType.Grass, TerrainType.Grass,
                    TerrainType.Grass, TerrainType.Grass, TerrainType.Grass,
                    TerrainType.Grass
                },
                {
                    TerrainType.Sand, TerrainType.Sand, TerrainType.Sand,
                    TerrainType.Sand, TerrainType.Grass, TerrainType.Grass,
                    TerrainType.Grass, TerrainType.Grass, TerrainType.Grass,
                    TerrainType.Grass
                },
                {
                    TerrainType.Sand, TerrainType.Sand, TerrainType.Sand,
                    TerrainType.Sand, TerrainType.Grass, TerrainType.Grass,
                    TerrainType.Grass, TerrainType.Grass, TerrainType.Grass,
                    TerrainType.Grass
                },
                {
                    TerrainType.Sand, TerrainType.Sand, TerrainType.Sand,
                    TerrainType.Sand, TerrainType.Grass, TerrainType.Grass,
                    TerrainType.Grass, TerrainType.Grass, TerrainType.Grass,
                    TerrainType.Grass
                },
                {
                    TerrainType.Sand, TerrainType.Sand, TerrainType.Sand,
                    TerrainType.Sand, TerrainType.Sand, TerrainType.Sand,
                    TerrainType.Sand, TerrainType.Wall, TerrainType.Wall,
                    TerrainType.Wall
                },
                {
                    TerrainType.Sand, TerrainType.Sand, TerrainType.Sand,
                    TerrainType.Sand, TerrainType.Sand, TerrainType.Sand,
                    TerrainType.Sand, TerrainType.Wall, TerrainType.Sand,
                    TerrainType.Sand
                },
                {
                    TerrainType.Sand, TerrainType.Sand, TerrainType.Sand,
                    TerrainType.Sand, TerrainType.Sand, TerrainType.Sand,
                    TerrainType.Sand, TerrainType.Wall, TerrainType.Sand,
                    TerrainType.Sand
                },
                {
                    TerrainType.Water, TerrainType.Water, TerrainType.Water,
                    TerrainType.Water, TerrainType.Water, TerrainType.Water,
                    TerrainType.Water, TerrainType.Wall, TerrainType.Sand,
                    TerrainType.Sand
                },
                {
                    TerrainType.Water, TerrainType.Water, TerrainType.Water,
                    TerrainType.Water, TerrainType.Water, TerrainType.Water,
                    TerrainType.Water, TerrainType.Wall, TerrainType.Sand,
                    TerrainType.Sand
                },
                {
                    TerrainType.Water, TerrainType.Water, TerrainType.Water,
                    TerrainType.Water, TerrainType.Water, TerrainType.Water,
                    TerrainType.Water, TerrainType.Wall, TerrainType.Water,
                    TerrainType.Water
                },
                {
                    TerrainType.Water, TerrainType.Water, TerrainType.Water,
                    TerrainType.Water, TerrainType.Water, TerrainType.Water,
                    TerrainType.Water, TerrainType.Wall, TerrainType.Water,
                    TerrainType.Water
                },
            };

            // Set the console to a proper encoding.
            Console.OutputEncoding = Encoding.UTF8;

            // Save console colors.
            var foregroundColor = Console.ForegroundColor;

            WriteLine("A simple game map:");
            WriteLine();

            // Print the game map.
            for (var y = 0; y < gameMap.GetLength(0); ++y)
            {
                for (var x = 0; x < gameMap.GetLength(1); ++x)
                {
                    Console.ForegroundColor =
                        gameMap[y, x].GetColor();

                    Write(gameMap[y, x].GetChar());
                }

                WriteLine();
            }

            // Restore console colors.
            Console.ForegroundColor = foregroundColor;

            WriteLine();
        }

        /// <summary>
        /// Demo of a daily transportation schedule for different
        /// transportation types. Showcases jagged arrays.
        /// </summary>
        private static void TransportationSchedule()
        {
            // Get the transportation types as an array to aid
            // random schedule generation.
            var transportationTypes =
                Enum.GetNames(typeof(TransportationType));

            // Compute the number of transportation types defined.
            // This will also help in random schedule generation.
            var transportationTypeCount =
                transportationTypes.Length;

            // The daily schedule (jagged array) with the first dimension
            // representing the month.
            var dailySchedule = new TransportationType[12][];

            // Get the number of days in each month.
            var monthDays = DateTimeHelper.GetMonthDays();

            // We will also need the names of the months for a nice output.
            var monthNames = DateTimeHelper.GetMonthNames();

            // Iterate over the months
            for (var monthIndex = 0; monthIndex < 12; ++monthIndex)
            {
                // First we need the correct number of slots (days) for
                // each month.
                dailySchedule[monthIndex] =
                    new TransportationType[monthDays[monthIndex]];

                for (var dayIndex = 0; dayIndex < monthDays[monthIndex]; ++dayIndex)
                {
                    // Generate random transportation for each day.
                    var randomIndex =
                        _random.Next(transportationTypeCount);

                    var transportationType = (TransportationType)
                        Enum.Parse(typeof(TransportationType), transportationTypes[randomIndex]);

                    dailySchedule[monthIndex][dayIndex] =
                        transportationType;
                }
            }

            // Schedule title
            WriteLine("DAILY TRANSPORTATION SCHEDULE");
            WriteLine();

            // For a nice output we need to know the longest month name.
            var maxMonthNameLength =
                monthNames.Max(m => m.Length) + 2;

            // The hard part is done, now display the schedule.
            for (var monthIndex = 0; monthIndex < 12; ++monthIndex)
            {
                var monthName = monthNames[monthIndex];

                monthName =
                    monthName.PadRight(maxMonthNameLength);

                Write(monthName);

                for (var dayIndex = 0; dayIndex < dailySchedule[monthIndex].GetLength(0); ++dayIndex)
                {
                    var transportation = dailySchedule[monthIndex][dayIndex];

                    transportation.Write();
                    // Extra space for better readability.
                    //Write(' ');
                }

                WriteLine();
            }

            WriteLine();
        }

        /// <summary>
        /// Showcase of the implementation of various sorting algorithms.
        /// </summary>
        private static void SortNumbers()
        {
            // Header

            WriteLine("SORTING ALGORITHMS");
            WriteLine();

            // Numbers

            Write("Numbers: ");
            WriteLine(String.Join(", ", _numbers));
            WriteLine();

            Write("Sorted by Selection Sort: ");
            WriteLine(String.Join(", ", _numbers.SelectionSort()));

            Write("Sorted by Insertion Sort: ");
            WriteLine(String.Join(", ", _numbers.InsertionSort()));

            Write("Sorted by Bubble Sort: ");
            WriteLine(String.Join(", ", _numbers.BubbleSort()));

            Write("Sorted by Quick Sort: ");
            WriteLine(String.Join(", ", _numbers.QuickSort()));

            WriteLine();

            // Names

            WriteLine($"Names: {String.Join(", ", _names)}");
            WriteLine();

            Write("Sorted by Selection Sort: ");
            WriteLine(String.Join(", ", _names.SelectionSort()));

            Write("Sorted by Insertion Sort: ");
            WriteLine(String.Join(", ", _names.InsertionSort()));

            Write("Sorted by Bubble Sort: ");
            WriteLine(String.Join(", ", _names.BubbleSort()));

            Write("Sorted by Quick Sort: ");
            WriteLine(String.Join(", ", _names.QuickSort()));

            WriteLine();
        }
    }
}
