using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagementBusinessObjects
{
    [Table("TaskStatus")]
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        [Column("taskStatus_id")]
        public int TaskStatusId { get; set; }
        [Column("status")]
        [StringLength(50)]
        public string? Status { get; set; }
        [Column("description")]
        [StringLength(500)]
        public string? Description { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
