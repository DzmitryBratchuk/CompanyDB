using CompanyDB.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyDB.Infrastructure.Data
{
    public partial class CompanydbContext : DbContext
    {
        public CompanydbContext(DbContextOptions<CompanydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeProject> EmployeesProjects { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>(entity =>
            {
                entity.HasIndex(e => new { e.InstitutionName, e.GraduationYear })
                    .HasName("UQ__Educatio__C1E3F46DC33E7BA1")
                    .IsUnique();

                entity.Property(e => e.InstitutionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmploymentDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EducationId)
                    .HasConstraintName("FK_Employees_To_Educations");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_Employees_To_Genders");
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.ProjectId })
                    .HasName("PK_EmployeeID_ProjectId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeesProjects)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeesProjects_To_Employees");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.EmployeesProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_EmployeesProjects_To_Projects");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasIndex(e => e.GenderName)
                    .HasName("UQ__Genders__F7C177154184CFCD")
                    .IsUnique();

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
