//----------------------------------------------------------------------------
// <copyright file="IDataNode.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A simple generic interface for data of any kind.
// </description>
// <version>v0.9.0 2018-07-31T21:43:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    /// <summary>
    /// A simple generic interface for data of any kind.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data being stored.
    /// </typeparam>
    public interface IDataNode<T>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the arbitrary data.
        /// </summary>
        T Data { get; set; }

        #endregion
    }
}
