﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IdSrvr4Demo.Context
{
    public partial class SsoDbContext : DbContext
    {
        public SsoDbContext()
        {
        }

        public SsoDbContext(DbContextOptions<SsoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DVTL597LKC2;Initial Catalog=SSO;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.UsersId)
                    .HasName("IX_Users");

                entity.Property(e => e.UsersId)
                    .HasMaxLength(150)
                    .ValueGeneratedNever();

                entity.Property(e => e.Country).HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Phone).HasMaxLength(150);

                entity.Property(e => e.Profile)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(150);
            });
        }
    }
}
