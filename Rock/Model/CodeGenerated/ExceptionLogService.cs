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

using System;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// ExceptionLog Service class
    /// </summary>
    public partial class ExceptionLogService : Service<ExceptionLog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionLogService"/> class
        /// </summary>
        public ExceptionLogService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionLogService"/> class
        /// </summary>
        public ExceptionLogService(IRepository<ExceptionLog> repository) : base(repository)
        {
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( ExceptionLog item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static class ExceptionLogExtensionMethods
    {
        /// <summary>
        /// Clones this ExceptionLog object to a new ExceptionLog object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static ExceptionLog Clone( this ExceptionLog source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as ExceptionLog;
            }
            else
            {
                var target = new ExceptionLog();
                target.ParentId = source.ParentId;
                target.SiteId = source.SiteId;
                target.PageId = source.PageId;
                target.ExceptionDate = source.ExceptionDate;
                target.CreatedByPersonId = source.CreatedByPersonId;
                target.HasInnerException = source.HasInnerException;
                target.StatusCode = source.StatusCode;
                target.ExceptionType = source.ExceptionType;
                target.Description = source.Description;
                target.Source = source.Source;
                target.StackTrace = source.StackTrace;
                target.PageUrl = source.PageUrl;
                target.ServerVariables = source.ServerVariables;
                target.QueryString = source.QueryString;
                target.Form = source.Form;
                target.Cookies = source.Cookies;
                target.Id = source.Id;
                target.Guid = source.Guid;

            
                return target;
            }
        }
    }
}
