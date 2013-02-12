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
    /// DataView Service class
    /// </summary>
    public partial class DataViewService : Service<DataView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataViewService"/> class
        /// </summary>
        public DataViewService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataViewService"/> class
        /// </summary>
        public DataViewService(IRepository<DataView> repository) : base(repository)
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
        public bool CanDelete( DataView item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static class DataViewExtensionMethods
    {
        /// <summary>
        /// Clones this DataView object to a new DataView object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static DataView Clone( this DataView source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as DataView;
            }
            else
            {
                var target = new DataView();
                target.IsSystem = source.IsSystem;
                target.Name = source.Name;
                target.Description = source.Description;
                target.CategoryId = source.CategoryId;
                target.EntityTypeId = source.EntityTypeId;
                target.DataViewFilterId = source.DataViewFilterId;
                target.Id = source.Id;
                target.Guid = source.Guid;

            
                return target;
            }
        }
    }
}