//----------------------------------------------------------------------------
// <copyright file="ICallCenter.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Methods a call center abstraction has to implement.
// </description>
// <version>v1.0.0 2018-06-09T01:07:31+02</version>
//
// This code is inspired by examples and exercises from the book
// "C# Data Structures and Algorithms" (C) 2018 by Marcin Jamro,
// Packt Publishing.
// https://www.packtpub.com/application-development/c-data-structures-and-algorithms-0
//
//----------------------------------------------------------------------------

namespace DataStructuresAndAlgos.Queues
{
    using System.Collections.Generic;

    /// <summary>
    /// Methods a call center abstraction has to implement.
    /// </summary>
    public interface ICallCenter
    {
        #region Methods

        int Call(int clientId, bool isPriority = false);

        IncomingCall Answer(string consultant);

        void End(IncomingCall call);

        #endregion

        #region Properties

        IEnumerable<IncomingCall> Calls { get; }

        bool AreCallsWaiting { get; }

        #endregion
    }
}
