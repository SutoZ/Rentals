using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.Domain.Enums;
using Rental.Domain.Models;

namespace Rental.Infrastructure.FluentConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public new void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable(nameof(Car));
        builder.Property(x => x.CarId).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Status).IsRequired().HasConversion(e => e.ToString(), e => (Status)Enum.Parse(typeof(Status), e));
        builder.Property(x => x.Details).HasColumnType("nvarchar(max)");

        builder.HasOne(x => x.Rental).WithMany(x => x.Cars).HasForeignKey(x => x.RentalId).IsRequired();


    }
}
