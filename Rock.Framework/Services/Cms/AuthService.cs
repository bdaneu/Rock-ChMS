//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rock.Models.Cms;
using Rock.Repository.Cms;

namespace Rock.Services.Cms
{
    public partial class AuthService : Rock.Services.Service<Rock.Models.Cms.Auth>
    {
        public IEnumerable<Rock.Models.Cms.Auth> GetByEntityTypeAndEntityId( string entityType, int? entityId )
        {
            return Repository.Find( t => t.EntityType == entityType && ( t.EntityId == entityId || ( entityId == null && t.EntityId == null ) ) ).OrderBy( t => t.Order );
        }
		
        public IEnumerable<Rock.Models.Cms.Auth> GetByGuid( Guid guid )
        {
            return Repository.Find( t => t.Guid == guid ).OrderBy( t => t.Order );
        }
		
    }
}
