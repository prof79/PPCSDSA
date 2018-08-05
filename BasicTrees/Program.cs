//----------------------------------------------------------------------------
// <copyright file="Program.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      The main program class for the "Basic Trees" console demos.
// </description>
// <version>v1.0.0 2018-08-04T00:37:54+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.BasicTrees
{
    using System;

    using at.markusegger.Lab.Library.DataStructures;
    //using Util;

    using static System.Console;

    /// <summary>
    /// The main program class for the "Basic Trees" console demos.
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
            WriteLine("*** BASIC TREE DEMOS ***");
            WriteLine();

            // Getting the feet wet with a simple tree structure/first use
            // of our own tree classes.
            SimpleTreeDemo();

            WriteLine();

            // Using a tree to represent a company structure.
            CompanyStructure();

            WriteLine();
        }

        /// <summary>
        /// Create and display a simple tree demo.
        /// </summary>
        private static void SimpleTreeDemo()
        {
            WriteLine("SIMPLE TREE DEMO");
            WriteLine();

            var tree = new Tree<int>
            {
                Root = new TreeNode<int> { Data = 100 }
            };

            var treeRoot = tree.Root as ITreeNode<int>;

            var child2 = new TreeNode<int> { Data = 150, Parent = tree.Root };

            treeRoot?.AddRange(
                new[]
                {
                    new TreeNode<int> { Data = 50, Parent = tree.Root },
                    new TreeNode<int> { Data = 1, Parent = tree.Root },
                    child2,
                }
            );

            child2?.AddRange(
                new[]
                {
                    new TreeNode<int> { Data = 30, Parent = child2 }
                }
            );

            WriteLine(tree);

            WriteLine();
        }

        /// <summary>
        /// Create and display a simple company structure demo.
        /// </summary>
        private static void CompanyStructure()
        {
            WriteLine("COMPANY STRUCTURE");
            WriteLine();

            var companyTree = new Tree<Employee>
            {
                Root = new TreeNode<Employee> { Data = new Employee { Id = 100, Name = "Marcin Jamro", Role = "CEO" } }
            };

            var companyTreeRoot = companyTree.Root as ITreeNode<Employee>;

            // First-level employees

            // 0
            // The new Tree Library sets parents automatically.
            var johnSmith = new TreeNode<Employee>
            {
                Data = new Employee { Id = 1, Name = "John Smith", Role = "Head of Development" },
                //Parent = companyTree.Root
            };

            // 1
            var maryFox = new TreeNode<Employee>
            {
                Data = new Employee { Id = 50, Name = "Mary Fox", Role = "Head of Research" },
                //Parent = companyTree.Root
            };

            // 2
            var lilySmith = new TreeNode<Employee>
            {
                Data = new Employee { Id = 150, Name = "Lily Smith", Role = "Head of Sales" },
                //Parent = companyTree.Root
            };

            companyTreeRoot?.AddRange(
                new[]
                {
                    johnSmith,
                    maryFox,
                    lilySmith,
                }
            );

            // 0-0
            var chrisNorris = new TreeNode<Employee>
            {
                Data = new Employee { Id = 74, Name = "Chris Morris", Role = "Senior Developer" },
                //Parent = johnSmith
            };

            johnSmith?.AddChild(chrisNorris);

            // 0-0-0
            var ericGreen = new TreeNode<Employee>
            {
                Data = new Employee { Id = 201, Name = "Eric Green", Role = "Junior Developer" },
                //Parent = chrisNorris
            };

            // 0-0-1
            var ashleyLopez = new TreeNode<Employee>
            {
                Data = new Employee { Id = 170, Name = "Ashley Lopez", Role = "Junior Developer" },
                //Parent = chrisNorris
            };

            chrisNorris?.AddRange(
                new[]
                {
                    ericGreen,
                    ashleyLopez,
                }
            );

            // 0-0-1-0
            var emilyYoung = new TreeNode<Employee>
            {
                Data = new Employee { Id = 310, Name = "Emily Young", Role = "Developer Intern" },
                //Parent = ashleyLopez
            };

            ashleyLopez?.AddChild(emilyYoung);

            // 1-0
            var jimmyStewart = new TreeNode<Employee>
            {
                Data = new Employee { Id = 58, Name = "Jimmy Stewart", Role = "Senior Researcher" },
                //Parent = maryFox
            };

            // 1-1
            var andyWood = new TreeNode<Employee>
            {
                Data = new Employee { Id = 70, Name = "Andy Wood", Role = "Senior Researcher" },
                //Parent = maryFox
            };

            maryFox?.AddRange(
                new[]
                {
                    jimmyStewart,
                    andyWood,
                }
            );

            // 2-0
            var anthonyBlack = new TreeNode<Employee>
            {
                Data = new Employee { Id = 30, Name = "Anthony Black", Role = "Senior Sales Specialist" },
                //Parent = lilySmith
            };

            // 2-1
            var angelaEvans = new TreeNode<Employee>
            {
                Data = new Employee { Id = 60, Name = "Angela Evans", Role = "Senior Sales Specialist" },
                //Parent = lilySmith
            };

            // 2-2
            var tonyButler = new TreeNode<Employee>
            {
                Data = new Employee { Id = 42, Name = "Tony Butler", Role = "Senior Account Manager" },
                //Parent = lilySmith
            };

            lilySmith?.AddRange(
                new[]
                {
                    anthonyBlack,
                    angelaEvans,
                    tonyButler,
                }
            );

            // 2-0-0
            var paulaScott = new TreeNode<Employee>
            {
                Data = new Employee { Id = 93, Name = "Paula Scott", Role = "Junior Sales Specialist" },
                //Parent = anthonyBlack
            };

            // 2-0-1
            var sarahWatson = new TreeNode<Employee>
            {
                Data = new Employee { Id = 85, Name = "Sarah Watson", Role = "Junior Sales Specialist" },
                //Parent = anthonyBlack
            };

            anthonyBlack?.AddRange(
                new[]
                {
                    paulaScott,
                    sarahWatson,
                }
            );

            WriteLine(companyTree);

            WriteLine($"Chris Norris' depth: {chrisNorris.Depth}");
            WriteLine($"Chris Norris' degree: {chrisNorris.Degree}");
            WriteLine($"Chris Norris' level: {chrisNorris.Level}");
            WriteLine($"Chris Norris' heigth: {chrisNorris.Height}");
            WriteLine($"Chris Norris' # of descendants: {chrisNorris.NumberOfDescendants}");
            WriteLine();
            WriteLine($"Tree height: {companyTree.Height}");
            WriteLine($"Node count: {companyTree.TotalNodeCount}");

            WriteLine();
        }
    }
}
