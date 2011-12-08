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

namespace Rock.REST.Groups
{
	/// <summary>
	/// Represents a REST WCF service for Groups
	/// </summary>
	[ServiceContract]
    public partial interface IGroupService
    {
		/// <summary>
		/// Gets a Group object
		/// </summary>
		[OperationContract]
        Rock.Groups.DTO.Group Get( string id );

		/// <summary>
		/// Gets a Group object
		/// </summary>
		[OperationContract]
        Rock.Groups.DTO.Group ApiGet( string id, string apiKey );

		/// <summary>
		/// Updates a Group object
		/// </summary>
        [OperationContract]
        void UpdateGroup( string id, Rock.Groups.DTO.Group Group );

		/// <summary>
		/// Updates a Group object
		/// </summary>
        [OperationContract]
        void ApiUpdateGroup( string id, string apiKey, Rock.Groups.DTO.Group Group );

		/// <summary>
		/// Creates a new Group object
		/// </summary>
        [OperationContract]
        void CreateGroup( Rock.Groups.DTO.Group Group );

		/// <summary>
		/// Creates a new Group object
		/// </summary>
        [OperationContract]
        void ApiCreateGroup( string apiKey, Rock.Groups.DTO.Group Group );

		/// <summary>
		/// Deletes a Group object
		/// </summary>
        [OperationContract]
        void DeleteGroup( string id );

		/// <summary>
		/// Deletes a Group object
		/// </summary>
        [OperationContract]
        void ApiDeleteGroup( string id, string apiKey );
    }
}
