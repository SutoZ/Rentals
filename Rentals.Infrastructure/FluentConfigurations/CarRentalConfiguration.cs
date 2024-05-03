using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.Domain.Models;

namespace Rental.Infrastructure.FluentConfigurations;

public class CarRentalConfiguration : IEntityTypeConfiguration<CarRental>
{
    public void Configure(EntityTypeBuilder<CarRental> builder)
    {
        builder.ToTable(nameof(CarRental));

        builder.Property(x => x.CarRentalId).IsRequired();

        builder.Property(x => x.From);
        builder.Property(x => x.To);
        builder.Property(x => x.Price);

        builder.HasMany(x => x.Customers).WithOne(x => x.Rental).HasForeignKey(x => x.RentalId);
        builder.HasMany(x => x.Cars).WithOne(x => x.Rental).HasForeignKey(x => x.RentalId).IsRequired();
    }
}
