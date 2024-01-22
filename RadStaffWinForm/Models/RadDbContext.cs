using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace RadStaffWinForm.Models;

public partial class RadDbContext : DbContext
{
    public RadDbContext()
    {
    }

    public RadDbContext(DbContextOptions<RadDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StaffMember>? StaffMembers { get; set; }

    public virtual DbSet<StaffStatus>? StaffStatuses { get; set; }

    public virtual DbSet<StaffType>? StaffTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        var connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        optionsBuilder.UseSqlServer(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StaffMember>(entity =>
        {
            entity.HasKey(e => e.StaffId);

            entity.ToTable("StaffMember");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.StaffCellPhone)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.StaffFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StaffHomePhone)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.StaffIrdnumber)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("StaffIRDNumber");
            entity.Property(e => e.StaffLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StaffManagerId).HasColumnName("StaffManagerID");
            entity.Property(e => e.StaffMiddleInitial)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StaffOfficeExtension)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.StaffStatusId).HasColumnName("StaffStatusID");
            entity.Property(e => e.StaffTitle)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.StaffTypeId).HasColumnName("StaffTypeID");

            entity.HasOne(d => d.StaffManager).WithMany(p => p.InverseStaffManager)
                .HasForeignKey(d => d.StaffManagerId)
                .HasConstraintName("FK_StaffMember_StaffManager");

            entity.HasOne(d => d.StaffStatus).WithMany(p => p.StaffMembers)
                .HasForeignKey(d => d.StaffStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StaffMember_StaffStatus");

            entity.HasOne(d => d.StaffType).WithMany(p => p.StaffMembers)
                .HasForeignKey(d => d.StaffTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StaffMember_StaffType");
        });

        modelBuilder.Entity<StaffStatus>(entity =>
        {
            entity.HasKey(e => e.StaffStatusId).HasName("PK_Status");

            entity.ToTable("StaffStatus");

            entity.Property(e => e.StaffStatusId).HasColumnName("StaffStatusID");
            entity.Property(e => e.StaffStatusDescription)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StaffType>(entity =>
        {
            entity.ToTable("StaffType");

            entity.Property(e => e.StaffTypeId).HasColumnName("StaffTypeID");
            entity.Property(e => e.StaffTypeDescription)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
