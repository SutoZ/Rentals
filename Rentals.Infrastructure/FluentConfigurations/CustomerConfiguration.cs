using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.Domain.Models;

namespace Rental.Infrastructure.FluentConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public new void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));

        builder.Property(x => x.CustomerId).IsRequired();

        builder.Property(x => x.Prefix).IsRequired();
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.Street);
        builder.Property(x => x.ZipCode);
        builder.Property(x => x.DoB).HasColumnName("DateOfBirth").IsRequired();
        builder.Property(x => x.Address);

        builder.HasOne(x => x.Rental).WithMany(x => x.Customers).HasForeignKey(x => x.RentalId).IsRequired();
    }
}
