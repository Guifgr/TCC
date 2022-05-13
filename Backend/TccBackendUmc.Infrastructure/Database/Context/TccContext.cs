using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TccBackendUmc.Domain.Enums;
using TccBackendUmc.Domain.Models;

namespace TccBackendUmc.Infrastructure.Database.Context
{
    public class TccContext : DbContext
    {
        public TccContext()
        {
        }

        public TccContext(DbContextOptions<TccContext> options) :
            base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Clinic> Clinics { get; set; } = null!;
        public DbSet<Professional> Professionals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext =>
                     !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext =>
                     ext is not RelationalOptionsExtension && ext is not CoreOptionsExtension)))
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DATA_BASE") ?? string.Empty);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Guid).HasDefaultValueSql("NEWID()");
                entity.HasIndex(e => e.Guid).IsUnique();
                
            });
            
            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.Property(e => e.Guid).HasDefaultValueSql("NEWID()");
                entity.HasIndex(e => e.Guid).IsUnique();
            });
            
            modelBuilder.Entity<Professional>(entity =>
            {
                entity.Property(e => e.Guid).HasDefaultValueSql("NEWID()");
                entity.HasIndex(e => e.Guid).IsUnique();
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}