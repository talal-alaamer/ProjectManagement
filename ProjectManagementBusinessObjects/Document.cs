using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ProjectManagementBusinessObjects
{
    [Table("Document")]
    public partial class Document
    {
        [Key]
        [Column("document_id")]
        public int DocumentId { get; set; }
        [Column("document_name")]
        [StringLength(100)]
        public string? DocumentName { get; set; }
        [Column("upload_time", TypeName = "datetime")]
        public DateTime? UploadTime { get; set; }
        [Column("path")]
        public string? Path { get; set; }
        [Column("type_id")]
        public int? TypeId { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }
        [Column("task_id")]
        public int? TaskId { get; set; }

        [ForeignKey("TaskId")]
        [InverseProperty("Documents")]
        public virtual Task? Task { get; set; }
        [ForeignKey("TypeId")]
        [InverseProperty("Documents")]
        public virtual DocumentType? Type { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Documents")]
        public virtual User? User { get; set; }
        public override string? ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
