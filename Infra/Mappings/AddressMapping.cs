using Domain;
using Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasMaxLength(40)
                .HasConversion(e => e.ToString(), value => Guid.Parse(value))
                .ValueGeneratedOnAdd()
                .HasValueGenerator((a, b) => new GuidValueGenerator());

            builder.Property(e => e.City)
                .IsRequired();

            builder.Property(e => e.Country)
                .IsRequired();

            builder.Property(e => e.District)
                .IsRequired();

            builder.Property(e => e.IsDefault)
                .IsRequired();

            builder.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(e => e.Street)
                .IsRequired();

            builder.HasOne<User>()
                .WithMany(e => e.Addresses)
                .HasForeignKey(e => e.UserId);
        }
    }
}