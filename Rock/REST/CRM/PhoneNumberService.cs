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
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Rock.REST.CRM
{
	/// <summary>
	/// REST WCF service for PhoneNumbers
	/// </summary>
    [Export(typeof(IService))]
    [ExportMetadata("RouteName", "CRM/PhoneNumber")]
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class PhoneNumberService : IPhoneNumberService, IService
    {
		/// <summary>
		/// Gets a PhoneNumber object
		/// </summary>
		[WebGet( UriTemplate = "{id}" )]
        public Rock.CRM.DTO.PhoneNumber Get( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CRM.PhoneNumberService PhoneNumberService = new Rock.CRM.PhoneNumberService();
				Rock.CRM.PhoneNumber PhoneNumber = PhoneNumberService.Get( int.Parse( id ) );
				if ( PhoneNumber.Authorized( "View", currentUser ) )
					return PhoneNumber.DataTransferObject;
				else
					throw new WebFaultException<string>( "Not Authorized to View this PhoneNumber", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Gets a PhoneNumber object
		/// </summary>
		[WebGet( UriTemplate = "{id}/{apiKey}" )]
        public Rock.CRM.DTO.PhoneNumber ApiGet( string id, string apiKey )
        {
            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CRM.PhoneNumberService PhoneNumberService = new Rock.CRM.PhoneNumberService();
					Rock.CRM.PhoneNumber PhoneNumber = PhoneNumberService.Get( int.Parse( id ) );
					if ( PhoneNumber.Authorized( "View", user.Username ) )
						return PhoneNumber.DataTransferObject;
					else
						throw new WebFaultException<string>( "Not Authorized to View this PhoneNumber", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Updates a PhoneNumber object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdatePhoneNumber( string id, Rock.CRM.DTO.PhoneNumber PhoneNumber )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CRM.PhoneNumberService PhoneNumberService = new Rock.CRM.PhoneNumberService();
				Rock.CRM.PhoneNumber existingPhoneNumber = PhoneNumberService.Get( int.Parse( id ) );
				if ( existingPhoneNumber.Authorized( "Edit", currentUser ) )
				{
					uow.objectContext.Entry(existingPhoneNumber).CurrentValues.SetValues(PhoneNumber);
					PhoneNumberService.Save( existingPhoneNumber, currentUser.PersonId() );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this PhoneNumber", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Updates a PhoneNumber object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}/{apiKey}" )]
        public void ApiUpdatePhoneNumber( string id, string apiKey, Rock.CRM.DTO.PhoneNumber PhoneNumber )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CRM.PhoneNumberService PhoneNumberService = new Rock.CRM.PhoneNumberService();
					Rock.CRM.PhoneNumber existingPhoneNumber = PhoneNumberService.Get( int.Parse( id ) );
					if ( existingPhoneNumber.Authorized( "Edit", user.Username ) )
					{
						uow.objectContext.Entry(existingPhoneNumber).CurrentValues.SetValues(PhoneNumber);
						PhoneNumberService.Save( existingPhoneNumber, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this PhoneNumber", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Creates a new PhoneNumber object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreatePhoneNumber( Rock.CRM.DTO.PhoneNumber PhoneNumber )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CRM.PhoneNumberService PhoneNumberService = new Rock.CRM.PhoneNumberService();
				Rock.CRM.PhoneNumber existingPhoneNumber = new Rock.CRM.PhoneNumber();
				PhoneNumberService.Add( existingPhoneNumber, currentUser.PersonId() );
				uow.objectContext.Entry(existingPhoneNumber).CurrentValues.SetValues(PhoneNumber);
				PhoneNumberService.Save( existingPhoneNumber, currentUser.PersonId() );
            }
        }

		/// <summary>
		/// Creates a new PhoneNumber object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "{apiKey}" )]
        public void ApiCreatePhoneNumber( string apiKey, Rock.CRM.DTO.PhoneNumber PhoneNumber )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CRM.PhoneNumberService PhoneNumberService = new Rock.CRM.PhoneNumberService();
					Rock.CRM.PhoneNumber existingPhoneNumber = new Rock.CRM.PhoneNumber();
					PhoneNumberService.Add( existingPhoneNumber, user.PersonId );
					uow.objectContext.Entry(existingPhoneNumber).CurrentValues.SetValues(PhoneNumber);
					PhoneNumberService.Save( existingPhoneNumber, user.PersonId );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a PhoneNumber object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeletePhoneNumber( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CRM.PhoneNumberService PhoneNumberService = new Rock.CRM.PhoneNumberService();
				Rock.CRM.PhoneNumber PhoneNumber = PhoneNumberService.Get( int.Parse( id ) );
				if ( PhoneNumber.Authorized( "Edit", currentUser ) )
				{
					PhoneNumberService.Delete( PhoneNumber, currentUser.PersonId() );
					PhoneNumberService.Save( PhoneNumber, currentUser.PersonId() );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this PhoneNumber", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a PhoneNumber object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}/{apiKey}" )]
        public void ApiDeletePhoneNumber( string id, string apiKey )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CRM.PhoneNumberService PhoneNumberService = new Rock.CRM.PhoneNumberService();
					Rock.CRM.PhoneNumber PhoneNumber = PhoneNumberService.Get( int.Parse( id ) );
					if ( PhoneNumber.Authorized( "Edit", user.Username ) )
					{
						PhoneNumberService.Delete( PhoneNumber, user.PersonId );
						PhoneNumberService.Save( PhoneNumber, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this PhoneNumber", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

    }
}
