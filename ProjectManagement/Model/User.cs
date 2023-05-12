using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Model
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Audits = new HashSet<Audit>();
            Comments = new HashSet<Comment>();
            Documents = new HashSet<Document>();
            Logs = new HashSet<Log>();
            Notifications = new HashSet<Notification>();
            ProjectMembers = new HashSet<ProjectMember>();
            Projects = new HashSet<Project>();
        }

        [Key]
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [Column("email")]
        [StringLength(150)]
        public string Email { get; set; } = null!;
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; } = null!;
        [Column("role_id")]
        public int RoleId { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Audit> Audits { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Document> Documents { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Log> Logs { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Notification> Notifications { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        [InverseProperty("ProjectManager")]
        public virtual ICollection<Project> Projects { get; set; }

        [NotMapped] // This property won't be mapped to the database
        public string UserName {get{ return FirstName + " " + LastName; } }
    }
}
