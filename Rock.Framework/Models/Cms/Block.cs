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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Rock.Models;

namespace Rock.Models.Cms
{
    [Table( "cmsBlock" )]
    public partial class Block : ModelWithAttributes<Block>, IAuditable
    {
		[DataMember]
		public bool System { get; set; }
		
		[MaxLength( 200 )]
		[DataMember]
		public string Path { get; set; }
		
		[MaxLength( 100 )]
		[DataMember]
		public string Name { get; set; }
		
		[DataMember]
		public string Description { get; set; }
		
		[DataMember]
		public DateTime? CreatedDateTime { get; set; }
		
		[DataMember]
		public DateTime? ModifiedDateTime { get; set; }
		
		[DataMember]
		public int? CreatedByPersonId { get; set; }
		
		[DataMember]
		public int? ModifiedByPersonId { get; set; }
		
		[NotMapped]
		public override string AuthEntity { get { return "Cms.Block"; } }

		public virtual ICollection<BlockInstance> BlockInstances { get; set; }

		public virtual Crm.Person CreatedByPerson { get; set; }

		public virtual Crm.Person ModifiedByPerson { get; set; }

        public static Block Read(int id)
        {
            return new Rock.Services.Cms.BlockService().Get( id );
        }

    }

    public partial class BlockConfiguration : EntityTypeConfiguration<Block>
    {
        public BlockConfiguration()
        {
			this.HasOptional( p => p.CreatedByPerson ).WithMany().HasForeignKey( p => p.CreatedByPersonId );
			this.HasOptional( p => p.ModifiedByPerson ).WithMany().HasForeignKey( p => p.ModifiedByPersonId );
		}
    }
}
