using Domain;
using Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasMaxLength(40)
                .HasConversion(e => e.ToString(), value => Guid.Parse(value))
                .ValueGeneratedOnAdd()
                .HasValueGenerator((a, b) => new GuidValueGenerator());

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.CPF)
                .IsRequired()
                .HasConversion(e => e.Value, e => e);

            builder.Property(e => e.Email)
                .IsRequired();

            builder.Property(e => e.BirthDate);

            builder.Property(e => e.MotherName);

            builder.Property(e => e.Phone)
                .HasConversion(e => e.Value, e => e);

            builder.Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasValueGenerator((_, __) => new DateTimeGenerator());

            builder.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAdd()
                .ValueGeneratedOnUpdate()
                .HasValueGenerator((_, __) => new DateTimeGenerator());

            builder.OwnsOne(user => user.Login, loginBuilder =>
            {
                loginBuilder.Property(e => e.UserName).IsRequired();
                loginBuilder.Property(e => e.Password).IsRequired();
            });

            builder.HasMany(e => e.Addresses)
                .WithOne()
                .HasPrincipalKey(e => e.Id)
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(e => e.Addresses).Metadata.SetField("_addresses");
        }
    }
}