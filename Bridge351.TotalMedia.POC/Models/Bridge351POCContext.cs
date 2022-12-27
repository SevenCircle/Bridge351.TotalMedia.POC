using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bridge351.TotalMedia.POC.Models
{
    public partial class Bridge351POCContext : DbContext
    {
        public Bridge351POCContext()
        {
        }

        public Bridge351POCContext(DbContextOptions<Bridge351POCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<VatRate> VatRates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=JOSEMIGUELWORKL\\SQLEXPRESS; Database=Bridge351.POC;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.CountryId).HasColumnName("countryID");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("countryName");
            });

            modelBuilder.Entity<VatRate>(entity =>
            {
                entity.HasKey(e => e.VatNumberId)
                    .HasName("PK_VatRates");

                entity.ToTable("vatRates");

                entity.Property(e => e.VatNumberId).HasColumnName("vatNumberId");

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.VatNumber)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("vatNumber");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.VatRates)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vatRates_country");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
