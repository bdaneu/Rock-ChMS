﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Web.UI;


namespace Rock.Web.Cache
{
    /// <summary>
    /// Information about an metric that is required by the rendering engine.
    /// This information will be cached by Rock. 
    /// 
    /// NOTE: Because this metric object is cached and shared by all entities 
    /// using the metric, a particlar instance's values are not included as a 
    /// property of this metric object.
    /// </summary>
    [Serializable]
    public class MetricCache : Rock.Core.MetricDto
    {
		private MetricCache() : base() { }
		private MetricCache( Rock.Core.Metric model ) : base( model ) { }

        #region Static Methods

        private static string CacheKey( int id )
        {
            return string.Format( "Rock:Metric:{0}", id );
        }

        /// <summary>
        /// Adds Metric model to cache, and returns cached object
        /// </summary>
        /// <param name="metricModel">The metricModel to cache</param>
        /// <returns></returns>
        public static MetricCache Read( Rock.Core.Metric metricModel )
        {
            string cacheKey = MetricCache.CacheKey( metricModel.Id );

            ObjectCache cache = MemoryCache.Default;
            MetricCache metric = cache[cacheKey] as MetricCache;

			if ( metric != null )
				return metric;
			else
			{
				metric = MetricCache.CopyModel( metricModel );
				cache.Set( cacheKey, metric, new CacheItemPolicy() );

				return metric;
			}
        }

        /// <summary>
        /// Returns Metric object from cache.  If metric does not already exist in cache, it
        /// will be read and added to cache
        /// </summary>
        /// <param name="id">The id of the Metric to read</param>
        /// <returns></returns>
        public static MetricCache Read( int id )
        {
            string cacheKey = MetricCache.CacheKey( id );

            ObjectCache cache = MemoryCache.Default;
            MetricCache metric = cache[cacheKey] as MetricCache;

            if ( metric != null )
                return metric;
            else
            {
                Rock.Core.MetricService metricService = new Rock.Core.MetricService();
                Rock.Core.Metric metricModel = metricService.Get( id );
                if ( metricModel != null )
                {
                    metric = MetricCache.CopyModel( metricModel );

                    cache.Set( cacheKey, metric, new CacheItemPolicy() );

                    return metric;
                }
                else
                    return null;

            }
        }

        /// <summary>
        /// Copies the properties of a <see cref="Rock.Core.Metric"/> object to a <see cref="MetricCache"/> object/>
        /// </summary>
        /// <param name="metricModel">The metric model.</param>
        /// <returns></returns>
        public static MetricCache CopyModel( Rock.Core.Metric metricModel )
        {
			MetricCache metric = new MetricCache( metricModel );
            return metric;
        }

        /// <summary>
        /// Removes metric from cache
        /// </summary>
        /// <param name="id">The id of the metric to remove from cache</param>
        public static void Flush( int id )
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove( MetricCache.CacheKey( id ) );
        }

        #endregion
    }
}