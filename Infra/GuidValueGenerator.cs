using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infra
{
    public class GuidValueGenerator : ValueGenerator<Guid>
    {
        public GuidValueGenerator() { }

        public override bool GeneratesTemporaryValues => false;

        public override Guid Next(EntityEntry entry)
        {
            return Guid.NewGuid();
        }
    }
}