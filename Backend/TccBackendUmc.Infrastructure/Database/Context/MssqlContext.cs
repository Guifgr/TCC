using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using TccBackendUmc.Domain.Models;

namespace TccBackendUmc.Infrastructure.Database.Context
{
    public class MssqlContext : DbContext
    {
        public MssqlContext()
        {
        }

        public MssqlContext(DbContextOptions<MssqlContext> options) :
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
                optionsBuilder.UseSqlServer(GetConnectionString("MssqlConnection"));
            }

            base.OnConfiguring(optionsBuilder);
        }

        private static string GetConnectionString(string connectionStringName)
        {
            var configurationBuilder =
                new ConfigurationBuilder().AddJsonFile("appsettings.json", true, false);
            var configuration = configurationBuilder.Build();
            return configuration.GetConnectionString(connectionStringName);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Guid).HasDefaultValueSql("NEWID()");
                entity.HasIndex(e => e.Guid).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}