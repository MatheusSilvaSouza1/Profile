using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasMaxLength(40)
                .ValueGeneratedOnAdd()
                .HasValueGenerator((a, b) => new GuidValueGenerator());

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.CPF)
                .IsRequired();

            builder.Property(e => e.Email)
                .IsRequired();

            builder.Property(e => e.BirthDate);

            builder.Property(e => e.MotherName);

            builder.Property(e => e.Phone);

            builder.Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasValueGenerator((_, __) => new DateTimeGenerator());

            builder.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAdd()
                .ValueGeneratedOnUpdate()
                .HasValueGenerator((_, __) => new DateTimeGenerator());

            // builder.HasOne(e => e.Login)
            //     .WithOne(e => e.User);
        }
    }
}