//----------------------------------------------------------------------------
// <copyright file="Program.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      The main program class for the "Lists" console demos.
// </description>
// <version>v1.0.0 2018-06-03T23:07:00+02</version>
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Util;

    using static System.Console;

    /// <summary>
    /// The main program class for the "Lists" console demos.
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
            WriteLine("*** LIST DEMOS ***");
            WriteLine();

            // ArrayList demo.
            ArrayListDemo();

            WriteLine();

            // Generic lists demo.
            GenericLists();

            WriteLine();

            // Sorted list demo.
            AddressBook();

            WriteLine();

            // Book reader (pagination/linked-list) demo.
            BookReader();

            WriteLine();

            // Circular linked list functional demo.
            CircularLinkedListDemo();

            WriteLine();

            // Spin Wheel game simulation (circular linked lists)
            SpinWheelGame();

            WriteLine();
        }

        /// <summary>
        /// Showcasing the use and quirks of <see cref="ArrayList"/>
        /// </summary>
        private static void ArrayListDemo()
        {
            // Header
            WriteLine("ARRAYLIST");
            WriteLine();

            // Create a new ArrayList
            var arrayList = new ArrayList();

            // Add a number
            arrayList.Add(5);

            // Add an array of integers
            arrayList.AddRange(new int[] { 6, -7, 8 });

            // Add an array of strings
            arrayList.AddRange(new string[] { "Marcin", "Mary" });

            // Insert a float value at index 5
            arrayList.Insert(5, 7.8);

            var first = arrayList[0];

            var thirdAsInt = (int) arrayList[2];

            WriteLine("Elements:");
            WriteLine();

            foreach (var element in arrayList)
            {
                WriteLine(element);
            }

            WriteLine();

            WriteLine($"Count: {arrayList.Count}");
            WriteLine($"Capacity: {arrayList.Capacity}");

            WriteLine();

            WriteLine($"Contains Mary? {arrayList.Contains("Mary")}");
            WriteLine($"Index of -7? {arrayList.IndexOf(-7)}");

            WriteLine();

            WriteLine("But as you can see, ArrayList is not strongly typed.");

            WriteLine();
        }

        /// <summary>
        /// Simple data generation helper to create a list of
        /// <see cref="Person"/> objects.
        /// </summary>
        /// <returns>
        /// A generic list of <see cref="Person"/> objects.
        /// </returns>
        private static List<Person> CreatePeople()
        {
            var people = new List<Person>();

            people.AddRange(
                new[]
                {
                    new Person { Name = "Marcin", Age = 29, Country = CountryCode.PL },
                    new Person { Name = "Sabine", Age = 25, Country = CountryCode.DE },
                    new Person { Name = "Ann", Age = 31, Country = CountryCode.PL },
                }
            );

            return people;
        }

        /// <summary>
        /// Showcasing generic lists.
        /// </summary>
        private static void GenericLists()
        {
            WriteLine("GENERIC LISTS");
            WriteLine();

            var numbers = new List<double>();

            // Read numbers from standard input ie. the user.
            while (true)
            {
                Write("Enter an integer or floating-point number: ");

                var numberString = ReadLine();

                if (Double.TryParse(numberString, NumberStyles.Float, new NumberFormatInfo(), out double doubleValue))
                {
                    numbers.Add(doubleValue);

                    WriteLine($"The average value: {numbers.Average()}");
                    WriteLine();
                }
                else
                {
                    break;
                }
            }

            WriteLine();
            WriteLine();

            var people = CreatePeople();

            WriteLine($"People: {String.Join(", ", people)}");

            var orderedPeople = people.OrderBy(p => p.Name).ToList();

            WriteLine($"Ordered people: {String.Join(", ", orderedPeople)}");

            WriteLine();

            var names = from p in people
                        where p.Age <= 30
                        select p.Name;

            WriteLine($"Names under 30: {String.Join(", ", names.ToList())}");

            WriteLine();
        }

        /// <summary>
        /// Address book sample showcasing <see cref="SortedList{TKey, TValue}"/>.
        /// </summary>
        private static void AddressBook()
        {
            WriteLine("SORTED GENERIC LISTS");
            WriteLine();

            var unsortedPeople = CreatePeople();

            var addressBook = new SortedList<string, Person>();

            foreach (var person in unsortedPeople)
            {
                addressBook.Add(person.Name, person);
            }

            // Iteration over a sorted list - yields key-value pairs.
            foreach (var keyValuePair in addressBook)
            {
                WriteLine($"Key: {keyValuePair.Key}");

                WriteLine($"Value (Person): {keyValuePair.Value}");

                WriteLine();
            }

            WriteLine();
        }

        /// <summary>
        /// Runs the book reader (linked-list and pagination) demo.
        /// </summary>
        private static void BookReader()
        {
            WriteLine("BOOK READER");
            WriteLine();
            Write("Press a key to start ...");

            ReadKey(true);

            WriteLine();

            var reader = new BookReader();

            reader.Run();
        }

        /// <summary>
        /// Functional test of circular linked list.
        /// </summary>
        private static void CircularLinkedListDemo()
        {
            WriteLine("CIRCULAR LINKED LIST");
            WriteLine();

            var circularList =
                new CircularLinkedList<int>();

            for (var count = 0; count < 10; ++count)
            {
                circularList.AddLast(count);
            }

            var sampleData = circularList.Take(24);

            WriteLine("Sample data:");

            WriteLine(String.Join(", ", sampleData.ToList()));

            WriteLine();

            WriteLine("Sample data 2:");

            int counter = 0;

            foreach (var item in circularList)
            {
                if (counter > 32)
                {
                    break;
                }

                Write($"{item}, ");

                ++counter;
            }

            WriteLine();

            var sampleData3 = (circularList as IEnumerable<int>)?.Take(28);

            WriteLine("Sample data 3:");

            WriteLine(String.Join(", ", sampleData3.ToList()));

            WriteLine();

            WriteLine();
        }

        /// <summary>
        /// Showcase of circular linked lists in a spin-the-wheel
        /// game simulation.
        /// </summary>
        private static void SpinWheelGame()
        {
            WriteLine("SPIN THE WHEEL GAME");
            WriteLine();

            var game = new SpinTheWheelGame();

            game.Run();

            WriteLine();
        }
    }
}
