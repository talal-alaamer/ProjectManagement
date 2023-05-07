using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Model
{
    [Table("Task")]
    public partial class Task
    {
        public Task()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        [Column("task_id")]
        public int TaskId { get; set; }
        [Column("task_name")]
        [StringLength(100)]
        public string TaskName { get; set; } = null!;
        [Column("description")]
        [StringLength(1000)]
        public string? Description { get; set; }
        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; } = null!;
        [Column("assign_date", TypeName = "datetime")]
        public DateTime AssignDate { get; set; }
        [Column("deadline", TypeName = "datetime")]
        public DateTime? Deadline { get; set; }
        [Column("project_id")]
        public int ProjectId { get; set; }
        [Column("document_id")]
        public int? DocumentId { get; set; }

        [ForeignKey("DocumentId")]
        [InverseProperty("Tasks")]
        public virtual Document? Document { get; set; }
        [ForeignKey("ProjectId")]
        [InverseProperty("Tasks")]
        public virtual Project Project { get; set; } = null!;
        [InverseProperty("Task")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
