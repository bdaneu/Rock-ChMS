﻿using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace Rock.Cms.Cached
{
    /// <summary>
    /// Information about a block that is required by the rendering engine.
    /// This information will be cached by the engine
    /// </summary>
    public class Block
    {
        /// <summary>
        /// Use Static Read() method to instantiate a new Block object
        /// </summary>
        private Block() { }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the path to the block control
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Gets the name of block
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Rock.Attribute.PropertyAttribute"/> attributes have been 
        /// verified for the block.  If not, Rock will create and/or update the attributes associated with the block.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if attributes have already been verified; otherwise, <c>false</c>.
        /// </value>
        public bool InstancePropertiesVerified { get; internal set; }

        private List<int> AttributeIds = new List<int>();
        /// <summary>
        /// List of attributes associated with the block.  This object will not include values.
        /// To get values associated with the current block instance, use the AttributeValues
        /// </summary>
        public List<Rock.Cms.Cached.Attribute> Attributes
        {
            get
            {
                List<Rock.Cms.Cached.Attribute> attributes = new List<Rock.Cms.Cached.Attribute>();

                foreach ( int id in AttributeIds )
                    attributes.Add( Attribute.Read( id ) );

                return attributes;
            }
        }

        /// <summary>
        /// Gets the attribute values.
        /// </summary>
        public Dictionary<string, KeyValuePair<string, string>> AttributeValues { get; private set; }

        /// <summary>
        /// Saves the attribute values.
        /// </summary>
        /// <param name="personId">The person id.</param>
        public void SaveAttributeValues(int? personId)
        {
            Rock.Services.Cms.BlockService blockService = new Services.Cms.BlockService();
            Rock.Models.Cms.Block blockModel = blockService.Get( this.Id );

            if ( blockModel != null )
            {
                Rock.Attribute.Helper.LoadAttributes( blockModel );
                foreach ( Rock.Cms.Cached.Attribute attribute in blockModel.Attributes )
                    Rock.Attribute.Helper.SaveAttributeValue( blockModel, attribute, this.AttributeValues[attribute.Key].Value, personId );
            }
        }

        #region Static Methods

        private static string CacheKey( int id )
        {
            return string.Format( "Rock:Block:{0}", id );
        }

        /// <summary>
        /// Returns Block object from cache.  If block does not already exist in cache, it
        /// will be read and added to cache
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static Block Read( int id )
        {
            string cacheKey = Block.CacheKey( id );

            ObjectCache cache = MemoryCache.Default;
            Block block = cache[cacheKey] as Block;

            if ( block != null )
                return block;
            else
            {
                Rock.Services.Cms.BlockService blockService = new Services.Cms.BlockService();
                Rock.Models.Cms.Block blockModel = blockService.Get( id );
                if ( blockModel != null )
                {
                    block = new Block();
                    block.Id = blockModel.Id;
                    block.Path = blockModel.Path;
                    block.Name = blockModel.Name;
                    block.Description = blockModel.Description;
                    block.InstancePropertiesVerified = false;

                    Rock.Attribute.Helper.LoadAttributes( blockModel );

                    block.AttributeValues = blockModel.AttributeValues;

                    if (blockModel.Attributes != null)
                        foreach ( Rock.Cms.Cached.Attribute attribute in blockModel.Attributes )
                            block.AttributeIds.Add( attribute.Id );

                    // Block cache expiration monitors the actual block on the file system so that it is flushed from 
                    // memory anytime the file contents change.  This is to force the cmsPage object to revalidate any
                    // BlockInstancePropery attributes that may have been added or modified
                    string physicalPath = System.Web.HttpContext.Current.Request.MapPath( block.Path );
                    List<string> filePaths = new List<string>();
                    filePaths.Add( physicalPath );
                    filePaths.Add( physicalPath + ".cs" );

                    CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                    cacheItemPolicy.ChangeMonitors.Add( new HostFileChangeMonitor( filePaths ) );
                    cache.Set( cacheKey, block, cacheItemPolicy );

                    return block;
                }
                else
                    return null;

            }
        }

        /// <summary>
        /// Removes block from cache
        /// </summary>
        /// <param name="guid"></param>
        public static void Flush( int id )
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove( Block.CacheKey( id ) );
        }

        #endregion
    }
}