using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ProjectManagementBusinessObjects
{
    [Table("ProjectMember")]
    public partial class ProjectMember
    {
        [Key]
        [Column("project_member_id")]
        public int ProjectMemberId { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }
        [Column("project_id")]
        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("ProjectMembers")]
        public virtual Project? Project { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("ProjectMembers")]
        public virtual User? User { get; set; }
        public override string? ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
