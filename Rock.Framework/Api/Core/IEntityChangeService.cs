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
using System.ServiceModel;

namespace Rock.Api.Core
{
	[ServiceContract]
    public partial interface IEntityChangeService
    {
		[OperationContract]
        Rock.Models.Core.EntityChange Get( string id );

        [OperationContract]
        void UpdateEntityChange( string id, Rock.Models.Core.EntityChange EntityChange );

        [OperationContract]
        void CreateEntityChange( Rock.Models.Core.EntityChange EntityChange );

        [OperationContract]
        void DeleteEntityChange( string id );
    }
}
