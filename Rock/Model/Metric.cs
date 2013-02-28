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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Metric POCO Entity.
    /// </summary>
    [Table( "Metric" )]
    [DataContract( IsReference = true )]
    public partial class Metric : Model<Metric>, IOrdered
    {
        /// <summary>
        /// Gets or sets the System.
        /// </summary>
        /// <value>
        /// System.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public bool IsSystem { get; set; }
        
        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        /// <value>
        /// Type.
        /// </value>
        [DataMember]
        public bool Type { get; set; }
        
        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        /// <value>
        /// Category.
        /// </value>
        [MaxLength( 100 )]
        [DataMember]
        public string Category { get; set; }
        
        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        /// <value>
        /// Title.
        /// </value>
        [Required]
        [MaxLength( 100 )]
        [DataMember( IsRequired = true )]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Subtitle.
        /// </summary>
        /// <value>
        /// Subtitle.
        /// </value>
        [MaxLength( 100 )]
        [DataMember]
        public string Subtitle { get; set; }
    
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// Description.
        /// </value>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the MinValue.
        /// </summary>
        /// <value>
        /// MinValue.
        /// </value>
        [DataMember]
        public int? MinValue { get; set; }

        /// <summary>
        /// Gets or sets the MaxValue.
        /// </summary>
        /// <value>
        /// MaxValue.
        /// </value>
        [DataMember]
        public int? MaxValue { get; set; }

        /// <summary>
        /// Gets or sets the CollectionFrequency.
        /// </summary>
        /// <value>
        /// CollectionFrequency.
        /// </value>
        [DataMember]
        public int? CollectionFrequencyValueId { get; set; }

        /// <summary>
        /// Gets or sets the LastCollected Date Time.
        /// </summary>
        /// <value>
        /// LastCollected Date Time.
        /// </value>
        [DataMember]
        public DateTime? LastCollected { get; set; }

        /// <summary>
        /// Gets or sets the Source.
        /// </summary>
        /// <value>
        /// Source.
        /// </value>
        [MaxLength( 100 )]
        [DataMember]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the SourceSQL.
        /// </summary>
        /// <value>
        /// SourceSQL.
        /// </value>
        [DataMember]
        public string SourceSQL { get; set; }

        /// <summary>
        /// Gets or sets the Order.
        /// </summary>
        /// <value>
        /// Order.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the Metric Values.
        /// </summary>
        /// <value>
        /// Collection of Metric Values.
        /// </value>
        [DataMember]
        public virtual ICollection<MetricValue> MetricValues { get; set; }

        /// <summary>
        /// Gets or sets the CollectionFrequency.
        /// </summary>
        /// <value>
        /// A <see cref="Model.DefinedValue"/> object.
        /// </value>
        [DataMember]
        public virtual Model.DefinedValue CollectionFrequencyValue { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Title;
        }
    }
    /// <summary>
    /// Metric Configuration class.
    /// </summary>
    public partial class MetricConfiguration : EntityTypeConfiguration<Metric>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricConfiguration"/> class.
        /// </summary>
        public MetricConfiguration()
        {
            this.HasOptional( p => p.CollectionFrequencyValue ).WithMany().HasForeignKey( p => p.CollectionFrequencyValueId ).WillCascadeOnDelete( false );
        }
    }
}