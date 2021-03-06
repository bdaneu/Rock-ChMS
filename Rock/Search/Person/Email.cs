﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;

using Rock.Model;

namespace Rock.Search.Person
{
    /// <summary>
    /// Searches for people who's email matches selected term
    /// </summary>
    [Description( "Person Email Search" )]
    [Export(typeof(SearchComponent))]
    [ExportMetadata("ComponentName", "Person Email")]
    public class Email : SearchComponent
    {

        /// <summary>
        /// Gets the attribute value defaults.
        /// </summary>
        /// <value>
        /// The attribute defaults.
        /// </value>
        public override Dictionary<string, string> AttributeValueDefaults
        {
            get
            {
                var defaults = new Dictionary<string, string>();
                defaults.Add( "SearchLabel", "Email" );
                return defaults;
            }
        }

        /// <summary>
        /// Returns a list of matching people
        /// </summary>
        /// <param name="searchterm"></param>
        /// <returns></returns>
        public override IQueryable<string> Search( string searchterm )
        {
            var personService = new PersonService();

            return personService.Queryable().
                Where( p => p.Email.Contains( searchterm ) ).
                OrderBy( p => p.Email ).
                Select( p => p.Email ).Distinct();
        }
    }
}