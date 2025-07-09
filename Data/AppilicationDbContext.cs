using Microsoft.EntityFrameworkCore;
using item_management.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace item_management.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<OITM> OITM { get; set; } = null!;
        public DbSet<OITW> OITW { get; set; } = null!;
        public DbSet<OUOM> OUOM { get; set; } = null!;
        public DbSet<OUGP> OUGP { get; set; } = null!;
        public DbSet<UGP1> UGP1 { get; set; } = null!;
        public DbSet<OWHS> OWHS { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure OUOM - Phải config trước vì các bảng khác phụ thuộc
            modelBuilder.Entity<OUOM>(entity =>
            {
                entity.ToTable("OUOM");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Code).IsUnique();
            });

            // Configure OUGP
            modelBuilder.Entity<OUGP>(entity =>
            {
                entity.ToTable("OUGP");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Code).IsUnique();
                
                // Chỉ định độ dài cho Code
                entity.Property(e => e.Code)
                      .HasMaxLength(50)
                      .IsRequired();

                // Relationship với OUOM - Không dùng navigation property
                entity.HasOne<OUOM>()
                      .WithMany()
                      .HasForeignKey(e => e.BaseUom)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure UGP1 
            modelBuilder.Entity<UGP1>(entity =>
            {
                entity.ToTable("UGP1");
                entity.HasKey(e => e.Id);
                
                // Unique constraint cho FatherId và AlternateUoM
                entity.HasIndex(e => new { e.FatherId, e.AlternateUoM }).IsUnique();

                // Relationship với OUGP - SỬA CHÍNH TẠI ĐÂY (sử dụng navigation property)
                entity.HasOne(e => e.Father)
                      .WithMany(e => e.UGP1)
                      .HasForeignKey(e => e.FatherId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship với OUOM (sử dụng navigation property)
                entity.HasOne(e => e.AlternateUnit)
                      .WithMany()
                      .HasForeignKey(e => e.AlternateUoM)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure OWHS
            modelBuilder.Entity<OWHS>(entity =>
            {
                entity.ToTable("OWHS");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.WhsCode).IsUnique();
                
                // Chỉ định độ dài cho WhsCode
                entity.Property(e => e.WhsCode)
                      .HasMaxLength(50)
                      .IsRequired();
            });

            // Configure OITM
            modelBuilder.Entity<OITM>(entity =>
            {
                entity.ToTable("OITM");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.ItemCode).IsUnique();
                entity.Property(e => e.Price).HasPrecision(18, 2);

                // Chỉ định độ dài cho OUGPId để khớp với OUGP.Code
                entity.Property(e => e.OUGPId)
                      .HasMaxLength(50)
                      .IsRequired(false);

                // Relationship với OUGP
                entity.HasOne<OUGP>()
                      .WithMany()
                      .HasForeignKey(e => e.OUGPId)
                      .HasPrincipalKey(e => e.Code)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired(false);
            });

            // Configure OITW
            modelBuilder.Entity<OITW>(entity =>
            {
                entity.ToTable("OITW");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => new { e.ItemId, e.WarehouseCode }).IsUnique();
                entity.Property(e => e.QuantityOnHand).HasPrecision(18, 2);

                // Chỉ định độ dài cho WarehouseCode để khớp với OWHS.WhsCode
                entity.Property(e => e.WarehouseCode)
                      .HasMaxLength(50)
                      .IsRequired();

                // Relationship với OITM
                entity.HasOne(e => e.Item)
                      .WithMany(e => e.OITW)
                      .HasForeignKey(e => e.ItemId)
                      .HasPrincipalKey(e => e.Id)  // Chỉ định rõ Principal Key
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship với OWHS
                entity.HasOne<OWHS>()
                      .WithMany()
                      .HasForeignKey(e => e.WarehouseCode)
                      .HasPrincipalKey(e => e.WhsCode)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Gọi SeedData
            SeedData.Initialize(modelBuilder);
        }
    }
}