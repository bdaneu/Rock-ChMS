﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rock.Controls
{
    /// <summary>
    /// Event argument used by the <see cref="Grid"/> events
    /// </summary>
    public class RowEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the index of the row that fired the event
        /// </summary>
        /// <value>
        /// The index of the row.
        /// </value>
        public int RowIndex { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RowEventArgs"/> class.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        public RowEventArgs( int rowIndex )
        {
            RowIndex = rowIndex;
        }
    }
}