//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using Rock.Crm;

namespace Rock.Rest.Crm
{
	/// <summary>
	/// Locations REST API
	/// </summary>
	public partial class LocationsController : Rock.Rest.ApiController<Rock.Crm.Location, Rock.Crm.LocationDto>
	{
		public LocationsController() : base( new Rock.Crm.LocationService() ) { } 
	}
}