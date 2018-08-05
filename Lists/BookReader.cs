//----------------------------------------------------------------------------
// <copyright file="BookReader.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A simple book reader (page navigation) demo
//      showcasing linked lists.
// </description>
// <version>v1.0.0 2018-06-03T00:57:25+02</version>
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
    using System.Collections.Generic;
    using Util;

    using static System.Console;

    /// <summary>
    /// A simple book reader (page navigation) demo
    /// showcasing linked lists.
    /// </summary>
    public class BookReader
    {
        #region Fields

        /// <summary>
        /// The console width in number of characters.
        /// </summary>
        private static readonly int _consoleWidth = Console.WindowWidth - 1;

        // Sample book data
        private static readonly Page _pageOne = new Page() { Content = "While using the List generic class, you can easily get access to particular elements of the collection using indices. However, when you get a single element, how can you move to the next element of the collection? Is it possible? To do so, you may consider the IndexOf method to get an index of the element. Unfortunately, it returns an index of the first occurrence of a given value in the collection, so it will not always work as expected in this scenario." };
        private static readonly Page _pageTwo = new Page() { Content = "With this approach, you can easily navigate from one element to the next one using the Next property. Such a structure is named the single-linked list. However, can it be further expanded by adding the Previous property to allow navigating in forward and backward directions? Of course! Such a data structure is named the double-linked list and is presented in the following diagram:" };
        private static readonly Page _pageThree = new Page() { Content = "As you can see, the double-linked list contains the First property that indicates the first element in the list. Each item has two properties that point to the previous and next element (Previous and Next, respectively). If there is no previous element, the Previous property is equal to null. Similarly, when there is no next element, the Next property is set to null. Moreover, the double-linked list contains the Last property that indicates the last element. When there are no items in the list, both the First and Last properties are set to null." };
        private static readonly Page _pageFour = new Page() { Content = "However, do you need to implement such a data structure on your own if you want to use it in your C#-based applications? Fortunately, no, because it is available as the LinkedList generic class in the System.Collections.Generic namespace." };
        private static readonly Page _pageFive = new Page() { Content = "While creating an instance of the class, you need to specify the type parameter that indicates a type of a single element within the list, such as int or string. However, a type of a single node is not just int or string, because in such a case you will not have access to any additional properties related to the double-linked list, such as Previous or Next. To solve this problem, each node is an instance of the LinkedListNode generic class, such as LinkedListNode<int> or LinkedListNode<string>." };
        private static readonly Page _pageSix = new Page() { Content = "All these methods return an instance of the LinkedListNode class. Moreover, there are also other methods, such as Contains for checking whether the specified value exists in the list, Clear for removing all elements from the list, and Remove for removing a node from the list." };

        private LinkedList<Page> _pages;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BookReader class.
        /// </summary>
        public BookReader()
        {
            Initialize();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The page currently open in the book.
        /// </summary>
        public LinkedListNode<Page> CurrentPage { get; private set; }

        // The number of the page currently open in the book.
        public int CurrentPageNumber { get; private set; } = 0;

        /// <summary>
        /// Is it possible to paginate backward?
        /// </summary>
        public bool CanPrevious
            => CurrentPage?.Previous != null;

        /// <summary>
        /// Is it possible to paginate forward?
        /// </summary>
        public bool CanNext
            => CurrentPage?.Next != null;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the linked list of pages.
        /// </summary>
        private void Initialize()
        {
            _pages = new LinkedList<Page>();

            _pages.AddLast(_pageTwo);

            var pageFourNode = _pages.AddLast(_pageFour);

            _pages.AddLast(_pageSix);

            _pages.AddFirst(_pageOne);

            _pages.AddBefore(pageFourNode, _pageThree);

            _pages.AddAfter(pageFourNode, _pageFive);

            CurrentPage = _pages.First;

            CurrentPageNumber = 1;
        }

        /// <summary>
        /// Runs the book reader in the system console.
        /// </summary>
        public void Run()
        {
            // Reader loop except current page is not set properly
            while (CurrentPage != null)
            {
                // Clear console screen
                Clear();

                // Nice formatting/output for the number of the current page
                var pageNumberString = $"- {CurrentPageNumber} - ";

                var leadingSpaceCount =
                    (_consoleWidth - pageNumberString.Length) / 2;

                var paddedPageNumberString =
                    pageNumberString.PadLeft(leadingSpaceCount + pageNumberString.Length);

                WriteLine(paddedPageNumberString);

                WriteLine();

                var currentPageContent = CurrentPage.Value.Content;

                // Page content output line-by-line
                for (var characterIndex = 0; characterIndex < currentPageContent.Length; characterIndex += _consoleWidth)
                {
                    // Determine whether we can chop off a whole line or only
                    // part of it when the remaining content is less than
                    // the console width in characters.
                    var characterCount =
                        Math.Min(_consoleWidth, currentPageContent.Length - characterIndex);

                    var line =
                        currentPageContent.Substring(characterIndex, characterCount);

                    WriteLine(line);
                }

                WriteLine();

                // Copyright notice for quotes
                WriteLine($"Quote from \"C# Data Structures and Algorithms\" by Marcin Jamro,{Environment.NewLine}published by Packt Publishing in 2018.");

                WriteLine();

                // Construct and write something like this to console:
                // < PREVIOUS [P]      |      [Q] QUIT      |      [N] NEXT >

                // The various labels ...
                var previousLabel =
                    CanPrevious
                    ? " < PREVIOUS [P]"
                    : "               ";

                var quitLabel = "[Q] QUIT";

                var nextLabel =
                    CanNext
                    ? "[N] NEXT >"
                    : "          ";

                var separatorLabel = "|";

                // The remaining number of characters left in the console line
                // after subtracting labels and separators.
                var remainder =
                    _consoleWidth
                    - previousLabel.Length
                    - separatorLabel.Length
                    - quitLabel.Length
                    - separatorLabel.Length
                    - nextLabel.Length;

                // There are four gaps to fill evenly between labels and
                // separators.
                var paddingCount = remainder / 4;

                var paddedPreviousLabel =
                    previousLabel.PadRight(paddingCount + previousLabel.Length);

                // Quit label is special because it is padded on both sides.
                var paddedLeftQuitLabel =
                    quitLabel.PadLeft(paddingCount + quitLabel.Length);

                var paddedQuitLabel =
                    paddedLeftQuitLabel.PadRight(paddingCount + paddedLeftQuitLabel.Length);

                var paddedNextLabel =
                    nextLabel.PadLeft(paddingCount + nextLabel.Length);

                // Write the menu line to screen
                WriteLine($"{paddedPreviousLabel}{separatorLabel}{paddedQuitLabel}{separatorLabel}{paddedNextLabel}");

                // User input and parsing
                switch (ReadKey(true).Key)
                {
                    // Previous page
                    case ConsoleKey.P:

                        if (CanPrevious)
                        {
                            CurrentPage = CurrentPage.Previous;
                            --CurrentPageNumber;
                        }

                        break;

                    // Next page
                    case ConsoleKey.N:

                        if (CanNext)
                        {
                            CurrentPage = CurrentPage.Next;
                            ++CurrentPageNumber;
                        }

                        break;

                    // Quit
                    case ConsoleKey.Q:
                        // Will exit the infinite loop
                        return;

                    // Ignore all other keys
                    default:
                        // No operation
                        break;
                }
            }
        }

        #endregion
    }
}
