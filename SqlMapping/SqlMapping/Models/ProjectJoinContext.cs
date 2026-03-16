using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SqlMapping.Models;

public partial class ProjectJoinContext : DbContext
{
   
    public ProjectJoinContext(DbContextOptions<ProjectJoinContext> options) : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Dba> Dbas { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompId).HasName("PK__Company__AD362A1690CBB10A");

            entity.ToTable("Company");

            entity.HasIndex(e => e.CompName, "UQ__Company__A05C45089F92949D").IsUnique();

            entity.HasIndex(e => e.RegisterNo, "UQ__Company__B921EA283693A0CC").IsUnique();

            entity.Property(e => e.CompName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RegisterNo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Dba).WithMany(p => p.Companies)
                .HasForeignKey(d => d.DbaId)
                .HasConstraintName("Fk_company_Dba");
        });

        modelBuilder.Entity<Dba>(entity =>
        {
            entity.HasKey(e => e.DbaId).HasName("PK__DBA__1C5A6E18F1FB652F");

            entity.ToTable("DBA");

            entity.HasIndex(e => e.Email, "UQ__DBA__A9D105340CB9853A").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__Departme__014881AE1B1D4E0F");

            entity.ToTable("Department");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeptName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Comp).WithMany(p => p.Departments)
                .HasForeignKey(d => d.CompId)
                .HasConstraintName("Fk_departement_company");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C2AD56151");

            entity.HasIndex(e => e.UserEmail, "UQ__Users__08638DF845D9139B").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Users)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("Fk_user_department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
