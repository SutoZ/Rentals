using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rental.Domain.Models;
using Rental.Infrastructure.Extensions;
using System.Reflection;
using System.Text;

namespace Rental.Infrastructure.DatabaseContext
{
    public class RentalContext : DbContext
    {
        private readonly IConfiguration _configuration;
        #region Entities

        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }

        #endregion

        public RentalContext(DbContextOptions<RentalContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AddEntityConfigurations(modelBuilder);

            ModelBuilderExtensions.Seed(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string conn = new StringBuilder(_configuration.GetConnectionString("RentalsConnection")).ToString();
            optionsBuilder.UseSqlServer(conn);
        }

        private void AddEntityConfigurations(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
