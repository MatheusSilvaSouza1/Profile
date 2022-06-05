using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class WriteContext : DbContext, IUnitOfWork
    {
        public WriteContext(DbContextOptions<WriteContext> options) : base(options) { }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}