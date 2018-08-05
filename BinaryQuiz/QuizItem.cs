//----------------------------------------------------------------------------
// <copyright file="QuizItem.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A simple quiz item model.
// </description>
// <version>v1.0.0 2018-08-01T00:42:00+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.BinaryQuiz
{
    /// <summary>
    /// A simple quiz item model.
    /// </summary>
    public class QuizItem
    {
        #region Constructors

        public QuizItem()
        {
        }

        public QuizItem(string text)
            => Text = text;

        #endregion

        #region Properties

        public string Text { get; set; }

        #endregion
    }
}
