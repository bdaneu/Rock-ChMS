﻿using System;
using System.Data.Objects;
using System.Data.Entity;
using System.Threading;

using Rock.Models;
using Rock.EntityFramework;

namespace Rock.Helpers
{
    /// <summary>
    /// Class used when services need to share the same DbContext
    /// </summary>
    public class UnitOfWorkScope : IDisposable
    {
        [ThreadStatic]
        private static UnitOfWorkScope currentScope;
        private bool isDisposed;

        /// <summary>
        /// The object context
        /// </summary>
        public readonly DbContext objectContext;

        /// <summary>
        /// Gets or sets a value indicating whether all changes should be saved when scope ends.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if changes should be saved; otherwise, <c>false</c>.
        /// </value>
        public bool SaveAllChangesAtScopeEnd { get; set; }

        /// <summary>
        /// Gets the current object context.
        /// </summary>
        internal static DbContext CurrentObjectContext
        {
            get { return currentScope != null ? currentScope.objectContext : null; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkScope"/> class.
        /// </summary>
        public UnitOfWorkScope() : this( false ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkScope"/> class.
        /// </summary>
        /// <param name="saveAllChangesAtScopeEnd">if set to <c>true</c> changes should be saved at scope end.</param>
        public UnitOfWorkScope( bool saveAllChangesAtScopeEnd )
        {
            if ( currentScope != null && !currentScope.isDisposed )
                throw new InvalidOperationException( "ObjectContextScope instances can not be nested" );

            SaveAllChangesAtScopeEnd = saveAllChangesAtScopeEnd;
            objectContext = new Rock.EntityFramework.RockContext();
            isDisposed = false;
            //Thread.BeginThreadAffinity();  --Not supported with Medium Trust
            currentScope = this;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if ( !isDisposed )
            {
                currentScope = null;
                //Thread.EndThreadAffinity();  -- Not supported with Medium Trust

                if ( SaveAllChangesAtScopeEnd )
                {
                    objectContext.SaveChanges();
                }

                objectContext.Dispose();
                isDisposed = true;
            }
        }
    }
}
