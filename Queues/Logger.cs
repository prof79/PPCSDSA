//----------------------------------------------------------------------------
// <copyright file="Logger.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A simple console text logger.
// </description>
// <version>v1.0.0 2018-06-09T01:20:18+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.Util
{
    using System;

    /// <summary>
    /// A simple console text logger.
    /// </summary>
    public static class Logger
    {
        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Properties

        #endregion

        #region (Extension) Methods

        /// <summary>
        /// Log some text to the console using a time-stamp.
        /// </summary>
        /// <param name="message">
        /// The message text to log.
        /// </param>
        public static void Log(this string message)
            => Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {message}");

        #endregion

        #region Event Handlers

        #endregion
    }
}
