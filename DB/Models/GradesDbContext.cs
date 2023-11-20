using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DB.Models;

public partial class GradesDbContext : DbContext
{
    public GradesDbContext()
    {
    }

    public GradesDbContext(DbContextOptions<GradesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server = LAB2-15\\SQLEXPRESS; Database=StudentGrades; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("pk_Grades");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("pk_Student");

            entity.Property(e => e.Name).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
