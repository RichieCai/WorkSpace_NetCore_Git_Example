using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DBChatRepository.Models.Data;

namespace DBChatRepository.Context
{
    public partial class dbChatMSContext : DbContext
    {
        public dbChatMSContext()
        {
        }

        public dbChatMSContext(DbContextOptions<dbChatMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Friend> Friends { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FriendId).ValueGeneratedOnAdd();

                entity.Property(e => e.FriendUserId)
                    .HasMaxLength(16)
                    .IsFixedLength();

                entity.Property(e => e.Status).HasComment("1:好友,2:封鎖,3:刪除");

                entity.Property(e => e.UserId)
                    .HasMaxLength(16)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ToUser)
                    .HasMaxLength(17)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .HasMaxLength(17)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Users");

                entity.HasIndex(e => e.UserName, "IX_Users_1");

                entity.Property(e => e.UserId)
                    .HasMaxLength(16)
                    .IsFixedLength();

                entity.Property(e => e.AddDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("add_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserName).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
