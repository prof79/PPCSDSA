//----------------------------------------------------------------------------
// <copyright file="SpinTheWheelGame.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Spin wheel game simulation to demo circular linked lists.
// </description>
// <version>v1.0.0 2018-06-03T22:464:41+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.Lists
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    using static System.Console;

    /// <summary>
    /// Spin wheel game simulation to demo circular linked lists.
    /// </summary>
    public class SpinTheWheelGame
    {
        #region Fields

        private static readonly Random _random =
            new Random();

        private CircularLinkedList<string> _categories;

        // Game variables
        private int _totalTime = 0;
        private int _remainingTime = 0;

        #endregion

        #region Constructors

        public SpinTheWheelGame()
        {
            Initialize();
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the game (list) data.
        /// </summary>
        private void Initialize()
        {
            _categories = new CircularLinkedList<string>();

            _categories.AddLast("Sport");
            _categories.AddLast("Culture");
            _categories.AddLast("History");
            _categories.AddLast("Geography");
            _categories.AddLast("People");
            _categories.AddLast("Technology");
            _categories.AddLast("Nature");
            _categories.AddLast("Science");
        }

        /// <summary>
        /// Resets the game state.
        /// </summary>
        private void Reset()
        {
            _totalTime = 0;
            _remainingTime = 0;
        }

        /// <summary>
        /// Runs the game simulation.
        /// </summary>
        public void Run()
        {
            Reset();

            WriteLine("The game begins ...");

            foreach (var category in _categories)
            {
                if (_remainingTime <= 0)
                {
                    WriteLine();
                    WriteLine("Press [ENTER] to start or any other key to exit.");
                    WriteLine();

                    // User input and parsing
                    switch (ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter:
                            _totalTime = _random.Next(1000, 5000);
                            _remainingTime = _totalTime;
                            Debug.WriteLine($"Total time: {_totalTime} ms");
                            break;

                        // Any other key
                        default:
                            // Abort (exit) game
                            return;
                    }
                }

                // ??? Some finicky delay time value calculation ...
                // Some gently exponential growth ...
                var categoryTime =
                    (-450 * _remainingTime) / (_totalTime - 50)
                    + 500
                    + (22500 / (_totalTime - 50));

                _remainingTime -= categoryTime;

                Debug.WriteLine($"Category time: {categoryTime} ms");

                Thread.Sleep(categoryTime);

                var oldForegroundColor = Console.ForegroundColor;

                ForegroundColor =
                    _remainingTime <= 0
                    ? ConsoleColor.Red
                    : ConsoleColor.Gray;

                WriteLine(category);

                ForegroundColor = oldForegroundColor;
            }
        }

        #endregion
    }
}
