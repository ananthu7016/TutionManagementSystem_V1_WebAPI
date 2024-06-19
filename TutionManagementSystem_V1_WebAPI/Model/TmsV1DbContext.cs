using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TutionManagementSystem_V1_WebAPI.Model;

public partial class TmsV1DbContext : DbContext
{
    public TmsV1DbContext()
    {
    }

    public TmsV1DbContext(DbContextOptions<TmsV1DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<EducationalStatus> EducationalStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source =HP_Ananthu\\SQLEXPRESS; Initial Catalog =TMS_V1_db; Integrated Security = True;\nTrusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927C09A391BCD");

            entity.Property(e => e.ClassName)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EducationalStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Educatio__C8EE2063050F9135");

            entity.ToTable("EducationalStatus");

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AEE3EDFA5");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B616050ED33E0").IsUnique();

            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B9941B9DE1A");

            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Dob).HasColumnType("date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Students__ClassI__571DF1D5");

            entity.HasOne(d => d.Status).WithMany(p => p.Students)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Students__Status__5812160E");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Students__UserId__59063A47");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__EDF2596439125A86");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Contact)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Teachers__ClassI__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Teachers__UserId__52593CB8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C5CEF1E55");

            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleId__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
