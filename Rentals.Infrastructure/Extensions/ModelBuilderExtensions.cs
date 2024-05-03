using Microsoft.EntityFrameworkCore;

namespace Rental.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>().Property(x => x.OwnerId).ValueGeneratedNever();
        modelBuilder.Entity<Car>().Property(x => x.CarId).ValueGeneratedNever();
        modelBuilder.Entity<CarRental>().Property(x => x.CarRentalId).ValueGeneratedNever();
        modelBuilder.Entity<Customer>().Property(x => x.CustomerId).ValueGeneratedNever();

        modelBuilder.Entity<Owner>().HasData(new Owner
        {
            OwnerId = Guid.Parse("3E5A7E66-E306-487F-BC00-25955F9DEB4C"),
            Prefix = "MR",
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@gmail.com",
            IsActive = true,
            ZipCode = "1452",
            Street = "Kiss",
            Address = "Budapest",
            Phone = "+36304874563"
        });

        modelBuilder.Entity<Car>().HasData(new Car
        {
            CarId = Guid.Parse("5A15EC11-E67C-46A8-BCBE-F5E008D13FD0"),
            Name = "Toyota Yaris",
            Details = "Test details",
            Price = 3500000,
            Status = Domain.Enums.Status.New,
            RentalId = Guid.Parse("5FABF3BA-AE75-432F-9D3B-FFE00C2FA8DF"),
        });

        modelBuilder.Entity<CarRental>().HasData(new CarRental
        {
            CarRentalId = Guid.Parse("5FABF3BA-AE75-432F-9D3B-FFE00C2FA8DF"),
            CarId = Guid.Parse("5A15EC11-E67C-46A8-BCBE-F5E008D13FD0"),
            From = DateTime.Now.AddDays(-5),
            To = DateTime.Now.AddDays(-1),
            Price = 50000,
            CustomerId = Guid.Parse("B64608EA-F373-4103-9856-2B31169ACF9A"),
        });

        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            CustomerId = Guid.Parse("B64608EA-F373-4103-9856-2B31169ACF9A"),
            FirstName = "John",
            LastName = "Smith",
            DoB = new DateTime(1970, 05, 05),
            Prefix = "MR",
            RentalId = Guid.Parse("5FABF3BA-AE75-432F-9D3B-FFE00C2FA8DF"),
            ZipCode = "1235",
            Address = "Budapest",
            Street = "Kiss",

        });

        return modelBuilder;
    }
}