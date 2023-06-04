using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectManagementBusinessObjects
{
    public partial class ProjectManagementDBContext : DbContext
    {
        public ProjectManagementDBContext()
        {
        }

        public ProjectManagementDBContext(DbContextOptions<ProjectManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Audit> Audits { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectMember> ProjectMembers { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskStatus> TaskStatuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=JASSIM\\JASSIMSQL;Initial Catalog=ProjectManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audit>(entity =>
            {
                entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Audits)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Audit_User");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentTimestamp).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Comment_Task");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.UploadTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_Document_Task1");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Document_Type");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Document_User");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Log_User1");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Notification_User1");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasOne(d => d.ProjectManager)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectManagerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Project_User");
            });

            modelBuilder.Entity<ProjectMember>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_ProjectMember_Project1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ProjectMember_User");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.AssignDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Task_Project");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Task_Status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Task_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
