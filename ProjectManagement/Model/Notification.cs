using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Model
{
    [Table("Notification")]
    public partial class Notification
    {
        [Key]
        [Column("notification_id")]
        public int NotificationId { get; set; }
        [Column("message")]
        [StringLength(500)]
        public string Message { get; set; } = null!;
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; } = null!;
        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; } = null!;
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Notifications")]
        public virtual User User { get; set; } = null!;
    }
}
