using Domain;
using Domain.SeedWork;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class WriteContext : DbContext, IUnitOfWork
    {
        public WriteContext(DbContextOptions<WriteContext> options) : base(options) { }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken) > 1;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WriteContext).Assembly);
        }

        public virtual DbSet<User> Users => Set<User>();
    }
}