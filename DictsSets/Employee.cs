//----------------------------------------------------------------------------
// <copyright file="Employee.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A simple representation of an employee.
// </description>
// <version>v1.0.0 2018-06-10T01:03:20+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.DictsSets
{
    /// <summary>
    /// A simple representation of an employee.
    /// </summary>
    public class Employee
    {
        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        #endregion
    }
}
