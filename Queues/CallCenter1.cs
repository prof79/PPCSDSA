//----------------------------------------------------------------------------
// <copyright file="CallCenter1.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      Call center abstraction version 1 & 2.
// </description>
// <version>v1.0.0 2018-06-09T01:24:38+02</version>
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
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Call center abstraction version 1 & 2.
    /// </summary>
    public class CallCenter1 : ICallCenter
    {
        #region Fields

        private int _counter = 0;

        #endregion

        #region ICallCenter

        public IEnumerable<IncomingCall> Calls { get; }
            = new ConcurrentQueue<IncomingCall>();

        public bool AreCallsWaiting
            => Calls?.Count() > 0;

        public IncomingCall Answer(string consultant)
        {
            if (Calls?.Count() > 0)
            {
                if ((Calls as ConcurrentQueue<IncomingCall>).TryDequeue(out var call))
                {
                    call.Consultant = consultant;
                    call.StartTime = DateTime.Now;

                    return call;
                }
            }

            return null;
        }

        public int Call(int clientId, bool isPriority = false)
        {
            var call = new IncomingCall
            {
                Id = ++_counter,
                ClientId = clientId,
                CallTime = DateTime.Now,
            };

            (Calls as ConcurrentQueue<IncomingCall>).Enqueue(call);

            return Calls.Count();
        }

        public void End(IncomingCall call)
            => call.EndTime = DateTime.Now;

        #endregion
    }
}
