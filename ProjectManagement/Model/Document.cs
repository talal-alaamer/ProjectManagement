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
        [Key]
        [Column("document_id")]
        public int DocumentId { get; set; }
        [Column("document_name")]
        [StringLength(100)]
        public string DocumentName { get; set; } = null!;
        [Column("upload_time")]
        public byte[] UploadTime { get; set; } = null!;
        [Column("path")]
        [StringLength(1000)]
        public string Path { get; set; } = null!;
        [Column("type_id")]
        public int TypeId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("task_id")]
        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        [InverseProperty("Documents")]
        public virtual Task Task { get; set; } = null!;
        [ForeignKey("TypeId")]
        [InverseProperty("Documents")]
        public virtual DocumentType Type { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("Documents")]
        public virtual User User { get; set; } = null!;
    }
}
