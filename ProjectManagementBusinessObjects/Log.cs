using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagementBusinessObjects
{
    [Table("Log")]
    public partial class Log
    {
        [Key]
        [Column("log_id")]
        public int LogId { get; set; }
        [Column("source")]
        [StringLength(50)]
        public string? Source { get; set; }
        [Column("exception")]
        [StringLength(1000)]
        public string? Exception { get; set; }
        [Column("timestamp")]
        public byte[]? Timestamp { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Logs")]
        public virtual User? User { get; set; }
    }
}
