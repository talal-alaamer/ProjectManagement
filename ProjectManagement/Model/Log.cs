using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Model
{
    [Table("Log")]
    public partial class Log
    {
        [Key]
        [Column("log_id")]
        public int LogId { get; set; }
        [Column("source")]
        [StringLength(50)]
        public string Source { get; set; } = null!;
        [Column("exception")]
        [StringLength(1000)]
        public string Exception { get; set; } = null!;
        [Column("timestamp")]
        public byte[] Timestamp { get; set; } = null!;
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Logs")]
        public virtual User User { get; set; } = null!;
    }
}
