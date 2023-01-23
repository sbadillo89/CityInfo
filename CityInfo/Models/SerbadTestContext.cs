using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Models;

public partial class SerbadTestContext : DbContext
{
    public SerbadTestContext()
    {
    }

    public SerbadTestContext(DbContextOptions<SerbadTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<History> Histories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__History__3214EC072B93ECE9");

            entity.ToTable("History");

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Info)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
