//----------------------------------------------------------------------------
// <copyright file="IncomingCall.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Abstraction of a helpline/support call.
// </description>
// <version>v1.0.0 2018-06-09T01:07:13+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.Queues
{
    using System;

    /// <summary>
    /// Abstraction of a helpline/support call.
    /// </summary>
    public class IncomingCall
    {
        #region Properties

        /// <summary>
        /// The internal ID of the call.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ID of the client making the call.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// The time when the call to support was made.
        /// </summary>
        public DateTime CallTime { get; set; }

        /// <summary>
        /// The time a consultant answered and started
        /// processing of the incident.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The time at which a consultant could resolve
        /// the incident and end the call.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// The name of the consultant handling the incident.
        /// </summary>
        public string Consultant { get; set; }

        /// <summary>
        /// Shows whether it is a priority call or not.
        /// </summary>
        public bool IsPriority { get; set; }

        #endregion
    }
}
