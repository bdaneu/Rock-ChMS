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

using Rock.Data;

namespace Rock.CMS
{
	/// <summary>
	/// Block Instance POCO Repository class
	/// </summary>
    public partial class BlockInstanceRepository : Repository<Rock.CMS.BlockInstance>
    {
		/// <summary>
		/// Gets Block Instances by Block Id
		/// </summary>
		/// <param name="blockId">Block Id.</param>
		/// <returns>An enumerable list of BlockInstance objects.</returns>
	    public IEnumerable<Rock.CMS.BlockInstance> GetByBlockId( int blockId )
        {
            return Find( t => t.BlockId == blockId ).OrderBy( t => t.Order );
        }
		
		/// <summary>
		/// Gets Block Instances by Layout
		/// </summary>
		/// <param name="layout">Layout.</param>
		/// <returns>An enumerable list of BlockInstance objects.</returns>
	    public IEnumerable<Rock.CMS.BlockInstance> GetByLayout( string layout )
        {
            return Find( t => ( t.Layout == layout || ( layout == null && t.Layout == null ) ) ).OrderBy( t => t.Order );
        }
		
		/// <summary>
		/// Gets Block Instances by Layout And Page Id And Zone
		/// </summary>
		/// <param name="layout">Layout.</param>
		/// <param name="pageId">Page Id.</param>
		/// <param name="zone">Zone.</param>
		/// <returns>An enumerable list of BlockInstance objects.</returns>
	    public IEnumerable<Rock.CMS.BlockInstance> GetByLayoutAndPageIdAndZone( string layout, int? pageId, string zone )
        {
            return Find( t => ( t.Layout == layout || ( layout == null && t.Layout == null ) ) && ( t.PageId == pageId || ( pageId == null && t.PageId == null ) ) && t.Zone == zone ).OrderBy( t => t.Order );
        }
		
		/// <summary>
		/// Gets Block Instances by Page Id
		/// </summary>
		/// <param name="pageId">Page Id.</param>
		/// <returns>An enumerable list of BlockInstance objects.</returns>
	    public IEnumerable<Rock.CMS.BlockInstance> GetByPageId( int? pageId )
        {
            return Find( t => ( t.PageId == pageId || ( pageId == null && t.PageId == null ) ) ).OrderBy( t => t.Order );
        }

        /// <summary>
        /// Moves the specified block instance to another zone.
        /// </summary>
        /// <param name="blockInstance">The block instance.</param>
        /// <returns></returns>
        public int Move( Rock.CMS.BlockInstance blockInstance )
        {
            Rock.CMS.BlockInstance existingBlockInstance = Get( blockInstance.Id );

            int? order = AsQueryable().
                            Where( b => b.Layout == blockInstance.Layout &&
                                b.PageId == blockInstance.PageId &&
                                b.Zone == blockInstance.Zone ).
                            Select( b => ( int? )b.Order ).Max();

            blockInstance.Order = order.HasValue ? order.Value + 1 : 0;

            return blockInstance.Order;
        }
    }
}