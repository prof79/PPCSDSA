//----------------------------------------------------------------------------
// <copyright file="Employee.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Abstraction of a company employee.
// </description>
// <version>v1.0.0 2018-06-10T03:11:47+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.BasicTrees
{
    /// <summary>
    /// Abstraction of a company employee.
    /// </summary>
    public class Employee
    {
        #region Fields

        #endregion

        #region Constructors

        public Employee()
        {

        }

        public Employee(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        #endregion

        #region Overridden Methods

        public override string ToString()
            => $"{Name}, {Role}";

        #endregion
    }
}
