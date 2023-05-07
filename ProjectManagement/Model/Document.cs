using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Model
{
    [Table("Document")]
    public partial class Document
    {
        public Document()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        [Column("document_id")]
        public int DocumentId { get; set; }
        [Column("document_name")]
        [StringLength(100)]
        public string DocumentName { get; set; } = null!;
        [Column("upload_time")]
        public byte[] UploadTime { get; set; } = null!;
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; } = null!;
        [Column("path")]
        [StringLength(1000)]
        public string Path { get; set; } = null!;
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Documents")]
        public virtual User User { get; set; } = null!;
        [InverseProperty("Document")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
