using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagementBusinessObjects
{
    [Table("Task")]
    public partial class Task
    {
        public Task()
        {
            Comments = new HashSet<Comment>();
            Documents = new HashSet<Document>();
        }

        [Key]
        [Column("task_id")]
        public int TaskId { get; set; }
        [Column("task_name")]
        [StringLength(100)]
        public string? TaskName { get; set; }
        [Column("description")]
        [StringLength(1000)]
        public string? Description { get; set; }
        [Column("assign_date", TypeName = "datetime")]
        public DateTime? AssignDate { get; set; }
        [Column("deadline", TypeName = "datetime")]
        public DateTime? Deadline { get; set; }
        [Column("status_id")]
        public int? StatusId { get; set; }
        [Column("project_id")]
        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("Tasks")]
        public virtual Project? Project { get; set; }
        [ForeignKey("StatusId")]
        [InverseProperty("Tasks")]
        public virtual TaskStatus? Status { get; set; }
        [InverseProperty("Task")]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty("Task")]
        public virtual ICollection<Document> Documents { get; set; }
    }
}
