//----------------------------------------------------------------------------
// <copyright file="Program.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      The main program class for the "Dicts and Sets" console demos.
// </description>
// <version>v1.0.0 2018-08-04T01:19:00+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.DictsSets
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using Util;

    using static System.Console;

    /// <summary>
    /// The main program class for the "Dicts and Sets" console demos.
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
            WriteLine("*** DICTIONARIES AND SETS DEMOS ***");
            WriteLine();

            // Non-generic simple phone book demo
            SimplePhoneBook();

            WriteLine();

            // Generic Dictionary Basics
            DictionaryBasics();

            WriteLine();

            // Product location Demo
            ProductLocationDemo();

            WriteLine();

            // User details demo
            UserDetailsDemo();

            WriteLine();

            // Simple encyclopedia demo
            SimpleEncyclopedia();

            WriteLine();

            // Coupons demo (HashSet)
            CouponsDemo();

            WriteLine();

            // Spa (swimming pools) demo
            SpaDemo();

            WriteLine();

            // Sorted Set demo by example of duplicate names
            SortedSetDemo();

            WriteLine();
        }

        /// <summary>
        /// Gets a random boolean value.
        /// </summary>
        /// <returns>
        /// A random boolean value.
        /// </returns>
        private static bool GetRandomBoolean()
            => _random.Next(2) == 1;

        /// <summary>
        /// Demo of a simple phone book.
        /// </summary>
        private static void SimplePhoneBook()
        {
            WriteLine("PHONE BOOK");
            WriteLine();

            var phoneBook = new Hashtable()
            {
                { "Marcin Jamro", "000-000-000" },
                { "John Smith", "111-111-111" },
                { "Mary Fox", "222-222-222" },
            };

            phoneBook["Lily Smith"] = "333-333-333";

            try
            {
                // Exceptions will only be thrown using "Add".
                // The indexer would just update the item.
                phoneBook.Add("Mary Fox", "222-222-222");
            }
            catch (ArgumentException)
            {
                WriteLine("The entry already exists in the phone book.");
                WriteLine();
            }

            WriteLine("Phone numbers:");
            WriteLine();

            if (phoneBook.Count == 0)
            {
                WriteLine("Empty.");
            }
            else
            {
                foreach (DictionaryEntry entry in phoneBook)
                {
                    WriteLine($"* {entry.Key}: {entry.Value}");
                }
            }

            WriteLine();

            bool abort = false;

            while (!abort)
            {
                Write("Search by name (Enter only to abort): ");

                var input = ReadLine().Trim();

                abort = String.IsNullOrEmpty(input);

                if (abort)
                {
                    break;
                }

                WriteLine();

                if (phoneBook.Contains(input))
                {
                    var number = phoneBook[input];

                    WriteLine($"Found phone number: {number}");
                }
                else
                {
                    WriteLine("Name not found in phone book.");
                }

                WriteLine();
            }

            WriteLine();
        }

        /// <summary>
        /// Demo of basic dictionary operations.
        /// </summary>
        private static void DictionaryBasics()
        {
            WriteLine("DICTIONARY BASICS");
            WriteLine();

            var dictionary = new Dictionary<string, string>
            {
                { "Key 1", "Value 1" },
                { "Key 2", "Value 2" },
            };

            var key = "key";

            try
            {
                var value1 = dictionary[key];
            }
            catch (KeyNotFoundException knfe)
            {
                WriteLine($"Key does not exist. ({knfe.Message})");
                WriteLine();
            }

            dictionary[key] = "value";

            WriteLine($"Now \"{key}\" has value \"{dictionary[key]}\".");
            WriteLine();

            if (dictionary.TryGetValue("Key 2", out var value))
            {
                WriteLine($"Got value for Key 2: {value}");
                WriteLine();
            }

            var concurrentDictionary = new ConcurrentDictionary<string, string>();

            WriteLine($"Items in concurrent dictionary: {concurrentDictionary.Count}");
            WriteLine();

            var concurrentKey = "ConcurrentKey";

            var concurrentValue = concurrentDictionary.GetOrAdd(concurrentKey, "Concurrent value");

            WriteLine($"Concurrent value: {concurrentValue}");
            WriteLine();

            WriteLine();
        }

        /// <summary>
        /// More demos of dictionary behavior like adding duplicates and search.
        /// </summary>
        private static void ProductLocationDemo()
        {
            WriteLine("PRODUCT LOCATION");
            WriteLine();

            var products = new Dictionary<string, string>
            {
                { "5900000000000", "A1" },
                { "5901111111111", "B5" },
                { "5902222222222", "C9" },
            };

            products["5903333333333"] = "D7";

            try
            {
                products.Add("5904444444444", "A3");
            }
            catch (ArgumentException)
            {
                WriteLine("The entry already exists.");
                WriteLine();
            }

            WriteLine("All products:");
            WriteLine();

            if (products.Count == 0)
            {
                WriteLine("No products found.");
            }
            else
            {
                foreach (var product in products)
                {
                    WriteLine($"* {product.Key}: {product.Value}");
                }
            }

            WriteLine();

            Write("Search by barcode: ");

            var input = ReadLine().Trim();

            if (products.TryGetValue(input, out var location))
            {
                WriteLine($"The product is in area {location}.");
            }
            else
            {
                WriteLine("Product not found.");
            }

            WriteLine();

            WriteLine();
        }

        /// <summary>
        /// An even nicer demo of dictionary search like in an employee register.
        /// </summary>
        private static void UserDetailsDemo()
        {
            WriteLine("USER DETAILS");
            WriteLine();

            var employees = new Dictionary<int, Employee>();

            employees.Add(
                100,
                new Employee { FirstName = "Marcin", LastName = "Jamro", PhoneNumber = "000-000-000"}
            );

            employees.Add(
                210,
                new Employee { FirstName = "Mary", LastName = "Fox", PhoneNumber = "111-111-111" }
            );

            employees.Add(
                303,
                new Employee { FirstName = "John", LastName = "Smith", PhoneNumber = "222-222-222" }
            );

            bool validInteger = true;

            do
            {
                Write("Enter the employee identifier: ");

                var input = ReadLine().Trim();

                WriteLine();

                validInteger = Int32.TryParse(input, out var id);

                if (validInteger)
                {
                    if (employees.TryGetValue(id, out var employee))
                    {
                        var nl = Environment.NewLine;

                        ConsoleColor.White.UseFore(() =>
                        {
                            WriteLine($"First Name: {employee.FirstName}{nl}Last Name: {employee.LastName}{nl}Phone Number: {employee.PhoneNumber}");
                        });
                    }
                    else
                    {
                        ConsoleColor.Yellow.UseFore(() =>
                            WriteLine($"The employee with the ID {id} does not exist.")
                        );
                    }

                    WriteLine();
                }
            }
            while (validInteger);

            WriteLine();
        }

        /// <summary>
        /// Demo of a sorted dictionary by mimicking a poor man's encyclopedia.
        /// </summary>
        private static void SimpleEncyclopedia()
        {
            WriteLine("ENCYCLOPEDIA");
            WriteLine();

            var definitions = new SortedDictionary<string, string>();

            var exit = false;

            do
            {
                Write("Choose an option ([a] - add, [l] - list: ");

                var inputKey = ReadKey();

                WriteLine();
                WriteLine();

                switch (inputKey.Key)
                {
                    case ConsoleKey.A:

                        ConsoleColor.White.UseFore(() =>
                        {
                            string name = String.Empty;

                            while (String.IsNullOrEmpty(name))
                            {
                                Write("Enter the name (must not be empty): ");

                                name = ReadLine().Trim();

                                WriteLine();
                            }

                            Write("Enter the explanation: ");

                            var explanation = ReadLine().Trim();

                            WriteLine();

                            definitions[name] = explanation;
                        });

                        break;

                    case ConsoleKey.L:

                        foreach (var definition in definitions)
                        {
                            ConsoleColor.White.UseFore(() =>
                                WriteLine($"{definition.Key}: {definition.Value}")
                            );
                        }

                        break;

                    default:

                        ConsoleColor.Cyan.UseFore(() =>
                        {
                            WriteLine("Do you want to exit the  program? Press [y]es or [n]o.");

                            var exitInputKey = ReadKey();

                            WriteLine();

                            exit = exitInputKey.Key == ConsoleKey.Y;
                        });

                        break;
                }

                WriteLine();
            }
            while (!exit);

            WriteLine();
        }

        /// <summary>
        /// HashSet demo for unique, non-reusable items like coupons.
        /// </summary>
        private static void CouponsDemo()
        {
            WriteLine("COUPONS");
            WriteLine();

            var usedCoupons = new HashSet<int>();

            var exit = false;

            do
            {
                Write("Enter the coupon number: ");

                var input = ReadLine().Trim();

                WriteLine();

                if (Int32.TryParse(input, out var couponNumber))
                {
                    if (usedCoupons.Contains(couponNumber))
                    {
                        ConsoleColor.Red.UseFore(() =>
                            WriteLine("This coupon has already been used :-(")
                        );
                    }
                    else
                    {
                        usedCoupons.Add(couponNumber);

                        ConsoleColor.Green.UseFore(() =>
                            WriteLine("Thank you :-)")
                        );
                    }

                    WriteLine();
                }
                else
                {
                    exit = true;
                }
            }
            while (!exit);

            WriteLine();
        }

        /// <summary>
        /// Complex demo to generate visitor statistics to spa pools using
        /// a dictionary and hash sets and their proper set operations.
        /// </summary>
        private static void SpaDemo()
        {
            WriteLine("SPA - SWIMMING POOLS");
            WriteLine();

            var poolTickets = new Dictionary<PoolType, HashSet<int>>
            {
                { PoolType.Competition, new HashSet<int>() },
                { PoolType.Kids, new HashSet<int>() },
                { PoolType.Recreation, new HashSet<int>() },
                { PoolType.Thermal, new HashSet<int>() },
            };

            // Randomly fill the ticket data.
            for (var ticketId = 1; ticketId < 100; ++ticketId)
            {
                foreach (var pool in poolTickets)
                {
                    if (GetRandomBoolean())
                    {
                        pool.Value.Add(ticketId);
                    }
                }
            }

            WriteLine("Number of visitors per pool:");
            WriteLine();

            foreach (var pool in poolTickets)
            {
                WriteLine($"- {pool.Key}: {pool.Value.Count}");
            }

            WriteLine();

            var maxVisitorsPool =
                poolTickets
                .OrderByDescending(kvp => kvp.Value.Count)
                .Select(kvp => kvp.Key)
                .FirstOrDefault();

            WriteLine($"{maxVisitorsPool} pool was the most popular.");

            WriteLine();

            // Visitors that have at least visited one pool.
            var anyPool = new HashSet<int>(poolTickets[PoolType.Competition]);

            anyPool.UnionWith(poolTickets[PoolType.Kids]);
            anyPool.UnionWith(poolTickets[PoolType.Recreation]);
            anyPool.UnionWith(poolTickets[PoolType.Thermal]);

            WriteLine($"{anyPool.Count} visitors have been to at least one pool.");

            WriteLine();

            // Visitors that have been to every pool.
            var allPools = new HashSet<int>(poolTickets[PoolType.Competition]);

            allPools.IntersectWith(poolTickets[PoolType.Kids]);
            allPools.IntersectWith(poolTickets[PoolType.Recreation]);
            allPools.IntersectWith(poolTickets[PoolType.Thermal]);

            WriteLine($"{allPools.Count} visitors have been to every pool.");

            WriteLine();

            WriteLine();
        }

        /// <summary>
        /// Demo of sorting names and removing duplicates just by using
        /// a sorted set.
        /// </summary>
        private static void SortedSetDemo()
        {
            WriteLine("DUPLICATE NAME REMOVER");
            WriteLine();

            var namesList = new List<string>
            {
                "Marcin",
                "Mary",
                "James",
                "Albert",
                "Lily",
                "Emily",
                "marcin",
                "James",
                "Jane",
            };

            var sortedNames = new SortedSet<string>(
                namesList,
                StringComparer.InvariantCultureIgnoreCase);

            WriteLine($"Input of names ({namesList.Count}):");
            WriteLine();

            foreach (var name in namesList)
            {
                WriteLine($"* {name}");
            }

            WriteLine();

            WriteLine($"Sorted names, duplicates removed ({sortedNames.Count}):");
            WriteLine();

            foreach (var sortedName in sortedNames)
            {
                WriteLine($"- {sortedName}");
            }

            WriteLine();

            WriteLine();
        }
    }
}
