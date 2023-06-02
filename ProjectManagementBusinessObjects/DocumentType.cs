using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagementBusinessObjects
{
    [Table("DocumentType")]
    public partial class DocumentType
    {
        public DocumentType()
        {
            Documents = new HashSet<Document>();
        }

        [Key]
        [Column("documentType_id")]
        public int DocumentTypeId { get; set; }
        [Column("type")]
        [StringLength(50)]
        public string? Type { get; set; }
        [Column("description")]
        [StringLength(500)]
        public string? Description { get; set; }

        [InverseProperty("Type")]
        public virtual ICollection<Document> Documents { get; set; }
    }
}
