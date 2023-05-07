using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Model
{
    [Table("Project")]
    public partial class Project
    {
        public Project()
        {
            ProjectMembers = new HashSet<ProjectMember>();
            Tasks = new HashSet<Task>();
        }

        [Key]
        [Column("project_id")]
        public int ProjectId { get; set; }
        [Column("project_name")]
        [StringLength(100)]
        public string ProjectName { get; set; } = null!;
        [Column("description")]
        [StringLength(1000)]
        public string? Description { get; set; }
        [Column("project_manager_id")]
        public int ProjectManagerId { get; set; }

        [ForeignKey("ProjectManagerId")]
        [InverseProperty("Projects")]
        public virtual User ProjectManager { get; set; } = null!;
        [InverseProperty("Project")]
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
