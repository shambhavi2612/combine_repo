using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASP.NETCoreWebMainAPI.Models
{
    public partial class myDbContext : DbContext
    {
        public myDbContext()
        {
        }

        public myDbContext(DbContextOptions<myDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Student1> Students1 { get; set; } = null!;
        public virtual DbSet<Logs> Logs { get; set; } // Add this line for Logs table


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FatherName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentGender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student1>(entity =>
            {
                entity.ToTable("Students");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FatherName)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.StudentGender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Logs>(entity =>
            {
                entity.ToTable("Logs");

                entity.Property(e => e.Operation).HasMaxLength(50);
                entity.Property(e => e.TableName).HasMaxLength(50);
                // Other properties mapping if needed
            });




            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}



