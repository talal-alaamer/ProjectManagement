using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Model
{
    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        [Column("comment_id")]
        public int CommentId { get; set; }
        [Column("comment_timestamp")]
        public byte[] CommentTimestamp { get; set; } = null!;
        [Column("comment_text")]
        [StringLength(1000)]
        public string CommentText { get; set; } = null!;
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("task_id")]
        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        [InverseProperty("Comments")]
        public virtual Task Task { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("Comments")]
        public virtual User User { get; set; } = null!;
    }
}
