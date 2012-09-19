﻿//------------------------------------------------------------------------------
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
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

using Rock.REST;

namespace Rock.Com.CCVOnline.REST.Service
{
    /// <summary>
    /// REST WCF service for ServiceRecordings
    /// </summary>
    [Export( typeof( IService ) )]
    [ExportMetadata( "RouteName", "Com/CCVOnline/Service/Recording" )]
    [AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class RecordingService : IRecordingService, IService
    {
        /// <summary>
        /// Gets a Block object
        /// </summary>
        [WebGet( UriTemplate = "{apiKey}?action={action}&campusid={campus}&label={label}&app={app}&stream={stream}&recording={recording}" )]
        public Rock.Com.CCVOnline.Service.RecordingDTO ApiGet( string apiKey, string action, string campus, string label, string app, string stream, string recording )
        {
            Rock.CMS.UserService userService = new Rock.CMS.UserService();
            Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

            if ( user != null )
            {
                int campusId = 0;
                if ( !Int32.TryParse( campus, out campusId ) )
                    campusId = 0;

                Rock.Com.CCVOnline.Service.RecordingService RecordingService = new CCVOnline.Service.RecordingService();
                Rock.Com.CCVOnline.Service.Recording Recording = null;

                try
                {
                    if ( action.Trim().ToLower() == "stop" )
                        Recording = RecordingService.StopRecording( campusId, label, app, stream, recording, user.PersonId );
                    else
                        Recording = RecordingService.StartRecording( campusId, label, app, stream, recording, user.PersonId );

                    if ( Recording != null )
                        return Recording.DataTransferObject;
                    else
                        throw new WebFaultException<string>( string.Format( "Was not able to {0} recording", action ), System.Net.HttpStatusCode.BadRequest );
                }

                catch ( SystemException ex )
                {
                    throw new WebFaultException<string>( "Recording Error Occurred (action = '" + action + "'): " + ex.Message, System.Net.HttpStatusCode.BadRequest );
                }

            }
            else
                throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
        }

    }
}