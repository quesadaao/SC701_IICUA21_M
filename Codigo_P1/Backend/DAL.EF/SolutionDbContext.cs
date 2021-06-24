using DAL.DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public partial class SolutionDbContext : DbContext
    {

        public SolutionDbContext(DbContextOptions<SolutionDbContext> options): base(options)
        {
        }

        public virtual DbSet<GroupInvitations> GroupInvitations { get; set; }
        public virtual DbSet<GroupRequests> GroupRequests { get; set; }
        public virtual DbSet<Foci> Foci { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }

        public virtual DbSet<GroupUpdates> GroupUpdates { get; set; }

        public virtual DbSet<GroupComments> GroupComments { get; set; }

        public virtual DbSet<GroupUpdateSupports> GroupUpdateSupports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Foci>(entity =>
            {
                entity.HasKey(e => e.FocusId)
                    .HasName("PK_dbo.Foci");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FocusName).HasMaxLength(50);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Foci)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.Foci_dbo.Groups_GroupId");
            });

            modelBuilder.Entity<GroupInvitations>(entity =>
            {
                entity.HasKey(e => e.GroupInvitationId)
                    .HasName("PK_dbo.GroupInvitations");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.Property(e => e.SentDate).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupInvitations)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.GroupInvitations_dbo.Groups_GroupId");
            });

            modelBuilder.Entity<GroupRequests>(entity =>
            {
                entity.HasKey(e => e.GroupRequestId)
                    .HasName("PK_dbo.GroupRequests");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupRequests)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.GroupRequests_dbo.Groups_GroupId");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.GroupRequests)
                //    .HasForeignKey(d => d.UserId)
                //    .HasConstraintName("FK_dbo.GroupRequests_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK_dbo.Groups");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<GroupUpdates>(entity =>
            {
                entity.HasKey(e => e.GroupUpdateId)
                    .HasName("PK_dbo.GroupUpdates");

                entity.HasIndex(e => e.GroupGoalId)
                    .HasName("IX_GroupGoalId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GroupComments>(entity =>
            {
                entity.HasKey(e => e.GroupCommentId)
                    .HasName("PK_dbo.GroupComments");

                entity.HasIndex(e => e.GroupUpdateId)
                    .HasName("IX_GroupUpdateId");

                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.HasOne(d => d.GroupUpdate)
                    .WithMany(p => p.GroupComments)
                    .HasForeignKey(d => d.GroupUpdateId)
                    .HasConstraintName("FK_dbo.GroupComments_dbo.GroupUpdates_GroupUpdateId");
            });

            modelBuilder.Entity<GroupUpdateSupports>(entity =>
            {
                entity.HasKey(e => e.GroupUpdateSupportId)
                    .HasName("PK_dbo.GroupUpdateSupports");

                entity.HasIndex(e => e.GroupUpdateId)
                    .HasName("IX_GroupUpdateId");

                entity.Property(e => e.UpdateSupportedDate).HasColumnType("datetime");

                entity.HasOne(d => d.GroupUpdate)
                    .WithMany(p => p.GroupUpdateSupports)
                    .HasForeignKey(d => d.GroupUpdateId)
                    .HasConstraintName("FK_dbo.GroupUpdateSupports_dbo.GroupUpdates_GroupUpdateId");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
