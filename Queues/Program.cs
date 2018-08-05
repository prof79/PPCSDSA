//----------------------------------------------------------------------------
// <copyright file="Program.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      The main program class for the "Queues" console demos.
// </description>
// <version>v1.0.0 2018-06-09T03:51:00+02</version>
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
    using System.Threading;
    using System.Threading.Tasks;

    using Util;

    using static System.Console;

    /// <summary>
    /// The main program class for the "Queues" console demos.
    /// </summary>
    internal static class Program
    {
        #region Fields

        private static readonly Random _random = new Random();

        #endregion

        /// <summary>
        /// The main method of the program.
        /// </summary>
        /// <param name="args">
        /// The program arguments supplied on the command-line.
        /// </param>
        private static void Main(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            WriteLine();
            WriteLine("*** QUEUE DEMOS ***");
            WriteLine();

            // Call center version 1 queue demo.
            CallCenter1Demo();

            WriteLine();

            // Call center version 2 queue demo.
            CallCenter2Demo();

            WriteLine();

            // Call center version 3 queue demo.
            CallCenter3Demo();

            WriteLine();
        }

        /// <summary>
        /// Call center version 1 demo.
        /// </summary>
        private static void CallCenter1Demo()
        {
            WriteLine("CALL CENTER 1");
            WriteLine();

            ICallCenter callCenter = new CallCenter1();

            callCenter.Call(1234);
            callCenter.Call(5678);
            callCenter.Call(1468);
            callCenter.Call(9641);

            while (callCenter.AreCallsWaiting)
            {
                var call = callCenter.Answer("Marcin");

                $"Call #{call.Id} from client {call.ClientId} is answered by consultant {call.Consultant}.".Log();

                Thread.Sleep(_random.Next(1000, 10000));

                callCenter.End(call);

                $"Call #{call.Id} from {call.ClientId} is ended by {call.Consultant}.".Log();
            }

            WriteLine();
        }

        /// <summary>
        /// Call center version 2 (concurrent) demo.
        /// </summary>
        private static void CallCenter2Demo()
        {
            WriteLine("CALL CENTER 2");
            WriteLine();
            WriteLine("(Press any key to cancel)");
            WriteLine();

            ICallCenter callCenter = new CallCenter1();

            using (var cts = new CancellationTokenSource())
            {
                Parallel.Invoke(
                    new ParallelOptions { CancellationToken = cts.Token },
                    () => CallerAction(callCenter, cts.Token),
                    () => ConsultantAction(callCenter, "Marcin", ConsoleColor.Red, cts.Token),
                    () => ConsultantAction(callCenter, "James", ConsoleColor.Yellow, cts.Token),
                    () => ConsultantAction(callCenter, "Olivia", ConsoleColor.Green, cts.Token),
                    () => { ReadKey(true); ConsoleColor.Cyan.UseFore(() => WriteLine("Canceling ...")); cts.Cancel(); }
                );

                Thread.Sleep(500);
            }

            WriteLine();
        }

        /// <summary>
        /// Helper method for <see cref="CallCenter2Demo"/>.
        /// </summary>
        private static void CallerAction(ICallCenter callCenter, CancellationToken ct = default(CancellationToken))
        {
            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    return;
                }

                var clientId = _random.Next(1, 10000);

                var waitingCount = callCenter.Call(clientId);

                $"Incoming call from #{clientId}, waiting in the queue: {waitingCount}".Log();

                Thread.Sleep(_random.Next(1000, 5000));
            }
        }

        /// <summary>
        /// Helper method for <see cref="CallCenter2Demo"/>.
        /// </summary>
        private static void ConsultantAction(ICallCenter callCenter, string consultantName, ConsoleColor foregroundColor, CancellationToken ct = default(CancellationToken))
        {
            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    return;
                }

                var call = callCenter.Answer(consultantName);

                if (call != null)
                {
                    foregroundColor.UseFore(() =>
                        $"Call #{call.Id} from {call.ClientId} is answered by {call.Consultant}.".Log()
                    );

                    Thread.Sleep(_random.Next(1000, 10000));

                    callCenter.End(call);

                    foregroundColor.UseFore(() =>
                        $"Call #{call.Id} from {call.ClientId} is ended by {call.Consultant}.".Log()
                    );

                    Thread.Sleep(_random.Next(500, 1000));
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        /// <summary>
        /// Call center version 3 (priority) demo.
        /// </summary>
        private static void CallCenter3Demo()
        {
            WriteLine("CALL CENTER 3");
            WriteLine();

            ICallCenter callCenter = new CallCenter3();

            callCenter.Call(1234);
            callCenter.Call(5678, true);
            callCenter.Call(1468);
            callCenter.Call(9641, true);

            while (callCenter.AreCallsWaiting)
            {
                var call = callCenter.Answer("Marcin");

                $"Call #{call.Id} from {call.ClientId} is answered by {call.Consultant}. Mode: {(call.IsPriority ? "priority" : "normal")}".Log();

                Thread.Sleep(_random.Next(1000, 10000));

                callCenter.End(call);

                $"Call #{call.Id} from {call.ClientId} is ended by {call.Consultant}.".Log();
            }

            WriteLine();
        }
    }
}
