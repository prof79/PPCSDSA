//----------------------------------------------------------------------------
// <copyright file="HanoiTower.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A Tower of Hanoi solver/game simulation.
// </description>
// <version>v1.0.0 2018-06-05T00:36:41+02</version>
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
    using System.Threading;

    using static System.Console;

    /// <summary>
    /// A Tower of Hanoi solver/game simulation.
    /// </summary>
    public class HanoiTower
    {
        #region Fields

        private static readonly int _consoleWidth = Console.WindowWidth;
        private static readonly int _consoleHeight = Console.WindowHeight;

        // -------------------------------------------------------------------
        //
        // Regarding console window metrics we need:
        //
        // 1. Vertically we need 4 lines at the top and 6 lines at the bottom
        //    for title texts and captions plus 1 line for the spindle base;
        //    = 11 lines vertically
        //
        // 2. Horizontally we will space each of the 3 spindle bases with
        //    two spaces left and two spaces right; at the very left and right
        //    we require one space each.
        //    = 14 spaces (characters) horizontally
        //
        // 3. Thus the disc width can be at most ((_consoleWidth - 14) / 3)
        //    characters wide. The number must be floored to an odd number
        //    to account for the spindle rod and space the disc evenly to
        //    the left and right. See schematic below.
        //
        // 4. The number of discs that can be stacked are (_consoleHeight - 11)
        //    according to the requirements of 1.
        //
        // 5. As hinted in 3 the discs should be of width x ranging from
        //    3 to n where n is <= w. w is ((_consoleWidth - 14) / 3) as of
        //    3. A picture is better suited to demonstrate why odd numbers
        //    starting from 3 are required/a sensible choice:
        //
        //        |             - tip of rod, not printed
        //       ===            - first disc
        //      =====
        //     =======
        //    =========         - fourth disc
        //    ---------         - spindle base
        //
        // -------------------------------------------------------------------

        private const int _verticalBorderSize = 11;
        private const int _horizontalPaddingTotal = 14;

        private static readonly int _maximumDiscWidth =
            (_consoleWidth - _horizontalPaddingTotal) / 3;

        private static readonly int _maximumDiscs =
            _consoleHeight - _verticalBorderSize;

        // The "towers"

        // Source stack with discs
        private Stack<int> _sourceStack
            = new Stack<int>();

        // Destination stack
        private Stack<int> _destinationStack
            = new Stack<int>();

        // Auxiliary stack for temporary placement
        private Stack<int> _temporaryStack
            = new Stack<int>();

        private int _userNumberOfDiscs;

        #endregion

        #region Constructors

        #endregion

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// Generates an infinite sequence of odd numbers.
        /// </summary>
        /// <param name="start">
        /// The odd number to start the sequence with.
        /// </param>
        /// <returns>
        /// A sequence of odd numbers.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="start"/> is not an odd number.
        /// </exception>
        public IEnumerable<int> OddNumbers(int start = 1)
        {
            if (start % 2 == 0)
            {
                throw new ArgumentException("Argument must be an odd number.", nameof(start));
            }

            var n = start;

            while (true)
            {
                yield return n;

                n += 2;
            }
        }

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
        public static void UsingForegroundColor(ConsoleColor color, Action action)
        {
            var oldForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = color;

            action?.Invoke();

            Console.ForegroundColor = oldForegroundColor;
        }

        /// <summary>
        /// Helper method to repeat an action a certain number of times.
        /// Example: writing spaces or line breaks to the console.
        /// </summary>
        /// <param name="count">
        /// The number of repetitions. Must be greater or equal 0.
        /// </param>
        /// <param name="action">
        /// The <see cref="Action"/> to perform <code>count</code> times.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="count"/> is negative or
        /// <paramref name="action"/> is <code>null</code>.
        /// </exception>
        public void Repeat(int count, Action action)
        {
            if (count < 0)
            {
                throw new ArgumentException("Repeat count must be greater or equal 0.", nameof(count));
            }

            if (action == null)
            {
                throw new ArgumentException("Action must not be null.", nameof(action));
            }

            for (var counter = 0; counter < count; ++counter)
            {
                action?.Invoke();
            }
        }

        /// <summary>
        /// Resets the necessary variables for a new simulation/game.
        /// </summary>
        private void Reset()
        {
            _sourceStack.Clear();
            _destinationStack.Clear();
            _temporaryStack.Clear();

            _userNumberOfDiscs = -1;
        }

        /// <summary>
        /// Runs the game simulation.
        /// </summary>
        /// <param name="numberOfDiscs">
        /// The number of discs to use in the simulation.
        /// Defaults to 5.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="numberOfDiscs"/> is smaller than 1 or
        /// larger than the number of discs that could fit the current console
        /// window.
        /// </exception>
        public void Run(int numberOfDiscs = 5)
        {
            var discCandidates =
                OddNumbers(3)
                .Take(_maximumDiscs)
                .ToList();

            var maximumDiscSelection =
                discCandidates
                .Where(n => n <= _maximumDiscWidth)
                .ToList();

            WriteLine("~~~ Hanoi Stats ~~~");
            WriteLine($"Console height: {_consoleHeight}");
            WriteLine($"Console width: {_consoleWidth}");
            WriteLine($"Maximum number of discs: {_maximumDiscs}");
            WriteLine($"Width candidates: {String.Join(", ", discCandidates)}");
            WriteLine($"Maximum disc width: {_maximumDiscWidth}");
            WriteLine($"Maximum disc selection: {String.Join(", ", maximumDiscSelection)}");
            WriteLine($"User-requested discs: {numberOfDiscs}");

            if (numberOfDiscs < 1)
            {
                throw new ArgumentException(
                    "The simulation must be run with a number of discs of 1 or greater.",
                    nameof(numberOfDiscs));
            }

            if (numberOfDiscs > _maximumDiscs)
            {
                throw new ArgumentException(
                    $"Too many discs: A console of {_consoleWidth}x{_consoleHeight} can support a maximum of {_maximumDiscs} discs.",
                    nameof(numberOfDiscs));
            }

            Reset();

            _userNumberOfDiscs = numberOfDiscs;

            var gameDiscs =
                maximumDiscSelection
                .Take(numberOfDiscs);

            WriteLine($"User discs: {String.Join(", ", gameDiscs)}");
            WriteLine();

            // Now put the selection of game discs on the source stack
            foreach (var gameDisc in gameDiscs.Reverse())
            {
                _sourceStack.Push(gameDisc);
            }

            DiscMoved += Visualize;

            // Initial dummy disc move (no discs moved) to get the
            // starting point drawn to screen
            DiscMoved?.Invoke(this, DiscMovedEventArgs<int>.Empty);

            // Recursively solve to move from-stack to goal-stack
            HanoiSolve(_userNumberOfDiscs, _sourceStack, _temporaryStack, _destinationStack);

            DiscMoved -= Visualize;
        }

        /// <summary>
        /// A default implementation of a console-based visualization
        /// of the Tower of Hanoi game/simulation.
        /// </summary>
        /// <param name="sender">
        /// The sender of the event.
        /// </param>
        /// <param name="e">
        /// The event arguments eg. disc information.
        /// </param>
        public void Visualize(object sender, DiscMovedEventArgs<int> e)
        {
            // Clear console
            Clear();

            DrawTitle();

            DrawDiscsAndRods();

            DrawSpindleBases();

            DrawCaptions();

            Thread.Sleep(2000);

            // Wait for key press
            //ReadKey(true);
        }

        private static void DrawTitle()
        {
            // Draw title
            const string title = "~~~ TOWERS OF HANOI ~~~";

            var halfWidth = (_consoleWidth - title.Length) / 2;

            var titleTemp = title.PadLeft(title.Length + halfWidth);
            var paddedTitle = titleTemp.PadRight(titleTemp.Length + halfWidth);

            WriteLine();
            UsingForegroundColor(ConsoleColor.Cyan, () => WriteLine(paddedTitle));
            WriteLine();
            WriteLine();
        }

        private void DrawDiscsAndRods()
        {
            // Disc drawing calculations
            int halfDiscSize;

            if (_maximumDiscWidth % 2 == 0)
            {
                halfDiscSize = _maximumDiscWidth / 2;
            }
            else
            {
                halfDiscSize = (_maximumDiscWidth - 1) / 2;
            }

            // Draw discs and rods
            for (var towerRow = 0; towerRow < _userNumberOfDiscs; ++towerRow)
            {
                Write(" ");

                // From Tower
                DrawTower(halfDiscSize, towerRow, _sourceStack);

                // To
                DrawTower(halfDiscSize, towerRow, _destinationStack);

                // Aux
                DrawTower(halfDiscSize, towerRow, _temporaryStack);

                Write(" ");

                WriteLine();
            }
        }

        private void DrawTower(int halfMaximumDiscSize, int towerRow, Stack<int> towerStack)
        {
            var discList = towerStack.ToList();

            var discBeginThreshold = _userNumberOfDiscs - discList.Count;

            // Draw Tower
            Write(" ");
            Write(" ");

            if (towerRow >= discBeginThreshold)
            {
                var currentDiscIndex = towerRow - discBeginThreshold;

                var currentDiscValue = discList[currentDiscIndex];

                var currentDiscHalf = currentDiscValue / 2;

                Repeat(halfMaximumDiscSize - currentDiscHalf, () => Write(" "));
                Repeat(currentDiscHalf, () => HanoiComponent.Disc.Write(currentDiscValue));
                HanoiComponent.Disc.Write(currentDiscValue);
                //UsingForegroundColor(ConsoleColor.Yellow, () => Write(currentDiscValue));
                Repeat(currentDiscHalf, () => HanoiComponent.Disc.Write(currentDiscValue));
                Repeat(halfMaximumDiscSize - currentDiscHalf, () => Write(" "));
            }
            else
            {
                Repeat(halfMaximumDiscSize, () => Write(" "));
                HanoiComponent.Peg.Write();
                Repeat(halfMaximumDiscSize, () => Write(" "));
            }

            Write(" ");
            Write(" ");
        }

        private void DrawSpindleBases()
        {
            // Draw spindle bases

            Write(" ");

            // From, To/Goal, Aux/Temporary
            Repeat(3, () =>
            {
                Write(" ");
                Write(" ");
                Repeat(_maximumDiscWidth, () => HanoiComponent.Base.Write());
                Write(" ");
                Write(" ");
            });

            Write(" ");

            WriteLine();
        }

        private void DrawCaptions()
        {
            // Draw captions

            const string fromLabel = "SOURCE";
            const string toLabel = "GOAL";
            const string auxLabel = "TEMP";

            var fromPadding = (_maximumDiscWidth - fromLabel.Length) / 2;
            var toPadding = (_maximumDiscWidth - toLabel.Length) / 2;
            var auxPadding = (_maximumDiscWidth - auxLabel.Length) / 2;

            var paddedFromTemp = fromLabel.PadLeft(fromLabel.Length + fromPadding);
            var paddedFrom = paddedFromTemp.PadRight(paddedFromTemp.Length + fromPadding);

            var paddedToTemp = toLabel.PadLeft(toLabel.Length + toPadding);
            var paddedTo = paddedToTemp.PadRight(paddedToTemp.Length + toPadding);

            var paddedAuxTemp = auxLabel.PadLeft(auxLabel.Length + auxPadding);
            var paddedAux = paddedAuxTemp.PadRight(paddedAuxTemp.Length + auxPadding);

            WriteLine();

            Write(" ");

            Write(" ");
            Write(" ");
            Write(paddedFrom);
            Write(" ");
            Write(" ");

            Write(" ");
            Write(" ");
            Write(paddedTo);
            Write(" ");
            Write(" ");

            Write(" ");
            Write(" ");
            Write(paddedAux);
            Write(" ");
            Write(" ");

            Write(" ");

            WriteLine();

            WriteLine();

            var verticalPadding = _maximumDiscs - _userNumberOfDiscs;

            Repeat(verticalPadding, WriteLine);
        }

        /// <summary>
        /// Solves the Tower of Hanoi problem recursively.
        /// </summary>
        /// <param name="discNumber">
        /// The current disc number counted from 1. The number is also
        /// identical to the size of the (sub-)tower to be solved.
        /// </param>
        /// <param name="source">
        /// The source/initial tower in form of a <see cref="Stack{T}"/>.
        /// </param>
        /// <param name="temporary">
        /// The tower for temporary operations in form of a
        /// <see cref="Stack{T}"/>.
        /// </param>
        /// <param name="destination">
        /// The destination/goal tower in form of a <see cref="Stack{T}"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="discNumber"/> is smaller than 1 or
        /// any of the stack references (<paramref name="source"/>,
        /// <paramref name="temporary"/>, <paramref name="destination"/>)
        /// is null.
        /// </exception>
        /// <remarks>
        /// The essential part to understand the algorithm is to realize that
        /// it is the target/goal tower that varies according to the
        /// sub-problem.
        /// At least some previous knowledge of recursive methods is
        /// absolutely required or you might not take the leap at all.
        /// If you have played the puzzle on paper for towers of 1 to 3 discs
        /// you may intuitively - thinking ahead - have moved discs
        /// in similar constellations differently and may fail to see the
        /// generic pattern and why behind it.
        /// For a 1-disc tower it is trivial - you directly move from
        /// the start peg to the goal peg.
        /// For a 2-disc tower you (hopefully) are not going to move
        /// top disc 1 directly to goal but to the temporary peg instead
        /// as you are anticipating that you could then move disc 2
        /// directly to its final destination, the goal peg.
        /// Finally you move disc 1 from current peg (temporary) to goal.
        /// For a 3-disc tower you should realize that it makes sense to
        /// first get the 2-disc "sub-tower" out of the way by erecting it
        /// on the temporary peg. Then you can simply move disc 3 to the
        /// final destination, the goal peg. Now the problem is reduced
        /// again to a 2-disc tower problem where the sub-tower is
        /// currently on the temporary peg and has to move to the goal peg.
        /// Hopefully you may start to see that it is only the "goal tower"
        /// that varies by the current needs. You move the current n - 1
        /// tower of discs out of the way to be able to move the last or
        /// nth disc to the final destination. Then you move the n - 1
        /// tower to the final destination.
        /// The more discs there are the more similar groups of steps
        /// there are that repeat over and over with varying source
        /// and destination pegs.
        /// </remarks>
        private void HanoiSolve(int discNumber, Stack<int> source, Stack<int> temporary, Stack<int> destination)
        {
            // Argument checking - discNumber must be >= 1
            if (discNumber < 1)
            {
                throw new ArgumentException(
                    $"Disc number must equal 1 or greater.",
                    nameof(discNumber));
            }

            // Null checks
            if (source == null
                || temporary == null
                || destination == null)
            {
                throw new ArgumentException(
                    "Neither stack must be null.");
            }

            // Base case - 1 disc; recursion ends
            if (discNumber == 1)
            {
                // Move directly from source to goal
                var disc = source.Pop();
                destination.Push(disc);

                // Cause a notification event to eg. draw and delay UI.
                DiscMoved?.Invoke(this, new DiscMovedEventArgs<int>(discNumber, source, destination));
            }
            else
            {
                // Recursive procedure - first move all discs less than
                // current discNumber out of the way thus using temporary
                // as goal and goal as temporary storage.
                HanoiSolve(discNumber - 1, source, destination, temporary);

                // We freed the current disc on the current from-stack.
                // Now move the current disc from target to goal.
                var disc = source.Pop();
                destination.Push(disc);

                // Cause a notification event to eg. draw and delay UI.
                DiscMoved?.Invoke(this, new DiscMovedEventArgs<int>(discNumber, source, destination));

                // Finally move the "sub-tower" of (n - 1) parked discs
                // (ie. < discNumber) to the goal peg.
                // We know we are currently on temporary and have to go to
                // goal, using from as temporary as necessary.
                HanoiSolve(discNumber - 1, temporary, source, destination);
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event fired when a disc has been moved.
        /// Primarily used to update the user interface.
        /// </summary>
        public EventHandler<DiscMovedEventArgs<int>> DiscMoved;

        #endregion
    }
}
