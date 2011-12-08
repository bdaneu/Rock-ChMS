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
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.CMS
{
    /// <summary>
    /// Html Content POCO Entity.
    /// </summary>
    [Table( "cmsHtmlContent" )]
    public partial class HtmlContent : ModelWithAttributes<HtmlContent>, IAuditable
    {
		/// <summary>
		/// Gets or sets the Block Id.
		/// </summary>
		/// <value>
		/// Block Id.
		/// </value>
		[DataMember]
		public int BlockId { get; set; }
		
		/// <summary>
		/// Gets or sets the Content.
		/// </summary>
		/// <value>
		/// Content.
		/// </value>
		[DataMember]
		public string Content { get; set; }
		
		/// <summary>
		/// Gets or sets the Entity Value.
		/// </summary>
		/// <value>
		/// Entity Value.
		/// </value>
		[MaxLength( 50 )]
		[DataMember]
		public string EntityValue { get; set; }
		
		/// <summary>
		/// Gets or sets the Version Label.
		/// </summary>
		/// <value>
		/// Version Label.
		/// </value>
		[DataMember]
		public int VersionLabel { get; set; }
		
		/// <summary>
		/// Gets or sets the Approved.
		/// </summary>
		/// <value>
		/// Approved.
		/// </value>
		[DataMember]
		public bool Approved { get; set; }
		
		/// <summary>
		/// Gets or sets the Approved By Person Id.
		/// </summary>
		/// <value>
		/// Approved By Person Id.
		/// </value>
		[DataMember]
		public int? ApprovedByPersonId { get; set; }
		
		/// <summary>
		/// Gets or sets the Approved Date Time.
		/// </summary>
		/// <value>
		/// Approved Date Time.
		/// </value>
		[DataMember]
		public DateTime? ApprovedDateTime { get; set; }
		
		/// <summary>
		/// Gets or sets the Created Date Time.
		/// </summary>
		/// <value>
		/// Created Date Time.
		/// </value>
		[DataMember]
		public DateTime? CreatedDateTime { get; set; }
		
		/// <summary>
		/// Gets or sets the Modified Date Time.
		/// </summary>
		/// <value>
		/// Modified Date Time.
		/// </value>
		[DataMember]
		public DateTime? ModifiedDateTime { get; set; }
		
		/// <summary>
		/// Gets or sets the Created By Person Id.
		/// </summary>
		/// <value>
		/// Created By Person Id.
		/// </value>
		[DataMember]
		public int? CreatedByPersonId { get; set; }
		
		/// <summary>
		/// Gets or sets the Modified By Person Id.
		/// </summary>
		/// <value>
		/// Modified By Person Id.
		/// </value>
		[DataMember]
		public int? ModifiedByPersonId { get; set; }
		
		/// <summary>
		/// Gets or sets the Start Date Time.
		/// </summary>
		/// <value>
		/// Start Date Time.
		/// </value>
		[DataMember]
		public DateTime? StartDateTime { get; set; }
		
		/// <summary>
		/// Gets or sets the Expire Date Time.
		/// </summary>
		/// <value>
		/// Expire Date Time.
		/// </value>
		[DataMember]
		public DateTime? ExpireDateTime { get; set; }
		
		/// <summary>
        /// Gets a Data Transfer Object (lightweight) version of this object.
        /// </summary>
        /// <value>
        /// A <see cref="Rock.CMS.DTO.HtmlContent"/> object.
        /// </value>
		public Rock.CMS.DTO.HtmlContent DataTransferObject
		{
			get 
			{ 
				Rock.CMS.DTO.HtmlContent dto = new Rock.CMS.DTO.HtmlContent();
				dto.Id = this.Id;
				dto.Guid = this.Guid;
				dto.BlockId = this.BlockId;
				dto.Content = this.Content;
				dto.EntityValue = this.EntityValue;
				dto.VersionLabel = this.VersionLabel;
				dto.Approved = this.Approved;
				dto.ApprovedByPersonId = this.ApprovedByPersonId;
				dto.ApprovedDateTime = this.ApprovedDateTime;
				dto.CreatedDateTime = this.CreatedDateTime;
				dto.ModifiedDateTime = this.ModifiedDateTime;
				dto.CreatedByPersonId = this.CreatedByPersonId;
				dto.ModifiedByPersonId = this.ModifiedByPersonId;
				dto.StartDateTime = this.StartDateTime;
				dto.ExpireDateTime = this.ExpireDateTime;
				return dto; 
			}
		}

        /// <summary>
        /// Gets the auth entity.
        /// </summary>
		[NotMapped]
		public override string AuthEntity { get { return "CMS.HtmlContent"; } }
        
		/// <summary>
        /// Gets or sets the Block.
        /// </summary>
        /// <value>
        /// A <see cref="BlockInstance"/> object.
        /// </value>
		public virtual BlockInstance Block { get; set; }
        
		/// <summary>
        /// Gets or sets the Approved By Person.
        /// </summary>
        /// <value>
        /// A <see cref="CRM.Person"/> object.
        /// </value>
		public virtual CRM.Person ApprovedByPerson { get; set; }
        
		/// <summary>
        /// Gets or sets the Created By Person.
        /// </summary>
        /// <value>
        /// A <see cref="CRM.Person"/> object.
        /// </value>
		public virtual CRM.Person CreatedByPerson { get; set; }
        
		/// <summary>
        /// Gets or sets the Modified By Person.
        /// </summary>
        /// <value>
        /// A <see cref="CRM.Person"/> object.
        /// </value>
		public virtual CRM.Person ModifiedByPerson { get; set; }

    }
    /// <summary>
    /// Html Content Configuration class.
    /// </summary>
    public partial class HtmlContentConfiguration : EntityTypeConfiguration<HtmlContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlContentConfiguration"/> class.
        /// </summary>
        public HtmlContentConfiguration()
        {
			this.HasRequired( p => p.Block ).WithMany( p => p.HtmlContents ).HasForeignKey( p => p.BlockId );
			this.HasOptional( p => p.ApprovedByPerson ).WithMany().HasForeignKey( p => p.ApprovedByPersonId );
			this.HasOptional( p => p.CreatedByPerson ).WithMany().HasForeignKey( p => p.CreatedByPersonId );
			this.HasOptional( p => p.ModifiedByPerson ).WithMany().HasForeignKey( p => p.ModifiedByPersonId );
		}
    }
}
