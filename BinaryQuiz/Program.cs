//----------------------------------------------------------------------------
// <copyright file="Program.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      The main program class for the "Binary Quiz" console program.
// </description>
// <version>v1.0.0 2018-08-04T00:48:00+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.BinaryQuiz
{
    using System;

    using at.markusegger.Lab.Library.DataStructures;

    using static System.Console;

    /// <summary>
    /// The main program class for the "Binary Quiz" console program.
    /// </summary>
    internal class Program
    {
        #region Fields

        private static readonly IBinaryTree<QuizItem> _quizItemTree;
        private static readonly IBinaryTreeNode<QuizItem> _quizStartItem;

        private static readonly Random _random = new Random();

        #endregion

        #region Constructors

        static Program()
        {
            _quizItemTree = CreateQuizTree();

            _quizStartItem = _quizItemTree.Root;
        }

        #endregion

        #region Main

        /// <summary>
        /// The main method of the "Binary Quiz" program.
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

            // Title
            var oldColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("*** BINARY CHOICE QUIZ ***");
            ForegroundColor = oldColor;

            WriteLine();

            var quit = false;

            while (!quit)
            {
                GameLoop();

                WriteLine();

                oldColor = ForegroundColor;
                ForegroundColor = ConsoleColor.Yellow;

                Write("Play again (y/n)? ");

                var answer = ReadKey(false).Key;

                ForegroundColor = oldColor;

                WriteLine();
                WriteLine();
                WriteLine();

                switch (answer)
                {
                    case ConsoleKey.Y:
                        quit = false;
                        break;

                    default:
                        quit = true;
                        break;
                }
            }

            WriteLine("Thanks for playing!");
            WriteLine();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The game loop for user input and console output.
        /// </summary>
        private static void GameLoop()
        {
            var node = _quizStartItem;

            while (null != node)
            {
                // Was that a question (inner node) or an answer (leaf node)?
                if (node.Height > 0)
                {
                    Write(node.Data.Text);
                    Write(" ");

                    var answer = ReadKey(false).Key;

                    WriteLine();

                    switch (answer)
                    {
                        case ConsoleKey.Y:
                            node = node.Left;
                            break;

                        case ConsoleKey.N:
                            node = node.Right;
                            break;

                        default:
                            var oldColor = ForegroundColor;
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("Invalid input, answer with y(es) or (n)o.");
                            ForegroundColor = oldColor;
                            break;
                    }
                }
                else
                {
                    // Write colored answer
                    var oldColor = ForegroundColor;
                    ForegroundColor = ConsoleColor.White;
                    WriteLine(node.Data.Text);
                    ForegroundColor = oldColor;

                    // Set node to null so we can quit properly
                    node = null;
                }

                WriteLine();
            }
        }

        /// <summary>
        /// Helper method to create a binary tree with questions and answers.
        /// </summary>
        /// <returns>
        /// A binary tree structure with nodes of type <see cref="BinaryTreeNode{T}"/>
        /// containing questions and answers.
        /// </returns>
        private static IBinaryTree<QuizItem> CreateQuizTree()
        {
            // Tree object instance
            var tree = new BinaryTree<QuizItem>();

            #region The quiz items

            var itemA = new QuizItem
            {
                Text = "Do you have experience in developing applications?"
            };

            var itemB = new QuizItem
            {
                Text = "Have you worked as a developer for more than five years?"
            };

            var itemC = new QuizItem
            {
                Text = "Apply as a senior developer!"
            };

            var itemD = new QuizItem
            {
                Text = "Apply as a middle developer!"
            };

            var itemE = new QuizItem
            {
                Text = "Have you completed the university?"
            };

            var itemF = new QuizItem
            {
                Text = "Apply as a junior developer!"
            };

            var itemG = new QuizItem
            {
                Text = "Will you find some time during the semester?"
            };

            var itemH = new QuizItem
            {
                Text = "Apply for our long-term internship program!"
            };

            var itemI= new QuizItem
            {
                Text = "Apply for summer internship program!"
            };

            #endregion

            #region The tree nodes

            var nodeA = new BinaryTreeNode<QuizItem>
            {
                Data = itemA
            };

            var nodeB = new BinaryTreeNode<QuizItem>
            {
                Data = itemB
            };

            var nodeC = new BinaryTreeNode<QuizItem>
            {
                Data = itemC
            };

            var nodeD = new BinaryTreeNode<QuizItem>
            {
                Data = itemD
            };

            var nodeE = new BinaryTreeNode<QuizItem>
            {
                Data = itemE
            };

            var nodeF = new BinaryTreeNode<QuizItem>
            {
                Data = itemF
            };

            var nodeG = new BinaryTreeNode<QuizItem>
            {
                Data = itemG
            };

            var nodeH = new BinaryTreeNode<QuizItem>
            {
                Data = itemH
            };

            var nodeI = new BinaryTreeNode<QuizItem>
            {
                Data = itemI
            };

            #endregion

            #region Build the tree

            tree.Root = nodeA;

            nodeA.Left = nodeB;
            nodeA.Right = nodeE;

            nodeB.Left = nodeC;
            nodeB.Right = nodeD;

            nodeE.Left = nodeF;
            nodeE.Right = nodeG;

            nodeG.Left = nodeH;
            nodeG.Right = nodeI;

            #endregion

            // Finished
            return tree;
        }

        #endregion
    }
}
