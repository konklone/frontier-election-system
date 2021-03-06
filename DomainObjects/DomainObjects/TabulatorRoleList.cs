// -----------------------------------------------------------------------------
// <copyright file="TabulatorRoleList.cs" company="Sequoia Voting Systems"> 
//     Copyright (c) 2009 Sequoia Voting Systems, Inc. All Rights Reserved.
//     Distribution of source code is allowable only under the terms of the
//     license agreement found at http://www.sequoiavote.com/license.html
// </copyright>
// <summary>
//     This file contains the TabulatorRoleList class.
// </summary>
// <revision revisor="dev13" date="4/17/2009" version="1.0.11.07">
//     File Created
// </revision>  
// -----------------------------------------------------------------------------

namespace Sequoia.DomainObjects
{
    #region Using directives

    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using Sequoia.DomainObjects.Persistence;

    #endregion

    /// <summary>
    ///     TabulatorRoleList is a <see cref="List{T}" /> of <see cref="TabulatorRole" /> objects. 
    /// </summary>
    /// <externalUnit cref="TabulatorRole"/>
    /// <revision revisor="dev13" date="4/17/2009" version="1.0.0.0">
    ///     Class created.
    /// </revision>
    [Serializable]
    [XmlRoot("TabulatorRoles")]
    public class TabulatorRoleList : DomainObjectList<TabulatorRole>
    {
        #region Fields

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TabulatorRoleList"/> class.
        /// </summary>
        /// <externalUnit/>
        /// <revision revisor="dev13" date="4/17/2009" version="1.0.11.07">
        ///     Member Created
        /// </revision> 
        public TabulatorRoleList()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TabulatorRoleList"/> class.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        /// <externalUnit cref="List{T}(int)"/>
        /// <revision revisor="dev13" date="4/17/2009" version="1.0.11.07">
        ///     Member Created
        /// </revision>
        public TabulatorRoleList(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TabulatorRoleList"/> class.
        /// </summary>
        /// <param name="tabulatorRoles">The tabulator roles.</param>
        /// <externalUnit cref="TabulatorRole"/>
        /// <externalUnit cref="List{T}(IEnumerable{T})"/>
        /// <externalUnit cref="IEnumerable{T}"/>
        /// <revision revisor="dev13" date="4/17/2009" version="1.0.0.0">
        ///     Member Created
        /// </revision>
        public TabulatorRoleList(IEnumerable<TabulatorRole> tabulatorRoles)
            : base(tabulatorRoles)
        {
        }

        #endregion

        #region Public Properties

        #endregion

        #region Public Methods

        #endregion

        #region Public Events

        #endregion

        #region Private Methods

        #endregion
    }
}
