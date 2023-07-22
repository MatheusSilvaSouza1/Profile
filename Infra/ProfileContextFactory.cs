using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra
{
    public class ProfileContextFactory : IDesignTimeDbContextFactory<WriteContext>

    {
        public WriteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WriteContext>();
            optionsBuilder.UseNpgsql("Host=localhost; Database=Profile; Username=postgres; Password=33632292");

            return new WriteContext(optionsBuilder.Options);
        }
    }
}