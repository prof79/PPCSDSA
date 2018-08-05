//----------------------------------------------------------------------------
// <copyright file="DateTimeHelper.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      DateTime utility methods.
// </description>
// <version>v1.0.0 2018-05-26T00:25:26+02</version>
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
    using System.Globalization;

    /// <summary>
    /// DateTime utility methods.
    /// </summary>
    public static class DateTimeHelper
    {
        #region Methods

        /// <summary>
        /// Generate an array of month names according to locale specified.
        /// Defaults to English.
        /// </summary>
        /// <param name="locale">
        /// The locale in ISO format like "en" or "de-DE". Defaults to English.
        /// </param>
        /// <returns>
        /// An array of month names indexed from 0 (January) to 11 (December).
        /// </returns>
        public static string[] GetMonthNames(string locale = "en")
        {
            // Create array for English month names.
            var months = new string[12];

            for (var month = 1; month <= months.Length; ++month)
            {
                // Generate a date for each first day of a month as a
                // means to deduce the month name from it.
                var firstDay = new DateTime(DateTime.Now.Year, month, 1);

                // Using format strings the month name can be obtained.
                var monthName =
                    firstDay.ToString("MMMM", CultureInfo.CreateSpecificCulture(locale));

                // Mind that arrays use zero-based indexing.
                months[month - 1] = monthName;
            }

            return months;
        }

        /// <summary>
        /// Return the number of days in a month as an array.
        /// </summary>
        /// <returns>
        /// An array of day counts indexed from 0 (January) to 11 (December).
        /// </returns>
        public static int[] GetMonthDays()
        {
            // The results will be stored here.
            var dayCounts = new int[12];

            var currentYear = DateTime.Now.Year;

            for (int monthIndex = 0; monthIndex < 12; ++monthIndex)
            {
                dayCounts[monthIndex] =
                    DateTime.DaysInMonth(currentYear, monthIndex + 1);
            }

            return dayCounts;
        }

        #endregion
    }
}
