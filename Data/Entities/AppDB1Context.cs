using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IdigitalCafe.Data.Entities;

public partial class AppDB1Context : DbContext
{
    public AppDB1Context()
    {
    }

    public AppDB1Context(DbContextOptions<AppDB1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Forecast> Forecasts { get; set; }

    public virtual DbSet<GradeLevel> GradeLevels { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Pullout> Pullouts { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;database=AppDB1;User ID=admin;Password=@@Win4me@@;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Forecast>(entity =>
        {
            entity.ToTable("Forecast");

            entity.Property(e => e.ForecastName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.Sales).WithMany(p => p.Forecasts)
                .HasForeignKey(d => d.SalesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Forecast_Sales");
        });

        modelBuilder.Entity<GradeLevel>(entity =>
        {
            entity.ToTable("GradeLevel");

            entity.HasIndex(e => e.CreatedById, "IX_GradeLevel_CreatedById");

            entity.HasIndex(e => e.DeletedById, "IX_GradeLevel_DeletedById");

            entity.HasIndex(e => e.UpdatedById, "IX_GradeLevel_UpdatedById");

            entity.Property(e => e.GradeLevelName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.Forecast).WithMany(p => p.GradeLevels)
                .HasForeignKey(d => d.ForecastId)
                .HasConstraintName("FK_GradeLevel_Forecast");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.LocationName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Location_Category");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.GradeLevel).WithMany(p => p.Products).HasForeignKey(d => d.GradeLevelId);

            entity.HasOne(d => d.Location).WithMany(p => p.Products).HasForeignKey(d => d.LocationId);
        });

        modelBuilder.Entity<Pullout>(entity =>
        {
            entity.ToTable("Pullout");

            entity.Property(e => e.PulloutDate).HasColumnType("datetime");
            entity.Property(e => e.PulloutDescription)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PulloutName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ReceiptImage)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.businessValue).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Sales).WithMany(p => p.Pullouts)
                .HasForeignKey(d => d.SalesId)
                .HasConstraintName("FK_Pullout_Sales");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SalesId);

            entity.Property(e => e.SalesName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
