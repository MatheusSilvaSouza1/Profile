using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class LoginMapping : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasMaxLength(40)
                .ValueGeneratedOnAdd()
                .HasValueGenerator((a, b) => new GuidValueGenerator());

            builder.Property(e => e.UserName)
                .IsRequired();

            builder.Property(e => e.Password)
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithOne(e => e.Login)
                .HasForeignKey<Login>(e => e.UserId);
        }
    }
}