//----------------------------------------------------------------------------
// <copyright file="Person.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A simple class representing a person.
// </description>
// <version>v1.0.0 2018-06-03T00:21:46+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.Util
{
    /// <summary>
    /// A simple POCO class representing a person.
    /// </summary>
    public class Person
    {
        #region Properties

        public string Name { get; set; }

        public uint Age { get; set; }

        public CountryCode Country { get; set; }

        #endregion

        #region Overridden Methods

        public override string ToString()
            => $"{Name} ({Age} years) from {Country}.";

        #endregion
    }
}
