using ClaimsTracker.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClaimsTracker.Api.Data
{
    public class ClaimsTrackerDbContext : DbContext
    {
        public ClaimsTrackerDbContext(DbContextOptions<ClaimsTrackerDbContext> options) : base(options)
        {
        }

        public DbSet<Claim> Claims => Set<Claim>();
        public DbSet<ClaimStatus> ClaimStatuses => Set<ClaimStatus>();
        public DbSet<ClaimType> ClaimTypes => Set<ClaimType>();
        public DbSet<ClaimAdjuster> ClaimAdjusters => Set<ClaimAdjuster>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureClaim(modelBuilder);
            ConfigureClaimStatus(modelBuilder);
            ConfigureClaimType(modelBuilder);
            ConfigureClaimAdjuster(modelBuilder);
        }

        private static void ConfigureClaim(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("Claim");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.ReportedAt)
                    .HasPrecision(0)
                    .HasDefaultValueSql("SYSUTCDATETIME()");

                entity.HasOne(x => x.Status)
                    .WithMany(x => x.Claims)
                    .HasForeignKey(x => x.StatusId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Type)
                    .WithMany(x => x.Claims)
                    .HasForeignKey(x => x.TypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.AssignedAdjuster)
                    .WithMany(x => x.AssignedClaims)
                    .HasForeignKey(x => x.AssignedAdjusterId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }

        private static void ConfigureClaimStatus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimStatus>(entity =>
            {
                entity.ToTable("ClaimStatus");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.StatusName)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.HasIndex(x => x.StatusName)
                    .IsUnique();
            });
        }

        private static void ConfigureClaimType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimType>(entity =>
            {
                entity.ToTable("ClaimType");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.TypeCode)
                    .HasMaxLength(30)
                    .IsRequired();

                entity.Property(x => x.TypeName)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.HasIndex(x => x.TypeCode)
                    .IsUnique();

                entity.HasIndex(x => x.TypeName)
                    .IsUnique();
            });
        }

        private static void ConfigureClaimAdjuster(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimAdjuster>(entity =>
            {
                entity.ToTable("ClaimAdjuster");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.FirstName)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(x => x.LastName)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(x => x.Email)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(x => x.HiredAt)
                    .HasPrecision(0)
                    .HasDefaultValueSql("SYSUTCDATETIME()");

                entity.Property(x => x.IsActive)
                    .IsRequired();

                entity.HasIndex(x => x.Email)
                    .IsUnique();
            });
        }
    }
}
