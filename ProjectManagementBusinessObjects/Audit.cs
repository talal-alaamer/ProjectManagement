using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagementBusinessObjects
{
    [Table("Audit")]
    public partial class Audit
    {
        [Key]
        [Column("audit_id")]
        public int AuditId { get; set; }
        [Column("timestamp")]
        public byte[]? Timestamp { get; set; }
        [Column("change_type")]
        [StringLength(50)]
        public string? ChangeType { get; set; }
        [Column("table_name")]
        [StringLength(50)]
        public string? TableName { get; set; }
        [Column("record_id")]
        public int? RecordId { get; set; }
        [Column("old_value")]
        public string? OldValue { get; set; }
        [Column("current_value")]
        public string? CurrentValue { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Audits")]
        public virtual User? User { get; set; }
    }
}
