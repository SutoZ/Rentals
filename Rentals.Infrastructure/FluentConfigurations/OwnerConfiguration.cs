using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental.Domain.Models;

namespace Rental.Infrastructure.FluentConfigurations;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public new void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable(nameof(Owner));

        builder.Property(x => x.OwnerId).IsRequired();

        builder.Property(x => x.Prefix).IsRequired();
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.Street);
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Phone).IsRequired();
        builder.Property(x => x.ZipCode).IsRequired();

    }
}
