
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
using System.ComponentModel;
using System.ComponentModel.Composition;

using Rock.Model;

namespace Rock.DataFilters.WorkflowType
{
    /// <summary>
    /// WorkflowType Logging Level Filter
    /// </summary>
    [Description("Filter Workflow Types on Logging Level")]
    [Export( typeof( DataFilterComponent ) )]
    [ExportMetadata( "ComponentName", "WorkflowType Logging Level Filter" )]
    public partial class LoggingLevelFilter : EnumPropertyFilter<WorkflowLoggingLevel>
    {

        /// <summary>
        /// Gets the name of the filtered entity type.
        /// </summary>
        /// <value>
        /// The name of the filtered entity type.
        /// </value>
        public override string FilteredEntityTypeName
        {
            get { return "Rock.Model.WorkflowType"; }
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public override string PropertyName
        {
            get { return "LoggingLevel"; }
        }
         
    }
}