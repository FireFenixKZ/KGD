using KGD.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace KGD.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasData(
                    new Department
                    {
                        Id = 1,
                        Name = "ВКО",
                        Code = "18xx"
                    },
                    new Department
                    {
                        Id = 2,
                        Name = "СКО",
                        Code = "48xx"
                    },
                    new Department
                    {
                        Id = 3,
                        Name = "Жамбыл",
                        Code = "21xx"
                    }
                );

            modelBuilder.Entity<ServiceType>()
                .HasData(
                    new ServiceType
                    {
                        Id = 1,
                        Name = "ТМЗ"
                    },
                    new ServiceType
                    {
                        Id = 2,
                        Name = "аренда"
                    },
                    new ServiceType
                    {
                        Id = 3,
                        Name = "транспортные услуги"
                    }
                );

            modelBuilder.Entity<TaxPayer>()
                .HasData(
                    new TaxPayer
                    {
                        Id = 1,
                        Name = "ТОО Азурит",
                        Bin = "10240004942"
                    },
                    new TaxPayer
                    {
                        Id = 2,
                        Name = "ТОО \"ЭлитСервис XXI\"",
                        Bin = "41040008232"
                    },
                    new TaxPayer
                    {
                        Id = 3,
                        Name = "ТОО Talas Investment Company",
                        Bin = "41040008232"
                    }
                );

            modelBuilder.Entity<Region>()
                .HasData(
                    new Region
                    {
                        Id = 1,
                        Name = "ВКО",
                    },
                    new Region
                    {
                        Id = 2,
                        Name = "СКО",
                    }
                );
        }
        public DbSet<User>? Users { get; set; }
        public DbSet<ReportHistory>? ReportHistories { get; set; }
        public DbSet<Region>? Regions { get; set; }
        public DbSet<Report>? Reports { get; set; }
        public DbSet<TaxPayer>? TaxPayers { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<ServiceType>? ServiceTypes { get; set; }
    }
}
